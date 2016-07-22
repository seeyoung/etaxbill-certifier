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
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using OpenETaxBill.SDK.Control.Library;

namespace OpenETaxBill.Engine.Certifier
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------------------
        // attributes
        //-------------------------------------------------------------------------------------------------------------------------

        private Form ActiveMDIForm
        {
            get
            {
                return ActiveMdiChild;
            }
        }

        bool IsTabbedMdi
        {
            get
            {
                return biTabbedMDI.Down;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // methodes
        //-------------------------------------------------------------------------------------------------------------------------
        private bool ActivateChildForm(XtraForm p_newForm)
        {
            var _found = false;

            foreach (XtraForm _form in MdiChildren)
            {
                if (_form.Name == p_newForm.Name)
                {
                    _form.Activate();
                    _found = true;

                    break;
                }
            }

            //if (_found == false)
            //{
            //    p_newForm.Parent = this;
            //    p_newForm.Show();
            //}

            return _found;
        }

        private void ToggleTabbedMDI()
        {
            tabbedMdiMgr.MdiParent = IsTabbedMdi ? this : null;
            biCascade.Visibility = biHorizontal.Visibility = biVertical.Visibility = IsTabbedMdi ? BarItemVisibility.Never : BarItemVisibility.Always;
        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();
            SkinHelper.InitSkinPopupMenu(bm_theme);

            ToggleTabbedMDI();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        // events
        //-------------------------------------------------------------------------------------------------------------------------
        private void mBarExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void biTabbedMDI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ToggleTabbedMDI();
        }

        private void biCascade_ItemClick(object sender, ItemClickEventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void biHorizontal_ItemClick(object sender, ItemClickEventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void biVertical_ItemClick(object sender, ItemClickEventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void biClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveMDIForm != null)
                ActiveMDIForm.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
            this.Text = String.Format("표준 전자세금계산서 인증시스템 - {0}", UCfgHelper.SNG.KeySize);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void biCreator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _creator = new eTaxCreator();

            if (ActivateChildForm(_creator) == false)
            {
                _creator.MdiParent = this;
                _creator.Show();
            }
        }

        private void biSignature_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _signatureForm = new eTaxSigning();

            if (ActivateChildForm(_signatureForm) == false)
            {
                _signatureForm.MdiParent = this;
                _signatureForm.Show();
            }
        }

        private void biEncrypt_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _envelope = new eTaxEncrypt();

            if (ActivateChildForm(_envelope) == false)
            {
                _envelope.MdiParent = this;
                _envelope.Show();
            }
        }

        private void biExchange_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _creator = new eTaxInvoice();

            if (ActivateChildForm(_creator) == false)
            {
                _creator.MdiParent = this;
                _creator.Show();
            }
        }

        private void biRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _creator = new eTaxRequest();

            if (ActivateChildForm(_creator) == false)
            {
                _creator.MdiParent = this;
                _creator.Show();
            }
        }

        private void btInteropSubmit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _interop = new eXmlInvoice();

            if (ActivateChildForm(_interop) == false)
            {
                _interop.MdiParent = this;
                _interop.Show();
            }
        }

        private void biInteropRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _interop = new eXmlRequest();

            if (ActivateChildForm(_interop) == false)
            {
                _interop.MdiParent = this;
                _interop.Show();
            }
        }

        private void bbCertRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.XtraEditors.XtraForm _certkey = new eKeyPublic();

            if (ActivateChildForm(_certkey) == false)
            {
                _certkey.MdiParent = this;
                _certkey.Show();
            }
        }

        private void biBizBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (System.Diagnostics.Process _process = new System.Diagnostics.Process())
            {
                _process.StartInfo.FileName = "http://www.odinsoftware.co.kr";
                _process.StartInfo.Verb = "Open";
                _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                _process.Start();
            }
        }

        private void biESeroTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (System.Diagnostics.Process _process = new System.Diagnostics.Process())
            {
                _process.StartInfo.FileName = "http://testbed.esero.go.kr";
                _process.StartInfo.Verb = "Open";
                _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                _process.Start();
            }
        }

        private void biTaxCertiTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (System.Diagnostics.Process _process = new System.Diagnostics.Process())
            {
                _process.StartInfo.FileName = "http://www.taxcerti.or.kr";
                _process.StartInfo.Verb = "Open";
                _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                _process.Start();
            }
        }

        private void biOutputFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (System.Diagnostics.Process _process = new System.Diagnostics.Process())
            {
                _process.StartInfo.FileName = UCfgHelper.SNG.OutputFolder;
                _process.StartInfo.Verb = "Open";
                _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                _process.Start();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (System.Diagnostics.Process _process = new System.Diagnostics.Process())
            {
                _process.StartInfo.FileName = @"AcroEdit.exe";
                _process.StartInfo.Verb = "Open";
                _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                _process.Start();
            }
        }

        private void biResponse_ItemClick(object sender, ItemClickEventArgs e)
        {
            string _endPoint = UCfgHelper.SNG.ReplyAddress;

            string _message
                = "처리결과 전송 검증은 테스트베드가 임의의 전자(세금)계산서 처리결과를 사업자 시스템에 전송하고, 이에 대한 응답메시지를 검증합니다.\n"
                + "사업자 시스템의 ENDPOINT: {0}로 가상의 처리결과를 전송한 후 이를 검증 합니다.\n\n"
                + "국세청 인증 서버에서 Responsor 서비스로 메시지를 전달하는 단계 입니다.\n"
                + "국세청 인증 사이트에서 전송 버튼을 클릭 후 log를 확인 하세요.\n\n"
                + "** Windows 서버인 경우 방화벽 인바운드규칙에서 8080포트를 열어 줘야 합니다. **";

            MessageBox.Show(String.Format(_message, _endPoint));
        }

        private void biOption_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //-------------------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------------------
    }
}