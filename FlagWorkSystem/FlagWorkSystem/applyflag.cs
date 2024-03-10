using HZH_Controls.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FlagWorkSystem.ApplyService;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public partial class applyflag : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        int afid;
        Teacher teacher;
        TeacherService teacherService;
        Examine exam;
        public applyflag(int teacherID, int selectedID)
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

            afid = selectedID;
            teacher = new Teacher(teacherID);
            teacherService = new TeacherService(teacherID);
            exam = teacherService.Searchexam(afid); // 调用Searchexam方法获取exam对象
        }
        public event EventHandler DataUpdated;

        private void applyflag_Load(object sender, EventArgs e)
        {
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;

            try
            {
                if (exam != null) // 确保exam对象不为空
                {
                    af_applicant.Text = exam.applicant.ToString();
                    if(exam.type==0)
                    {
                        af_type.Text="换班";
                        af_replacetime.Text = exam.replacement_time.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        af_type.Text="替班";
                        af_replacetime.Text="[替班无需替班人班次]";
                    }
                    af_applytime.Text = exam.applicant_time.ToString("yyyy-MM-dd");
                    af_applicantpeople.Text = exam.replacement.ToString();
                    af_starttime.Text = exam.requeset_time.ToString();
                    af_reason.Text = exam.reason.ToString();
                    if(exam.is_examine!=0)
                    {
                        flag_agree.Enabled=false;
                        flag_disagree.Enabled=false;
                    }
                }
                else
                {
                    //MessageBox.Show("未找到相关数据"); // 如果exam对象为空，显示提示信息
                    FrmTips.ShowTips(this, "未找到相关数据", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);

                }
            }
            catch(Exception ex) {
                //MaterialMessageBox.Show("查询审批错误:"+ex.Message); 
                FrmTips.ShowTips(this, "查询审批错误:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        private void flag_agree_Click(object sender, EventArgs e)
        {
            try
            {
                //DealRequest(afid,1);
                DateTime date;
                DateTime.TryParse(af_applytime.Text,out date);
                ChangeFlag(date,af_applicant.Text,af_applicantpeople.Text);
                AddMessage(exam.replacement,exam.applicant+"提交的换班申请已被老师通过，请于"+date.ToString("yyyy年MM月dd日")+"前去值班");
                string msg="您提交的"+af_type.Text+"申请已被通过，无需参加"+date.ToString("yyyy年MM月dd日")+"的值班。";
                if(exam.type==0)
                {
                    DateTime.TryParse(af_replacetime.Text,out date);
                    ChangeFlag(date,af_applicantpeople.Text,af_applicant.Text);
                    msg+="但请您记得参加"+date.ToString("yyyy年MM月dd日")+"的值班";
                }
                AddMessage(exam.applicant,msg);
            }
            catch(Exception ex) {
                //MaterialMessageBox.Show("提交审批结果:"+ex.Message); 
                FrmTips.ShowTips(this, "提交审批结果错误:" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
            finally
            {
                teacherService.Changeexam(afid, 1, 1);
                // 触发事件，通知 Teacher 界面更新数据
                DataUpdated?.Invoke(this, EventArgs.Empty);
                Close();
            }
        }

        private void flag_disagree_Click(object sender, EventArgs e)
        {
            teacherService.Changeexam(afid, 2, 1);
            // 触发事件，通知 Teacher 界面更新数据
            DataUpdated?.Invoke(this, EventArgs.Empty);
            //DealRequest(afid,2);
            DateTime date;
            DateTime.TryParse(af_applytime.Text,out date);
            AddMessage(exam.applicant,"您提交的有关"+date.ToString("yyyy年MM月dd日")+"的"+af_type.Text+"申请已被驳回，记得按时值班或再次提交申请。");
            Close();
        }
    }
}
