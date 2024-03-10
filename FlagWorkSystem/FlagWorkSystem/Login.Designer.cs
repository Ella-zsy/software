namespace FlagWorkSystem
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.tabPageStudent = new System.Windows.Forms.TabPage();
            this.TextBoxStudentPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.TextBoxStudentID = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.ButtonStudentLogin = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.TabControlLogin = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageTeacher = new System.Windows.Forms.TabPage();
            this.TextBoxTeacherPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.TextBoxTeacherID = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.ButtonTeacherLogin = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.TextBoxAdminPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.TextBoxAdminName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.ButtonAdminLogin = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageStudent.SuspendLayout();
            this.TabControlLogin.SuspendLayout();
            this.tabPageTeacher.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageStudent
            // 
            this.tabPageStudent.BackColor = System.Drawing.Color.White;
            this.tabPageStudent.Controls.Add(this.TextBoxStudentPassword);
            this.tabPageStudent.Controls.Add(this.TextBoxStudentID);
            this.tabPageStudent.Controls.Add(this.ButtonStudentLogin);
            this.tabPageStudent.Controls.Add(this.materialLabel3);
            this.tabPageStudent.Controls.Add(this.materialLabel4);
            this.tabPageStudent.Location = new System.Drawing.Point(4, 31);
            this.tabPageStudent.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStudent.Name = "tabPageStudent";
            this.tabPageStudent.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageStudent.Size = new System.Drawing.Size(904, 619);
            this.tabPageStudent.TabIndex = 1;
            this.tabPageStudent.Text = "学生登录";
            // 
            // TextBoxStudentPassword
            // 
            this.TextBoxStudentPassword.AnimateReadOnly = false;
            this.TextBoxStudentPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxStudentPassword.Depth = 0;
            this.TextBoxStudentPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxStudentPassword.LeadingIcon = null;
            this.TextBoxStudentPassword.Location = new System.Drawing.Point(249, 250);
            this.TextBoxStudentPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxStudentPassword.MaxLength = 50;
            this.TextBoxStudentPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxStudentPassword.Multiline = false;
            this.TextBoxStudentPassword.Name = "TextBoxStudentPassword";
            this.TextBoxStudentPassword.Password = true;
            this.TextBoxStudentPassword.Size = new System.Drawing.Size(407, 50);
            this.TextBoxStudentPassword.TabIndex = 21;
            this.TextBoxStudentPassword.Text = "";
            this.TextBoxStudentPassword.TrailingIcon = null;
            // 
            // TextBoxStudentID
            // 
            this.TextBoxStudentID.AllowPromptAsInput = true;
            this.TextBoxStudentID.AnimateReadOnly = false;
            this.TextBoxStudentID.AsciiOnly = false;
            this.TextBoxStudentID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBoxStudentID.BeepOnError = false;
            this.TextBoxStudentID.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxStudentID.Depth = 0;
            this.TextBoxStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxStudentID.HidePromptOnLeave = false;
            this.TextBoxStudentID.HideSelection = true;
            this.TextBoxStudentID.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.TextBoxStudentID.LeadingIcon = null;
            this.TextBoxStudentID.Location = new System.Drawing.Point(249, 127);
            this.TextBoxStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxStudentID.Mask = "";
            this.TextBoxStudentID.MaxLength = 32767;
            this.TextBoxStudentID.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxStudentID.Name = "TextBoxStudentID";
            this.TextBoxStudentID.PasswordChar = '\0';
            this.TextBoxStudentID.PrefixSuffixText = null;
            this.TextBoxStudentID.PromptChar = '_';
            this.TextBoxStudentID.ReadOnly = false;
            this.TextBoxStudentID.RejectInputOnFirstFailure = false;
            this.TextBoxStudentID.ResetOnPrompt = true;
            this.TextBoxStudentID.ResetOnSpace = true;
            this.TextBoxStudentID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxStudentID.SelectedText = "";
            this.TextBoxStudentID.SelectionLength = 0;
            this.TextBoxStudentID.SelectionStart = 0;
            this.TextBoxStudentID.ShortcutsEnabled = true;
            this.TextBoxStudentID.Size = new System.Drawing.Size(407, 48);
            this.TextBoxStudentID.SkipLiterals = true;
            this.TextBoxStudentID.TabIndex = 20;
            this.TextBoxStudentID.TabStop = false;
            this.TextBoxStudentID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxStudentID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxStudentID.TrailingIcon = null;
            this.TextBoxStudentID.UseSystemPasswordChar = false;
            this.TextBoxStudentID.ValidatingType = null;
            // 
            // ButtonStudentLogin
            // 
            this.ButtonStudentLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonStudentLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonStudentLogin.Depth = 0;
            this.ButtonStudentLogin.Font = new System.Drawing.Font("宋体", 15F);
            this.ButtonStudentLogin.HighEmphasis = true;
            this.ButtonStudentLogin.Icon = null;
            this.ButtonStudentLogin.Location = new System.Drawing.Point(333, 397);
            this.ButtonStudentLogin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ButtonStudentLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonStudentLogin.Name = "ButtonStudentLogin";
            this.ButtonStudentLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonStudentLogin.Size = new System.Drawing.Size(64, 36);
            this.ButtonStudentLogin.TabIndex = 19;
            this.ButtonStudentLogin.Text = "登录";
            this.ButtonStudentLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ButtonStudentLogin.UseAccentColor = false;
            this.ButtonStudentLogin.UseVisualStyleBackColor = true;
            this.ButtonStudentLogin.Click += new System.EventHandler(this.ButtonStudentLogin_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(115, 267);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(49, 19);
            this.materialLabel3.TabIndex = 18;
            this.materialLabel3.Text = "密码：";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(115, 156);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(65, 19);
            this.materialLabel4.TabIndex = 17;
            this.materialLabel4.Text = "学生名：";
            // 
            // TabControlLogin
            // 
            this.TabControlLogin.Controls.Add(this.tabPageStudent);
            this.TabControlLogin.Controls.Add(this.tabPageTeacher);
            this.TabControlLogin.Controls.Add(this.tabPageAdmin);
            this.TabControlLogin.Depth = 0;
            this.TabControlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlLogin.Location = new System.Drawing.Point(4, 90);
            this.TabControlLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TabControlLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlLogin.Multiline = true;
            this.TabControlLogin.Name = "TabControlLogin";
            this.TabControlLogin.SelectedIndex = 0;
            this.TabControlLogin.Size = new System.Drawing.Size(912, 654);
            this.TabControlLogin.TabIndex = 2;
            // 
            // tabPageTeacher
            // 
            this.tabPageTeacher.BackColor = System.Drawing.Color.White;
            this.tabPageTeacher.Controls.Add(this.TextBoxTeacherPassword);
            this.tabPageTeacher.Controls.Add(this.TextBoxTeacherID);
            this.tabPageTeacher.Controls.Add(this.ButtonTeacherLogin);
            this.tabPageTeacher.Controls.Add(this.materialLabel1);
            this.tabPageTeacher.Controls.Add(this.materialLabel2);
            this.tabPageTeacher.Location = new System.Drawing.Point(4, 31);
            this.tabPageTeacher.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTeacher.Name = "tabPageTeacher";
            this.tabPageTeacher.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTeacher.Size = new System.Drawing.Size(904, 619);
            this.tabPageTeacher.TabIndex = 2;
            this.tabPageTeacher.Text = "老师登录";
            // 
            // TextBoxTeacherPassword
            // 
            this.TextBoxTeacherPassword.AnimateReadOnly = false;
            this.TextBoxTeacherPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxTeacherPassword.Depth = 0;
            this.TextBoxTeacherPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxTeacherPassword.LeadingIcon = null;
            this.TextBoxTeacherPassword.Location = new System.Drawing.Point(249, 250);
            this.TextBoxTeacherPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxTeacherPassword.MaxLength = 50;
            this.TextBoxTeacherPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxTeacherPassword.Multiline = false;
            this.TextBoxTeacherPassword.Name = "TextBoxTeacherPassword";
            this.TextBoxTeacherPassword.Password = true;
            this.TextBoxTeacherPassword.Size = new System.Drawing.Size(407, 50);
            this.TextBoxTeacherPassword.TabIndex = 22;
            this.TextBoxTeacherPassword.Text = "";
            this.TextBoxTeacherPassword.TrailingIcon = null;
            // 
            // TextBoxTeacherID
            // 
            this.TextBoxTeacherID.AllowPromptAsInput = true;
            this.TextBoxTeacherID.AnimateReadOnly = false;
            this.TextBoxTeacherID.AsciiOnly = false;
            this.TextBoxTeacherID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBoxTeacherID.BeepOnError = false;
            this.TextBoxTeacherID.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxTeacherID.Depth = 0;
            this.TextBoxTeacherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxTeacherID.HidePromptOnLeave = false;
            this.TextBoxTeacherID.HideSelection = true;
            this.TextBoxTeacherID.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.TextBoxTeacherID.LeadingIcon = null;
            this.TextBoxTeacherID.Location = new System.Drawing.Point(249, 127);
            this.TextBoxTeacherID.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxTeacherID.Mask = "";
            this.TextBoxTeacherID.MaxLength = 32767;
            this.TextBoxTeacherID.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxTeacherID.Name = "TextBoxTeacherID";
            this.TextBoxTeacherID.PasswordChar = '\0';
            this.TextBoxTeacherID.PrefixSuffixText = null;
            this.TextBoxTeacherID.PromptChar = '_';
            this.TextBoxTeacherID.ReadOnly = false;
            this.TextBoxTeacherID.RejectInputOnFirstFailure = false;
            this.TextBoxTeacherID.ResetOnPrompt = true;
            this.TextBoxTeacherID.ResetOnSpace = true;
            this.TextBoxTeacherID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxTeacherID.SelectedText = "";
            this.TextBoxTeacherID.SelectionLength = 0;
            this.TextBoxTeacherID.SelectionStart = 0;
            this.TextBoxTeacherID.ShortcutsEnabled = true;
            this.TextBoxTeacherID.Size = new System.Drawing.Size(407, 48);
            this.TextBoxTeacherID.SkipLiterals = true;
            this.TextBoxTeacherID.TabIndex = 20;
            this.TextBoxTeacherID.TabStop = false;
            this.TextBoxTeacherID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxTeacherID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxTeacherID.TrailingIcon = null;
            this.TextBoxTeacherID.UseSystemPasswordChar = false;
            this.TextBoxTeacherID.ValidatingType = null;
            // 
            // ButtonTeacherLogin
            // 
            this.ButtonTeacherLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonTeacherLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonTeacherLogin.Depth = 0;
            this.ButtonTeacherLogin.Font = new System.Drawing.Font("宋体", 15F);
            this.ButtonTeacherLogin.HighEmphasis = true;
            this.ButtonTeacherLogin.Icon = null;
            this.ButtonTeacherLogin.Location = new System.Drawing.Point(333, 397);
            this.ButtonTeacherLogin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ButtonTeacherLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonTeacherLogin.Name = "ButtonTeacherLogin";
            this.ButtonTeacherLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonTeacherLogin.Size = new System.Drawing.Size(64, 36);
            this.ButtonTeacherLogin.TabIndex = 19;
            this.ButtonTeacherLogin.Text = "登录";
            this.ButtonTeacherLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ButtonTeacherLogin.UseAccentColor = false;
            this.ButtonTeacherLogin.UseVisualStyleBackColor = true;
            this.ButtonTeacherLogin.Click += new System.EventHandler(this.ButtonTeacherLogin_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(115, 267);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 19);
            this.materialLabel1.TabIndex = 18;
            this.materialLabel1.Text = "密码：";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(115, 156);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(65, 19);
            this.materialLabel2.TabIndex = 17;
            this.materialLabel2.Text = "老师名：";
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.BackColor = System.Drawing.Color.White;
            this.tabPageAdmin.Controls.Add(this.TextBoxAdminPassword);
            this.tabPageAdmin.Controls.Add(this.TextBoxAdminName);
            this.tabPageAdmin.Controls.Add(this.ButtonAdminLogin);
            this.tabPageAdmin.Controls.Add(this.materialLabel5);
            this.tabPageAdmin.Controls.Add(this.materialLabel6);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 31);
            this.tabPageAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAdmin.Size = new System.Drawing.Size(904, 619);
            this.tabPageAdmin.TabIndex = 3;
            this.tabPageAdmin.Text = "后台登录";
            // 
            // TextBoxAdminPassword
            // 
            this.TextBoxAdminPassword.AnimateReadOnly = false;
            this.TextBoxAdminPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxAdminPassword.Depth = 0;
            this.TextBoxAdminPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxAdminPassword.LeadingIcon = null;
            this.TextBoxAdminPassword.Location = new System.Drawing.Point(249, 250);
            this.TextBoxAdminPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxAdminPassword.MaxLength = 50;
            this.TextBoxAdminPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxAdminPassword.Multiline = false;
            this.TextBoxAdminPassword.Name = "TextBoxAdminPassword";
            this.TextBoxAdminPassword.Password = true;
            this.TextBoxAdminPassword.Size = new System.Drawing.Size(407, 50);
            this.TextBoxAdminPassword.TabIndex = 22;
            this.TextBoxAdminPassword.Text = "";
            this.TextBoxAdminPassword.TrailingIcon = null;
            // 
            // TextBoxAdminName
            // 
            this.TextBoxAdminName.AllowPromptAsInput = true;
            this.TextBoxAdminName.AnimateReadOnly = false;
            this.TextBoxAdminName.AsciiOnly = false;
            this.TextBoxAdminName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TextBoxAdminName.BeepOnError = false;
            this.TextBoxAdminName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxAdminName.Depth = 0;
            this.TextBoxAdminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxAdminName.HidePromptOnLeave = false;
            this.TextBoxAdminName.HideSelection = true;
            this.TextBoxAdminName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.TextBoxAdminName.LeadingIcon = null;
            this.TextBoxAdminName.Location = new System.Drawing.Point(249, 127);
            this.TextBoxAdminName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxAdminName.Mask = "";
            this.TextBoxAdminName.MaxLength = 32767;
            this.TextBoxAdminName.MouseState = MaterialSkin.MouseState.OUT;
            this.TextBoxAdminName.Name = "TextBoxAdminName";
            this.TextBoxAdminName.PasswordChar = '\0';
            this.TextBoxAdminName.PrefixSuffixText = null;
            this.TextBoxAdminName.PromptChar = '_';
            this.TextBoxAdminName.ReadOnly = false;
            this.TextBoxAdminName.RejectInputOnFirstFailure = false;
            this.TextBoxAdminName.ResetOnPrompt = true;
            this.TextBoxAdminName.ResetOnSpace = true;
            this.TextBoxAdminName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBoxAdminName.SelectedText = "";
            this.TextBoxAdminName.SelectionLength = 0;
            this.TextBoxAdminName.SelectionStart = 0;
            this.TextBoxAdminName.ShortcutsEnabled = true;
            this.TextBoxAdminName.Size = new System.Drawing.Size(407, 48);
            this.TextBoxAdminName.SkipLiterals = true;
            this.TextBoxAdminName.TabIndex = 20;
            this.TextBoxAdminName.TabStop = false;
            this.TextBoxAdminName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxAdminName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.TextBoxAdminName.TrailingIcon = null;
            this.TextBoxAdminName.UseSystemPasswordChar = false;
            this.TextBoxAdminName.ValidatingType = null;
            // 
            // ButtonAdminLogin
            // 
            this.ButtonAdminLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonAdminLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonAdminLogin.Depth = 0;
            this.ButtonAdminLogin.Font = new System.Drawing.Font("宋体", 15F);
            this.ButtonAdminLogin.HighEmphasis = true;
            this.ButtonAdminLogin.Icon = null;
            this.ButtonAdminLogin.Location = new System.Drawing.Point(333, 397);
            this.ButtonAdminLogin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ButtonAdminLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonAdminLogin.Name = "ButtonAdminLogin";
            this.ButtonAdminLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonAdminLogin.Size = new System.Drawing.Size(64, 36);
            this.ButtonAdminLogin.TabIndex = 19;
            this.ButtonAdminLogin.Text = "登录";
            this.ButtonAdminLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.ButtonAdminLogin.UseAccentColor = false;
            this.ButtonAdminLogin.UseVisualStyleBackColor = true;
            this.ButtonAdminLogin.Click += new System.EventHandler(this.ButtonAdminLogin_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(115, 267);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(49, 19);
            this.materialLabel5.TabIndex = 18;
            this.materialLabel5.Text = "密码：";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(115, 156);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(65, 19);
            this.materialLabel6.TabIndex = 17;
            this.materialLabel6.Text = "管理员：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 748);
            this.Controls.Add(this.TabControlLogin);
            this.DrawerAutoShow = true;
            this.DrawerBackgroundWithAccent = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControlLogin;
            this.DrawerUseColors = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(4, 90, 4, 4);
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.tabPageStudent.ResumeLayout(false);
            this.tabPageStudent.PerformLayout();
            this.TabControlLogin.ResumeLayout(false);
            this.tabPageTeacher.ResumeLayout(false);
            this.tabPageTeacher.PerformLayout();
            this.tabPageAdmin.ResumeLayout(false);
            this.tabPageAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageStudent;
        private MaterialSkin.Controls.MaterialMaskedTextBox TextBoxStudentID;
        private MaterialSkin.Controls.MaterialButton ButtonStudentLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTabControl TabControlLogin;
        private System.Windows.Forms.TabPage tabPageTeacher;
        private MaterialSkin.Controls.MaterialMaskedTextBox TextBoxTeacherID;
        private MaterialSkin.Controls.MaterialButton ButtonTeacherLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private MaterialSkin.Controls.MaterialMaskedTextBox TextBoxAdminName;
        private MaterialSkin.Controls.MaterialButton ButtonAdminLogin;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox TextBoxStudentPassword;
        private MaterialSkin.Controls.MaterialTextBox TextBoxTeacherPassword;
        private MaterialSkin.Controls.MaterialTextBox TextBoxAdminPassword;
    }
}