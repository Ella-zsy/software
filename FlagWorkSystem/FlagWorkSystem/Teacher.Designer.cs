using System.Windows.Forms;

namespace FlagWorkSystem
{
    partial class Teacher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher));
            this.tabPagePerDetail = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchID = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPageWorkSchedule = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.AddDropFlag = new MaterialSkin.Controls.MaterialButton();
            this.StudentName = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.FlagDateTime = new System.Windows.Forms.DateTimePicker();
            this.DropStLb = new MaterialSkin.Controls.MaterialLabel();
            this.TotStLb = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PictureBt = new MaterialSkin.Controls.MaterialButton();
            this.CommentBt = new MaterialSkin.Controls.MaterialButton();
            this.CommentTb = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.CancleFlagBt = new MaterialSkin.Controls.MaterialButton();
            this.tabPageTrainSchedule = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelTrainOrNot = new System.Windows.Forms.Label();
            this.CancelTrainButton = new MaterialSkin.Controls.MaterialButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DropPersonsTextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.DropButton = new MaterialSkin.Controls.MaterialButton();
            this.trainDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.queryDropListButton = new MaterialSkin.Controls.MaterialButton();
            this.queryComeListButton = new MaterialSkin.Controls.MaterialButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ComePercentLabel = new MaterialSkin.Controls.MaterialLabel();
            this.DropNumLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ComeNumLabel = new MaterialSkin.Controls.MaterialLabel();
            this.TrainPerlistView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PercentLabel = new MaterialSkin.Controls.MaterialLabel();
            this.DropLabel = new MaterialSkin.Controls.MaterialLabel();
            this.ComeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.TabControlTeacher = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageRequests = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonExport = new MaterialSkin.Controls.MaterialButton();
            this.DoneFlagBt = new MaterialSkin.Controls.MaterialButton();
            this.TotFlagBt = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.GenerateBt = new MaterialSkin.Controls.MaterialButton();
            this.labelDate = new System.Windows.Forms.Label();
            this.TotTimeLine = new HZH_Controls.Controls.UCTimeLine();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.tabPagePerDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageWorkSchedule.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageTrainSchedule.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.TabControlTeacher.SuspendLayout();
            this.tabPageRequests.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagePerDetail
            // 
            this.tabPagePerDetail.AutoScroll = true;
            this.tabPagePerDetail.Controls.Add(this.listView2);
            this.tabPagePerDetail.Controls.Add(this.panel2);
            this.tabPagePerDetail.Location = new System.Drawing.Point(4, 28);
            this.tabPagePerDetail.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPagePerDetail.Name = "tabPagePerDetail";
            this.tabPagePerDetail.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPagePerDetail.Size = new System.Drawing.Size(1062, 611);
            this.tabPagePerDetail.TabIndex = 7;
            this.tabPagePerDetail.Text = "队员训练详情";
            this.tabPagePerDetail.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 132);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1056, 478);
            this.listView2.StateImageList = this.imageList1;
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "学生ID";
            this.columnHeader7.Width = 158;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "学生姓名";
            this.columnHeader8.Width = 116;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "unread");
            this.imageList1.Images.SetKeyName(1, "read");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.searchID);
            this.panel2.Controls.Add(this.materialButton4);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 131);
            this.panel2.TabIndex = 0;
            // 
            // searchID
            // 
            this.searchID.AllowPromptAsInput = true;
            this.searchID.AnimateReadOnly = false;
            this.searchID.AsciiOnly = false;
            this.searchID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.searchID.BeepOnError = false;
            this.searchID.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.searchID.Depth = 0;
            this.searchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.searchID.HidePromptOnLeave = false;
            this.searchID.HideSelection = true;
            this.searchID.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.searchID.LeadingIcon = null;
            this.searchID.Location = new System.Drawing.Point(228, 31);
            this.searchID.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.searchID.Mask = "";
            this.searchID.MaxLength = 32767;
            this.searchID.MouseState = MaterialSkin.MouseState.OUT;
            this.searchID.Name = "searchID";
            this.searchID.PasswordChar = '\0';
            this.searchID.PrefixSuffixText = null;
            this.searchID.PromptChar = '_';
            this.searchID.ReadOnly = false;
            this.searchID.RejectInputOnFirstFailure = false;
            this.searchID.ResetOnPrompt = true;
            this.searchID.ResetOnSpace = true;
            this.searchID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchID.SelectedText = "";
            this.searchID.SelectionLength = 0;
            this.searchID.SelectionStart = 0;
            this.searchID.ShortcutsEnabled = true;
            this.searchID.Size = new System.Drawing.Size(351, 48);
            this.searchID.SkipLiterals = true;
            this.searchID.TabIndex = 32;
            this.searchID.TabStop = false;
            this.searchID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchID.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.searchID.TrailingIcon = null;
            this.searchID.UseSystemPasswordChar = false;
            this.searchID.ValidatingType = null;
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(770, 42);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(64, 36);
            this.materialButton4.TabIndex = 30;
            this.materialButton4.Text = "查询";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(73, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "学生ID：";
            // 
            // tabPageWorkSchedule
            // 
            this.tabPageWorkSchedule.BackColor = System.Drawing.Color.White;
            this.tabPageWorkSchedule.Controls.Add(this.panel8);
            this.tabPageWorkSchedule.Controls.Add(this.panel3);
            this.tabPageWorkSchedule.Controls.Add(this.panel1);
            this.tabPageWorkSchedule.Location = new System.Drawing.Point(4, 28);
            this.tabPageWorkSchedule.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPageWorkSchedule.Name = "tabPageWorkSchedule";
            this.tabPageWorkSchedule.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPageWorkSchedule.Size = new System.Drawing.Size(1061, 611);
            this.tabPageWorkSchedule.TabIndex = 6;
            this.tabPageWorkSchedule.Text = "排班表";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.AddDropFlag);
            this.panel8.Controls.Add(this.StudentName);
            this.panel8.Controls.Add(this.FlagDateTime);
            this.panel8.Controls.Add(this.DropStLb);
            this.panel8.Controls.Add(this.TotStLb);
            this.panel8.Location = new System.Drawing.Point(369, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(675, 288);
            this.panel8.TabIndex = 11;
            // 
            // AddDropFlag
            // 
            this.AddDropFlag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddDropFlag.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddDropFlag.Depth = 0;
            this.AddDropFlag.HighEmphasis = true;
            this.AddDropFlag.Icon = null;
            this.AddDropFlag.Location = new System.Drawing.Point(423, 112);
            this.AddDropFlag.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.AddDropFlag.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddDropFlag.Name = "AddDropFlag";
            this.AddDropFlag.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddDropFlag.Size = new System.Drawing.Size(64, 36);
            this.AddDropFlag.TabIndex = 23;
            this.AddDropFlag.Text = "未到";
            this.AddDropFlag.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddDropFlag.UseAccentColor = true;
            this.AddDropFlag.UseVisualStyleBackColor = true;
            this.AddDropFlag.Click += new System.EventHandler(this.AddDropFlag_Click);
            // 
            // StudentName
            // 
            this.StudentName.AllowPromptAsInput = true;
            this.StudentName.AnimateReadOnly = false;
            this.StudentName.AsciiOnly = false;
            this.StudentName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StudentName.BeepOnError = false;
            this.StudentName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.StudentName.Depth = 0;
            this.StudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.StudentName.HidePromptOnLeave = false;
            this.StudentName.HideSelection = true;
            this.StudentName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.StudentName.LeadingIcon = null;
            this.StudentName.Location = new System.Drawing.Point(9, 96);
            this.StudentName.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.StudentName.Mask = "";
            this.StudentName.MaxLength = 32767;
            this.StudentName.MouseState = MaterialSkin.MouseState.OUT;
            this.StudentName.Name = "StudentName";
            this.StudentName.PasswordChar = '\0';
            this.StudentName.PrefixSuffixText = null;
            this.StudentName.PromptChar = '_';
            this.StudentName.ReadOnly = false;
            this.StudentName.RejectInputOnFirstFailure = false;
            this.StudentName.ResetOnPrompt = true;
            this.StudentName.ResetOnSpace = true;
            this.StudentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StudentName.SelectedText = "";
            this.StudentName.SelectionLength = 0;
            this.StudentName.SelectionStart = 0;
            this.StudentName.ShortcutsEnabled = true;
            this.StudentName.Size = new System.Drawing.Size(351, 48);
            this.StudentName.SkipLiterals = true;
            this.StudentName.TabIndex = 22;
            this.StudentName.TabStop = false;
            this.StudentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.StudentName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.StudentName.TrailingIcon = null;
            this.StudentName.UseSystemPasswordChar = false;
            this.StudentName.ValidatingType = null;
            // 
            // FlagDateTime
            // 
            this.FlagDateTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlagDateTime.Location = new System.Drawing.Point(9, 35);
            this.FlagDateTime.Margin = new System.Windows.Forms.Padding(1);
            this.FlagDateTime.Name = "FlagDateTime";
            this.FlagDateTime.Size = new System.Drawing.Size(508, 39);
            this.FlagDateTime.TabIndex = 4;
            this.FlagDateTime.CloseUp += new System.EventHandler(this.FlagDateTime_CloseUp);
            // 
            // DropStLb
            // 
            this.DropStLb.AutoSize = true;
            this.DropStLb.Depth = 0;
            this.DropStLb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DropStLb.Location = new System.Drawing.Point(4, 247);
            this.DropStLb.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.DropStLb.MouseState = MaterialSkin.MouseState.HOVER;
            this.DropStLb.Name = "DropStLb";
            this.DropStLb.Size = new System.Drawing.Size(105, 19);
            this.DropStLb.TabIndex = 3;
            this.DropStLb.Text = "未到场名单：  ";
            // 
            // TotStLb
            // 
            this.TotStLb.AutoSize = true;
            this.TotStLb.Depth = 0;
            this.TotStLb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TotStLb.Location = new System.Drawing.Point(4, 196);
            this.TotStLb.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.TotStLb.MouseState = MaterialSkin.MouseState.HOVER;
            this.TotStLb.Name = "TotStLb";
            this.TotStLb.Size = new System.Drawing.Size(89, 19);
            this.TotStLb.TabIndex = 2;
            this.TotStLb.Text = "升旗名单：  ";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.PictureBt);
            this.panel3.Controls.Add(this.CommentBt);
            this.panel3.Controls.Add(this.CommentTb);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Font = new System.Drawing.Font("宋体", 8.25F);
            this.panel3.Location = new System.Drawing.Point(0, 268);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1047, 352);
            this.panel3.TabIndex = 10;
            // 
            // PictureBt
            // 
            this.PictureBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PictureBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.PictureBt.Depth = 0;
            this.PictureBt.HighEmphasis = true;
            this.PictureBt.Icon = null;
            this.PictureBt.Location = new System.Drawing.Point(118, 265);
            this.PictureBt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.PictureBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.PictureBt.Name = "PictureBt";
            this.PictureBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.PictureBt.Size = new System.Drawing.Size(85, 36);
            this.PictureBt.TabIndex = 7;
            this.PictureBt.Text = "添加图片";
            this.PictureBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.PictureBt.UseAccentColor = true;
            this.PictureBt.UseVisualStyleBackColor = true;
            this.PictureBt.Click += new System.EventHandler(this.PictureBt_Click);
            // 
            // CommentBt
            // 
            this.CommentBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CommentBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CommentBt.Depth = 0;
            this.CommentBt.HighEmphasis = true;
            this.CommentBt.Icon = null;
            this.CommentBt.Location = new System.Drawing.Point(561, 264);
            this.CommentBt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.CommentBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.CommentBt.Name = "CommentBt";
            this.CommentBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CommentBt.Size = new System.Drawing.Size(85, 36);
            this.CommentBt.TabIndex = 6;
            this.CommentBt.Text = "提交评论";
            this.CommentBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CommentBt.UseAccentColor = true;
            this.CommentBt.UseVisualStyleBackColor = true;
            this.CommentBt.Click += new System.EventHandler(this.CommentBt_Click);
            // 
            // CommentTb
            // 
            this.CommentTb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CommentTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentTb.Depth = 0;
            this.CommentTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CommentTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CommentTb.Location = new System.Drawing.Point(378, 40);
            this.CommentTb.Margin = new System.Windows.Forms.Padding(1);
            this.CommentTb.MouseState = MaterialSkin.MouseState.HOVER;
            this.CommentTb.Name = "CommentTb";
            this.CommentTb.Size = new System.Drawing.Size(508, 196);
            this.CommentTb.TabIndex = 5;
            this.CommentTb.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(105, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 198);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.CancleFlagBt);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 270);
            this.panel1.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("华文新魏", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(60, 71);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(260, 48);
            this.label19.TabIndex = 2;
            this.label19.Text = "今日有升旗";
            // 
            // CancleFlagBt
            // 
            this.CancleFlagBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancleFlagBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CancleFlagBt.Depth = 0;
            this.CancleFlagBt.HighEmphasis = true;
            this.CancleFlagBt.Icon = null;
            this.CancleFlagBt.Location = new System.Drawing.Point(118, 175);
            this.CancleFlagBt.Margin = new System.Windows.Forms.Padding(6, 11, 6, 11);
            this.CancleFlagBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancleFlagBt.Name = "CancleFlagBt";
            this.CancleFlagBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CancleFlagBt.Size = new System.Drawing.Size(85, 36);
            this.CancleFlagBt.TabIndex = 0;
            this.CancleFlagBt.Text = "取消升旗";
            this.CancleFlagBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CancleFlagBt.UseAccentColor = true;
            this.CancleFlagBt.UseVisualStyleBackColor = true;
            this.CancleFlagBt.Click += new System.EventHandler(this.CancleFlagBt_Click);
            // 
            // tabPageTrainSchedule
            // 
            this.tabPageTrainSchedule.BackColor = System.Drawing.Color.White;
            this.tabPageTrainSchedule.Controls.Add(this.panel5);
            this.tabPageTrainSchedule.Controls.Add(this.panel6);
            this.tabPageTrainSchedule.Controls.Add(this.panel7);
            this.tabPageTrainSchedule.Location = new System.Drawing.Point(4, 28);
            this.tabPageTrainSchedule.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.tabPageTrainSchedule.Name = "tabPageTrainSchedule";
            this.tabPageTrainSchedule.Padding = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.tabPageTrainSchedule.Size = new System.Drawing.Size(1062, 611);
            this.tabPageTrainSchedule.TabIndex = 5;
            this.tabPageTrainSchedule.Text = "训练表";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelTrainOrNot);
            this.panel5.Controls.Add(this.CancelTrainButton);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(370, 270);
            this.panel5.TabIndex = 6;
            // 
            // labelTrainOrNot
            // 
            this.labelTrainOrNot.AutoSize = true;
            this.labelTrainOrNot.Font = new System.Drawing.Font("华文新魏", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTrainOrNot.Location = new System.Drawing.Point(58, 72);
            this.labelTrainOrNot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTrainOrNot.Name = "labelTrainOrNot";
            this.labelTrainOrNot.Size = new System.Drawing.Size(260, 48);
            this.labelTrainOrNot.TabIndex = 1;
            this.labelTrainOrNot.Text = "今日有训练";
            // 
            // CancelTrainButton
            // 
            this.CancelTrainButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelTrainButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.CancelTrainButton.Depth = 0;
            this.CancelTrainButton.HighEmphasis = true;
            this.CancelTrainButton.Icon = null;
            this.CancelTrainButton.Location = new System.Drawing.Point(118, 169);
            this.CancelTrainButton.Margin = new System.Windows.Forms.Padding(6, 11, 6, 11);
            this.CancelTrainButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelTrainButton.Name = "CancelTrainButton";
            this.CancelTrainButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.CancelTrainButton.Size = new System.Drawing.Size(85, 36);
            this.CancelTrainButton.TabIndex = 0;
            this.CancelTrainButton.Text = "取消训练";
            this.CancelTrainButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.CancelTrainButton.UseAccentColor = true;
            this.CancelTrainButton.UseVisualStyleBackColor = true;
            this.CancelTrainButton.Click += new System.EventHandler(this.CancelTrainButton_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.DropPersonsTextBox);
            this.panel6.Controls.Add(this.DropButton);
            this.panel6.Controls.Add(this.trainDateTimePicker);
            this.panel6.Controls.Add(this.queryDropListButton);
            this.panel6.Controls.Add(this.queryComeListButton);
            this.panel6.Location = new System.Drawing.Point(370, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(677, 270);
            this.panel6.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(287, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "请以空格分隔！";
            // 
            // DropPersonsTextBox
            // 
            this.DropPersonsTextBox.AnimateReadOnly = false;
            this.DropPersonsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DropPersonsTextBox.Depth = 0;
            this.DropPersonsTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DropPersonsTextBox.LeadingIcon = null;
            this.DropPersonsTextBox.Location = new System.Drawing.Point(8, 104);
            this.DropPersonsTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.DropPersonsTextBox.MaxLength = 50;
            this.DropPersonsTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.DropPersonsTextBox.Multiline = false;
            this.DropPersonsTextBox.Name = "DropPersonsTextBox";
            this.DropPersonsTextBox.Size = new System.Drawing.Size(266, 50);
            this.DropPersonsTextBox.TabIndex = 2;
            this.DropPersonsTextBox.Text = "";
            this.DropPersonsTextBox.TrailingIcon = null;
            // 
            // DropButton
            // 
            this.DropButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DropButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DropButton.Depth = 0;
            this.DropButton.HighEmphasis = true;
            this.DropButton.Icon = null;
            this.DropButton.Location = new System.Drawing.Point(435, 113);
            this.DropButton.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.DropButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DropButton.Name = "DropButton";
            this.DropButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DropButton.Size = new System.Drawing.Size(64, 36);
            this.DropButton.TabIndex = 3;
            this.DropButton.Text = "未到";
            this.DropButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DropButton.UseAccentColor = true;
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            // 
            // trainDateTimePicker
            // 
            this.trainDateTimePicker.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trainDateTimePicker.Location = new System.Drawing.Point(8, 40);
            this.trainDateTimePicker.Margin = new System.Windows.Forms.Padding(1);
            this.trainDateTimePicker.Name = "trainDateTimePicker";
            this.trainDateTimePicker.Size = new System.Drawing.Size(518, 39);
            this.trainDateTimePicker.TabIndex = 4;
            this.trainDateTimePicker.ValueChanged += new System.EventHandler(this.trainDateTimePicker_ValueChanged);
            // 
            // queryDropListButton
            // 
            this.queryDropListButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.queryDropListButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.queryDropListButton.Depth = 0;
            this.queryDropListButton.HighEmphasis = true;
            this.queryDropListButton.Icon = null;
            this.queryDropListButton.Location = new System.Drawing.Point(333, 200);
            this.queryDropListButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.queryDropListButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.queryDropListButton.Name = "queryDropListButton";
            this.queryDropListButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.queryDropListButton.Size = new System.Drawing.Size(132, 36);
            this.queryDropListButton.TabIndex = 1;
            this.queryDropListButton.Text = "查看未参训名单";
            this.queryDropListButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.queryDropListButton.UseAccentColor = false;
            this.queryDropListButton.UseVisualStyleBackColor = true;
            this.queryDropListButton.Click += new System.EventHandler(this.queryDropListButton_Click);
            // 
            // queryComeListButton
            // 
            this.queryComeListButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.queryComeListButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.queryComeListButton.Depth = 0;
            this.queryComeListButton.HighEmphasis = true;
            this.queryComeListButton.Icon = null;
            this.queryComeListButton.Location = new System.Drawing.Point(8, 200);
            this.queryComeListButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.queryComeListButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.queryComeListButton.Name = "queryComeListButton";
            this.queryComeListButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.queryComeListButton.Size = new System.Drawing.Size(117, 36);
            this.queryComeListButton.TabIndex = 0;
            this.queryComeListButton.Text = "查看参训名单";
            this.queryComeListButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.queryComeListButton.UseAccentColor = false;
            this.queryComeListButton.UseVisualStyleBackColor = true;
            this.queryComeListButton.Click += new System.EventHandler(this.queryComeListButton_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.ComePercentLabel);
            this.panel7.Controls.Add(this.DropNumLabel);
            this.panel7.Controls.Add(this.ComeNumLabel);
            this.panel7.Controls.Add(this.TrainPerlistView);
            this.panel7.Controls.Add(this.PercentLabel);
            this.panel7.Controls.Add(this.DropLabel);
            this.panel7.Controls.Add(this.ComeLabel);
            this.panel7.Font = new System.Drawing.Font("宋体", 8.25F);
            this.panel7.Location = new System.Drawing.Point(0, 277);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1047, 313);
            this.panel7.TabIndex = 3;
            // 
            // ComePercentLabel
            // 
            this.ComePercentLabel.AutoSize = true;
            this.ComePercentLabel.Depth = 0;
            this.ComePercentLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ComePercentLabel.Location = new System.Drawing.Point(237, 217);
            this.ComePercentLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ComePercentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ComePercentLabel.Name = "ComePercentLabel";
            this.ComePercentLabel.Size = new System.Drawing.Size(17, 19);
            this.ComePercentLabel.TabIndex = 8;
            this.ComePercentLabel.Text = "----";
            // 
            // DropNumLabel
            // 
            this.DropNumLabel.AutoSize = true;
            this.DropNumLabel.Depth = 0;
            this.DropNumLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DropNumLabel.Location = new System.Drawing.Point(237, 116);
            this.DropNumLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.DropNumLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DropNumLabel.Name = "DropNumLabel";
            this.DropNumLabel.Size = new System.Drawing.Size(17, 19);
            this.DropNumLabel.TabIndex = 7;
            this.DropNumLabel.Text = "----";
            // 
            // ComeNumLabel
            // 
            this.ComeNumLabel.AutoSize = true;
            this.ComeNumLabel.Depth = 0;
            this.ComeNumLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ComeNumLabel.Location = new System.Drawing.Point(237, 20);
            this.ComeNumLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ComeNumLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ComeNumLabel.Name = "ComeNumLabel";
            this.ComeNumLabel.Size = new System.Drawing.Size(17, 19);
            this.ComeNumLabel.TabIndex = 6;
            this.ComeNumLabel.Text = "----";
            // 
            // TrainPerlistView
            // 
            this.TrainPerlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.TrainPerlistView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TrainPerlistView.HideSelection = false;
            this.TrainPerlistView.Location = new System.Drawing.Point(378, 1);
            this.TrainPerlistView.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.TrainPerlistView.Name = "TrainPerlistView";
            this.TrainPerlistView.Size = new System.Drawing.Size(522, 281);
            this.TrainPerlistView.StateImageList = this.imageList1;
            this.TrainPerlistView.TabIndex = 5;
            this.TrainPerlistView.UseCompatibleStateImageBehavior = false;
            this.TrainPerlistView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "用户ID";
            this.columnHeader9.Width = 135;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "用户名";
            this.columnHeader10.Width = 291;
            // 
            // PercentLabel
            // 
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.Depth = 0;
            this.PercentLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PercentLabel.Location = new System.Drawing.Point(96, 217);
            this.PercentLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.PercentLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(65, 19);
            this.PercentLabel.TabIndex = 4;
            this.PercentLabel.Text = "出勤率：";
            // 
            // DropLabel
            // 
            this.DropLabel.AutoSize = true;
            this.DropLabel.Depth = 0;
            this.DropLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DropLabel.Location = new System.Drawing.Point(96, 116);
            this.DropLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.DropLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DropLabel.Name = "DropLabel";
            this.DropLabel.Size = new System.Drawing.Size(81, 19);
            this.DropLabel.TabIndex = 3;
            this.DropLabel.Text = "未训人数：";
            // 
            // ComeLabel
            // 
            this.ComeLabel.AutoSize = true;
            this.ComeLabel.Depth = 0;
            this.ComeLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ComeLabel.Location = new System.Drawing.Point(96, 20);
            this.ComeLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ComeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ComeLabel.Name = "ComeLabel";
            this.ComeLabel.Size = new System.Drawing.Size(81, 19);
            this.ComeLabel.TabIndex = 2;
            this.ComeLabel.Text = "参训人数：";
            // 
            // TabControlTeacher
            // 
            this.TabControlTeacher.Controls.Add(this.tabPageTrainSchedule);
            this.TabControlTeacher.Controls.Add(this.tabPageWorkSchedule);
            this.TabControlTeacher.Controls.Add(this.tabPagePerDetail);
            this.TabControlTeacher.Controls.Add(this.tabPageRequests);
            this.TabControlTeacher.Controls.Add(this.tabPage1);
            this.TabControlTeacher.Depth = 0;
            this.TabControlTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlTeacher.Location = new System.Drawing.Point(3, 77);
            this.TabControlTeacher.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.TabControlTeacher.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlTeacher.Multiline = true;
            this.TabControlTeacher.Name = "TabControlTeacher";
            this.TabControlTeacher.SelectedIndex = 0;
            this.TabControlTeacher.Size = new System.Drawing.Size(1070, 643);
            this.TabControlTeacher.TabIndex = 2;
            this.TabControlTeacher.SelectedIndexChanged += new System.EventHandler(this.TabControlTeacher_SelectedIndexChanged);
            // 
            // tabPageRequests
            // 
            this.tabPageRequests.Controls.Add(this.listView1);
            this.tabPageRequests.Controls.Add(this.panel4);
            this.tabPageRequests.Location = new System.Drawing.Point(4, 28);
            this.tabPageRequests.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPageRequests.Name = "tabPageRequests";
            this.tabPageRequests.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.tabPageRequests.Size = new System.Drawing.Size(1061, 611);
            this.tabPageRequests.TabIndex = 8;
            this.tabPageRequests.Text = "调休申请";
            this.tabPageRequests.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader11,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 90);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1055, 520);
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "是否已读";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "申请类型";
            this.columnHeader2.Width = 157;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "审批ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "申请人";
            this.columnHeader3.Width = 148;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "申请状态";
            this.columnHeader4.Width = 139;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "发起时间";
            this.columnHeader5.Width = 143;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "处理时间";
            this.columnHeader6.Width = 159;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label21);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1055, 89);
            this.panel4.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("华文新魏", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(354, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(231, 36);
            this.label21.TabIndex = 0;
            this.label21.Text = "队员申请列表";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.buttonExport);
            this.tabPage1.Controls.Add(this.DoneFlagBt);
            this.tabPage1.Controls.Add(this.TotFlagBt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.GenerateBt);
            this.tabPage1.Controls.Add(this.labelDate);
            this.tabPage1.Controls.Add(this.TotTimeLine);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPage1.Size = new System.Drawing.Size(1061, 611);
            this.tabPage1.TabIndex = 9;
            this.tabPage1.Text = "排班总览";
            // 
            // buttonExport
            // 
            this.buttonExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonExport.Depth = 0;
            this.buttonExport.HighEmphasis = true;
            this.buttonExport.Icon = null;
            this.buttonExport.Location = new System.Drawing.Point(722, 66);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.buttonExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonExport.Size = new System.Drawing.Size(101, 36);
            this.buttonExport.TabIndex = 42;
            this.buttonExport.Text = "导出排班表";
            this.buttonExport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonExport.UseAccentColor = false;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // DoneFlagBt
            // 
            this.DoneFlagBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DoneFlagBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DoneFlagBt.Depth = 0;
            this.DoneFlagBt.HighEmphasis = true;
            this.DoneFlagBt.Icon = null;
            this.DoneFlagBt.Location = new System.Drawing.Point(722, 256);
            this.DoneFlagBt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.DoneFlagBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.DoneFlagBt.Name = "DoneFlagBt";
            this.DoneFlagBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DoneFlagBt.Size = new System.Drawing.Size(117, 36);
            this.DoneFlagBt.TabIndex = 41;
            this.DoneFlagBt.Text = "显示完成排班";
            this.DoneFlagBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DoneFlagBt.UseAccentColor = false;
            this.DoneFlagBt.UseVisualStyleBackColor = true;
            this.DoneFlagBt.Click += new System.EventHandler(this.DoneFlagBt_Click);
            // 
            // TotFlagBt
            // 
            this.TotFlagBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TotFlagBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.TotFlagBt.Depth = 0;
            this.TotFlagBt.HighEmphasis = true;
            this.TotFlagBt.Icon = null;
            this.TotFlagBt.Location = new System.Drawing.Point(722, 161);
            this.TotFlagBt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.TotFlagBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.TotFlagBt.Name = "TotFlagBt";
            this.TotFlagBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.TotFlagBt.Size = new System.Drawing.Size(117, 36);
            this.TotFlagBt.TabIndex = 40;
            this.TotFlagBt.Text = "显示所有排班";
            this.TotFlagBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.TotFlagBt.UseAccentColor = false;
            this.TotFlagBt.UseVisualStyleBackColor = true;
            this.TotFlagBt.Click += new System.EventHandler(this.TotFlagBt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SeaGreen;
            this.label2.Location = new System.Drawing.Point(719, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 54);
            this.label2.TabIndex = 39;
            this.label2.Text = "请您于每月收集完\r\n学生空闲时间后点\r\n击按钮生成下月排班";
            // 
            // GenerateBt
            // 
            this.GenerateBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenerateBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GenerateBt.Depth = 0;
            this.GenerateBt.HighEmphasis = true;
            this.GenerateBt.Icon = null;
            this.GenerateBt.Location = new System.Drawing.Point(721, 354);
            this.GenerateBt.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.GenerateBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.GenerateBt.Name = "GenerateBt";
            this.GenerateBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GenerateBt.Size = new System.Drawing.Size(117, 36);
            this.GenerateBt.TabIndex = 38;
            this.GenerateBt.Text = "生成下月排班";
            this.GenerateBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GenerateBt.UseAccentColor = true;
            this.GenerateBt.UseVisualStyleBackColor = true;
            this.GenerateBt.Click += new System.EventHandler(this.GenerateBt_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("华文新魏", 21.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.Location = new System.Drawing.Point(64, 42);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(195, 44);
            this.labelDate.TabIndex = 37;
            this.labelDate.Text = "排班总览";
            // 
            // TotTimeLine
            // 
            this.TotTimeLine.AutoScroll = true;
            this.TotTimeLine.DetailsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.TotTimeLine.DetailsForcolor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.TotTimeLine.Items = new HZH_Controls.Controls.TimeLineItem[0];
            this.TotTimeLine.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.TotTimeLine.Location = new System.Drawing.Point(39, 125);
            this.TotTimeLine.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.TotTimeLine.Name = "TotTimeLine";
            this.TotTimeLine.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.TotTimeLine.Size = new System.Drawing.Size(633, 445);
            this.TotTimeLine.TabIndex = 1;
            this.TotTimeLine.TitleFont = new System.Drawing.Font("微软雅黑", 14F);
            this.TotTimeLine.TitleForcolor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.TotTimeLine.UseWaitCursor = true;
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelLogout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelLogout.LinkColor = System.Drawing.Color.White;
            this.linkLabelLogout.Location = new System.Drawing.Point(825, 29);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(110, 31);
            this.linkLabelLogout.TabIndex = 3;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "退出登录";
            this.linkLabelLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLogout_LinkClicked);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 721);
            this.Controls.Add(this.linkLabelLogout);
            this.Controls.Add(this.TabControlTeacher);
            this.DrawerAutoShow = true;
            this.DrawerBackgroundWithAccent = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabControlTeacher;
            this.DrawerUseColors = true;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "Teacher";
            this.Padding = new System.Windows.Forms.Padding(3, 77, 3, 1);
            this.Text = "老师";
            this.Load += new System.EventHandler(this.Teacher_Load);
            this.tabPagePerDetail.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageWorkSchedule.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageTrainSchedule.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.TabControlTeacher.ResumeLayout(false);
            this.tabPageRequests.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPagePerDetail;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPageWorkSchedule;
        private System.Windows.Forms.TabPage tabPageTrainSchedule;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialButton CancelTrainButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker trainDateTimePicker;
        private MaterialSkin.Controls.MaterialButton queryDropListButton;
        private MaterialSkin.Controls.MaterialButton queryComeListButton;
        private System.Windows.Forms.Panel panel7;
        private MaterialSkin.Controls.MaterialLabel PercentLabel;
        private MaterialSkin.Controls.MaterialLabel DropLabel;
        private MaterialSkin.Controls.MaterialLabel ComeLabel;
        private MaterialSkin.Controls.MaterialTabControl TabControlTeacher;
        private System.Windows.Forms.TabPage tabPageRequests;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton CancleFlagBt;
        private System.Windows.Forms.Label labelTrainOrNot;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel DropStLb;
        private MaterialSkin.Controls.MaterialLabel TotStLb;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DateTimePicker FlagDateTime;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox DropPersonsTextBox;
        private MaterialSkin.Controls.MaterialButton DropButton;
        private MaterialSkin.Controls.MaterialMultiLineTextBox CommentTb;
        private MaterialSkin.Controls.MaterialButton PictureBt;
        private MaterialSkin.Controls.MaterialButton CommentBt;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.LinkLabel linkLabelLogout;
        private System.Windows.Forms.ListView TrainPerlistView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private MaterialSkin.Controls.MaterialLabel ComePercentLabel;
        private MaterialSkin.Controls.MaterialLabel DropNumLabel;
        private MaterialSkin.Controls.MaterialLabel ComeNumLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private MaterialSkin.Controls.MaterialMaskedTextBox StudentName;
        private MaterialSkin.Controls.MaterialButton AddDropFlag;
        private TabPage tabPage1;
        private HZH_Controls.Controls.UCTimeLine TotTimeLine;
        private Label labelDate;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton GenerateBt;
        private MaterialSkin.Controls.MaterialButton DoneFlagBt;
        private MaterialSkin.Controls.MaterialButton TotFlagBt;
        private MaterialSkin.Controls.MaterialMaskedTextBox searchID;
        private MaterialSkin.Controls.MaterialButton buttonExport;
    }
}