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
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OdinSoft.SDK.eTaxBill.Security.Issue;
using OdinSoft.SDK.eTaxBill.Security.Signature;

namespace OpenETaxBill.Certifier
{
    public partial class eTaxSigning : Form
    {

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private MainForm __parent_form = null;

        public eTaxSigning(Form p_parent_form)
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
        private void XmlSignature_Load(object sender, EventArgs e)
        {
            __parent_form.RestoreFormLayout(this);
        }

        private void XmlSignature_FormClosing(object sender, FormClosingEventArgs e)
        {
            __parent_form.SaveFormLayout(this);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbSourceXml.Text = "";
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            DialogResult _result = xmlLoadDlg.ShowDialog();
            if (_result == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(xmlLoadDlg.FileName) == false)
                {
                    tbSourceXml.Text = File.ReadAllText(xmlLoadDlg.FileName, Encoding.UTF8);
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DialogResult _result = xmlSaveDlg.ShowDialog();
            if (_result == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(xmlSaveDlg.FileName) == false)
                {
                    File.WriteAllText(xmlSaveDlg.FileName, tbSourceXml.Text, Encoding.UTF8);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void FixupNamespaceNodes(XmlElement p_srcNode, XmlElement p_dstNode)
        {
            // remove namespace nodes
            foreach (XmlAttribute _attr1 in p_dstNode.SelectNodes("namespace::*"))
            {
                if (_attr1.LocalName == "xml")
                    continue;

                p_dstNode.RemoveAttributeNode(p_dstNode.OwnerDocument.ImportNode(_attr1, true) as XmlAttribute);
            }

            // add namespace nodes
            foreach (XmlAttribute _attr1 in p_srcNode.SelectNodes("namespace::*"))
            {
                if (_attr1.LocalName == "xml")
                    continue;
                if (_attr1.OwnerElement == p_srcNode)
                    continue;

                p_dstNode.SetAttributeNode(p_dstNode.OwnerDocument.ImportNode(_attr1, true) as XmlAttribute);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void sbXPath_Click(object sender, EventArgs e)
        {
            byte[] _source = Encoding.UTF8.GetBytes(tbSourceXml.Text);
            byte[] _target = Encoding.UTF8.GetBytes(tbTargetXml.Text);

            int _maxLength = _source.Length > _target.Length ? _source.Length : _target.Length;
            int _pos = 0;

            for (; _pos < _maxLength; _pos++)
            {
                if (_pos >= _source.Length || _pos >= _target.Length)
                    break;

                if (_source[_pos] != _target[_pos])
                    break;
            }

            if (_pos < _maxLength)
            {
                WriteLine("missmatch: " + tbSourceXml.Text.Substring(_pos, 80));
            }
            else
            {
                WriteLine("completed comapare is same.");
            }
        }

        private void sbCreate_Click(object sender, EventArgs e)
        {
            var _type_code = String.Format("{0:00}{1:00}", (cbKind1.SelectedIndex + 1), (cbKind2.SelectedIndex + 1));

            string _readfile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\2-{_type_code}.xml");
            WriteLine("read source file: " + _readfile);

            MemoryStream _targetXml = XSignature.SNG.GetSignedXmlStream(_readfile, UCertHelper.SNG.UserSignCert.X509Cert2);

            var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\6-{_type_code}.xml");
            {
                File.WriteAllBytes(_savefile, _targetXml.ToArray());

                tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                WriteLine("result docuement write on the " + _savefile);
            }

            MessageBox.Show(String.Format("암호화 되지 않은 XML형식의(전자서명 포함) 전자세금계산서\n\r{0} 파일을\n\r국세청 인증사이트에 업로드 하세요.", _savefile));
        }

        private void sbVerify_Click(object sender, EventArgs e)
        {
            string _signedFile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"unitest\6.xml");

            XmlNamespaceManager _xmlmgr = new XmlNamespaceManager(new NameTable());
            _xmlmgr.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);

            XmlDocument _xmldoc = new XmlDocument(_xmlmgr.NameTable);
            _xmldoc.PreserveWhitespace = true;
            _xmldoc.Load(_signedFile);

            XmlElement _binarySecurityToken = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::ds:X509Certificate", _xmlmgr);
            byte[] _token = Convert.FromBase64String(_binarySecurityToken.InnerText);

            X509Certificate2 _x509cert2 = new X509Certificate2(_token);

            XmlElement _signedInfo = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::ds:SignedInfo", _xmlmgr);
            byte[] _content = Encoding.UTF8.GetBytes(
                        _signedInfo.OuterXml.Replace(
                            "<ds:SignedInfo xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\">", 
                            "<ds:SignedInfo xmlns=\"urn:kr:or:kec:standard:Tax:ReusableAggregateBusinessInformationEntitySchemaModule:1:0\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
                            )
                        );
            //byte[] _content = Encoding.UTF8.GetBytes(_signedInfo.OuterXml);

            XmlElement _signatureValue = (XmlElement)_xmldoc.DocumentElement.SelectSingleNode("descendant::ds:SignatureValue", _xmlmgr);
            byte[] _signature = Convert.FromBase64String(_signatureValue.InnerText);

            if (Validator.SNG.VerifySignature(_content, _signature, _x509cert2.PublicKey.Key) == true)
                WriteLine("verify success");
            else
                WriteLine("verify failure");
        }

        private void btValidate_Click(object sender, EventArgs e)
        {
            string _signedFile = Path.Combine(UCfgHelper.SNG.OutputFolder, @"unitest\6.xml");

            MemoryStream _ms = new MemoryStream(File.ReadAllBytes(_signedFile));

            WriteLine("Validating..." + Environment.NewLine);

            Validator.SNG.DoValidation(_ms);

            WriteLine(Validator.SNG.Result + Environment.NewLine);
            WriteLine("Done..." + Environment.NewLine);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
