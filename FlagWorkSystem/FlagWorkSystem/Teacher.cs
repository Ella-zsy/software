using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static FlagWorkSystem.classes;
using static FlagWorkSystem.TeacherService;


namespace FlagWorkSystem
{
    public partial class Teacher : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;

        int ID;
        TeacherService teacherService;

        string teachername;

        List<Trainning_schedule> trainning_Schedules;

        //string[] TrainDays = { "星期一", "星期三", "星期五" };


        public Teacher(int teacherID)
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            //materialSkinManager.AddFormToManage(this);


            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
               ColorTranslator.FromHtml("#a72b28"),
               ColorTranslator.FromHtml("#8d2926"),
               ColorTranslator.FromHtml("#f1ac20"),
               ColorTranslator.FromHtml("#f1ac20"),
               TextShade.WHITE);

            ID = teacherID;
            teacherService = new TeacherService(ID);

            List<string> names = teacherService.QueryTeachernameByID(ID);

            foreach (string name in names)
            {
                teachername = name;
            }

            trainning_Schedules = teacherService.QueryTrainingCondition(DateTime.Now.Date);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            updateBasicInformation();
            FlagDateTime_CloseUp(FlagDateTime,EventArgs.Empty);
            List<TimeLineItem> items=GetFlagTimes(DateTime.Now.Date);
           // MessageBox.Show(items.Count().ToString());
            TotTimeLine.Items=items.ToArray();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView2.SelectedItems[0];
                int studentid = int.Parse(selectedItem.SubItems[0].Text);
                string selectedData = selectedItem.SubItems[1].Text; // 假设要获取第二列的数据
                PerDetail detailPage = new PerDetail(studentid, selectedData);
                detailPage.Show();
            }
            return;
        }

        //初始化listview，将数据库数据导入
        private void Teacher_Load(object sender, EventArgs e)
        {

            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;


            this.Text = teachername + "老师";

            User[] users = teacherService.ShowdataUser();
            listView2.Items.Clear();
            foreach (User user in users)
            {
                ListViewItem item = new ListViewItem(user.id.ToString());
                item.SubItems.Add(user.name);
                this.listView2.Items.Add(item);
            }


            Examine[] exams = teacherService.ShowdataApply();
            listView1.Items.Clear();
            foreach (Examine exam in exams)
            {
                ListViewItem item = new ListViewItem();
                listView1.SmallImageList = imageList1; // 将imageList1与ListView关联
                if (exam.is_read == 0)
                {
                    item.ImageKey = "unread";
                    item.Text = "未读"; // 添加显示文字
                }
                else
                {
                    item.ImageKey = "read";
                    item.Text = "已读"; // 添加显示文字
                }
                switch (exam.type)
                {
                    case 0:
                        item.SubItems.Add("换班");
                        break;
                    case 1:
                        item.SubItems.Add("替班");
                        break;
                    case 2:
                        item.SubItems.Add("训练请假");
                        break;
                    default:
                        item.SubItems.Add(exam.type.ToString());
                        break;
                }
                item.SubItems.Add(exam.id.ToString());
                item.SubItems.Add(exam.applicant);
                switch (exam.is_examine)
                {
                    case 0:
                        item.SubItems.Add("未审批");
                        break;
                    case 1:
                        item.SubItems.Add("同意");
                        break;
                    case 2:
                        item.SubItems.Add("不同意");
                        break;
                    default:
                        item.SubItems.Add(exam.type.ToString());
                        break;
                }
                item.SubItems.Add(exam.requeset_time.ToString());
                item.SubItems.Add(exam.examine_time.ToString());

                listView1.Items.Add(item);
            }

            DateTime currentDate = DateTime.Now;
            DateTime nextMonth=currentDate.AddMonths(1);
            int nextYear = nextMonth.Year;
            int nextMonthNumber = nextMonth.Month;
            DateTime firstDayOfNextMonth = new DateTime(nextYear, nextMonthNumber, 1);
            DateTime lastDayOfNextMonth = firstDayOfNextMonth.AddMonths(1).AddDays(-1);
            if(QueryFlagCondition(lastDayOfNextMonth)!=null||QueryFlagCondition(firstDayOfNextMonth)!=null)
                GenerateBt.Enabled=false;

            teacherService.UpdateAllUserTraining(DateTime.Now.Date);
            teacherService.UpdateAllUserWork(DateTime.Now.Date);

        }

        //点击通过用户ID查询每个队员的表现详情
        private void materialButton4_Click(object sender, EventArgs e)
        {
            string searchText = searchID.Text;
            //TeacherService teacherService = new TeacherService();
            User[] users = teacherService.SearchID(searchID.Text);
            listView2.Items.Clear();

            try
            {
                foreach (User user in users)
                {
                    ListViewItem item = new ListViewItem(user.id.ToString());
                    item.SubItems.Add(user.name);
                    this.listView2.Items.Add(item);
                }
                teacherService.SearchID(searchID.Text);
            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "查询错误:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
            
        }

        //取消今日升降旗
        private void CancleFlagBt_Click(object sender, EventArgs e)
        {
            try
            {
                teacherService.CancelFlag(DateTime.Now.Date);
                //MaterialMessageBox.Show("取消成功！");
                FrmTips.ShowTips(this, "取消成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                FlagDateTime_CloseUp(FlagDateTime,EventArgs.Empty);

                teacherService.InsertFlagCancelMessages(DateTime.Now.Date);
            }
            catch(Exception ex)
            {
                //MaterialMessageBox.Show("取消升旗失败:"+ex.Message);
                FrmTips.ShowTips(this, "取消升旗失败:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        //提交评论
        private void CommentBt_Click(object sender, EventArgs e)
        {
            try
            {
                string text=CommentTb.Text;
                AddComment(DateTime.Now.Date,text);
                //MaterialMessageBox.Show("评论成功！");
                FrmTips.ShowTips(this, "评论成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                FlagDateTime_CloseUp(FlagDateTime,EventArgs.Empty);
            }
            catch(Exception ex)
            {
                //MaterialMessageBox.Show("评论失败:"+ex.Message);
                FrmTips.ShowTips(this, "评论失败:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        //退出登录
        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }
        
        //取消今日训练
        private void CancelTrainButton_Click(object sender, EventArgs e)
        {
            try
            {
                teacherService.CancelTraing(DateTime.Now.Date);
                //MaterialMessageBox.Show("取消成功！");
                FrmTips.ShowTips(this, "取消成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                CancelTrainButton.Enabled = false;
                trainning_Schedules = teacherService.QueryTrainingCondition(trainDateTimePicker.Value.Date);
                updateBasicInformation();

                teacherService.InsertTrainCancelMessages();

            }
            catch (Exception ex)
            {
                //MaterialMessageBox.Show("取消训练失败:" + ex.Message);
                FrmTips.ShowTips(this, "取消训练失败:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        //所选日期发生改变，不同按钮的可操作性发生相应变化
        private void trainDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            trainning_Schedules = teacherService.QueryTrainingCondition(trainDateTimePicker.Value.Date);
            updateBasicInformation();
            TrainPerlistView.Items.Clear();
        }

        private void queryDropListButton_Click(object sender, EventArgs e)
        {

            TrainPerlistView.Items.Clear();
            try
            {
                foreach (Trainning_schedule schedule in trainning_Schedules)
                {
                    List<User> users = teacherService.QueryDropUsers(schedule.drop_users);

                    foreach (User user in users)
                    {
                        ListViewItem item = new ListViewItem(user.id.ToString());
                        item.SubItems.Add(user.name);
                        this.TrainPerlistView.Items.Add(item);
                    }

                }

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "查看未参训名单错误:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
            
        }



        //选项卡发生变化（相应选项页将要显示）
        private void TabControlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TabControlTeacher.SelectedTab.Name == "tabPageTrainSchedule")
            {
                trainning_Schedules = teacherService.QueryTrainingCondition(DateTime.Now.Date);

                updateBasicInformation();
            }
            else if (TabControlTeacher.SelectedTab.Name == "tabPageWorkSchedule")
            {

            }
            else if (TabControlTeacher.SelectedTab.Name == "tabPagePerDetail")
            {

            }
            else if(TabControlTeacher.SelectedTab.Name == "tabPageRequests")
            {

            }
            else
            {

            }
        }

        private void queryComeListButton_Click(object sender, EventArgs e)
        {
            TrainPerlistView.Items.Clear();
            try
            {
                foreach (Trainning_schedule schedule in trainning_Schedules)
                {
                    List<User> users = teacherService.QueryComeUsers(schedule.drop_users);

                    foreach (User user in users)
                    {
                        ListViewItem item = new ListViewItem(user.id.ToString());
                        item.SubItems.Add(user.name);
                        this.TrainPerlistView.Items.Add(item);
                    }

                }
            }
            catch(Exception ex)
            {
                FrmTips.ShowTips(this, "查看名单错误:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
            
        }
        //选择日期发生变化或者初始化，更新“是否有训”label的显示内容以及其他控件的可用状态
        private void updateBasicInformation()
        {
            bool shallTrain = false;

            //选择日期早于当前日期
            if (trainDateTimePicker.Value.Date < DateTime.Now.Date)
            {
                CancelTrainButton.Enabled = false;
                DropPersonsTextBox.Enabled = false;
                DropButton.Enabled = false;
                queryComeListButton.Enabled = true;
                queryDropListButton.Enabled = true;

                //trainning_Schedules = QueryTrainingCondition(trainDateTimePicker.Value.Date);

                foreach (Trainning_schedule schedule in trainning_Schedules)
                {
                    if (schedule.shallTrain&&!(schedule.is_cancle))
                    {
                        shallTrain = true;
                    }
                }

                if (shallTrain)
                {
                    labelTrainOrNot.Text = "此日有训练";
                    queryComeListButton.Enabled = true;
                    queryDropListButton.Enabled = true;
                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        ComeNumLabel.Text = teacherService.CountComeNum(schedule.drop_users).ToString();
                    }
                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        DropNumLabel.Text = teacherService.CountDropNum(schedule.drop_users).ToString();
                    }
                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        ComePercentLabel.Text = (100 * teacherService.CountComeNum(schedule.drop_users) / (teacherService.CountDropNum(schedule.drop_users) + teacherService.CountComeNum(schedule.drop_users))).ToString() + "%";
                    }
                }
                else
                {
                    labelTrainOrNot.Text = "此日无训练";
                    queryComeListButton.Enabled = false;
                    queryDropListButton.Enabled = false;
                    ComeNumLabel.Text = "----";
                    DropNumLabel.Text = "----";
                    ComePercentLabel.Text = "----";
                }

            }
            //选择日期迟于当前日期
            else if (trainDateTimePicker.Value.Date > DateTime.Now.Date)
            {
                CancelTrainButton.Enabled = false;
                DropPersonsTextBox.Enabled = false;
                DropButton.Enabled = false;
                queryComeListButton.Enabled = false;
                queryDropListButton.Enabled = false;

                ComeNumLabel.Text = "----";
                DropNumLabel.Text = "----";
                ComePercentLabel.Text = "----";


                
                if (trainning_Schedules.Count != 0)
                {

                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        if (schedule.shallTrain)
                        {
                            shallTrain = true;
                        }
                    }

                    if (shallTrain)
                    {
                        labelTrainOrNot.Text = "预计有训练";
                    }
                    else
                    {
                        labelTrainOrNot.Text = "预计无训练";
                    }

                }
                else
                {
                    labelTrainOrNot.Text = "尚未做安排";
                }
                
              

            }
            //选择日期为当前日期
            else
            {
                
                //trainning_Schedules = QueryTrainingCondition(DateTime.Now.Date);

                foreach (Trainning_schedule schedule in trainning_Schedules)
                {
                    if (schedule.shallTrain && !(schedule.is_cancle))
                    {
                        shallTrain = true;
                    }
                }
                if (shallTrain)
                {
                    labelTrainOrNot.Text = "今日有训练";
                    CancelTrainButton.Enabled = true;
                    DropPersonsTextBox.Enabled = true;
                    DropButton.Enabled = true;
                    queryComeListButton.Enabled = true;
                    queryDropListButton.Enabled = true;

                    foreach(Trainning_schedule schedule in trainning_Schedules)
                    {
                        ComeNumLabel.Text = teacherService.CountComeNum(schedule.drop_users).ToString();
                    }
                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        DropNumLabel.Text = teacherService.CountDropNum(schedule.drop_users).ToString();
                    }
                    foreach (Trainning_schedule schedule in trainning_Schedules)
                    {
                        ComePercentLabel.Text =(100 * teacherService.CountComeNum(schedule.drop_users)/(teacherService.CountDropNum(schedule.drop_users)+ teacherService.CountComeNum(schedule.drop_users))).ToString() + "%";
                    }

                }
                else
                {
                    labelTrainOrNot.Text = "今日无训练";
                    CancelTrainButton.Enabled = false;
                    DropPersonsTextBox.Enabled = false;
                    DropButton.Enabled = false;
                    queryComeListButton.Enabled = false;
                    queryDropListButton.Enabled = false;
                    ComeNumLabel.Text = "----";
                    DropNumLabel.Text = "----";
                    ComePercentLabel.Text = "----";
                }
            }
        }

        private void DropButton_Click(object sender, EventArgs e)
        {

            try
            {
                string[] dropList = DropPersonsTextBox.Text.Split(' ');
                DropPersonsTextBox.Text = "";
                teacherService.RecordNoTrainingStudent(dropList, trainDateTimePicker.Value.Date);
                trainning_Schedules = teacherService.QueryTrainingCondition(trainDateTimePicker.Value.Date);
                updateBasicInformation();
                FrmTips.ShowTips(this, "登记旷训学生成功", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "登记失败：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
        }

        private void Apply_DataUpdated(object sender, EventArgs e)
        {
            RefreshTeacherView();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
            int selectedid = int.Parse(selectedItem.SubItems[2].Text);
            string selectedtype = selectedItem.SubItems[1].Text;
            if (selectedtype == "训练请假")
            {
                applytraining at = new applytraining(ID, selectedid);
                at.DataUpdated += Apply_DataUpdated;
                at.Show();
            }
            else
            {
                applyflag af = new applyflag(ID, selectedid);
                af.DataUpdated += Apply_DataUpdated;
                af.Show();
            }

        }

        // 刷新Teacher界面
        public void RefreshTeacherView()
        {
            // 刷新审批数据
            Examine[] exams = teacherService.ShowdataApply();
            listView1.Items.Clear();
            foreach (Examine exam in exams)
            {
                ListViewItem item = new ListViewItem();
                listView1.SmallImageList = imageList1; // 将imageList1与ListView关联
                if (exam.is_read == 0)
                {
                    item.ImageKey = "unread";
                    item.Text = "未读"; // 添加显示文字
                }
                else
                {
                    item.ImageKey = "read";
                    item.Text = "已读"; // 添加显示文字
                }
                switch (exam.type)
                {
                    case 0:
                        item.SubItems.Add("换班");
                        break;
                    case 1:
                        item.SubItems.Add("替班");
                        break;
                    case 2:
                        item.SubItems.Add("训练请假");
                        break;
                    default:
                        item.SubItems.Add(exam.type.ToString());
                        break;
                }
                item.SubItems.Add(exam.id.ToString());
                item.SubItems.Add(exam.applicant);
                switch (exam.is_examine)
                {
                    case 0:
                        item.SubItems.Add("未审批");
                        break;
                    case 1:
                        item.SubItems.Add("同意");
                        break;
                    case 2:
                        item.SubItems.Add("不同意");
                        break;
                    default:
                        item.SubItems.Add(exam.type.ToString());
                        break;
                }
                item.SubItems.Add(exam.requeset_time.ToString());
                item.SubItems.Add(exam.examine_time.ToString());
                listView1.Items.Add(item);
            }
        }

        private void AddDropFlag_Click(object sender, EventArgs e)
        {
            try
            {
                string name=StudentName.Text;
                RecordNoFlagStudent(DateTime.Now.Date,name);
                //MaterialMessageBox.Show("登记旷班学生成功");
                FrmTips.ShowTips(this, "登记旷班学生成功", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                StudentName.Text=null;FlagDateTime_CloseUp(FlagDateTime,EventArgs.Empty);
            }
            catch(Exception ex) {
                //MaterialMessageBox.Show("登记失败："+ex.Message);
                FrmTips.ShowTips(this, "登记失败：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        private void PictureBt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try
                {
                    openFileDialog.Filter ="Image Files (*.jpg; *.jpeg; *.png; *.gif;)|*.jpg; *.jpeg; *.png; *.gif";
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image= System.Drawing.Image.FromFile(openFileDialog.FileName);
                        AddPicture(DateTime.Now.Date,openFileDialog.FileName.ToString());
                    }
                    //MaterialMessageBox.Show("上传图片成功");
                    FrmTips.ShowTips(this, "上传图片成功", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                    FlagDateTime_CloseUp(FlagDateTime,EventArgs.Empty);
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    FrmTips.ShowTips(this, "上传图片失败：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

                }
            }
        }

        private void FlagDateTime_CloseUp(object sender, EventArgs e)
        {
            StudentName.ReadOnly=true;
            CommentTb.ReadOnly=true;
            StudentName.Text=null;
            CommentTb.Text=null;
            pictureBox1.Image=null;
            CancleFlagBt.Enabled=false;
            CommentBt.Enabled=false;
            PictureBt.Enabled=false;
            AddDropFlag.Enabled=false;
            TotStLb.Text="升旗名单:";DropStLb.Text="未到场名单:";
            if (FlagDateTime.Value.Month > DateTime.Now.AddMonths(1).Month || FlagDateTime.Value.Year > DateTime.Now.AddMonths(1).Year)
            {
                // 选中日期已超过下个月
                label19.Text="排班尚未生成";
                return ;
            }
            Working_schedule ws=QueryFlagCondition(FlagDateTime.Value.Date);
            if(ws==null||ws.is_cancle==true)
            {
                label19.Text="今日无升旗";
                return ;
            }
            label19.Text="今日有升旗";
            TotStLb.Text+=ws.user1+" "+ws.user2+" "+ws.user3;
            if(FlagDateTime.Value.Date<DateTime.Now.Date)
            {
                DropStLb.Text+=ws.drop_users;
                CommentTb.Text=ws.Text;
                if(ws.Photo!=null)
                    pictureBox1.Image= System.Drawing.Image.FromFile(ws.Photo);
            }
            if(FlagDateTime.Value.Date==DateTime.Now.Date)
            {
                DropStLb.Text+=ws.drop_users;
                CommentTb.Text=ws.Text;
                if(ws.Photo!=null)
                    pictureBox1.Image= System.Drawing.Image.FromFile(ws.Photo);
                CancleFlagBt.Enabled=true;
                CommentBt.Enabled=true;
                PictureBt.Enabled=true;
                AddDropFlag.Enabled=true;
            }
        }

        private void GenerateBt_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateFlag();
                GenerateTrainning();
                AddMsgToALL();
                GenerateBt.Enabled=false;
                FrmTips.ShowTips(this, "生成下月排班成功！" , 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);
            }
            catch(Exception ex) { FrmTips.ShowTips(this, "生成下月排班错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);}
        }

        private void TotFlagBt_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime nextMonth=currentDate.AddMonths(1);
                int nextYear = nextMonth.Year;
                int nextMonthNumber = nextMonth.Month;
                DateTime firstDayOfNextMonth = new DateTime(nextYear, nextMonthNumber, 1);
                DateTime lastDayOfNextMonth = firstDayOfNextMonth.AddMonths(1).AddDays(-1);
                List<TimeLineItem> items=GetFlagTimes(lastDayOfNextMonth);
                TotTimeLine.Items=items.ToArray();
            }
            catch(Exception ex)
            {
                 FrmTips.ShowTips(this, "加载全部排班错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
        }

        private void DoneFlagBt_Click(object sender, EventArgs e)
        {
            try
            {
                List<TimeLineItem> items=GetFlagTimes(DateTime.Now.Date);
                TotTimeLine.Items=items.ToArray();
            }
            catch(Exception ex)
            {
                 FrmTips.ShowTips(this, "加载已完成排班错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                TeacherService.ExportScheduleToExcel();
                FrmTips.ShowTips(this, "导出成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);
            }
            catch (Exception ex)
            {
                Console.WriteLine("导出Excel发生错误: " + ex.Message);
                FrmTips.ShowTips(this, "导出错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }
        }
    }
}
