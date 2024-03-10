using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HZH_Controls.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public partial class Admin : MaterialForm
    {
        AdminService adminService;


        private readonly MaterialSkinManager materialSkinManager;

        public Admin()
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



            adminService = new AdminService();
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.Show();
        }
        //创建用户
        private void btncreateuser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(materialMaskedTextBox1.Text);
            string username = materialMaskedTextBox2.Text;
            string password = materialMaskedTextBox3.Text;

            if (!materialRadioButton1.Checked && !materialRadioButton2.Checked)
            {
                //MaterialMessageBox.Show("请选择一个用户类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmTips.ShowTips(this, "请选择一个用户类型！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);

                return;
            }

            bool isTeacher = materialRadioButton1.Checked;

            //AdminService adminService = new AdminService();
            try
            {
                adminService.AddUser(userId, username, password, isTeacher);
                FrmTips.ShowTips(this, "创建用户成功！" , 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "创建用户有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }


        }
        //查询
        private void btnqueryuser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(materialMaskedTextBox4.Text);
            bool isTeacher = materialRadioButton3.Checked;

            //AdminService adminService = new AdminService();
            List<User> userList = adminService.QueryUser(userId, isTeacher);
            // 清空 ListView
            listView1.Items.Clear();

            try
            {
                foreach (User user in userList)
                {
                    ListViewItem item = new ListViewItem(user.id.ToString());
                    item.SubItems.Add(user.name);
                    item.SubItems.Add(user.password);
                    // Add more subitems for additional properties
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "查询错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }

            

        }
        //删除
        private void btndeleteuser_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int userId = Convert.ToInt32(selectedItem.SubItems[0].Text);
                bool isTeacher = materialRadioButton3.Checked;
                //AdminService adminService = new AdminService();
                try
                {
                    adminService.DeleteUser(userId, isTeacher);
                    // 从ListView中移除选中的行
                    listView1.Items.Remove(selectedItem);
                    FrmTips.ShowTips(this, "删除用户成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);
                }
                catch (Exception ex)
                {
                    FrmTips.ShowTips(this, "删除用户有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
                }
            }
            else
            {
                FrmTips.ShowTips(this, "请先选择要删除的用户！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);
            }

        }
        //查询
        private void btnqueryuser2_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(materialMaskedTextBox5.Text);
                bool isTeacher = materialRadioButton5.Checked;
                //AdminService adminService = new AdminService();
                List<User> userList = adminService.QueryUser(userId, isTeacher);
                if (userList.Count > 0)
                {
                    materialMaskedTextBox6.Text = userList[0].name;
                    materialMaskedTextBox9.Text = userList[0].password;
                }
                else
                {
                    materialMaskedTextBox6.Text = "";
                    materialMaskedTextBox9.Text = "";
                    //MaterialMessageBox.Show("未找到匹配的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmTips.ShowTips(this, "未找到匹配的用户！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Warning);
                }
            }
            catch (Exception ex)
            {
                //MaterialMessageBox.Show("发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmTips.ShowTips(this, "发生错误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);
            }

        }
        //修改
        private void btnedituser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(materialMaskedTextBox5.Text);
            string newUsername = materialMaskedTextBox6.Text;
            string newPassword = materialMaskedTextBox9.Text;
            bool isTeacher = materialRadioButton5.Checked;

            //AdminService adminService = new AdminService();
            try
            {
                adminService.EditUser(userId, newUsername, newPassword, isTeacher);
                FrmTips.ShowTips(this, "修改用户成功！", 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Success);

            }
            catch (Exception ex)
            {
                FrmTips.ShowTips(this, "修改用户有误：" + ex.Message, 0, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Medium, null, TipsState.Error);

            }


        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            Left = (size.Width - Width) / 2;
            Top = (size.Height - Height) / 6;
            WindowState = FormWindowState.Normal;
        }
    }
    }


    