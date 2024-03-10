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
using static FlagWorkSystem.classes;
using static FlagWorkSystem.ApplyService;
using HZH_Controls.Forms;
using MaterialSkin;

namespace FlagWorkSystem
{
    public partial class applytraining : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;

        int atid;
        Teacher teacher;
        TeacherService teacherService;
        Examine exam;
        public applytraining(int teacherID, int selectedID)
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

            atid = selectedID;
            teacher = new Teacher(teacherID);
            teacherService = new TeacherService(teacherID);
            exam = teacherService.Searchexam(atid); // 调用Searchexam方法获取exam对象
        }
        public event EventHandler DataUpdated;

        private void applytraining_Load(object sender, EventArgs e)
        {

            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;

            if (exam != null) // 确保exam对象不为空
            {
                at_applicant.Text = exam.applicant;
                at_applytime.Text = exam.applicant_time.ToString("yyyy-MM-dd");
                at_starttime.Text = exam.requeset_time.ToString();
                at_reason.Text = exam.reason;
                if(exam.is_examine!=0)
                {
                    at_agree.Enabled=false;at_disagree.Enabled=false;
                }
            }
            else
            {
                //MessageBox.Show("未找到相关数据"); // 如果exam对象为空，显示提示信息
                FrmTips.ShowTips(this, "未找到相关数据", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);

            }
        }

        private void at_agree_Click(object sender, EventArgs e)
        {
            //DealRequest(atid,1);
            AddMessage(exam.applicant,"老师已通过您于"+exam.applicant_time.ToString("yyyy年MM月dd日")+"的训练请假");
            teacherService.Changeexam(atid, 1, 1);
            // 触发事件，通知 Teacher 界面更新数据
            DataUpdated?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void at_disagree_Click(object sender, EventArgs e)
        {
            //DealRequest(atid,2);
            AddMessage(exam.applicant,"老师已驳回您于"+exam.applicant_time.ToString("yyyy年MM月dd日")+"的训练请假，请按时到场或重新申请。");
            teacherService.Changeexam(atid, 2, 1);
            // 触发事件，通知 Teacher 界面更新数据
            DataUpdated?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
