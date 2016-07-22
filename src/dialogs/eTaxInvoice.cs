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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OpenETaxBill.Channel.Library.Security.Issue;
using OpenETaxBill.Channel.Library.Security.Mime;
using OpenETaxBill.Channel.Library.Security.Notice;
using OpenETaxBill.SDK.Control.Library;

namespace OpenETaxBill.Certifier
{
    public partial class eTaxInvoice : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        public eTaxInvoice()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void WriteLine(string p_message)
        {
            tbResult.Text += p_message + Environment.NewLine;
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void eXmlCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void eXmlCreator_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);

            ceTestOk_CheckedChanged(sender, e);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void CreateInvoce(string p_type_code)
        {
            var _timeStamp = DateTime.Now;

            Header _soapHeader = new Header
            {
				ToAddress = tbTaxInvoiceSubmitUrl.Text.Trim(),
                Action = Request.eTaxInvoiceSubmit,
                Version = UCfgHelper.SNG.eTaxVersion,

                FromParty = new Party(UCfgHelper.SNG.SenderBizNo, UCfgHelper.SNG.SenderBizName),
                ToParty = new Party(UCfgHelper.SNG.ReceiverBizNo, UCfgHelper.SNG.ReceiverBizName),

                ReplyTo = UCfgHelper.SNG.ReplyAddress,
                OperationType = Request.OperationType_InvoiceSubmit,
                MessageType = Request.MessageType_Request,

                TimeStamp = _timeStamp,
                MessageId = Packing.SNG.GetMessageId(_timeStamp)
            };

            Body _soapBody = new Body
            {
                SubmitID = Packing.SNG.GetSubmitID(_soapHeader.TimeStamp, UCfgHelper.SNG.RegisterId),
                ReferenceID = Guid.NewGuid().ToString(),
                TotalCount = 1 /* 전자세금계산서의 총 개수*/
            };

            string _loadfile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\7-{p_type_code}.asn");
            {
                tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                WriteLine("encrypted file load from " + _loadfile);
            }

            byte[] _encrypted = File.ReadAllBytes(_loadfile);

            //-------------------------------------------------------------------------------------------------------------------------
            // Signature
            //-------------------------------------------------------------------------------------------------------------------------
            XmlDocument _signedXml = Packing.SNG.GetSignedSoapEnvelope(_encrypted, UCertHelper.SNG.AspSignCert.X509Cert2, _soapHeader, _soapBody);

            var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"security\\7-{p_type_code}-전자서명후.txt");
            {
                File.WriteAllText(_savefile, _signedXml.OuterXml, Encoding.UTF8);

                tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                WriteLine("transforms write on the " + _savefile);
            }
        }

        private void sbInvoiceSubmit_Click(object sender, EventArgs e)
        {
            var _type_code = String.Format("{0:00}{1:00}", (cbKind1.SelectedIndex + 1), (cbKind2.SelectedIndex + 1));

            if (String.IsNullOrEmpty(tbTaxInvoiceSubmitUrl.Text.Trim()) == true)
			{
				MessageBox.Show("전자세금계산서 제출을 위한 웹서비스 URL을 입력해 주십시오.");
				tbTaxInvoiceSubmitUrl.Focus();
				return;
			}

			MessageBox.Show(String.Format("전자세금계산서 제출을 위한 웹서비스 메시지를,\n\r{0} ENDPOINT를\n\r 통해 인증 시스템으로 전송 합니다.", tbTaxInvoiceSubmitUrl.Text.Trim()));
            CreateInvoce(_type_code);

            string _referenceId = "";

            string _loadfile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"security\\7-{_type_code}-전자서명후.txt");
            {
                tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                WriteLine("after transform read from " + _loadfile);

                XmlDocument _xd = new XmlDocument();
                _xd.Load(_loadfile);

                _referenceId = _xd.SelectSingleNode("descendant::kec:ReferenceID", Packing.SNG.SoapNamespaces).InnerText;
                WriteLine(String.Format("retrieve reference-id :<{0}>", _referenceId));
            }

            byte[] _soappart = File.ReadAllBytes(_loadfile);
            byte[] _attachment = File.ReadAllBytes(Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\7-{_type_code}.asn"));
            {
                WriteLine("read encrypt data " + _attachment.Length);
            }

			MimeContent _mimeContent = Request.SNG.TaxInvoiceSubmit(_soappart, _attachment, _referenceId, tbTaxInvoiceSubmitUrl.Text.Trim());
            if (_mimeContent.StatusCode == 0)
            {
                var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"security\\8-{_type_code}-TaxInvoiceRecvAck.txt");
                {
                    File.WriteAllText(_savefile, _mimeContent.Parts[1].GetContentAsString(), Encoding.ASCII);

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

        private void btLoad_Click(object sender, EventArgs e)
        {
            DialogResult _result = xmlLoadDlg.ShowDialog();
            if (_result == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(xmlLoadDlg.FileName) == false)
                {
                }
            }
        }

        private void sbCheckSign_Click(object sender, EventArgs e)
        {
            string _signedFile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"security\7. 전자서명후.txt");

            XmlDocument _xmldoc = new XmlDocument(Packing.SNG.SoapNamespaces.NameTable)
            {
                PreserveWhitespace = true
            };
            _xmldoc.Load(_signedFile);

            XmlElement _binarySecurityToken = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::wsse:BinarySecurityToken", Packing.SNG.SoapNamespaces);
            byte[] _token = Convert.FromBase64String(_binarySecurityToken.InnerText);

            X509Certificate2 _x509cert2 = new X509Certificate2(_token);

            XmlElement _signedInfo = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::ds:SignedInfo", Packing.SNG.SoapNamespaces);
            byte[] _content = Encoding.UTF8.GetBytes(
                            _signedInfo.OuterXml.Replace(
                                    "<ds:SignedInfo xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\">",
                                    "<ds:SignedInfo xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:kec=\"http://www.kec.or.kr/standard/Tax/\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
                                )
                             );

            XmlElement _signatureValue = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::ds:SignatureValue", Packing.SNG.SoapNamespaces);
            byte[] _signature = Convert.FromBase64String(_signatureValue.InnerText);

            if (Validator.SNG.VerifySignature(_content, _signature, _x509cert2.PublicKey.Key) == true)
                WriteLine("verify success");
            else
                WriteLine("verify failure");
        }

        private void ceTestOk_CheckedChanged(object sender, EventArgs e)
        {
            tbTaxInvoiceSubmitUrl.Text = UCfgHelper.SNG.RequestResultsSubmitUrl(ceTestOk.Checked, false);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}