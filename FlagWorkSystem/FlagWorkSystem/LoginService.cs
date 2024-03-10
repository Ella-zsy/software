using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using static FlagWorkSystem.classes;




namespace FlagWorkSystem
{
    public class LoginService
    {
        public LoginService()
        {
            /*
            //测试数据库连接
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MaterialMessageBox.Show("连接成功:");
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("连接错误:" + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
            */
        }

        // 用户登录验证
        public bool ValidateLogin(string tableName, int userID, string password)
        {
            bool isValid = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE 用户ID = @userID AND 密码 = @password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        isValid = (count > 0);
                    }
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("登录验证连接错误: " + ex.Message);
                }
            }

            return isValid;
        }

        // 学生登录验证
        public bool ValidateStudentLogin(int userID, string password)
        {
            bool isValid = false;
            List<User> users = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT 用户ID,用户名,密码 FROM 用户";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("获取用户列表错误: " + ex.Message);
                }
            }
            try
            {

                var QuerySyntax = from user in users
                                  where user.id == userID
                                  select user.password;

                foreach (var item in QuerySyntax)
                {
                    
                    if (item == password)
                    {
                        isValid = true; 
                    }
                }

            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("验证学生ID密码错误: " + ex.Message);
            }
            return isValid;
        }

        // 学生登录验证
        public bool ValidateTeacherLogin(int userID, string password)
        {
            bool isValid = false;
            List<User> users = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT 用户ID,用户名,密码 FROM 老师";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("获取老师列表错误: " + ex.Message);
                }
            }
            try
            {

                var QuerySyntax = from user in users
                                  where user.id == userID
                                  select user.password;

                foreach (var item in QuerySyntax)
                {
                    if (item == password)
                    {
                        isValid = true; break;
                    }
                }

            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("验证老师ID密码错误: " + ex.Message);
            }
            return isValid;
        }

        //管理员登录验证
        public bool ValidateAdmin(string adminName, string password)
        {
            bool isValid = false;

            if (adminName == "admin" && password == "admin")
            {
                isValid = true;
            }


            return isValid;
        }


    }
}
