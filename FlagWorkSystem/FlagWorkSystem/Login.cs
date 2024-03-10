using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using static FlagWorkSystem.classes;
using static FlagWorkSystem.LoginService;
using static FlagWorkSystem.TeacherService;

namespace FlagWorkSystem
{
    public partial class Login : MaterialForm
    {
        LoginService loginService;

        private readonly MaterialSkinManager materialSkinManager;

        public Login()
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

            loginService = new LoginService();
        }

        private void ButtonStudentLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = int.Parse(TextBoxStudentID.Text);
                string studentPassword = TextBoxStudentPassword.Text;

                //bool isValid = ValidateLogin("用户", studentID, studentPassword);
                bool isValid = loginService.ValidateStudentLogin(studentID, studentPassword);

                if (isValid)
                {
                    FrmTips.ShowTips(this, "登录成功，欢迎！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

                    Student studentForm = new Student(studentID);
                    this.Hide();
                    studentForm.Show();
                }
                else
                {
                    //MaterialMessageBox.Show("学生ID或密码有误！请重新输入");
                    FrmTips.ShowTips(this, "学生ID或密码有误！请重新输入", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);

                }
            }
            catch (Exception ex) { 
                //MaterialMessageBox.Show(ex.Message);
                FrmTips.ShowTips(this, "学生登录出错：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        private void ButtonTeacherLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int teacherID = int.Parse(TextBoxTeacherID.Text);
                string teacherPassword = TextBoxTeacherPassword.Text;

                //bool isValid = ValidateLogin("老师", teacherID, teacherPassword);
                bool isValid = loginService.ValidateTeacherLogin(teacherID, teacherPassword);

                if (isValid)
                {
                    FrmTips.ShowTips(this, "登录成功，欢迎！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);


                    Teacher teacherForm = new Teacher(teacherID);
                    this.Hide();
                    teacherForm.Show();
                }
                else
                {
                    //MaterialMessageBox.Show("老师ID或密码有误！请重新输入");
                    FrmTips.ShowTips(this, "老师ID或密码有误！请重新输入", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);
                }
            }
            catch(Exception ex) {
                //MaterialMessageBox.Show(ex.Message);
                FrmTips.ShowTips(this, "老师登录出错：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        private void ButtonAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string adminName = TextBoxAdminName.Text;
                string adminPassword = TextBoxAdminPassword.Text;

                bool isValid = loginService.ValidateAdmin(adminName, adminPassword);

                if (isValid)
                {
                    Admin adminForm = new Admin();
                    this.Hide();
                    adminForm.Show();
                }
                else
                {
                    //MaterialMessageBox.Show("管理员名称或密码有误！请重新输入");
                    FrmTips.ShowTips(this, "管理员名称或密码有误！请重新输入", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);

                }
            }
            catch(Exception ex) {
                //MaterialMessageBox.Show(ex.Message);
                FrmTips.ShowTips(this, "管理员登录出错：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;
        }
    }
}
