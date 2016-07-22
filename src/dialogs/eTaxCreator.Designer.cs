namespace OpenETaxBill.Certifier
{
    partial class eTaxCreator
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
            this.cbKind2 = new OpenETaxBill.SDK.Control.DVX.uComboBoxEdit();
            this.cbKind1 = new OpenETaxBill.SDK.Control.DVX.uComboBoxEdit();
            this.lbKind2 = new DevExpress.XtraEditors.LabelControl();
            this.uLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbTransform = new DevExpress.XtraEditors.SimpleButton();
            this.tbCanonical = new DevExpress.XtraEditors.SimpleButton();
            this.tbInvoicerId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btClear = new DevExpress.XtraEditors.SimpleButton();
            this.btSave = new DevExpress.XtraEditors.SimpleButton();
            this.btLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btCreate = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.tbResult = new DevExpress.XtraEditors.MemoEdit();
            this.uPanelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.uSplitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tbSourceXml = new DevExpress.XtraEditors.MemoEdit();
            this.uPanelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xmlLoadDlg = new System.Windows.Forms.OpenFileDialog();
            this.xmlSaveDlg = new System.Windows.Forms.SaveFileDialog();
            this.xmlSchmaDlg = new System.Windows.Forms.SaveFileDialog();
            this.certLoadDlg = new System.Windows.Forms.OpenFileDialog();
            this.certSaveDlg = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInvoicerId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl2)).BeginInit();
            this.uPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSourceXml.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl1)).BeginInit();
            this.uPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cbKind2);
            this.panelControl2.Controls.Add(this.cbKind1);
            this.panelControl2.Controls.Add(this.lbKind2);
            this.panelControl2.Controls.Add(this.uLabelControl1);
            this.panelControl2.Controls.Add(this.sbTransform);
            this.panelControl2.Controls.Add(this.tbCanonical);
            this.panelControl2.Controls.Add(this.tbInvoicerId);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.btClear);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btLoad);
            this.panelControl2.Controls.Add(this.btCreate);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(934, 99);
            this.panelControl2.TabIndex = 1;
            // 
            // cbKind2
            // 
            this.cbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind2.DisplayMember = "name";
            this.cbKind2.EditValue = "일반";
            this.cbKind2.Location = new System.Drawing.Point(699, 20);
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
            this.cbKind2.TabIndex = 36;
            this.cbKind2.ValueMember = "code";
            // 
            // cbKind1
            // 
            this.cbKind1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind1.DisplayMember = "name";
            this.cbKind1.EditValue = "세금계산서";
            this.cbKind1.Location = new System.Drawing.Point(546, 20);
            this.cbKind1.Name = "cbKind1";
            this.cbKind1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKind1.Properties.Items.AddRange(new object[] {
            "세금계산서",
            "수정세금계산서",
            "계산서",
            "수정계산서"});
            this.cbKind1.Size = new System.Drawing.Size(117, 20);
            this.cbKind1.TabIndex = 35;
            this.cbKind1.ValueMember = "code";
            // 
            // lbKind2
            // 
            this.lbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbKind2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbKind2.Location = new System.Drawing.Point(669, 22);
            this.lbKind2.Name = "lbKind2";
            this.lbKind2.Size = new System.Drawing.Size(24, 17);
            this.lbKind2.TabIndex = 34;
            this.lbKind2.Text = "구분";
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.uLabelControl1.Location = new System.Drawing.Point(516, 22);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(24, 17);
            this.uLabelControl1.TabIndex = 33;
            this.uLabelControl1.Text = "종류";
            // 
            // sbTransform
            // 
            this.sbTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbTransform.Location = new System.Drawing.Point(843, 63);
            this.sbTransform.Name = "sbTransform";
            this.sbTransform.Size = new System.Drawing.Size(79, 30);
            this.sbTransform.TabIndex = 32;
            this.sbTransform.Text = "TRANSFORM";
            this.sbTransform.Click += new System.EventHandler(this.sbTransform_Click);
            // 
            // tbCanonical
            // 
            this.tbCanonical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCanonical.Location = new System.Drawing.Point(759, 63);
            this.tbCanonical.Name = "tbCanonical";
            this.tbCanonical.Size = new System.Drawing.Size(78, 30);
            this.tbCanonical.TabIndex = 30;
            this.tbCanonical.Text = "CANONICAL";
            this.tbCanonical.Click += new System.EventHandler(this.tbCanonical_Click);
            // 
            // tbInvoicerId
            // 
            this.tbInvoicerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInvoicerId.EditValue = "1388602200";
            this.tbInvoicerId.Location = new System.Drawing.Point(77, 20);
            this.tbInvoicerId.Name = "tbInvoicerId";
            this.tbInvoicerId.Size = new System.Drawing.Size(198, 20);
            this.tbInvoicerId.TabIndex = 26;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(11, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 17);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "사업자번호";
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(528, 63);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(70, 30);
            this.btClear.TabIndex = 24;
            this.btClear.Text = "CLEAR";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(682, 63);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(70, 30);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "SAVE";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(605, 63);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(70, 30);
            this.btLoad.TabIndex = 22;
            this.btLoad.Text = "LOAD";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btCreate
            // 
            this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btCreate.Appearance.Options.UseFont = true;
            this.btCreate.Location = new System.Drawing.Point(826, 12);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(96, 36);
            this.btCreate.TabIndex = 20;
            this.btCreate.Text = "CreateXml";
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.tbResult);
            this.panelControl3.Controls.Add(this.uPanelControl2);
            this.panelControl3.Controls.Add(this.uSplitterControl1);
            this.panelControl3.Controls.Add(this.tbSourceXml);
            this.panelControl3.Controls.Add(this.uPanelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 99);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(934, 562);
            this.panelControl3.TabIndex = 2;
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.EditValue = "";
            this.tbResult.Location = new System.Drawing.Point(2, 464);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(930, 96);
            this.tbResult.TabIndex = 1;
            // 
            // uPanelControl2
            // 
            this.uPanelControl2.Controls.Add(this.labelControl7);
            this.uPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl2.Location = new System.Drawing.Point(2, 440);
            this.uPanelControl2.Name = "uPanelControl2";
            this.uPanelControl2.Size = new System.Drawing.Size(930, 24);
            this.uPanelControl2.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl7.Location = new System.Drawing.Point(2, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(89, 14);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Validation Result";
            // 
            // uSplitterControl1
            // 
            this.uSplitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uSplitterControl1.Location = new System.Drawing.Point(2, 435);
            this.uSplitterControl1.Name = "uSplitterControl1";
            this.uSplitterControl1.Size = new System.Drawing.Size(930, 5);
            this.uSplitterControl1.TabIndex = 10;
            this.uSplitterControl1.TabStop = false;
            // 
            // tbSourceXml
            // 
            this.tbSourceXml.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSourceXml.EditValue = "";
            this.tbSourceXml.Location = new System.Drawing.Point(2, 21);
            this.tbSourceXml.Name = "tbSourceXml";
            this.tbSourceXml.Size = new System.Drawing.Size(930, 414);
            this.tbSourceXml.TabIndex = 8;
            // 
            // uPanelControl1
            // 
            this.uPanelControl1.Controls.Add(this.labelControl6);
            this.uPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uPanelControl1.Location = new System.Drawing.Point(2, 2);
            this.uPanelControl1.Name = "uPanelControl1";
            this.uPanelControl1.Size = new System.Drawing.Size(930, 19);
            this.uPanelControl1.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl6.Location = new System.Drawing.Point(2, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(94, 14);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Display XML Code";
            // 
            // xmlLoadDlg
            // 
            this.xmlLoadDlg.FileName = "*.xml";
            this.xmlLoadDlg.Filter = "All Files (*.xml)|*.xml";
            // 
            // xmlSaveDlg
            // 
            this.xmlSaveDlg.FileName = "2.xml";
            this.xmlSaveDlg.Filter = "All Files (*.xml)|*.xml";
            // 
            // xmlSchmaDlg
            // 
            this.xmlSchmaDlg.FileName = "taxSchema.xml";
            this.xmlSchmaDlg.Filter = "All Files (*.xml)|*.xml";
            // 
            // certLoadDlg
            // 
            this.certLoadDlg.FileName = "*.der";
            this.certLoadDlg.Filter = "All Files (*.der)|*.der";
            // 
            // certSaveDlg
            // 
            this.certSaveDlg.FileName = "cryption.key";
            this.certSaveDlg.Filter = "All Files (*.key)|*.key";
            // 
            // eTaxCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "eTaxCreator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "XmlCreator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlCreator_FormClosing);
            this.Load += new System.EventHandler(this.XmlCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKind1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbInvoicerId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl2)).EndInit();
            this.uPanelControl2.ResumeLayout(false);
            this.uPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSourceXml.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPanelControl1)).EndInit();
            this.uPanelControl1.ResumeLayout(false);
            this.uPanelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.MemoEdit tbResult;
        private DevExpress.XtraEditors.MemoEdit tbSourceXml;
        private DevExpress.XtraEditors.PanelControl uPanelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btCreate;
        private DevExpress.XtraEditors.SimpleButton btSave;
        private DevExpress.XtraEditors.SimpleButton btLoad;
        private System.Windows.Forms.OpenFileDialog xmlLoadDlg;
        private DevExpress.XtraEditors.SplitterControl uSplitterControl1;
        private DevExpress.XtraEditors.PanelControl uPanelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btClear;
        private DevExpress.XtraEditors.TextEdit tbInvoicerId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.SaveFileDialog xmlSaveDlg;
        private DevExpress.XtraEditors.SimpleButton tbCanonical;
        private System.Windows.Forms.SaveFileDialog xmlSchmaDlg;
        private DevExpress.XtraEditors.SimpleButton sbTransform;
        private System.Windows.Forms.OpenFileDialog certLoadDlg;
        private System.Windows.Forms.SaveFileDialog certSaveDlg;
        private DevExpress.XtraEditors.LabelControl lbKind2;
        private DevExpress.XtraEditors.LabelControl uLabelControl1;
        private OpenETaxBill.SDK.Control.DVX.uComboBoxEdit cbKind2;
        private OpenETaxBill.SDK.Control.DVX.uComboBoxEdit cbKind1;
    }
}