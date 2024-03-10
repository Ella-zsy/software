using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using static FlagWorkSystem.classes;
using HZH_Controls;
using HZH_Controls.Controls;
using static FlagWorkSystem.StudentService;
using HZH_Controls.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MaterialSkin;

namespace FlagWorkSystem
{
    
    public partial class Student : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;

        int ID;
        string username;

        StudentService studentService;
        Personal_work work;
        Personal_train train;
        
      


        public Student(int studentID)
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

            ID = studentID;

            studentService = new StudentService(ID);

            List<string> names = QueryUsernameByID(ID);

            foreach (string name in names)
            {
                username = name;
            }
           DataUpdated += StudentService_DataUpdated;

        }
        //退出登录
        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }

        //显示通知消息
        public void ShowMessage()
        {
            List<Inform> messages = studentService.QueryMessage(username);
            foreach (Inform message in messages)
            {
                FrmTips.ShowTips(this, message.events, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, null, TipsState.Info);
                studentService.DeleteMessageByID(message.id);
            }


        }

        //在时间线中显示安排
        private void ShowSchedule(string type)
        {


            if (type == "future")
            {
                List<TimeLineItem> items = new List<TimeLineItem>();
                List<DateTime> trainDates = studentService.QueryFtutureTrainingDates(DateTime.Now.Date);
                foreach (DateTime date in trainDates)
                {
                    string title = date.ToLongDateString().ToString();
                    string detail = "21:10  操场训练";
                    TimeLineItem item = new TimeLineItem();
                    item.Title = title;
                    item.Details = detail;
                    items.Add(item);
                }

                List<DateTime> flagDates = studentService.QueryFtutureFlagDates(DateTime.Now.Date, username);
                foreach (DateTime date in flagDates)
                {
                    string title = date.ToLongDateString().ToString();
                    if (items.Exists(t => t.Title == title))
                    {
                        TimeLineItem item = items.Find(t => t.Title == title);
                        string detail1 = "7:00  升旗";
                        string detail2 = "18:00  降旗";
                        item.Details += "\r\n" + detail1;
                        item.Details += "\r\n" + detail2;
                    }
                    else
                    {

                        string detail = "7:00  升旗\r\n18:00  降旗";

                        TimeLineItem item = new TimeLineItem();
                        item.Title = title;
                        item.Details = detail;
                        items.Add(item);
                    }

                }

                List<TimeLineItem> sortedItems = items.OrderBy(t => DateTime.Parse(t.Title)).ToList();

                ScheduleTimeLine.Items = sortedItems.ToArray();
            }
            else if (type == "past")
            {
                List<TimeLineItem> items = new List<TimeLineItem>();
                List<DateTime> trainDates = studentService.QueryPastTrainingDates(DateTime.Now.Date);
                foreach (DateTime date in trainDates)
                {
                    string title = date.ToLongDateString().ToString();
                    string detail = "21:10  操场训练";
                    TimeLineItem item = new TimeLineItem();
                    item.Title = title;
                    item.Details = detail;
                    items.Add(item);
                }

                List<DateTime> flagDates = studentService.QueryPastFlagDates(DateTime.Now.Date, username);
                foreach (DateTime date in flagDates)
                {
                    string title = date.ToLongDateString().ToString();
                    if (items.Exists(t => t.Title == title))
                    {
                        TimeLineItem item = items.Find(t => t.Title == title);
                        string detail1 = "7:00  升旗";
                        string detail2 = "18:00  降旗";
                        item.Details += "\r\n" + detail1;
                        item.Details += "\r\n" + detail2;
                    }
                    else
                    {

                        string detail = "7:00  升旗\r\n18:00  降旗";

                        TimeLineItem item = new TimeLineItem();
                        item.Title = title;
                        item.Details = detail;
                        items.Add(item);
                    }

                }

                List<TimeLineItem> sortedItems = items.OrderBy(t => DateTime.Parse(t.Title)).ToList();

                ScheduleTimeLine.Items = sortedItems.ToArray();
            }
            else
            {

            }
        }

        //显示今日安排
        private void ShowTodaySchedule()
        {
            try
            {
                if (studentService.QueryTodayShallTrain(DateTime.Now.Date))
                {
                    string line = "21:10  操场训练";

                    TodayScheduleTextBox.AppendText(line);
                }
                else
                {
                    string line = "今日无训练";

                    TodayScheduleTextBox.AppendText(line);
                }

                if (studentService.QueryTodayShallFlag(DateTime.Now.Date, username))
                {
                    string line1 = "7:00  升旗";
                    string line2 = "18:00  降旗";

                    TodayScheduleTextBox.AppendText("\r\n" + line1);
                    TodayScheduleTextBox.AppendText("\r\n" + line2);
                }
                else
                {
                    string line = "今日无任务";

                    TodayScheduleTextBox.AppendText("\r\n" + line);
                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show("显示今日安排有误：" + ex.Message);
                FrmTips.ShowTips(this, "显示今日安排有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);


            }

        }
        public event EventHandler DataUpdated;
        private void StudentService_DataUpdated(object sender, EventArgs e)
        {
            // 在事件触发时执行刷新操作
            ShowApprovalData();
        }
        private void OnDataUpdated()
        {
            // 触发事件
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void Student_Load(object sender, EventArgs e)
        {

            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;

            labelDate.Text = DateTime.Now.Date.ToLongDateString().ToString();

            this.Text = username + "同学";

            applicantpeople.Text = username;

            applicant2.Text = username;

            ShowTodaySchedule();

            ShowSchedule("future");
            ShowApprovalData();
            listView1.SelectedIndexChanged += listView1_DoubleClick;
            listView1.DoubleClick += listView1_DoubleClick;
            List<string> names = QueryUsernameByID(ID);
            if (names != null && names.Count > 0)
            {
                materialMaskedTextBox6.Text = names[0];
            }
            else
            {
                materialMaskedTextBox6.Text = "未找到对应的学生姓名";
            }



            studentService.UpdateUserTraining(ID, DateTime.Now.Date);
            studentService.UpdateUserWork(ID, DateTime.Now.Date);

            ShowMessage();

            DateTime selectedDateTime = selectedtime.Value;
            string time = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";

            work = studentService.Searchshow1(ID, time);
            train = studentService.Searchshow2(ID, time);



            if (work != null)
            {
                sumtime2.Text = work.total.ToString();
                actualtime2.Text = work.actualtime.ToString();
                leavetime2.Text = work.leave.ToString();
                absencetime2.Text = work.drop.ToString();
                if (work.total != 0)
                {
                    double attendanceRate = 100.0 * work.actualtime / work.total;
                    attendancerate2.Text = attendanceRate.ToString("F2") + "%";
                }
                else
                    attendancerate2.Text = "0";
            }
            else
            {
                sumtime2.Text = "空";
                actualtime2.Text = "空";
                leavetime2.Text = "空";
                absencetime2.Text = "空";
                attendancerate2.Text = "空";

            }

            if (train != null)
            {
                sumtime1.Text = train.total.ToString();
                actualtime1.Text = train.actualtime.ToString();
                leavetime1.Text = train.leave.ToString();
                absencetime1.Text = train.drop.ToString();
                if (train.total != 0)
                {
                    double attendanceRate = 100.0 * train.actualtime / train.total;
                    attendancerate1.Text = attendanceRate.ToString("F2") + "%";
                }
                else
                    attendancerate1.Text = "0";
            }
            else
            {
                sumtime1.Text = "空";
                actualtime1.Text = "空";
                leavetime1.Text = "空";
                absencetime1.Text = "空";
                attendancerate1.Text = "空";
            }

            if (work != null && train != null)
            {
                double scores = (100 - train.leave * 1 - train.drop * 5) * 0.6 + (100 - work.leave * 5 - train.drop * 10) * 0.4;
                score.Text = scores.ToString("F2");
            }
            else
            {
                score.Text = null;
            }



            //图表
            string time1 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            string time2 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            string time3 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            if (selectedDateTime.Month == 1)
            {
                time2 = (selectedDateTime.Year - 1) + "年" + "12" + "月";
                time3 = (selectedDateTime.Year - 1) + "年" + "11" + "月";

            }
            else if (selectedDateTime.Month == 2)
            {
                time2 = selectedDateTime.Year + "年" + "1" + "月";
                time3 = (selectedDateTime.Year - 1) + "年" + "12" + "月";

            }
            else
            {
                time2 = selectedDateTime.Year + "年" + (selectedDateTime.Month - 1) + "月";
                time3 = selectedDateTime.Year + "年" + (selectedDateTime.Month - 2) + "月";

            }
            Personal_work work1 = studentService.Searchshow1(ID, time1);
            Personal_train train1 = studentService.Searchshow2(ID, time1);
            Personal_work work2 = studentService.Searchshow1(ID, time2);
            Personal_train train2 = studentService.Searchshow2(ID, time2);
            Personal_work work3 = studentService.Searchshow1(ID, time3);
            Personal_train train3 = studentService.Searchshow2(ID, time3);

            double attendanceRatework1;
            double attendanceRatework2;
            double attendanceRatework3;
            double attendanceRatetrain1;
            double attendanceRatetrain2;
            double attendanceRatetrain3;
            if (work1 == null || work1.total == 0)
            {
                attendanceRatework1 = 0;
            }
            else
                attendanceRatework1 = Math.Round(100.0 * work1.actualtime / work1.total, 2);

            if (work2 == null || work2.total == 0)
            {
                attendanceRatework2 = 0;
            }
            else
                attendanceRatework2 = Math.Round(100.0 * work2.actualtime / work2.total, 2);
            if (work3 == null || work3.total == 0)
            {
                attendanceRatework3 = 0;
            }
            else
                attendanceRatework3 = Math.Round(100.0 * work3.actualtime / work3.total, 2);
            if (train1 == null || train1.total == 0)
            {
                attendanceRatetrain1 = 0;
            }
            else
                attendanceRatetrain1 = Math.Round(100.0 * train1.actualtime / train1.total, 2);
            if (train2 == null || train2.total == 0)
            {
                attendanceRatetrain2 = 0;
            }
            else
                attendanceRatetrain2 = Math.Round(100.0 * train2.actualtime / train2.total, 2);
            if (train3 == null || train3.total == 0)
            {
                attendanceRatetrain3 = 0;
            }
            else
                attendanceRatetrain3 = Math.Round(100.0 * train3.actualtime / train3.total, 2);




            List<string> xworkData = new List<string>() { "实到", "旷操", "请假" };
            List<int> yworkData = new List<int>() { 0, 0, 0 };
            if (work != null)
            {
                yworkData = new List<int>() { work.actualtime, work.drop, work.leave };
            }

            List<string> xtrainData = new List<string>() { "实到", "旷操", "请假" };
            List<int> ytrainData = new List<int>() { 0, 0, 0 };
            if (train != null)
            {
                ytrainData = new List<int>() { train.actualtime, train.drop, train.leave };
            }

            List<string> xDatawork = new List<string>() { time3, time2, time1 };
            List<double> yDatawork = new List<double>() { attendanceRatework3, attendanceRatework2, attendanceRatework1 };
            List<string> xDatatrian = new List<string>() { time3, time2, time1 };
            List<double> yDatatrain = new List<double>() { attendanceRatetrain3, attendanceRatetrain2, attendanceRatetrain1 };

            chart2.Series[0].Points.DataBindXY(xworkData, yworkData);
            chart1.Series[0].Points.DataBindXY(xtrainData, ytrainData);

            chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet; //设置网格类型为虚线
            chart3.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; //设置网格类型为虚线
            chart3.Series[0].IsValueShownAsLabel = true;//设置显示示数
            chart3.Series[0].Points.DataBindXY(xDatawork, yDatawork);

            chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet; //设置网格类型为虚线
            chart3.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; //设置网格类型为虚线
            chart3.Series[1].IsValueShownAsLabel = true;//设置显示示数
            chart3.Series[1].Points.DataBindXY(xDatatrian, yDatatrain);



        }
        private void ShowApprovalData()
        {

            List<Examine> approvalData = studentService.GetApprovalData(ID);
            // 清空ListView中的项
            listView1.Items.Clear();
            // 在ListView中显示审批数据
            foreach (Examine examine in approvalData)
            {
                ListViewItem item = new ListViewItem(examine.requeset_time.ToString());
                string type;
                switch (examine.type)
                {
                    case 0:
                        type = "换班";
                        break;
                    case 1:
                        type = "替班";
                        break;
                    case 2:
                        type = "训练请假";
                        break;
                    default:
                        type = "未知类型";
                        break;
                }
                item.SubItems.Add(type);
                item.SubItems.Add(examine.examine_time.ToString());
                // 根据审批状态设置相应的文字描述
                string status;
                switch (examine.is_examine)
                {
                    case 0:
                        status = "未审批";
                        break;
                    case 1:
                        status = "同意";
                        break;
                    case 2:
                        status = "不同意";
                        break;
                    default:
                        status = "未知状态";
                        break;
                }
                item.SubItems.Add(status);
                item.Tag = examine.id;
                listView1.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int id = (int)selectedItem.Tag; // 获取选中行的审批ID
                Examine[] exams = studentService.QueryFlagSchedule(id);

                if (exams.Length > 0)
                {
                    Examine exam = exams[0];
                    if (exam.type == 0 || exam.type == 1)
                    {
                        // 执行界面跳转操作，传递选中行的审批ID和学生ID参数
                        queryFlag queryFlagForm = new queryFlag(id, ID);
                        queryFlagForm.Show();
                        //this.Hide(); // 隐藏当前窗体
                    }
                    else if (exam.type == 2)
                    {
                        // 执行界面跳转操作，传递选中行的审批ID和学生ID参数
                        queryTraining queryTrainingForm = new queryTraining(id, ID);
                        queryTrainingForm.Show();
                        //this.Hide(); // 隐藏当前窗体
                    }
                }
            }
        }




        private void QueryFutureButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSchedule("future");
            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "加载未来排班错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }

        }

        private void QueryPastButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSchedule("past");
            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "加载过去排班错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }

        }

        private void submitButton1_Click(object sender, EventArgs e)
        {
            string applicant = applicantpeople.Text;
            string reason = reason1.Text;
            DateTime applicant_time = applicanttime.Value;
            string replacement = replacepeople.Text;
            int type = 1;
            DateTime requeset_time = DateTime.Now;
            DateTime? replacement_time = null;
            if (comboBox1.SelectedIndex == 0)
            {
                type = 0;
                replacement_time = replacetime.Value;
            }
            try
            {
                studentService.AddFlagRequest(type, applicant, reason, applicant_time, replacement, replacement_time, requeset_time);
                FrmTips.ShowTips(this, "提交申请成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "提交申请有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
            // 清空 ComboBox 控件的选择
            comboBox1.SelectedIndex = -1;
            reason1.Text = "";
            applicanttime.Value = DateTime.Now; // 将日期时间控件设置为当前日期时间
            replacepeople.Text = "";
            replacetime.Value = DateTime.Now; // 将日期时间控件设置为当前日期时间

            OnDataUpdated();
        }

        private void submitButton2_Click(object sender, EventArgs e)
        {
            string applicant = applicant2.Text;
            string reason = reason2.Text;
            DateTime applicant_time = leavetime.Value;
            string replacement = replacepeople.Text;
            DateTime requeset_time = DateTime.Now;
            try
            {
                studentService.AddTrainingRequest(applicant, reason, applicant_time, replacement, requeset_time);
                FrmTips.ShowTips(this, "提交申请成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "提交申请有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
            reason2.Text = "";
            leavetime.Value = DateTime.Now;

            OnDataUpdated();
        }



        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                string newUsername = materialMaskedTextBox6.Text;
                string newPassword = materialTextBox1.Text;
                // 确认密码
                string confirmPassword = materialTextBox2.Text;

                if (newPassword != confirmPassword)
                {
                    MaterialMessageBox.Show("确认密码不匹配！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                studentService.EditInformation(ID, newUsername, newPassword);

                //materialMaskedTextBox6.Text = "";
                materialTextBox1.Text = "";
                materialTextBox2.Text = "";
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnedit2_Click(object sender, EventArgs e)
        {
            bool[] freeTime = new bool[6];
            freeTime[0] = materialCheckbox1.Checked;
            freeTime[1] = materialCheckbox2.Checked;
            freeTime[2] = materialCheckbox3.Checked;
            freeTime[3] = materialCheckbox4.Checked;
            freeTime[4] = materialCheckbox5.Checked;
            freeTime[5] = materialCheckbox6.Checked;
            try
            {
                studentService.EditFreeTime(freeTime);
                FrmTips.ShowTips(this, "修改空余时间成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "修改空余时间有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }

            // 禁用 CheckBox 控件
            materialCheckbox1.Enabled = false;
            materialCheckbox2.Enabled = false;
            materialCheckbox3.Enabled = false;
            materialCheckbox4.Enabled = false;
            materialCheckbox5.Enabled = false;
            materialCheckbox6.Enabled = false;
        }

        private void selectedtime_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = selectedtime.Value;
            string time = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";

            work = studentService.Searchshow1(ID, time);
            train = studentService.Searchshow2(ID, time);
            if (work != null)
            {
                sumtime2.Text = work.total.ToString();
                actualtime2.Text = work.actualtime.ToString();
                leavetime2.Text = work.leave.ToString();
                absencetime2.Text = work.drop.ToString();
                if (work.total != 0)
                {
                    double attendanceRate = 100.0 * work.actualtime / work.total;
                    attendancerate2.Text = attendanceRate.ToString("F2") + "%";
                }
                else
                    attendancerate2.Text = "0";
            }
            else
            {
                sumtime2.Text = "空";
                actualtime2.Text = "空";
                leavetime2.Text = "空";
                absencetime2.Text = "空";
                attendancerate2.Text = "空";

            }

            if (train != null)
            {
                sumtime1.Text = train.total.ToString();
                actualtime1.Text = train.actualtime.ToString();
                leavetime1.Text = train.leave.ToString();
                absencetime1.Text = train.drop.ToString();
                if (train.total != 0)
                {
                    double attendanceRate = 100.0 * train.actualtime / train.total;
                    attendancerate1.Text = attendanceRate.ToString("F2") + "%";
                }
                else
                    attendancerate1.Text = "0";
            }
            else
            {
                sumtime1.Text = "空";
                actualtime1.Text = "空";
                leavetime1.Text = "空";
                absencetime1.Text = "空";
                attendancerate1.Text = "空";
            }

            if (work != null && train != null)
            {
                double scores = (100 - train.leave * 1 - train.drop * 5) * 0.6 + (100 - work.leave * 5 - train.drop * 10) * 0.4;
                score.Text = scores.ToString("F2");
            }
            else
            {
                score.Text = null;
            }


            //图表
            string time1 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            string time2 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            string time3 = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";
            if (selectedDateTime.Month == 1)
            {
                time2 = (selectedDateTime.Year - 1) + "年" + "12" + "月";
                time3 = (selectedDateTime.Year - 1) + "年" + "11" + "月";

            }
            else if (selectedDateTime.Month == 2)
            {
                time2 = selectedDateTime.Year + "年" + "1" + "月";
                time3 = (selectedDateTime.Year - 1) + "年" + "12" + "月";

            }
            else
            {
                time2 = selectedDateTime.Year + "年" + (selectedDateTime.Month - 1) + "月";
                time3 = selectedDateTime.Year + "年" + (selectedDateTime.Month - 2) + "月";

            }
            Personal_work work1 = studentService.Searchshow1(ID, time1);
            Personal_train train1 = studentService.Searchshow2(ID, time1);
            Personal_work work2 = studentService.Searchshow1(ID, time2);
            Personal_train train2 = studentService.Searchshow2(ID, time2);
            Personal_work work3 = studentService.Searchshow1(ID, time3);
            Personal_train train3 = studentService.Searchshow2(ID, time3);

            double attendanceRatework1;
            double attendanceRatework2;
            double attendanceRatework3;
            double attendanceRatetrain1;
            double attendanceRatetrain2;
            double attendanceRatetrain3;
            if (work1 == null || work1.total == 0)
            {
                attendanceRatework1 = 0;
            }
            else
                attendanceRatework1 = Math.Round(100.0 * work1.actualtime / work1.total, 2);

            if (work2 == null || work2.total == 0)
            {
                attendanceRatework2 = 0;
            }
            else
                attendanceRatework2 = Math.Round(100.0 * work2.actualtime / work2.total, 2);
            if (work3 == null || work3.total == 0)
            {
                attendanceRatework3 = 0;
            }
            else
                attendanceRatework3 = Math.Round(100.0 * work3.actualtime / work3.total, 2);
            if (train1 == null || train1.total == 0)
            {
                attendanceRatetrain1 = 0;
            }
            else
                attendanceRatetrain1 = Math.Round(100.0 * train1.actualtime / train1.total, 2);
            if (train2 == null || train2.total == 0)
            {
                attendanceRatetrain2 = 0;
            }
            else
                attendanceRatetrain2 = Math.Round(100.0 * train2.actualtime / train2.total, 2);
            if (train3 == null || train3.total == 0)
            {
                attendanceRatetrain3 = 0;
            }
            else
                attendanceRatetrain3 = Math.Round(100.0 * train3.actualtime / train3.total, 2);




            List<string> xworkData = new List<string>() { "实到", "旷操", "请假" };
            List<int> yworkData = new List<int>() { 0, 0, 0 };
            if (work != null)
            {
                yworkData = new List<int>() { work.actualtime, work.drop, work.leave };
            }

            List<string> xtrainData = new List<string>() { "实到", "旷操", "请假" };
            List<int> ytrainData = new List<int>() { 0, 0, 0 };
            if (train != null)
            {
                ytrainData = new List<int>() { train.actualtime, train.drop, train.leave };
            }

            List<string> xDatawork = new List<string>() { time3, time2, time1 };
            List<double> yDatawork = new List<double>() { attendanceRatework3, attendanceRatework2, attendanceRatework1 };
            List<string> xDatatrian = new List<string>() { time3, time2, time1 };
            List<double> yDatatrain = new List<double>() { attendanceRatetrain3, attendanceRatetrain2, attendanceRatetrain1 };

            chart2.Series[0].Points.DataBindXY(xworkData, yworkData);


            chart1.Series[0].Points.DataBindXY(xtrainData, ytrainData);

            chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet; //设置网格类型为虚线
            chart3.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; //设置网格类型为虚线
            chart3.Series[0].IsValueShownAsLabel = true;//设置显示示数
            chart3.Series[0].Points.DataBindXY(xDatawork, yDatawork);

            chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet; //设置网格类型为虚线
            chart3.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; //设置网格类型为虚线
            chart3.Series[1].IsValueShownAsLabel = true;//设置显示示数
            chart3.Series[1].Points.DataBindXY(xDatatrian, yDatatrain);
        }

        private void btnedit2_Click_1(object sender, EventArgs e)
        {
            // 检查是否在排班结束的前三天内
            if (studentService.IsWithinThreeDaysBeforeScheduleEnd())
            {
                bool[] freeTime = new bool[6];
                freeTime[0] = materialCheckbox1.Checked;
                freeTime[1] = materialCheckbox2.Checked;
                freeTime[2] = materialCheckbox3.Checked;
                freeTime[3] = materialCheckbox4.Checked;
                freeTime[4] = materialCheckbox5.Checked;
                freeTime[5] = materialCheckbox6.Checked;

                try
                {
                    studentService.EditFreeTime(freeTime);
                    FrmTips.ShowTips(this, "修改空余时间成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);
                }
                catch (Exception ex)
                {
                    FrmTips.ShowTips(this, "修改空余时间有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
                }

                // 禁用 CheckBox 控件
                DisableCheckBoxControls();
            }
            else
            {
                FrmTips.ShowTips(this, "非修改时间，无法修改空余时间！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);
            }
        }
        private void DisableCheckBoxControls()
        {
            materialCheckbox1.Enabled = false;
            materialCheckbox2.Enabled = false;
            materialCheckbox3.Enabled = false;
            materialCheckbox4.Enabled = false;
            materialCheckbox5.Enabled = false;
            materialCheckbox6.Enabled = false;
        }
    }
}
