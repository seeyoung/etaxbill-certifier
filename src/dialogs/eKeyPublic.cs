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
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using OdinSoft.SDK.Data.Collection;
using OdinSoft.SDK.eTaxBill.Security.Encrypt;
using OdinSoft.SDK.eTaxBill.Security.Mime;
using OdinSoft.SDK.eTaxBill.Security.Notice;

namespace OpenETaxBill.Certifier
{
    public partial class eKeyPublic : Form
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private MainForm __parent_form = null;

        public eKeyPublic(Form p_parent_form)
        {
            InitializeComponent();

            __parent_form = (MainForm)p_parent_form;
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
        private void eXmlPublicKey_Load(object sender, EventArgs e)
        {
            __parent_form.RestoreFormLayout(this);

            tbBizId.Text = UCfgHelper.SNG.SenderBizNo;
            tbBizName.Text = UCfgHelper.SNG.SenderBizName;
            tbRegId.Text = UCfgHelper.SNG.RegisterId;
        }

        private void eXmlPublicKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            __parent_form.SaveFormLayout(this);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        private void CreateRequest()
        {
            Header _soapHeader = new Header();
            {
                _soapHeader.ToAddress = UCfgHelper.SNG.RequestCertUrl;
                _soapHeader.Action = Request.eTaxRequestCertSubmit;
                _soapHeader.Version = UCfgHelper.SNG.eTaxVersion;

                _soapHeader.FromParty = new Party(UCfgHelper.SNG.SenderBizNo, UCfgHelper.SNG.SenderBizName);
                _soapHeader.ToParty = new Party(UCfgHelper.SNG.ReceiverBizNo, UCfgHelper.SNG.ReceiverBizName);

                _soapHeader.OperationType = Request.OperationType_RequestSubmit;
                _soapHeader.MessageType = Request.MessageType_Request;

                _soapHeader.TimeStamp = DateTime.Now;
            }

            Body _soapBody = new Body();
            {
                _soapBody.RequestParty = new Party(tbBizId.Text, tbBizName.Text, tbRegId.Text);
                _soapBody.FileType = tbFileType.Text;
            }

            //-------------------------------------------------------------------------------------------------------------------------
            // Signature
            //-------------------------------------------------------------------------------------------------------------------------
            XmlDocument _signedXml = Packing.SNG.GetSignedSoapEnvelope(null, UCertHelper.SNG.AspSignCert.X509Cert2, _soapHeader, _soapBody);

            var _savefile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\31.CertReqSubmit.txt");
            {
                File.WriteAllText(_savefile, _signedXml.OuterXml, Encoding.UTF8);

                tbSourceXml.Text = File.ReadAllText(_savefile, Encoding.UTF8);
                WriteLine("transforms write on the " + _savefile);
            }
        }

        private void sbPublicKeyReqSubmit_Click(object sender, EventArgs e)
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

        private void sbUnZip_Click(object sender, EventArgs e)
        {
            string _zipFile = Path.Combine(UCfgHelper.SNG.RootOutFolder, @"pubkey\32.CertReqRecvAck.zip");
            {
                WriteLine("read zip file from " + _zipFile);

                ZipInputStream _izipStream = new ZipInputStream(File.OpenRead(_zipFile));

                WriteLine("unzipping...");

                ZipEntry _izipEntry;
                while ((_izipEntry = _izipStream.GetNextEntry()) != null)
                {
                    if (_izipEntry.Name.IndexOf(".ini") >= 0)
                        continue;

                    MemoryStream _ostream = new MemoryStream();
                    {
                        int _size = 2048;
                        byte[] _obuffer = new byte[_size];

                        while (true)
                        {
                            _size = _izipStream.Read(_obuffer, 0, _obuffer.Length);
                            if (_size <= 0)
                                break;

                            _ostream.Write(_obuffer, 0, _size);
                        }

                        _ostream.Seek(0, SeekOrigin.Begin);
                    }

                    string _fileName = Path.GetFileNameWithoutExtension(_izipEntry.Name);

                    string _registerid = _fileName.Substring(0, 8);
                    string _newEMail = _fileName.Substring(9);

                    byte[] _publicBytes = _ostream.ToArray();
                    string _publicStr = Encryptor.SNG.PlainBytesToChiperBase64(_publicBytes);

                    X509Certificate2 _publicCert2 = new X509Certificate2(_publicBytes);
                    DateTime _expiration = Convert.ToDateTime(_publicCert2.GetExpirationDateString());

                    string _userName = _publicCert2.GetNameInfo(X509NameType.SimpleName, false);

                    string _sqlstr
                        = "SELECT publicKey, aspEMail "
                        + "  FROM TB_eTAX_PROVIDER "
                        + " WHERE registerId=@registerId AND aspEMail=@aspEMail";

                    var _dbps = new DatParameters();
                    {
                        _dbps.Add("@registerId", SqlDbType.NVarChar, _registerid);
                        _dbps.Add("@aspEMail", SqlDbType.NVarChar, _newEMail);
                    }

                    var _ds = LDataHelper.SelectDataSet(UCfgHelper.SNG.ConnectionString, _sqlstr, _dbps);
                    if (LDataHelper.IsNullOrEmpty(_ds) == true)
                    {
                        _sqlstr
                            = "INSERT TB_eTAX_PROVIDER "
                            + "( "
                            + " registerId, aspEMail, name, person, publicKey, userName, expiration, lastUpdate, providerId "
                            + ") "
                            + "VALUES "
                            + "( "
                            + " @registerId, @aspEMail, @name, @person, @publicKey, @userName, @expiration, @lastUpdate, @providerId "
                            + ")";

                        _dbps.Add("@registerId", SqlDbType.NVarChar, _registerid);
                        _dbps.Add("@aspEMail", SqlDbType.NVarChar, _newEMail);
                        _dbps.Add("@name", SqlDbType.NVarChar, _userName);
                        _dbps.Add("@person", SqlDbType.NVarChar, "");
                        _dbps.Add("@publicKey", SqlDbType.NVarChar, _publicStr);
                        _dbps.Add("@userName", SqlDbType.NVarChar, _userName);
                        _dbps.Add("@expiration", SqlDbType.DateTime, _expiration);
                        _dbps.Add("@lastUpdate", SqlDbType.DateTime, DateTime.Now);
                        _dbps.Add("@providerId", SqlDbType.NVarChar, "");

                        if (LDataHelper.ExecuteText(UCfgHelper.SNG.ConnectionString, _sqlstr, _dbps) < 1)
                        {
                            WriteLine(String.Format("INSERT FAILURE: {0}, {1}, {2}, {3}", _userName, _registerid, _newEMail, _expiration));
                        }
                        else
                        {
                            WriteLine(String.Format("INSERT SUCCESS: {0}, {1}, {2}, {3}", _userName, _registerid, _newEMail, _expiration));
                        }
                    }
                    else
                    {
                        DataRow _dr = _ds.Tables[0].Rows[0];

                        string _publicKey = Convert.ToString(_dr["publicKey"]);
                        byte[] _puboldBytes = Encryptor.SNG.ChiperBase64ToPlainBytes(_publicKey);

                        X509Certificate2 _puboldCert2 = new X509Certificate2(_puboldBytes);
                        if (_puboldCert2.Equals(_publicCert2) == false)
                        {
                            _sqlstr
                                = "UPDATE TB_eTAX_PROVIDER "
                                + "   SET publicKey=@publicKey, userName=@userName, expiration=@expiration, lastUpdate=@lastUpdate "
                                + " WHERE registerId=@registerId AND aspEMail=@aspEMail";

                            _dbps.Add("@publicKey", SqlDbType.NVarChar, _publicStr);
                            _dbps.Add("@userName", SqlDbType.NVarChar, _userName);
                            _dbps.Add("@expiration", SqlDbType.DateTime, _expiration);
                            _dbps.Add("@lastUpdate", SqlDbType.DateTime, DateTime.Now);

                            if (LDataHelper.ExecuteText(UCfgHelper.SNG.ConnectionString, _sqlstr, _dbps) > 0)
                                WriteLine(String.Format("UPDATE SUCCESS: {0}, {1}, {2}, {3}", _userName, _registerid, _newEMail, _expiration));
                        }
                        else
                        {
                            //WriteLine(String.Format("SAME-KEY: {0}, {1}, {2}, {3}", _userName, _registerid, _newEMail, _expiration));
                        }
                    }

                    _ostream.Close();
                }

                _izipStream.Close();

                WriteLine("unzipped to " + UCfgHelper.SNG.RootOutFolder);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}