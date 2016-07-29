namespace OpenETaxBill.Certifier
{
    partial class eTaxEncrypt
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
            this.cbKind2 = new System.Windows.Forms.ComboBox();
            this.cbKind1 = new System.Windows.Forms.ComboBox();
            this.lbKind2 = new System.Windows.Forms.Label();
            this.uLabelControl2 = new System.Windows.Forms.Label();
            this.sbEncrypt = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
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
            this.xmlSaveDlg = new System.Windows.Forms.SaveFileDialog();
            this.xmlLoadDlg = new System.Windows.Forms.OpenFileDialog();
            this.panelControl2.SuspendLayout();
            this.pnBackGround.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.uPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cbKind2);
            this.panelControl2.Controls.Add(this.cbKind1);
            this.panelControl2.Controls.Add(this.lbKind2);
            this.panelControl2.Controls.Add(this.uLabelControl2);
            this.panelControl2.Controls.Add(this.sbEncrypt);
            this.panelControl2.Controls.Add(this.btClear);
            this.panelControl2.Controls.Add(this.btSave);
            this.panelControl2.Controls.Add(this.btLoad);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1062, 107);
            this.panelControl2.TabIndex = 3;
            // 
            // cbKind2
            // 
            this.cbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKind2.DisplayMember = "name";
            this.cbKind2.Items.AddRange(new object[] {
            "일반",
            "영세율",
            "위수탁",
            "수입",
            "영세율위수탁",
            "수입납부유예"});
            this.cbKind2.Location = new System.Drawing.Point(804, 19);
            this.cbKind2.Name = "cbKind2";
            this.cbKind2.Size = new System.Drawing.Size(138, 23);
            this.cbKind2.TabIndex = 40;
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
            this.cbKind1.Location = new System.Drawing.Point(611, 19);
            this.cbKind1.Name = "cbKind1";
            this.cbKind1.Size = new System.Drawing.Size(133, 23);
            this.cbKind1.TabIndex = 39;
            this.cbKind1.Text = "세금계산서";
            this.cbKind1.ValueMember = "code";
            // 
            // lbKind2
            // 
            this.lbKind2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbKind2.Location = new System.Drawing.Point(761, 21);
            this.lbKind2.Name = "lbKind2";
            this.lbKind2.Size = new System.Drawing.Size(37, 18);
            this.lbKind2.TabIndex = 38;
            this.lbKind2.Text = "구분";
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl2.Location = new System.Drawing.Point(558, 21);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(47, 18);
            this.uLabelControl2.TabIndex = 37;
            this.uLabelControl2.Text = "종류";
            // 
            // sbEncrypt
            // 
            this.sbEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbEncrypt.Location = new System.Drawing.Point(960, 3);
            this.sbEncrypt.Name = "sbEncrypt";
            this.sbEncrypt.Size = new System.Drawing.Size(90, 58);
            this.sbEncrypt.TabIndex = 25;
            this.sbEncrypt.Text = "Encrypt";
            this.sbEncrypt.Click += new System.EventHandler(this.sbEncrypt_Click);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(794, 68);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(80, 32);
            this.btClear.TabIndex = 24;
            this.btClear.Text = "CLEAR";
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(970, 68);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(80, 32);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "SAVE";
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(882, 68);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(80, 32);
            this.btLoad.TabIndex = 22;
            this.btLoad.Text = "LOAD";
            // 
            // pnBackGround
            // 
            this.pnBackGround.Controls.Add(this.pnTop);
            this.pnBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackGround.Location = new System.Drawing.Point(0, 107);
            this.pnBackGround.Name = "pnBackGround";
            this.pnBackGround.Size = new System.Drawing.Size(1062, 454);
            this.pnBackGround.TabIndex = 4;
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
            this.pnTop.Size = new System.Drawing.Size(1062, 454);
            this.pnTop.TabIndex = 12;
            // 
            // tbTargetXml
            // 
            this.tbTargetXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetXml.Location = new System.Drawing.Point(513, 20);
            this.tbTargetXml.Name = "tbTargetXml";
            this.tbTargetXml.Size = new System.Drawing.Size(549, 434);
            this.tbTargetXml.TabIndex = 14;
            this.tbTargetXml.Text = "";
            // 
            // spTopLeft
            // 
            this.spTopLeft.Location = new System.Drawing.Point(507, 20);
            this.spTopLeft.Name = "spTopLeft";
            this.spTopLeft.Size = new System.Drawing.Size(6, 434);
            this.spTopLeft.TabIndex = 13;
            this.spTopLeft.TabStop = false;
            // 
            // tbSourceXml
            // 
            this.tbSourceXml.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSourceXml.Location = new System.Drawing.Point(0, 20);
            this.tbSourceXml.Name = "tbSourceXml";
            this.tbSourceXml.Size = new System.Drawing.Size(507, 434);
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
            this.uPanelControl1.Size = new System.Drawing.Size(1062, 20);
            this.uPanelControl1.TabIndex = 11;
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uLabelControl1.Location = new System.Drawing.Point(988, 0);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(74, 20);
            this.uLabelControl1.TabIndex = 4;
            this.uLabelControl1.Text = "Sample XML";
            // 
            // labelControl6
            // 
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl6.Location = new System.Drawing.Point(0, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 20);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Source XML";
            // 
            // xmlSaveDlg
            // 
            this.xmlSaveDlg.FileName = "2.xml";
            this.xmlSaveDlg.Filter = "All Files (*.xml)|*.xml";
            // 
            // xmlLoadDlg
            // 
            this.xmlLoadDlg.Filter = "All Files (*.*)|*.*";
            // 
            // eTaxEncrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 561);
            this.Controls.Add(this.pnBackGround);
            this.Controls.Add(this.panelControl2);
            this.Name = "eTaxEncrypt";
            this.Text = "Envelope";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Envelope_FormClosing);
            this.Load += new System.EventHandler(this.Envelope_Load);
            this.panelControl2.ResumeLayout(false);
            this.pnBackGround.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.uPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl2;
        private System.Windows.Forms.Button sbEncrypt;
        private System.Windows.Forms.Button btClear;
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
        private System.Windows.Forms.SaveFileDialog xmlSaveDlg;
        private System.Windows.Forms.OpenFileDialog xmlLoadDlg;
        private System.Windows.Forms.ComboBox cbKind2;
        private System.Windows.Forms.ComboBox cbKind1;
        private System.Windows.Forms.Label lbKind2;
        private System.Windows.Forms.Label uLabelControl2;
    }
}