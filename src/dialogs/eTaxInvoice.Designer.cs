namespace OpenETaxBill.Certifier
{
    partial class eTaxInvoice
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
            this.panelControl2 = new System.Windows.Forms.Panel();
            this.ceTestOk = new System.Windows.Forms.CheckBox();
            this.cbKind2 = new System.Windows.Forms.ComboBox();
            this.cbKind1 = new System.Windows.Forms.ComboBox();
            this.lbKind2 = new System.Windows.Forms.Label();
            this.uLabelControl3 = new System.Windows.Forms.Label();
            this.tbTaxInvoiceSubmitUrl = new System.Windows.Forms.TextBox();
            this.uLabelControl2 = new System.Windows.Forms.Label();
            this.sbCheckSign = new System.Windows.Forms.Button();
            this.sbFirstRefTarget = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.pnBackGround = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.tbTargetXml = new System.Windows.Forms.RichTextBox();
            this.spTopLeft = new System.Windows.Forms.Splitter();
            this.tbSourceXml = new System.Windows.Forms.RichTextBox();
            this.uPanelControl1 = new System.Windows.Forms.Panel();
            this.uLabelControl1 = new System.Windows.Forms.Label();
            this.labelControl6 = new System.Windows.Forms.Label();
            this.xmlLoadDlg = new System.Windows.Forms.OpenFileDialog();
            this.panelControl2.SuspendLayout();
            this.pnBackGround.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.uPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ceTestOk);
            this.panelControl2.Controls.Add(this.cbKind2);
            this.panelControl2.Controls.Add(this.cbKind1);
            this.panelControl2.Controls.Add(this.lbKind2);
            this.panelControl2.Controls.Add(this.uLabelControl3);
            this.panelControl2.Controls.Add(this.tbTaxInvoiceSubmitUrl);
            this.panelControl2.Controls.Add(this.uLabelControl2);
            this.panelControl2.Controls.Add(this.sbCheckSign);
            this.panelControl2.Controls.Add(this.sbFirstRefTarget);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btLoad);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1062, 116);
            this.panelControl2.TabIndex = 4;
            // 
            // ceTestOk
            // 
            this.ceTestOk.Location = new System.Drawing.Point(62, 38);
            this.ceTestOk.Name = "ceTestOk";
            this.ceTestOk.Size = new System.Drawing.Size(113, 20);
            this.ceTestOk.TabIndex = 45;
            this.ceTestOk.Text = "인증 검사 중";
            this.ceTestOk.CheckedChanged += new System.EventHandler(this.ceTestOk_CheckedChanged);
            // 
            // cbKind2
            // 
            this.cbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind2.DisplayMember = "name";
            this.cbKind2.Items.AddRange(new object[] {
            "일반",
            "영세",
            "위수탁",
            "수입",
            "영세율위수탁",
            "수입납부유예"});
            this.cbKind2.Location = new System.Drawing.Point(814, 38);
            this.cbKind2.Name = "cbKind2";
            this.cbKind2.Size = new System.Drawing.Size(138, 23);
            this.cbKind2.TabIndex = 44;
            this.cbKind2.Text = "일반";
            this.cbKind2.ValueMember = "code";
            // 
            // cbKind1
            // 
            this.cbKind1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind1.DisplayMember = "name";
            this.cbKind1.Items.AddRange(new object[] {
            "세금계산서",
            "수정세금계산서",
            "계산서",
            "수정계산서"});
            this.cbKind1.Location = new System.Drawing.Point(628, 38);
            this.cbKind1.Name = "cbKind1";
            this.cbKind1.Size = new System.Drawing.Size(133, 23);
            this.cbKind1.TabIndex = 43;
            this.cbKind1.Text = "세금계산서";
            this.cbKind1.ValueMember = "code";
            // 
            // lbKind2
            // 
            this.lbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbKind2.Location = new System.Drawing.Point(767, 40);
            this.lbKind2.Name = "lbKind2";
            this.lbKind2.Size = new System.Drawing.Size(39, 18);
            this.lbKind2.TabIndex = 42;
            this.lbKind2.Text = "구분";
            // 
            // uLabelControl3
            // 
            this.uLabelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl3.Location = new System.Drawing.Point(580, 40);
            this.uLabelControl3.Name = "uLabelControl3";
            this.uLabelControl3.Size = new System.Drawing.Size(42, 18);
            this.uLabelControl3.TabIndex = 41;
            this.uLabelControl3.Text = "종류";
            // 
            // tbTaxInvoiceSubmitUrl
            // 
            this.tbTaxInvoiceSubmitUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTaxInvoiceSubmitUrl.Location = new System.Drawing.Point(64, 5);
            this.tbTaxInvoiceSubmitUrl.Name = "tbTaxInvoiceSubmitUrl";
            this.tbTaxInvoiceSubmitUrl.Size = new System.Drawing.Size(888, 25);
            this.tbTaxInvoiceSubmitUrl.TabIndex = 33;
            this.tbTaxInvoiceSubmitUrl.Text = "http://www.taxcerti.or.kr/etax/er/SubmitEtaxInvoiceService/07855a68-d5a2-4e58-983" +
    "3-ea76b7703826";
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Location = new System.Drawing.Point(10, 8);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(47, 15);
            this.uLabelControl2.TabIndex = 32;
            this.uLabelControl2.Text = "제출URL";
            // 
            // sbCheckSign
            // 
            this.sbCheckSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCheckSign.Location = new System.Drawing.Point(754, 72);
            this.sbCheckSign.Name = "sbCheckSign";
            this.sbCheckSign.Size = new System.Drawing.Size(111, 32);
            this.sbCheckSign.TabIndex = 30;
            this.sbCheckSign.Text = "CheckSign";
            this.sbCheckSign.Click += new System.EventHandler(this.sbCheckSign_Click);
            // 
            // sbFirstRefTarget
            // 
            this.sbFirstRefTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbFirstRefTarget.Location = new System.Drawing.Point(961, 5);
            this.sbFirstRefTarget.Name = "sbFirstRefTarget";
            this.sbFirstRefTarget.Size = new System.Drawing.Size(90, 58);
            this.sbFirstRefTarget.TabIndex = 29;
            this.sbFirstRefTarget.Text = "INVOICE SUBMIT";
            this.sbFirstRefTarget.Click += new System.EventHandler(this.sbInvoiceSubmit_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(969, 72);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(80, 32);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "SAVE";
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(871, 72);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(91, 32);
            this.btLoad.TabIndex = 22;
            this.btLoad.Text = "LOAD";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // pnBackGround
            // 
            this.pnBackGround.Controls.Add(this.pnTop);
            this.pnBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackGround.Location = new System.Drawing.Point(0, 116);
            this.pnBackGround.Name = "pnBackGround";
            this.pnBackGround.Size = new System.Drawing.Size(1062, 445);
            this.pnBackGround.TabIndex = 5;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.tbTargetXml);
            this.pnTop.Controls.Add(this.spTopLeft);
            this.pnTop.Controls.Add(this.tbSourceXml);
            this.pnTop.Controls.Add(this.uPanelControl1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1062, 445);
            this.pnTop.TabIndex = 12;
            // 
            // tbTargetXml
            // 
            this.tbTargetXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetXml.Location = new System.Drawing.Point(513, 23);
            this.tbTargetXml.Name = "tbTargetXml";
            this.tbTargetXml.Size = new System.Drawing.Size(549, 422);
            this.tbTargetXml.TabIndex = 14;
            this.tbTargetXml.Text = "";
            // 
            // spTopLeft
            // 
            this.spTopLeft.Location = new System.Drawing.Point(507, 23);
            this.spTopLeft.Name = "spTopLeft";
            this.spTopLeft.Size = new System.Drawing.Size(6, 422);
            this.spTopLeft.TabIndex = 13;
            this.spTopLeft.TabStop = false;
            // 
            // tbSourceXml
            // 
            this.tbSourceXml.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSourceXml.Location = new System.Drawing.Point(0, 23);
            this.tbSourceXml.Name = "tbSourceXml";
            this.tbSourceXml.Size = new System.Drawing.Size(507, 422);
            this.tbSourceXml.TabIndex = 12;
            this.tbSourceXml.Text = "";
            // 
            // uPanelControl1
            // 
            this.uPanelControl1.Controls.Add(this.uLabelControl1);
            this.uPanelControl1.Controls.Add(this.labelControl6);
            this.uPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.uPanelControl1.Name = "uPanelControl1";
            this.uPanelControl1.Size = new System.Drawing.Size(1062, 23);
            this.uPanelControl1.TabIndex = 11;
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uLabelControl1.Location = new System.Drawing.Point(988, 0);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(74, 23);
            this.uLabelControl1.TabIndex = 4;
            this.uLabelControl1.Text = "Sample XML";
            // 
            // labelControl6
            // 
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(0, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 23);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Source XML";
            // 
            // xmlLoadDlg
            // 
            this.xmlLoadDlg.FileName = "*.*";
            this.xmlLoadDlg.Filter = "All Files (*.*)|*.*";
            // 
            // eTaxInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 561);
            this.Controls.Add(this.pnBackGround);
            this.Controls.Add(this.panelControl2);
            this.Name = "eTaxInvoice";
            this.Text = "SoapCreator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.eXmlCreator_FormClosing);
            this.Load += new System.EventHandler(this.eXmlCreator_Load);
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.pnBackGround.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.uPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl2;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Panel pnBackGround;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.RichTextBox tbTargetXml;
        private System.Windows.Forms.Splitter spTopLeft;
        private System.Windows.Forms.RichTextBox tbSourceXml;
        private System.Windows.Forms.Panel uPanelControl1;
        private System.Windows.Forms.Label uLabelControl1;
        private System.Windows.Forms.Label labelControl6;
        private System.Windows.Forms.Button sbFirstRefTarget;
        private System.Windows.Forms.OpenFileDialog xmlLoadDlg;
        private System.Windows.Forms.Button sbCheckSign;
		private System.Windows.Forms.TextBox tbTaxInvoiceSubmitUrl;
		private System.Windows.Forms.Label uLabelControl2;
        private System.Windows.Forms.ComboBox cbKind2;
        private System.Windows.Forms.ComboBox cbKind1;
        private System.Windows.Forms.Label lbKind2;
        private System.Windows.Forms.Label uLabelControl3;
        private System.Windows.Forms.CheckBox ceTestOk;
    }
}