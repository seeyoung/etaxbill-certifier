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
using OpenETaxBill.Engine.ELIB.Security.Signature;

namespace OpenETaxBill.Engine.Certifier
{
    /// <summary>
    /// 
    /// </summary>
    public class UCertHelper : IDisposable
    {
        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
        private readonly static Lazy<UCertHelper> m_lzayHelper = new Lazy<UCertHelper>(() =>
        {
            return new UCertHelper();
        });

        /// <summary>
        /// 
        /// </summary>
        public static UCertHelper SNG
        {
            get
            {
                return m_lzayHelper.Value;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public X509CertMgr UserSignCert
        {
            get
            {
                if (UCfgHelper.SNG.KeySize == 2048)
                    return UserSignCert_2048;
                else
                    return UserSignCert_1024;
            }
        }

        private X509CertMgr m_userSignCert_2048 = null;

        /// <summary>
        /// 전자서명용 -> 사용자로써의 오딘소프트 서명용 2048 인증서 
        /// </summary>
        public X509CertMgr UserSignCert_2048
        {
            get
            {
                if (m_userSignCert_2048 == null)
                {
                    string _publicFile = Path.Combine(UCfgHelper.SNG.RootCertFolder, @"ASP\2048\signCert.der");
                    string _privatFile = Path.Combine(UCfgHelper.SNG.RootCertFolder, @"ASP\2048\signPri.key");
                    string _password = UCfgHelper.SNG.UserCertPassword_2048;

                    m_userSignCert_2048 = new X509CertMgr(_publicFile, _privatFile, _password);
                }

                return m_userSignCert_2048;
            }
        }

        private X509CertMgr m_userSignCert_1024 = null;

        /// <summary>
        /// 전자서명용 -> 사용자로써의 오딘소프트 서명용 1024 인증서 
        /// </summary>
        public X509CertMgr UserSignCert_1024
        {
            get
            {
                if (m_userSignCert_1024 == null)
                {
                    string _publicFile = Path.Combine(UCfgHelper.SNG.RootCertFolder, @"ASP\1024\signCert.der");
                    string _privatFile = Path.Combine(UCfgHelper.SNG.RootCertFolder, @"ASP\1024\signPri.key");
                    string _password = UCfgHelper.SNG.UserCertPassword_1024;

                    m_userSignCert_1024 = new X509CertMgr(_publicFile, _privatFile, _password);
                }

                return m_userSignCert_1024;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------

        private X509CertMgr m_aspSignCert = null;

        /// <summary>
        /// 전자서명용 -> ASP사업자인 오딘소프트의 서명용 인증서 (테스트 기간에는 진흥원에서 제공한 2048 인증서 사용)
        /// </summary>
        public X509CertMgr AspSignCert
        {
            get
            {
                if (m_aspSignCert == null)
                {
                    string _publicFile = Path.Combine(UCfgHelper.SNG.AspCertFolder, "signCert.der");
                    string _privatFile = Path.Combine(UCfgHelper.SNG.AspCertFolder, "signPri.key");
                    string _password = UCfgHelper.SNG.AspCertPassword;

                    m_aspSignCert = new X509CertMgr(_publicFile, _privatFile, _password);
                }

                return m_aspSignCert;
            }
        }

        private X509Certificate2 m_ntsPublicKey = null;

        /// <summary>
        /// 암호화용 -> 국세청에서 제공하는 공캐키, 검증시에는 진흥원 키 사용
        /// </summary>
        public X509Certificate2 NtsPublicKey
        {
            get
            {
                if (m_ntsPublicKey == null)
                {
                    string _public_cert_file;

                    if (UCfgHelper.SNG.LiveServer == true)
                        _public_cert_file = Path.Combine(UCfgHelper.SNG.NtsCertFolder, "국세청.der");
                    else
                        _public_cert_file = Path.Combine(UCfgHelper.SNG.NtsCertFolder, "진흥원.der");

                    m_ntsPublicKey = new X509Certificate2(_public_cert_file);
                }

                return m_ntsPublicKey;
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
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~UCertHelper()
        {
            Dispose(false);
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // 
        //-------------------------------------------------------------------------------------------------------------------------
    }
}