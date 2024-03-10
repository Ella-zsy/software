using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaterialSkin;
using MaterialSkin.Controls;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public partial class queryTraining : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        private StudentService studentService;
        private int id;
        public queryTraining(int id, int studentID)
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

            this.id = id;
            studentService = new StudentService(studentID);
        }

        private void queryTraining_Load(object sender, EventArgs e)
        {

            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;

            Examine[] exams = studentService.QueryFlagSchedule(id);

            if (exams.Length > 0)
            {
                Examine exam = exams[0];

                // 将审批数据显示在文本框中


                labelApplicant.Text = exam.applicant;
                labelReason.Text = exam.reason;
                labelStatus.Text = GetApprovalStatusDescription(exam.is_examine);
                labelTime1.Text = exam.applicant_time.ToString();
                labelRequestTime.Text = exam.requeset_time.ToString();
                labelExamineTime.Text = exam.examine_time.ToString();

                // 获取审批状态的文字描述
                string GetApprovalStatusDescription(int status)
                {
                    string description;
                    switch (status)
                    {
                        case 0:
                            description = "未审批";
                            break;
                        case 1:
                            description = "同意";
                            break;
                        case 2:
                            description = "不同意";
                            break;
                        default:
                            description = "未知状态";
                            break;
                    }
                    return description;
                }

            }
        }
    }
    }

