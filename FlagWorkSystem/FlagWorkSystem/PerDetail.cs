using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using MaterialSkin;
using MaterialSkin.Controls;
using static FlagWorkSystem.classes;


namespace FlagWorkSystem
{
    public partial class PerDetail : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;

        int studentid;
        string Name;
        Teacher teacher;
        TeacherService teacherService;
        Personal_work work;
        Personal_train train;
        public PerDetail(int id, string name)
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

            studentid = id;
            Name = name;
            teacherService = new TeacherService(id);
        }

        private void PerDetail_Load(object sender, EventArgs e)
        {
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;

            studentname.Text = Name;
            DateTime selectedDateTime = selectedtime.Value;
            string time = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";

            work = teacherService.Searchshow1(studentid, time);
            train = teacherService.Searchshow2(studentid, time);

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
            Personal_work work1 = teacherService.Searchshow1(studentid, time1);
            Personal_train train1 = teacherService.Searchshow2(studentid, time1);
            Personal_work work2 = teacherService.Searchshow1(studentid, time2);
            Personal_train train2 = teacherService.Searchshow2(studentid, time2);
            Personal_work work3 = teacherService.Searchshow1(studentid, time3);
            Personal_train train3 = teacherService.Searchshow2(studentid, time3);

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

        private void selectedtime_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = selectedtime.Value;
            string time = selectedDateTime.Year + "年" + selectedDateTime.Month + "月";

            work = teacherService.Searchshow1(studentid, time);
            train = teacherService.Searchshow2(studentid, time);
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
            Personal_work work1 = teacherService.Searchshow1(studentid, time1);
            Personal_train train1 = teacherService.Searchshow2(studentid, time1);
            Personal_work work2 = teacherService.Searchshow1(studentid, time2);
            Personal_train train2 = teacherService.Searchshow2(studentid, time2);
            Personal_work work3 = teacherService.Searchshow1(studentid, time3);
            Personal_train train3 = teacherService.Searchshow2(studentid, time3);

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
    }
}
