/*
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see<http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OdinSoft.SDK.eTaxBill.Security.Encrypt;
using OdinSoft.SDK.eTaxBill.Security.Issue;
using OdinSoft.SDK.eTaxBill.Security.Mime;
using OdinSoft.SDK.eTaxBill.Security.Notice;
using OdinSoft.SDK.eTaxBill.Security.Signature;
using OdinSoft.SDK.Control.Library;
using OdinSoft.SDK.Data;
using OdinSoft.SDK.Data.Collection;

namespace OpenETaxBill.Certifier
{
    public partial class eXmlInvoice : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        public eXmlInvoice()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------

        private OdinSoft.SDK.Data.DataHelper m_dataHelper = null;
        private OdinSoft.SDK.Data.DataHelper LDataHelper
        {
            get
            {
                if (m_dataHelper == null)
                    m_dataHelper = new OdinSoft.SDK.Data.DataHelper();
                return m_dataHelper;
            }
        }

        private void WriteLine(string p_message)
        {
            tbResult.Text = p_message + Environment.NewLine + tbResult.Text;
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private DataSet getMasterDataSet(string p_issue_id)
        {
            string _sqlstr = "SELECT * FROM TB_eTAX_INVOICE WHERE issueId=@issueId";

            var _dbps = new DatParameters();
            _dbps.Add("@issueId", SqlDbType.NVarChar, p_issue_id);

            return LDataHelper.SelectDataSet(UCfgHelper.SNG.ConnectionString, _sqlstr, _dbps);
        }

        private DataSet getDetailDataSet(string p_issue_id)
        {
            string _sqlstr = "SELECT * FROM TB_eTAX_LINEITEM WHERE issueId=@issueId";

            var _dbps = new DatParameters();
            _dbps.Add("@issueId", SqlDbType.NVarChar, p_issue_id);

            return LDataHelper.SelectDataSet(UCfgHelper.SNG.ConnectionString, _sqlstr, _dbps);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void eXmlInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void eXmlInterop_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);

            tbInvoicerId.Text = UCfgHelper.SNG.InvoicerBizNo;
            ceTestOk_CheckedChanged(sender, e);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void sbSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTaxInvoiceSubmitUrl.Text.Trim()) == true)
            {
                MessageBox.Show("전자세금계산서 제출을 위한 웹서비스 URL을 입력해 주십시오.");
                tbTaxInvoiceSubmitUrl.Focus();
                return;
            }

            string _endpoint = tbTaxInvoiceSubmitUrl.Text.Trim();

            MessageBox.Show(String.Format("상호운영성 테스트 검증을 위한 웹서비스 메시지를,\n\r{0} ENDPOINT를\n\r 통해 인증 시스템으로 전송 합니다.", _endpoint));
            if (CreateInvoce() == true)
            {
                string _referenceId = "";

                string _loadfile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\17.전자서명후.txt");
                {
                    tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                    WriteLine("after transform read from " + _loadfile);

                    XmlDocument _xd = new XmlDocument();
                    _xd.Load(_loadfile);

                    _referenceId = _xd.SelectSingleNode("descendant::kec:ReferenceID", Packing.SNG.SoapNamespaces).InnerText;
                    WriteLine(String.Format("retrieve reference-id :<{0}>", _referenceId));
                }

                byte[] _soappart = File.ReadAllBytes(_loadfile);
                byte[] _attachment = File.ReadAllBytes(Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\14.두번째ReferenceTarget.asn"));
                {
                    WriteLine("read encrypt data " + _attachment.Length);
                }

                MimeContent _mimeContent = Request.SNG.TaxInvoiceSubmit(_soappart, _attachment, _referenceId, _endpoint);
                if (_mimeContent.StatusCode == 0)
                {
                    var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\21.TaxInvoiceRecvAck.txt");
                    {
                        File.WriteAllText(_savefile, _mimeContent.Parts[1].GetContentAsString(), Encoding.UTF8);

                        tbTargetXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                        WriteLine("response write on the " + _savefile);
                    }

                    MessageBox.Show("전송 되었습니다.");
                }
                else
                {
                    MessageBox.Show(_mimeContent.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// 2048비트 인증서로 서명된 일반 전자세금계산서(1건)와 당초승인번호가 기입된 수정 전자세금계산서(1건) 
        /// 그리고 2048비트 인증서로 서명된 일반 계산서(1건)와 당초승인번호가 기입된 수정 계산서(1건)는 반드시 첨부해야 합니다.(총 4건)
        /// </summary>
        /// <returns></returns>
        private bool CreateInvoce()
        {
            X509Certificate2 _ntsCert2 = UCertHelper.SNG.NtsPublicKey;

            //-------------------------------------------------------------------------------------------------------------------//
            // 세금계산서 작성
            //-------------------------------------------------------------------------------------------------------------------//

            // 2048_전자세금계산서
            var _read_file = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\2-0101.xml");

            var _c_0101 = new XmlDocument();
            _c_0101.LoadXml((new StreamReader(_read_file, Encoding.UTF8)).ReadToEnd());
            var _t_0101 = Convertor.SNG.CanonicalizationToDocument(_c_0101, "\t");

            // 2048_전자계산서
            _read_file = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\2-0301.xml");

            var _c_0301 = new XmlDocument();
            _c_0301.LoadXml((new StreamReader(_read_file, Encoding.UTF8)).ReadToEnd());
            var _t_0301 = Convertor.SNG.CanonicalizationToDocument(_c_0301, "\t");

            // 2048_수정전자세금계산서
            _read_file = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\2-0201.xml");

            var _c_0201 = new XmlDocument();
            _c_0201.LoadXml((new StreamReader(_read_file, Encoding.UTF8)).ReadToEnd());
            var _t_0201 = Convertor.SNG.CanonicalizationToDocument(_c_0201, "\t");

            // 2048_수정전자계산서
            _read_file = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\2-0401.xml");

            var _c_0401 = new XmlDocument();
            _c_0401.LoadXml((new StreamReader(_read_file, Encoding.UTF8)).ReadToEnd());
            var _t_0401 = Convertor.SNG.CanonicalizationToDocument(_c_0401, "\t");

            //-------------------------------------------------------------------------------------------------------------------//
            // 전자서명
            //-------------------------------------------------------------------------------------------------------------------//
            MemoryStream _readfile = new MemoryStream(Encoding.UTF8.GetBytes(_t_0101.OuterXml));
            MemoryStream _p_0101 = XSignature.SNG.GetSignedXmlStream(_readfile, UCertHelper.SNG.UserSignCert.X509Cert2);

            _readfile = new MemoryStream(Encoding.UTF8.GetBytes(_t_0301.OuterXml));
            MemoryStream _p_0301 = XSignature.SNG.GetSignedXmlStream(_readfile, UCertHelper.SNG.UserSignCert.X509Cert2);

            _readfile = new MemoryStream(Encoding.UTF8.GetBytes(_t_0201.OuterXml));
            MemoryStream _p_0201 = XSignature.SNG.GetSignedXmlStream(_readfile, UCertHelper.SNG.UserSignCert.X509Cert2);

            _readfile = new MemoryStream(Encoding.UTF8.GetBytes(_t_0401.OuterXml));
            MemoryStream _p_0401 = XSignature.SNG.GetSignedXmlStream(_readfile, UCertHelper.SNG.UserSignCert.X509Cert2);

            var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\12.전자세금계산서.xml");
            {
                string _xmltxt = (new StreamReader(_p_0101)).ReadToEnd() + "\n";
                _p_0101.Seek(0, SeekOrigin.Begin);

                _xmltxt += (new StreamReader(_p_0301)).ReadToEnd() + "\n";
                _p_0301.Seek(0, SeekOrigin.Begin);

                _xmltxt += (new StreamReader(_p_0201)).ReadToEnd() + "\n";
                _p_0201.Seek(0, SeekOrigin.Begin);

                _xmltxt += (new StreamReader(_p_0401)).ReadToEnd() + "\n";
                _p_0401.Seek(0, SeekOrigin.Begin);

                File.WriteAllText(_savefile, _xmltxt);
                WriteLine("write invoice document on the " + _savefile);
            }

            //-------------------------------------------------------------------------------------------------------------------//
            // 암호화
            //-------------------------------------------------------------------------------------------------------------------//
            byte[] _rvalue = UCertHelper.SNG.UserSignCert.RandomNumber;

            ArrayList _taxinvoice = new ArrayList();
            {
                TaxInvoiceStruct _s_0301 = new TaxInvoiceStruct
                {
                    SignerRValue = _rvalue,
                    TaxInvoice = _p_0301.ToArray()
                };
                _taxinvoice.Add(_s_0301);

                TaxInvoiceStruct _s_0101 = new TaxInvoiceStruct
                {
                    SignerRValue = _rvalue,
                    TaxInvoice = _p_0101.ToArray()
                };
                _taxinvoice.Add(_s_0101);

                TaxInvoiceStruct _s_0401 = new TaxInvoiceStruct
                {
                    SignerRValue = _rvalue,
                    TaxInvoice = _p_0401.ToArray()
                };
                _taxinvoice.Add(_s_0401);

                TaxInvoiceStruct _s_0201 = new TaxInvoiceStruct
                {
                    SignerRValue = _rvalue,
                    TaxInvoice = _p_0201.ToArray()
                };
                _taxinvoice.Add(_s_0201);
            }

            byte[] _encrypted = CmsManager.SNG.GetContentInfo(_ntsCert2, _taxinvoice);

            _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\14.두번째ReferenceTarget.asn");
            {
                File.WriteAllBytes(_savefile, _encrypted);
                WriteLine("write encrypted on the " + _savefile);
            }

            //-------------------------------------------------------------------------------------------------------------------//
            // SOAP Envelope
            //-------------------------------------------------------------------------------------------------------------------//
            Header _soapHeader = new Header();
            {
                _soapHeader.ToAddress = tbTaxInvoiceSubmitUrl.Text.Trim();

                _soapHeader.Action = Request.eTaxInvoiceSubmit;
                _soapHeader.Version = UCfgHelper.SNG.eTaxVersion;

                _soapHeader.FromParty = new Party(UCfgHelper.SNG.SenderBizNo, UCfgHelper.SNG.SenderBizName);
                _soapHeader.ToParty = new Party(UCfgHelper.SNG.ReceiverBizNo, UCfgHelper.SNG.ReceiverBizName);

                _soapHeader.ReplyTo = UCfgHelper.SNG.ReplyAddress;
                _soapHeader.OperationType = Request.OperationType_InvoiceSubmit;
                _soapHeader.MessageType = Request.MessageType_Request;

                _soapHeader.TimeStamp = DateTime.Now;
                _soapHeader.MessageId = Packing.SNG.GetMessageId(_soapHeader.TimeStamp);
            }

            Body _soapBody = new Body();
            {
                _soapBody.SubmitID = Packing.SNG.GetSubmitID(_soapHeader.TimeStamp, UCfgHelper.SNG.RegisterId);
                _soapBody.ReferenceID = Guid.NewGuid().ToString();

                _soapBody.TotalCount = 4;   // 전자세금계산서의 총 개수
            }

            //-------------------------------------------------------------------------------------------------------------------//
            // SOAP Signature
            //-------------------------------------------------------------------------------------------------------------------//
            XmlDocument _signedXml = Packing.SNG.GetSignedSoapEnvelope(_encrypted, UCertHelper.SNG.AspSignCert.X509Cert2, _soapHeader, _soapBody);

            _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"interop\17.전자서명후.txt");
            {
                File.WriteAllText(_savefile, _signedXml.OuterXml, Encoding.UTF8);

                tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                WriteLine("transforms write on the " + _savefile);
            }

            return true;
        }

        private void ceTestOk_CheckedChanged(object sender, EventArgs e)
        {
            tbTaxInvoiceSubmitUrl.Text = UCfgHelper.SNG.TaxInvoiceSubmitUrl(ceTestOk.Checked, true);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
