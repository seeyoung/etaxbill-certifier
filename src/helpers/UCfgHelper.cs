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

namespace OpenETaxBill.Engine.Certifier
{
    /// <summary>
    /// 
    /// </summary>
    public class UCfgHelper : IDisposable
    {
        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
        private readonly static Lazy<UCfgHelper> m_lzayHelper = new Lazy<UCfgHelper>(() =>
        {
            return new UCfgHelper();
        });

        /// <summary>
        /// 
        /// </summary>
        public static UCfgHelper SNG
        {
            get
            {
                return m_lzayHelper.Value;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
        private OpenETaxBill.Engine.Interface.ISigner m_isigner = null;
        private OpenETaxBill.Engine.Interface.ISigner ISigner
        {
            get
            {
                if (m_isigner == null)
                    m_isigner = new OpenETaxBill.Engine.Interface.ISigner(false);

                return m_isigner;
            }
        }

        private OpenETaxBill.Engine.Channel.CCollector m_ccollector = null;
        private OpenETaxBill.Engine.Channel.CCollector CCollector
        {
            get
            {
                if (m_ccollector == null)
                    m_ccollector = new OpenETaxBill.Engine.Channel.CCollector(ISigner.Manager);

                return m_ccollector;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_appkey"></param>
        /// <param name="p_default"></param>
        /// <returns></returns>
        private string GetCfgValue(string p_appkey, string p_default)
        {
            return CCollector.GetCfgValue(p_appkey, p_default);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
        private string m_keySize = "";
        public int KeySize
        {
            get
            {
                if (String.IsNullOrEmpty(m_keySize) == true)
                    m_keySize = GetCfgValue("KeySize", "2048");

                return Convert.ToInt32(m_keySize);
            }
        }

        public string UserCertPassword
        {
            get
            {
                if (KeySize == 2048)
                    return UserCertPassword_2048;
                else
                    return UserCertPassword_1024;
            }
        }

        private string m_userCertPassword_1024 = "";

        /// <summary>
        /// 세금계산서를 발행하는 사업자의 인증서 입니다.
        /// AspCertPassword는 ASP 또는 ERP 사업자의 인증서 암호 입니다.
        /// </summary>
        public string UserCertPassword_1024
        {
            get
            {
                if (String.IsNullOrEmpty(m_userCertPassword_1024) == true)
                    m_userCertPassword_1024 = GetCfgValue("UserCertPassword_1024", "password");

                return m_userCertPassword_1024;
            }
        }

        private string m_userCertPassword_2048 = "";

        /// <summary>
        /// 세금계산서를 발행하는 사업자의 인증서 입니다.
        /// AspCertPassword는 ASP 또는 ERP 사업자의 인증서 암호 입니다.
        /// </summary>
        public string UserCertPassword_2048
        {
            get
            {
                if (String.IsNullOrEmpty(m_userCertPassword_2048) == true)
                    m_userCertPassword_2048 = GetCfgValue("UserCertPassword_2048", "password");

                return m_userCertPassword_2048;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // client only usage property, probably will remove.
        //-------------------------------------------------------------------------------------------------------------------------
        private string m_testerBizNo = "";
        public string TesterBizNo
        {
            get
            {
                if (String.IsNullOrEmpty(m_testerBizNo) == true)
                    m_testerBizNo = GetCfgValue("TesterBizNo", "1388602200");

                return m_testerBizNo;
            }
        }

        private string m_root_folder = "";
        public string RootFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_root_folder) == true)
                    m_root_folder = GetCfgValue("RootFolder", @"D:\odinsoft-git\ubsvc3\bizapp\etaxbill\src\engine\client\etax.engine.certifier\worker");

                return m_root_folder;
            }
        }


        private string m_rootOutFolder = "";
        public string RootOutFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_rootOutFolder) == true)
                    m_rootOutFolder = GetCfgValue("RootOutFolder", Path.Combine(RootFolder, "output"));

                return m_rootOutFolder;
            }
        }

        private string m_outputFolder = "";
        public string OutputFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_outputFolder) == true)
                    m_outputFolder = Path.Combine(RootOutFolder, KeySize.ToString());

                return m_outputFolder;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
        private static string m_isLiveServer = null;

        /// <summary>
        /// live 서버에서 수행 되는지 여부를 설정 합니다.
        /// </summary>
        public bool LiveServer
        {
            get
            {
                if (String.IsNullOrEmpty(m_isLiveServer) == true)
                    m_isLiveServer = GetCfgValue("LiveServer", "false");

                return m_isLiveServer.ToLower() == "true";
            }
        }

        private static string m_connection_string = "";
        public string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(m_connection_string) == true)
                {
                    if (LiveServer == false)
						m_connection_string = GetCfgValue("Test_ConnectionString", "server=odin-db-server;uid=odinsoft;pwd=p@ssw0rd;database=ODIN-TAX-V46");
                    else
						m_connection_string = GetCfgValue("Live_ConnectionString", "server=odin-db-server;uid=odinsoft;pwd=p@ssw0rd;database=ODIN-TAX-V46");
                }

                return m_connection_string;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_is_testing">인증 심사 중 인지 여부</param>
        /// <param name="p_is_interop">false이면 단위기능별검증, true이면 상호운용성 검증</param>
        /// <returns></returns>
        public string TaxInvoiceSubmitUrl(bool p_is_testing = false, bool p_is_interop = false)
        {
            var _result = "";

            if (p_is_testing == false)
            {
                if (p_is_interop == false)
                    _result = "http://www.taxcerti.or.kr/etax/mr/SubmitEtaxInvoiceService/07855a68-d5a2-4e58-9833-ea76b7703826";            // 단위 기능별 검증
                else
                    _result = "http://www.taxcerti.or.kr/etax/er/SubmitEtaxInvoiceService/07855a68-d5a2-4e58-9833-ea76b7703826";            // 상호 운용성 검즘
            }
            else
            {
                if (p_is_interop == false)
                    _result = "http://www.taxcerti.or.kr/etax/mr/CertSubmitEtaxInvoiceService/07855a68-d5a2-4e58-9833-ea76b7703826";        // 단위 기능별 검증
                else
                    _result = "http://www.taxcerti.or.kr/etax/er/CertSubmitEtaxInvoiceService/07855a68-d5a2-4e58-9833-ea76b7703826";        // 상호 운용성 검즘
            }

            return _result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_is_testing">인증 심사 중 인지 여부</param>
        /// <param name="p_is_interop">false이면 단위기능별검증, true이면 상호운용성 검증</param>
        /// <returns></returns>
        public string RequestResultsSubmitUrl(bool p_is_testing = false, bool p_is_interop = false)
        {
            var _result = "";

            if (p_is_testing == false)
            {
                if (p_is_interop == false)
                    _result = "http://www.taxcerti.or.kr/etax/mr/RequestResultsService/07855a68-d5a2-4e58-9833-ea76b7703826";            // 단위 기능별 검증
                else
                    _result = "http://www.taxcerti.or.kr/etax/er/RequestResultsService/07855a68-d5a2-4e58-9833-ea76b7703826";            // 상호 운용성 검즘
            }
            else
            {
                if (p_is_interop == false)
                    _result = "http://www.taxcerti.or.kr/etax/mr/CertRequestResultsService/07855a68-d5a2-4e58-9833-ea76b7703826";        // 단위 기능별 검증
                else
                    _result = "http://www.taxcerti.or.kr/etax/er/CertRequestResultsService/07855a68-d5a2-4e58-9833-ea76b7703826";        // 상호 운용성 검즘
            }

            return _result;
        }

        private static string m_requestCertUrl = "";
        public string RequestCertUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_requestCertUrl) == true)
                    m_requestCertUrl = GetCfgValue("RequestCertUrl", "http://webservice.esero.go.kr/services/RequestCert");

                return m_requestCertUrl;
            }
        }

        private static string m_rootCertFolder = "";
        public string RootCertFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_rootCertFolder) == true)
					m_rootCertFolder = GetCfgValue("RootCertFolder", Path.Combine(RootFolder, "certkey"));


                return m_rootCertFolder;
            }
        }

        private static string m_soapKeySize = "";
        public int SoapKeySize
        {
            get
            {
                if (String.IsNullOrEmpty(m_soapKeySize) == true)
                    m_soapKeySize = GetCfgValue("SoapKeySize", "2048");

                return Convert.ToInt32(m_soapKeySize);
            }
        }

        private static string m_aspCertFolder = "";
        public string AspCertFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_aspCertFolder) == true)
                    m_aspCertFolder = Path.Combine(RootCertFolder, "ASP", SoapKeySize.ToString());

                return m_aspCertFolder;
            }
        }

        private static string m_ntsCertFolder = "";
        public string NtsCertFolder
        {
            get
            {
                if (String.IsNullOrEmpty(m_ntsCertFolder) == true)
                    m_ntsCertFolder = Path.Combine(RootCertFolder,"NTS", SoapKeySize.ToString());

                return m_ntsCertFolder;
            }
        }

        private static string m_aspCertPassword = "";

        /// <summary>
        /// ASP 또는 ERP 사업자의 인증서 암호 입니다.
        /// UserCertPassword는 세금계산서를 발행하는 사업자의 인증서 입니다.
        /// </summary>
        public string AspCertPassword
        {
            get
            {
                if (String.IsNullOrEmpty(m_aspCertPassword) == true)
                    m_aspCertPassword = GetCfgValue("AspCertPassword", "password");

                return m_aspCertPassword;
            }
        }

        private static string m_senderBizNo = "";
        public string SenderBizNo
        {
            get
            {
                if (String.IsNullOrEmpty(m_senderBizNo) == true)
                    m_senderBizNo = GetCfgValue("SenderBizNo", "1388602200");

                return m_senderBizNo;
            }
        }

        private static string m_senderBizName = "";
        public string SenderBizName
        {
            get
            {
                if (String.IsNullOrEmpty(m_senderBizName) == true)
                    m_senderBizName = GetCfgValue("SenderBizName", "(주)오딘소프트");

                return m_senderBizName;
            }
        }

        private static string m_receiverBizNo = "";
        public string ReceiverBizNo
        {
            get
            {
                if (String.IsNullOrEmpty(m_receiverBizNo) == true)
                    m_receiverBizNo = GetCfgValue("ReceiverBizNo", "9999999999");

                return m_receiverBizNo;
            }
        }

        private static string m_receiverBizName = "";
        public string ReceiverBizName
        {
            get
            {
                if (String.IsNullOrEmpty(m_receiverBizName) == true)
                    m_receiverBizName = GetCfgValue("ReceiverBizName", "국세청");

                return m_receiverBizName;
            }
        }

        private static string m_eTaxVersion = "";
        public string eTaxVersion
        {
            get
            {
                if (String.IsNullOrEmpty(m_eTaxVersion) == true)
                    m_eTaxVersion = GetCfgValue("eTaxVersion", "3.0");

                return m_eTaxVersion;
            }
        }

        private static string m_registerId = "";
        public string RegisterId
        {
            get
            {
                if (String.IsNullOrEmpty(m_registerId) == true)
                    m_registerId = GetCfgValue("RegisterId", "42000238");

                return m_registerId;
            }
        }

        private static string m_acceptedRequestUrl = "";
        public string AcceptedRequestUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_acceptedRequestUrl) == true)
                    m_acceptedRequestUrl = GetCfgValue("AcceptedRequestUrl", "/ResultSubmit");

                return m_acceptedRequestUrl.ToLower();
            }
        }

        public string ReplyAddress
        {
            get
            {
                return String.Format("http://{0}:{1}{2}", HostAddress, PortNumber, AcceptedRequestUrl);
            }
        }

        private static string m_hostAddress = "";
        public string HostAddress
        {
            get
            {
                if (String.IsNullOrEmpty(m_hostAddress) == true)
                {
                    if (LiveServer == false)
						m_hostAddress = GetCfgValue("Test_HostAddress", "localhost");	
                    else
                        m_hostAddress = GetCfgValue("Live_HostAddress", "etax.odinsoftware.co.kr");
                }

                return m_hostAddress;
            }
        }

        private static string m_portNumber = "";
        public int PortNumber
        {
            get
            {
                if (String.IsNullOrEmpty(m_portNumber) == true)
                    m_portNumber = GetCfgValue("PortNumber", "8080");

                return Convert.ToInt32(m_portNumber);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_isigner != null)
                {
                    m_isigner.Dispose();
                    m_isigner = null;
                }
                if (m_ccollector != null)
                {
                    m_ccollector.Dispose();
                    m_ccollector = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~UCfgHelper()
        {
            Dispose(false);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
    }
}