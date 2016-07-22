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
using OpenETaxBill.Channel.Library.Security.Mime;
using OpenETaxBill.Channel.Library.Security.Notice;
using OpenETaxBill.SDK.Control.Library;

namespace OpenETaxBill.Certifier
{
    public partial class eTaxSmtp : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        public eTaxSmtp()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void WriteLine(string p_message)
        {
            tbResult.Text = p_message + Environment.NewLine + tbResult.Text;
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void eTaxSmtp_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
        }

        private void eTaxSmtp_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void CreateRequest()
        {
            //var _mime = new MimeConstructor
            //{
            //    From = _invoicerEMail,
            //    To = _providerEMail.Split(';'),
            //    Subject = String.Format("전자세금계산서가 {0}에서 발급되었습니다.", _invoicerName),
            //    BodyHtml = GetProviderBody(_issuedRow)
            //};

            //byte[] _obuffer = CmsManager.SNG.GetEncryptedContent(GetProviderKey(_invoiceeId), Encoding.UTF8.GetBytes(_document));
            //_mime.Attachments.Add(new Attachment(String.Format("{0}.msg", _issueId), _obuffer));

            ////-------------------------------------------------------------------------------------------------------------------------
            //// Signature
            ////-------------------------------------------------------------------------------------------------------------------------
            //XmlDocument _signedXml = Packing.SNG.GetSignedSoapEnvelope(null, UCertHelper.SNG.AspSignCert.X509Cert2, _soapHeader, _soapBody);

            //var _savefile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\31.CertReqSubmit.txt");
            //{
            //    File.WriteAllText(_savefile, _signedXml.OuterXml, Encoding.UTF8);

            //    tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
            //    WriteLine("transforms write on the " + _savefile);
            //}
        }

        private void sbCreateMsg_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("공인인증서 요청을 위한 웹서비스 메시지를,\n\r{0} ENDPOINT를\n\r 통해 인증 시스템으로 전송 합니다.", UCfgHelper.SNG.RequestCertUrl));
            CreateRequest();

            string _loadfile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\31.CertReqSubmit.txt");
            {
                tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                WriteLine("read requesting certification soap-message from " + _loadfile);
            }

            byte[] _soappart = Encoding.UTF8.GetBytes(File.ReadAllText(_loadfile, Encoding.UTF8));

            MimeContent _mimeContent = Request.SNG.TaxRequestCertSubmit(_soappart, UCfgHelper.SNG.RequestCertUrl);
            if (_mimeContent.StatusCode == 0)
            {
                var _savefile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\32.CertReqRecvAck.txt");
                {
                    File.WriteAllText(_savefile, _mimeContent.Parts[0].GetContentAsString(), Encoding.UTF8);

                    if (_mimeContent.StatusCode == 0)
                        tbTargetXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                    else
                        tbTargetXml.Text = _mimeContent.ErrorMessage;

                    WriteLine("response write on the " + _savefile);
                }

                string _zipfile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\32.CertReqRecvAck.zip");
                {
                    File.WriteAllBytes(_zipfile, _mimeContent.Parts[1].GetContentAsStream().ToArray());

                    WriteLine("zip file write on the " + _zipfile);
                }

                MessageBox.Show(String.Format("수신된 Zip 파일이 {0}에 저장 되었습니다.", _zipfile));
            }
            else
            {
                MessageBox.Show(_mimeContent.ErrorMessage);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}