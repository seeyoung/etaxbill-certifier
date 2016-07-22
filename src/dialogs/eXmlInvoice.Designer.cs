namespace OpenETaxBill.Engine.Certifier
{
    partial class eXmlInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tbTaxInvoiceSubmitUrl = new DevExpress.XtraEditors.TextEdit();
            this.uLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.sbInvoiceSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.tbInvoicerId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.btLoad = new DevExpress.XtraEditors.SimpleButton();
            this.pnBackGround = new DevExpress.XtraEditors.PanelControl();
            this.tbResult = new DevExpress.XtraEditors.MemoEdit();
            this.uPanelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.spBottomMiddle = new DevExpress.XtraEditors.SplitterControl();
            this.pnTop = new DevExpress.XtraEditors.PanelControl();
            this.tbTargetXml = new DevExpress.XtraEditors.MemoEdit();
            this.spTopLeft = new DevExpress.XtraEditors.SplitterControl();
            this.tbSourceXml = new DevExpress.XtraEditors.MemoEdit();
            this.uPanelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.uLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xmlLoadDlg = new System.Windows.Forms.OpenFileDialog();
            this.ceTestOk = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTaxInvoiceSubmitUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInvoicerId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnBackGround)).BeginInit();
            this.pnBackGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl2)).BeginInit();
            this.uPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetXml.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSourceXml.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl1)).BeginInit();
            this.uPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceTestOk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ceTestOk);
            this.panelControl2.Controls.Add(this.tbTaxInvoiceSubmitUrl);
            this.panelControl2.Controls.Add(this.uLabelControl2);
            this.panelControl2.Controls.Add(this.sbInvoiceSubmit);
            this.panelControl2.Controls.Add(this.tbInvoicerId);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btLoad);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(934, 108);
            this.panelControl2.TabIndex = 5;
            // 
            // tbTaxInvoiceSubmitUrl
            // 
            this.tbTaxInvoiceSubmitUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTaxInvoiceSubmitUrl.EditValue = "http://www.taxcerti.or.kr/etax/er/SubmitEtaxInvoiceService/07855a68-d5a2-4e58-983" +
    "3-ea76b7703826";
            this.tbTaxInvoiceSubmitUrl.Location = new System.Drawing.Point(55, 7);
            this.tbTaxInvoiceSubmitUrl.Name = "tbTaxInvoiceSubmitUrl";
            this.tbTaxInvoiceSubmitUrl.Size = new System.Drawing.Size(784, 20);
            this.tbTaxInvoiceSubmitUrl.TabIndex = 35;
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Location = new System.Drawing.Point(8, 10);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(41, 14);
            this.uLabelControl2.TabIndex = 34;
            this.uLabelControl2.Text = "제출URL";
            // 
            // sbInvoiceSubmit
            // 
            this.sbInvoiceSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbInvoiceSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.sbInvoiceSubmit.Appearance.Options.UseFont = true;
            this.sbInvoiceSubmit.Appearance.Options.UseTextOptions = true;
            this.sbInvoiceSubmit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sbInvoiceSubmit.Location = new System.Drawing.Point(845, 5);
            this.sbInvoiceSubmit.Name = "sbInvoiceSubmit";
            this.sbInvoiceSubmit.Size = new System.Drawing.Size(77, 50);
            this.sbInvoiceSubmit.TabIndex = 29;
            this.sbInvoiceSubmit.Text = "INVOICE SUBMIT";
            this.sbInvoiceSubmit.Click += new System.EventHandler(this.sbSubmit_Click);
            // 
            // tbInvoicerId
            // 
            this.tbInvoicerId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInvoicerId.EditValue = "1388602200";
            this.tbInvoicerId.Location = new System.Drawing.Point(641, 35);
            this.tbInvoicerId.Name = "tbInvoicerId";
            this.tbInvoicerId.Size = new System.Drawing.Size(198, 20);
            this.tbInvoicerId.TabIndex = 28;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(575, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 14);
            this.labelControl4.TabIndex = 27;
            this.labelControl4.Text = "사업자번호";
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(856, 65);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(70, 30);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "SAVE";
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(780, 65);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(70, 30);
            this.btLoad.TabIndex = 22;
            this.btLoad.Text = "LOAD";
            // 
            // pnBackGround
            // 
            this.pnBackGround.Controls.Add(this.tbResult);
            this.pnBackGround.Controls.Add(this.uPanelControl2);
            this.pnBackGround.Controls.Add(this.spBottomMiddle);
            this.pnBackGround.Controls.Add(this.pnTop);
            this.pnBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackGround.Location = new System.Drawing.Point(0, 108);
            this.pnBackGround.Name = "pnBackGround";
            this.pnBackGround.Size = new System.Drawing.Size(934, 553);
            this.pnBackGround.TabIndex = 6;
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.EditValue = "";
            this.tbResult.Location = new System.Drawing.Point(2, 452);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(930, 99);
            this.tbResult.TabIndex = 1;
            // 
            // uPanelControl2
            // 
            this.uPanelControl2.Controls.Add(this.labelControl7);
            this.uPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl2.Location = new System.Drawing.Point(2, 424);
            this.uPanelControl2.Name = "uPanelControl2";
            this.uPanelControl2.Size = new System.Drawing.Size(930, 28);
            this.uPanelControl2.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl7.Location = new System.Drawing.Point(2, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 14);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Result";
            // 
            // spBottomMiddle
            // 
            this.spBottomMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.spBottomMiddle.Location = new System.Drawing.Point(2, 416);
            this.spBottomMiddle.Name = "spBottomMiddle";
            this.spBottomMiddle.Size = new System.Drawing.Size(930, 8);
            this.spBottomMiddle.TabIndex = 13;
            this.spBottomMiddle.TabStop = false;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.tbTargetXml);
            this.pnTop.Controls.Add(this.spTopLeft);
            this.pnTop.Controls.Add(this.tbSourceXml);
            this.pnTop.Controls.Add(this.uPanelControl1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(2, 2);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(930, 414);
            this.pnTop.TabIndex = 12;
            // 
            // tbTargetXml
            // 
            this.tbTargetXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetXml.EditValue = "";
            this.tbTargetXml.Location = new System.Drawing.Point(454, 24);
            this.tbTargetXml.Name = "tbTargetXml";
            this.tbTargetXml.Size = new System.Drawing.Size(474, 388);
            this.tbTargetXml.TabIndex = 14;
            // 
            // spTopLeft
            // 
            this.spTopLeft.Location = new System.Drawing.Point(446, 24);
            this.spTopLeft.Name = "spTopLeft";
            this.spTopLeft.Size = new System.Drawing.Size(8, 388);
            this.spTopLeft.TabIndex = 13;
            this.spTopLeft.TabStop = false;
            // 
            // tbSourceXml
            // 
            this.tbSourceXml.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSourceXml.EditValue = "";
            this.tbSourceXml.Location = new System.Drawing.Point(2, 24);
            this.tbSourceXml.Name = "tbSourceXml";
            this.tbSourceXml.Size = new System.Drawing.Size(444, 388);
            this.tbSourceXml.TabIndex = 12;
            // 
            // uPanelControl1
            // 
            this.uPanelControl1.Controls.Add(this.uLabelControl1);
            this.uPanelControl1.Controls.Add(this.labelControl6);
            this.uPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl1.Location = new System.Drawing.Point(2, 2);
            this.uPanelControl1.Name = "uPanelControl1";
            this.uPanelControl1.Size = new System.Drawing.Size(926, 22);
            this.uPanelControl1.TabIndex = 11;
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uLabelControl1.Location = new System.Drawing.Point(859, 2);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(65, 14);
            this.uLabelControl1.TabIndex = 4;
            this.uLabelControl1.Text = "Sample XML";
            // 
            // labelControl6
            // 
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(2, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 14);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Source XML";
            // 
            // xmlLoadDlg
            // 
            this.xmlLoadDlg.FileName = "*.*";
            this.xmlLoadDlg.Filter = "All Files (*.*)|*.*";
            // 
            // ceTestOk
            // 
            this.ceTestOk.Location = new System.Drawing.Point(53, 36);
            this.ceTestOk.Name = "ceTestOk";
            this.ceTestOk.Properties.Caption = "인증 검사 중";
            this.ceTestOk.Size = new System.Drawing.Size(99, 19);
            this.ceTestOk.TabIndex = 36;
            this.ceTestOk.CheckedChanged += new System.EventHandler(this.ceTestOk_CheckedChanged);
            // 
            // eXmlInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.pnBackGround);
            this.Controls.Add(this.panelControl2);
            this.Name = "eXmlInvoice";
            this.Text = "eXmlInterop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eXmlInterop_FormClosing);
            this.Load += new System.EventHandler(this.eXmlInterop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTaxInvoiceSubmitUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInvoicerId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnBackGround)).EndInit();
            this.pnBackGround.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl2)).EndInit();
            this.uPanelControl2.ResumeLayout(false);
            this.uPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).EndInit();
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbTargetXml.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSourceXml.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl1)).EndInit();
            this.uPanelControl1.ResumeLayout(false);
            this.uPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceTestOk.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton sbInvoiceSubmit;
        private DevExpress.XtraEditors.TextEdit tbInvoicerId;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SimpleButton btLoad;
        private DevExpress.XtraEditors.PanelControl pnBackGround;
        private DevExpress.XtraEditors.MemoEdit tbResult;
        private DevExpress.XtraEditors.PanelControl uPanelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SplitterControl spBottomMiddle;
        private DevExpress.XtraEditors.PanelControl pnTop;
        private DevExpress.XtraEditors.MemoEdit tbTargetXml;
        private DevExpress.XtraEditors.SplitterControl spTopLeft;
        private DevExpress.XtraEditors.MemoEdit tbSourceXml;
        private DevExpress.XtraEditors.PanelControl uPanelControl1;
        private DevExpress.XtraEditors.LabelControl uLabelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.OpenFileDialog xmlLoadDlg;
		private DevExpress.XtraEditors.TextEdit tbTaxInvoiceSubmitUrl;
		private DevExpress.XtraEditors.LabelControl uLabelControl2;
        private DevExpress.XtraEditors.CheckEdit ceTestOk;
    }
}