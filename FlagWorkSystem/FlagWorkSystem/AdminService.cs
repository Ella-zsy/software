using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public class AdminService
    {
        

        //后台管理员的构造
        public AdminService()
        {
           

        }

        //查询用户（老师&学生）
        public List<User> QueryUser(int userId, bool isTeacher)
        {
            List<User> userList = new List<User>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                string tableName = isTeacher ? "老师" : "用户";

                cmd.CommandText = $"SELECT `用户ID`, `用户名`, `密码` FROM `{tableName}` WHERE `用户ID` = @userId";
                cmd.Parameters.AddWithValue("@userId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                          Convert.ToInt32(reader["用户ID"]),
                          reader["用户名"].ToString(),
                          reader["密码"].ToString()
                        );

                        userList.Add(user);
                    }
                }

                conn.Close();
            }

            return userList;
        }



        //添加用户（老师&学生）
        public void AddUser(int id, string name, string password, bool isTeacher)
        {
            string tableName = isTeacher ? "老师" : "用户";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                // 检查用户ID是否存在
                cmd.CommandText = $"SELECT * FROM `{tableName}` WHERE `用户ID` = @userId";
                cmd.Parameters.AddWithValue("@userId", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close(); // 关闭数据读取器
                    MaterialMessageBox.Show("用户ID已存在，不能重复插入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                reader.Close(); // 关闭数据读取器

                // 插入用户表
                cmd.CommandText = $"INSERT INTO `{tableName}` (`用户ID`, `用户名`, `密码`) VALUES (@userId, @username, @password)";
                cmd.Parameters.Clear(); // 清除参数集合
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", password);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //MaterialMessageBox.Show("创建用户成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MaterialMessageBox.Show("创建用户失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
        }

        //修改用户（老师&学生）
        public void EditUser(int userId, string newUsername, string newPassword, bool isTeacher)
        {
            string tableName = isTeacher ? "老师" : "用户";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                // 检查用户ID是否存在
                cmd.CommandText = $"SELECT * FROM `{tableName}` WHERE `用户ID` = @userId";
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close(); // 关闭数据读取器
                    MaterialMessageBox.Show("用户ID不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                reader.Close(); // 关闭数据读取器

                // 更新用户表
                cmd.CommandText = $"UPDATE `{tableName}` SET `用户名` = @newUsername, `密码` = @newPassword WHERE `用户ID` = @userId";
                cmd.Parameters.Clear(); // 清除参数集合
                cmd.Parameters.AddWithValue("@newUsername", newUsername);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                cmd.Parameters.AddWithValue("@userId", userId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //MaterialMessageBox.Show("修改用户成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MaterialMessageBox.Show("修改用户失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
        }

        //删除用户（老师&学生）
        public void DeleteUser(int userId, bool isTeacher)
        {
            string tableName = isTeacher ? "老师" : "用户";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                // 检查用户ID是否存在
                cmd.CommandText = $"SELECT * FROM `{tableName}` WHERE `用户ID` = @userId";
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close(); // 关闭数据读取器
                    MaterialMessageBox.Show("用户ID不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                reader.Close(); // 关闭数据读取器

                // 删除用户
                cmd.CommandText = $"DELETE FROM `{tableName}` WHERE `用户ID` = @userId";
                cmd.Parameters.Clear(); // 清除参数集合
                cmd.Parameters.AddWithValue("@userId", userId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //MaterialMessageBox.Show("删除用户成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MaterialMessageBox.Show("删除用户失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
        }


    }
}
