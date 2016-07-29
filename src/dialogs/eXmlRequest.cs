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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OdinSoft.SDK.eTaxBill.Security.Mime;
using OdinSoft.SDK.eTaxBill.Security.Notice;

namespace OpenETaxBill.Certifier
{
    public partial class eXmlRequest : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private MainForm __parent_form = null;

        public eXmlRequest(Form p_parent_form)
        {
            InitializeComponent();

            __parent_form = (MainForm)p_parent_form;
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void WriteLine(string p_message)
        {
            if (__parent_form != null)
            {
                var _main = __parent_form;
                _main.WriteOutput(p_message, this.Name);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void eXmlInterop_FormClosing(object sender, FormClosingEventArgs e)
        {
            __parent_form.SaveFormLayout(this);
        }

        private void eXmlInterop_Load(object sender, EventArgs e)
        {
            __parent_form.RestoreFormLayout(this);

            ceTestOk_CheckedChanged(sender, e);
            tbSubmitId.Text = UCfgHelper.SNG.RegisterId + "-20160708-451f22a828182f47921e93b1b747e5dc";
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void CreateRequest()
        {
            Header _soapHeader = new Header();
            {
				_soapHeader.ToAddress = tbResultsReqSubmitUrl.Text.Trim();
                _soapHeader.Action = Request.eTaxRequestSubmit;
                _soapHeader.Version = UCfgHelper.SNG.eTaxVersion;

                _soapHeader.FromParty = new Party(UCfgHelper.SNG.SenderBizNo, UCfgHelper.SNG.SenderBizName);
                _soapHeader.ToParty = new Party(UCfgHelper.SNG.ReceiverBizNo, UCfgHelper.SNG.ReceiverBizName);

                _soapHeader.OperationType = Request.OperationType_RequestSubmit;
                _soapHeader.MessageType = Request.MessageType_Request;
                
                _soapHeader.TimeStamp = DateTime.Now;
                _soapHeader.MessageId = Packing.SNG.GetMessageId(_soapHeader.TimeStamp);
            }

            Body _soapBody = new Body();
            {
                _soapBody.RefSubmitID = tbSubmitId.Text;
            }

            //-------------------------------------------------------------------------------------------------------------------------
            // Signature
            //-------------------------------------------------------------------------------------------------------------------------
            XmlDocument _signedXml = Packing.SNG.GetSignedSoapEnvelope(null, UCertHelper.SNG.AspSignCert.X509Cert2, _soapHeader, _soapBody);

            var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"interop\\19-ResultsReqsubmit.txt");
            {
                File.WriteAllText(_savefile, _signedXml.OuterXml, Encoding.UTF8);

                tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                WriteLine("transforms write on the " + _savefile);
            }
        }

        private void sbRequestSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbResultsReqSubmitUrl.Text.Trim()) == true)
			{
				MessageBox.Show("처리결과 요청을 위한 웹서비스 URL을 입력해 주십시오.");
				tbResultsReqSubmitUrl.Focus();
				return;
			}

			string _endpoint = tbResultsReqSubmitUrl.Text.Trim();

            MessageBox.Show(String.Format("상호운영성 테스트 검증을 위한 처리 결과 요청 메시지를,\n\rENDPOINT: {0}를\n\r 통해 인증 시스템으로 전송 합니다. ", _endpoint));
            CreateRequest();

            string _loadfile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"interop\\19-ResultsReqSubmit.txt");
            {
                tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                WriteLine("after transform read from " + _loadfile);
            }

            byte[] _soappart = File.ReadAllBytes(_loadfile);

            MimeContent _mimeContent = Request.SNG.TaxRequestSubmit(_soappart, _endpoint);
            if (_mimeContent.StatusCode == 0)
            {
                var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"interop\\10-ResultsReqRecvAck.txt");
                {
                    string _response = _mimeContent.GetContentAsString();
                    File.WriteAllText(_savefile, _response, Encoding.UTF8);

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

        private void ceTestOk_CheckedChanged(object sender, EventArgs e)
        {
            tbResultsReqSubmitUrl.Text = UCfgHelper.SNG.RequestResultsSubmitUrl(ceTestOk.Checked, true);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
