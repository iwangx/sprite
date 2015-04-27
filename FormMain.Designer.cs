namespace CssBgImageMergeTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelImages = new System.Windows.Forms.Panel();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonMakeBigImageCss = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonHRange = new System.Windows.Forms.Button();
            this.buttonVRange = new System.Windows.Forms.Button();
            this.comboBoxImgType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBgColor = new System.Windows.Forms.ComboBox();
            this.txtSass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.radioBtnCss = new System.Windows.Forms.RadioButton();
            this.radioBtnSass = new System.Windows.Forms.RadioButton();
            this.txtCss = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.chkBoxPhone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panelImages
            // 
            this.panelImages.AutoScroll = true;
            this.panelImages.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelImages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelImages.Location = new System.Drawing.Point(14, 43);
            this.panelImages.Name = "panelImages";
            this.panelImages.Size = new System.Drawing.Size(816, 147);
            this.panelImages.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(14, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(220, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "选择多幅小背景图片...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonMakeBigImageCss
            // 
            this.buttonMakeBigImageCss.Location = new System.Drawing.Point(416, 501);
            this.buttonMakeBigImageCss.Name = "buttonMakeBigImageCss";
            this.buttonMakeBigImageCss.Size = new System.Drawing.Size(257, 23);
            this.buttonMakeBigImageCss.TabIndex = 9;
            this.buttonMakeBigImageCss.Text = "生成雪碧图";
            this.buttonMakeBigImageCss.UseVisualStyleBackColor = true;
            this.buttonMakeBigImageCss.Click += new System.EventHandler(this.ButtonMakeBigImageCss_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "所有文件|*.*|Gif文件|*.gif|Jpeg文件|*.jpeg|Jpg文件|*.jpg|Png文件|*.png";
            this.openFileDialog.Multiselect = true;
            // 
            // buttonHRange
            // 
            this.buttonHRange.Location = new System.Drawing.Point(587, 12);
            this.buttonHRange.Name = "buttonHRange";
            this.buttonHRange.Size = new System.Drawing.Size(75, 23);
            this.buttonHRange.TabIndex = 5;
            this.buttonHRange.Text = "小图横排";
            this.buttonHRange.UseVisualStyleBackColor = true;
            this.buttonHRange.Click += new System.EventHandler(this.buttonHRange_Click);
            // 
            // buttonVRange
            // 
            this.buttonVRange.Location = new System.Drawing.Point(479, 12);
            this.buttonVRange.Name = "buttonVRange";
            this.buttonVRange.Size = new System.Drawing.Size(75, 23);
            this.buttonVRange.TabIndex = 4;
            this.buttonVRange.Text = "小图纵排";
            this.buttonVRange.UseVisualStyleBackColor = true;
            this.buttonVRange.Click += new System.EventHandler(this.ButtonVRange_Click);
            // 
            // comboBoxImgType
            // 
            this.comboBoxImgType.FormattingEnabled = true;
            this.comboBoxImgType.Items.AddRange(new object[] {
            "Png",
            "Jpeg",
            "Gif"});
            this.comboBoxImgType.Location = new System.Drawing.Point(86, 503);
            this.comboBoxImgType.Name = "comboBoxImgType";
            this.comboBoxImgType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxImgType.TabIndex = 7;
            this.comboBoxImgType.Text = "Png";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "大图类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "背景色：";
            // 
            // comboBoxBgColor
            // 
            this.comboBoxBgColor.FormattingEnabled = true;
            this.comboBoxBgColor.Location = new System.Drawing.Point(289, 503);
            this.comboBoxBgColor.Name = "comboBoxBgColor";
            this.comboBoxBgColor.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBgColor.TabIndex = 8;
            this.comboBoxBgColor.Text = "Transparent";
            this.comboBoxBgColor.Leave += new System.EventHandler(this.comboBoxBgColor_Changed);
            // 
            // txtSass
            // 
            this.txtSass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSass.Location = new System.Drawing.Point(14, 347);
            this.txtSass.Multiline = true;
            this.txtSass.Name = "txtSass";
            this.txtSass.ReadOnly = true;
            this.txtSass.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSass.Size = new System.Drawing.Size(816, 148);
            this.txtSass.TabIndex = 11;
            this.txtSass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSass_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "css中文件夹路径：";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(121, 209);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(704, 21);
            this.txtDir.TabIndex = 14;
            this.txtDir.Text = "../images";
            this.txtDir.TextChanged += new System.EventHandler(this.txtDir_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "图片文件名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 245);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(725, 21);
            this.txtName.TabIndex = 16;
            this.txtName.Text = "img";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // radioBtnCss
            // 
            this.radioBtnCss.AutoSize = true;
            this.radioBtnCss.Location = new System.Drawing.Point(91, 315);
            this.radioBtnCss.Name = "radioBtnCss";
            this.radioBtnCss.Size = new System.Drawing.Size(65, 16);
            this.radioBtnCss.TabIndex = 17;
            this.radioBtnCss.Text = "css代码";
            this.radioBtnCss.UseVisualStyleBackColor = true;
            this.radioBtnCss.CheckedChanged += new System.EventHandler(this.radioBtnCss_CheckedChanged);
            // 
            // radioBtnSass
            // 
            this.radioBtnSass.AutoSize = true;
            this.radioBtnSass.Checked = true;
            this.radioBtnSass.Location = new System.Drawing.Point(14, 315);
            this.radioBtnSass.Name = "radioBtnSass";
            this.radioBtnSass.Size = new System.Drawing.Size(71, 16);
            this.radioBtnSass.TabIndex = 18;
            this.radioBtnSass.TabStop = true;
            this.radioBtnSass.Text = "sass代码";
            this.radioBtnSass.UseVisualStyleBackColor = true;
            this.radioBtnSass.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // txtCss
            // 
            this.txtCss.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCss.Location = new System.Drawing.Point(12, 347);
            this.txtCss.Multiline = true;
            this.txtCss.Name = "txtCss";
            this.txtCss.ReadOnly = true;
            this.txtCss.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCss.Size = new System.Drawing.Size(816, 148);
            this.txtCss.TabIndex = 19;
            this.txtCss.Visible = false;
            // 
            // chkBoxPhone
            // 
            this.chkBoxPhone.AutoSize = true;
            this.chkBoxPhone.Location = new System.Drawing.Point(14, 283);
            this.chkBoxPhone.Name = "chkBoxPhone";
            this.chkBoxPhone.Size = new System.Drawing.Size(96, 16);
            this.chkBoxPhone.TabIndex = 20;
            this.chkBoxPhone.Text = "是否是手机端";
            this.chkBoxPhone.UseVisualStyleBackColor = true;
            this.chkBoxPhone.CheckedChanged += new System.EventHandler(this.chkBoxPhone_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 545);
            this.Controls.Add(this.chkBoxPhone);
            this.Controls.Add(this.txtCss);
            this.Controls.Add(this.radioBtnSass);
            this.Controls.Add(this.radioBtnCss);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSass);
            this.Controls.Add(this.comboBoxBgColor);
            this.Controls.Add(this.comboBoxImgType);
            this.Controls.Add(this.buttonVRange);
            this.Controls.Add(this.buttonHRange);
            this.Controls.Add(this.buttonMakeBigImageCss);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.panelImages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Css背景图合并工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelImages;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonMakeBigImageCss;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonHRange;
        private System.Windows.Forms.Button buttonVRange;
        private System.Windows.Forms.ComboBox comboBoxImgType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBgColor;
        private System.Windows.Forms.TextBox txtSass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton radioBtnCss;
        private System.Windows.Forms.RadioButton radioBtnSass;
        private System.Windows.Forms.TextBox txtCss;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox chkBoxPhone;
    }
}

