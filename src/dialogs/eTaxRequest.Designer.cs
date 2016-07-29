namespace OpenETaxBill.Certifier
{
    partial class eTaxRequest
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
            this.ceTestOk = new DevExpress.XtraEditors.CheckEdit();
            this.cbKind2 = new OdinSoft.SDK.Control.DVX.uComboBoxEdit();
            this.cbKind1 = new OdinSoft.SDK.Control.DVX.uComboBoxEdit();
            this.lbKind2 = new DevExpress.XtraEditors.LabelControl();
            this.uLabelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbResultsReqSubmitUrl = new DevExpress.XtraEditors.TextEdit();
            this.uLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btReqSubmit = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceTestOk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResultsReqSubmitUrl.Properties)).BeginInit();
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
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ceTestOk);
            this.panelControl2.Controls.Add(this.cbKind2);
            this.panelControl2.Controls.Add(this.cbKind1);
            this.panelControl2.Controls.Add(this.lbKind2);
            this.panelControl2.Controls.Add(this.uLabelControl4);
            this.panelControl2.Controls.Add(this.tbResultsReqSubmitUrl);
            this.panelControl2.Controls.Add(this.uLabelControl2);
            this.panelControl2.Controls.Add(this.btReqSubmit);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btLoad);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(934, 108);
            this.panelControl2.TabIndex = 4;
            // 
            // ceTestOk
            // 
            this.ceTestOk.Location = new System.Drawing.Point(50, 36);
            this.ceTestOk.Name = "ceTestOk";
            this.ceTestOk.Properties.Caption = "인증 검사 중";
            this.ceTestOk.Size = new System.Drawing.Size(99, 19);
            this.ceTestOk.TabIndex = 53;
            this.ceTestOk.CheckedChanged += new System.EventHandler(this.ceTestOk_CheckedChanged);
            // 
            // cbKind2
            // 
            this.cbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind2.DisplayMember = "name";
            this.cbKind2.EditValue = "일반";
            this.cbKind2.Location = new System.Drawing.Point(719, 35);
            this.cbKind2.Name = "cbKind2";
            this.cbKind2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKind2.Properties.Items.AddRange(new object[] {
            "일반",
            "영세",
            "위수탁",
            "수입",
            "영세율위수탁",
            "수입납부유예"});
            this.cbKind2.Size = new System.Drawing.Size(121, 20);
            this.cbKind2.TabIndex = 52;
            this.cbKind2.ValueMember = "code";
            // 
            // cbKind1
            // 
            this.cbKind1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind1.DisplayMember = "name";
            this.cbKind1.EditValue = "세금계산서";
            this.cbKind1.Location = new System.Drawing.Point(566, 35);
            this.cbKind1.Name = "cbKind1";
            this.cbKind1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKind1.Properties.Items.AddRange(new object[] {
            "세금계산서",
            "수정세금계산서",
            "계산서",
            "수정계산서"});
            this.cbKind1.Size = new System.Drawing.Size(117, 20);
            this.cbKind1.TabIndex = 51;
            this.cbKind1.ValueMember = "code";
            // 
            // lbKind2
            // 
            this.lbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbKind2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbKind2.Location = new System.Drawing.Point(689, 37);
            this.lbKind2.Name = "lbKind2";
            this.lbKind2.Size = new System.Drawing.Size(24, 17);
            this.lbKind2.TabIndex = 50;
            this.lbKind2.Text = "구분";
            // 
            // uLabelControl4
            // 
            this.uLabelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.uLabelControl4.Location = new System.Drawing.Point(536, 37);
            this.uLabelControl4.Name = "uLabelControl4";
            this.uLabelControl4.Size = new System.Drawing.Size(24, 17);
            this.uLabelControl4.TabIndex = 49;
            this.uLabelControl4.Text = "종류";
            // 
            // tbResultsReqSubmitUrl
            // 
            this.tbResultsReqSubmitUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResultsReqSubmitUrl.EditValue = "http://www.taxcerti.or.kr/etax/mr/RequestResultsService/07855a68-d5a2-4e58-9833-e" +
    "a76b7703826";
            this.tbResultsReqSubmitUrl.Location = new System.Drawing.Point(52, 5);
            this.tbResultsReqSubmitUrl.Name = "tbResultsReqSubmitUrl";
            this.tbResultsReqSubmitUrl.Size = new System.Drawing.Size(788, 20);
            this.tbResultsReqSubmitUrl.TabIndex = 37;
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Location = new System.Drawing.Point(5, 8);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(41, 14);
            this.uLabelControl2.TabIndex = 36;
            this.uLabelControl2.Text = "요청URL";
            // 
            // btReqSubmit
            // 
            this.btReqSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btReqSubmit.Appearance.Options.UseFont = true;
            this.btReqSubmit.Appearance.Options.UseTextOptions = true;
            this.btReqSubmit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btReqSubmit.Location = new System.Drawing.Point(846, 5);
            this.btReqSubmit.Name = "btReqSubmit";
            this.btReqSubmit.Size = new System.Drawing.Size(77, 50);
            this.btReqSubmit.TabIndex = 24;
            this.btReqSubmit.Text = "REQUEST SUBMIT";
            this.btReqSubmit.Click += new System.EventHandler(this.btRequest_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(853, 67);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(70, 30);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "SAVE";
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(777, 67);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(70, 30);
            this.btLoad.TabIndex = 22;
            this.btLoad.Text = "LOAD";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
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
            this.pnBackGround.TabIndex = 5;
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.EditValue = "";
            this.tbResult.Location = new System.Drawing.Point(2, 454);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(930, 97);
            this.tbResult.TabIndex = 1;
            // 
            // uPanelControl2
            // 
            this.uPanelControl2.Controls.Add(this.labelControl7);
            this.uPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl2.Location = new System.Drawing.Point(2, 426);
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
            this.spBottomMiddle.Location = new System.Drawing.Point(2, 421);
            this.spBottomMiddle.Name = "spBottomMiddle";
            this.spBottomMiddle.Size = new System.Drawing.Size(930, 5);
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
            this.pnTop.Size = new System.Drawing.Size(930, 419);
            this.pnTop.TabIndex = 12;
            // 
            // tbTargetXml
            // 
            this.tbTargetXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetXml.EditValue = "";
            this.tbTargetXml.Location = new System.Drawing.Point(451, 24);
            this.tbTargetXml.Name = "tbTargetXml";
            this.tbTargetXml.Size = new System.Drawing.Size(477, 393);
            this.tbTargetXml.TabIndex = 14;
            // 
            // spTopLeft
            // 
            this.spTopLeft.Location = new System.Drawing.Point(446, 24);
            this.spTopLeft.Name = "spTopLeft";
            this.spTopLeft.Size = new System.Drawing.Size(5, 393);
            this.spTopLeft.TabIndex = 13;
            this.spTopLeft.TabStop = false;
            // 
            // tbSourceXml
            // 
            this.tbSourceXml.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSourceXml.EditValue = "";
            this.tbSourceXml.Location = new System.Drawing.Point(2, 24);
            this.tbSourceXml.Name = "tbSourceXml";
            this.tbSourceXml.Size = new System.Drawing.Size(444, 393);
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
            // eTaxRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.pnBackGround);
            this.Controls.Add(this.panelControl2);
            this.Name = "eTaxRequest";
            this.Text = "SoapCreator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eXmlCreator_FormClosing);
            this.Load += new System.EventHandler(this.eXmlCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceTestOk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbResultsReqSubmitUrl.Properties)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btReqSubmit;
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
		private DevExpress.XtraEditors.TextEdit tbResultsReqSubmitUrl;
		private DevExpress.XtraEditors.LabelControl uLabelControl2;
        private OdinSoft.SDK.Control.DVX.uComboBoxEdit cbKind2;
        private OdinSoft.SDK.Control.DVX.uComboBoxEdit cbKind1;
        private DevExpress.XtraEditors.LabelControl lbKind2;
        private DevExpress.XtraEditors.LabelControl uLabelControl4;
        private DevExpress.XtraEditors.CheckEdit ceTestOk;
    }
}