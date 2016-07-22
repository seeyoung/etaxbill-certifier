﻿/*
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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using OdinSoft.eTaxBill.Engine.ELIB.Security.Encrypt;
using OdinSoft.eTaxBill.SDK.Control.Library;
using Org.BouncyCastle.Asn1;

namespace OdinSoft.eTaxBill.Engine.Certifier
{
    public partial class eTaxEncrypt : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        public eTaxEncrypt()
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
        private void Envelope_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void Envelope_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
        }

        private void sbEncrypt_Click(object sender, EventArgs e)
        {
            var _type_code = String.Format("{0:00}{1:00}", (cbKind1.SelectedIndex + 1), (cbKind2.SelectedIndex + 1));

            string _loadfile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\6-{_type_code}.xml");
            {
                tbSourceXml.Text = File.ReadAllText(_loadfile, Encoding.UTF8);
                WriteLine("plain data read from " + _loadfile);
            }

            byte[] _plainXml = File.ReadAllBytes(_loadfile);
            byte[] _rvalue = UCertHelper.SNG.UserSignCert.RandomNumber;

            ArrayList _taxinvoice = new ArrayList();
            {
                TaxInvoiceStruct _s = new TaxInvoiceStruct
                {
                    SignerRValue = _rvalue,
                    TaxInvoice = _plainXml
                };

                _taxinvoice.Add(_s);
            }

            var _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\7-{_type_code}.ber");
            {
                File.WriteAllBytes(_savefile, GetTaxInvoicePackage(_taxinvoice));
                WriteLine("tax invoice package write on the " + _savefile);
            }

            X509Certificate2 _nipaCert2 = UCertHelper.SNG.NtsPublicKey;
            byte[] _encoded = CmsManager.SNG.GetContentInfo(_nipaCert2, _taxinvoice);

            _savefile = Path.Combine(UCfgHelper.SNG.OutputFolder, $"unitest\\7-{_type_code}.asn");
            {
                File.WriteAllBytes(_savefile, _encoded);

                tbSourceXml.Text = Convert.ToBase64String(_encoded);
                WriteLine("encrypted result write on the " + _savefile);
            }

            MessageBox.Show(String.Format("암호화된 형식의 전자세금계산서\n\r{0} 파일을\n\r업로드 하여 검증을 실시 하세요.", _savefile));
        }

        private byte[] GetTaxInvoicePackage(ArrayList p_taxInvoices)
        {
            Asn1EncodableVector _asn1Vector = new Asn1EncodableVector();

            for (int i = 0; i < p_taxInvoices.Count; i++)
            {
                TaxInvoiceStruct _taxInvoiceStruct = (TaxInvoiceStruct)p_taxInvoices[i];

                DerOctetString _taxInvoce = new DerOctetString(_taxInvoiceStruct.TaxInvoice);
                DerOctetString _signerRvalue = new DerOctetString(_taxInvoiceStruct.SignerRValue);

                DerSequence _taxInvoiceData = new DerSequence(_signerRvalue, _taxInvoce);
                _asn1Vector.Add(_taxInvoiceData);
            }

            return
                (
                    new DerSequence
                    (
                        new DerInteger(p_taxInvoices.Count),
                        new DerSet(_asn1Vector)
                    )
                ).GetDerEncoded();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}
