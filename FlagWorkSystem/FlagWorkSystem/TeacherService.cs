using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static FlagWorkSystem.classes;
using MaterialSkin.Controls;
using static FlagWorkSystem.StudentService;
using HZH_Controls.Controls;
using System.IO;
using OfficeOpenXml;


namespace FlagWorkSystem
{
    public class TeacherService
    {
        public int ID;

        //老师用户的构造
        public TeacherService(int teacherID)
        {
            ID = teacherID;
        }

        //查找学生表现详情
        public Personal_work Searchshow1(int id, string time)
        {
            Personal_work work = null; // 在循环外部定义 Personal_work 对象
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "select 当月排班次数,缺勤次数,旷班次数,实到次数 from 用户排班 where 用户ID = @id AND 月份 = @time"; // 添加 WHERE 子句
                                                                                                           // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@time", time);

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) // 使用 if 语句而不是 while
                    {
                        int total = Convert.ToInt32(reader["当月排班次数"]);
                        int drop = Convert.ToInt32(reader["旷班次数"]);
                        int leave = Convert.ToInt32(reader["缺勤次数"]);
                        int actualtime = Convert.ToInt32(reader["实到次数"]);
                        work = new Personal_work(time, total, drop, leave, actualtime);// 创建一个对象
                    }
                    reader.Close();
                    conn.Close();
                    return work; // 返回 Personal_work 对象
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查找学生升降旗情况错误:" + ex.Message);
                    return null;
                }

            }

        }

        public Personal_train Searchshow2(int id, string time)
        {
            Personal_train train = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "select 训练总数,请假次数,旷训次数,实到次数 from 用户训练 where 用户ID = @id AND 月份 = @time"; // 添加 WHERE 子句
                                                                                                         // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@time", time);

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) // 使用 if 语句而不是 while
                    {
                        int total = Convert.ToInt32(reader["训练总数"]);
                        int drop = Convert.ToInt32(reader["旷训次数"]);
                        int leave = Convert.ToInt32(reader["请假次数"]);
                        int actualtime = Convert.ToInt32(reader["实到次数"]);
                        train = new Personal_train(time, total, drop, leave, actualtime);// 创建一个对象
                    }
                    reader.Close();
                    conn.Close();
                    return train; // 返回 Personal_train 对象
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查找学生训练情况错误:" + ex.Message);
                    return null;
                }

            }

        }


        //数据库导入数据到listview
        public User[] ShowdataUser()
        {
            List<User> userList = new List<User>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    // 设置MySQL连接编码
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "select 用户ID,用户名,密码 from 用户";
                    // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["用户ID"]);
                        string name = reader["用户名"].ToString().Trim();
                        User user = new User(id, name, null);
                        userList.Add(user);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                    MaterialMessageBox.Show("导入错误:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return userList.ToArray();
        }


        //查询ID
        public User[] SearchID(string searchstring)
        {
            List<User> userList = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "select 用户ID,用户名 from 用户 where 用户ID like @searchstring";
                    // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@searchstring", searchstring);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["用户ID"]);
                        string name = reader["用户名"].ToString().Trim();
                        User user = new User(id, name, null);
                        userList.Add(user);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    MaterialMessageBox.Show("查询错误:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            return userList.ToArray();
        }

        //显示申请列表
        public Examine[] ShowdataApply()
        {
            List<Examine> ExamineList = new List<Examine>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "SELECT `查看状态`, `请假类型`, `审批ID`, `申请人`, `审批状态`, `学生发起时间`, `老师处理时间` FROM `审批` ORDER BY `查看状态` ASC";
                    // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int is_read = Convert.ToInt32(reader["查看状态"]);
                        int type = Convert.ToInt32(reader["请假类型"]);
                        int id = Convert.ToInt32(reader["审批ID"]);
                        int is_examine = Convert.ToInt32(reader["审批状态"]);
                        string applicant = reader["申请人"].ToString().Trim();
                        DateTime requeset_time = reader.GetDateTime(reader.GetOrdinal("学生发起时间"));//提交时间
                        DateTime examine_time = reader.GetDateTime(reader.GetOrdinal("老师处理时间"));//审核时间
                        Examine exam = new Examine(id, type, applicant, is_read, is_examine, requeset_time, examine_time); // 创建一个Examine对象
                        ExamineList.Add(exam);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                    MaterialMessageBox.Show("显示错误:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return ExamineList.ToArray();
        }


        //根据id寻找申请
        public Examine Searchexam(int id)
        {
            Examine exam = null; // 在循环外部定义 Examine 对象

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "select 请假类型, 申请人, 原因, 查看状态, 审批状态, 时间1, 替换人, 时间2, 学生发起时间 from 审批 where 审批ID = @id"; // 添加 WHERE 子句
                                                                                                                     // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id); // 添加参数
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // 使用 if 语句而不是 while
                    {
                        int type = Convert.ToInt32(reader["请假类型"]);
                        string applicant = reader["申请人"].ToString().Trim();
                        string reason = reader["原因"].ToString().Trim();
                        string replacement = reader["替换人"].ToString().Trim();
                        DateTime applicant_time = reader.GetDateTime(reader.GetOrdinal("时间1"));
                        DateTime? replacement_time = !reader.IsDBNull(reader.GetOrdinal("时间2")) ? reader.GetDateTime(reader.GetOrdinal("时间2")) : (DateTime?)null;
                        int is_read = Convert.ToInt32(reader["查看状态"]);
                        int is_examine = Convert.ToInt32(reader["审批状态"]);
                        DateTime requeset_time = reader.GetDateTime(reader.GetOrdinal("学生发起时间"));
                        exam = new Examine(id, type, applicant, reason, applicant_time, is_read, is_examine, replacement, replacement_time, requeset_time);// 创建一个Examine对象
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                    MaterialMessageBox.Show("寻找申请错误:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return exam; // 返回 Examine 对象
        }


        //更改审批数据
        public void Changeexam(int approvalId, int newApprovalStatus, int newReadStatus)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE 审批 SET 审批状态 = @newApprovalStatus, 查看状态 = @newReadStatus, 老师处理时间 = @newrequeset_time WHERE 审批ID = @approvalId";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@newApprovalStatus", newApprovalStatus);
                    command.Parameters.AddWithValue("@newReadStatus", newReadStatus);
                    command.Parameters.AddWithValue("@approvalId", approvalId);
                    command.Parameters.AddWithValue("@newrequeset_time", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   
                    MaterialMessageBox.Show("更改错误:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        //修改总训练中的当日情况
        //取消当日训练
        public void CancelTraing(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE 总训练 SET 是否取消=1 WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("取消训练错误:" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //修改总训练的当日情况以及用户训练
        //登记旷训学生
        public void RecordNoTrainingStudent(string[] drop_list, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string dropusers = "";
                    if (drop_list == null)
                    {
                        dropusers = " ";
                    }
                    else
                    {
                        dropusers = drop_list[0];
                        for(int i = 1; i < drop_list.Length; i++)
                        {
                            dropusers += " " + drop_list[i];
                        }
                    }

                    connection.Open();
                    string query = "UPDATE 总训练 SET 旷训名单 =@dropusers WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@dropusers", dropusers);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    MaterialMessageBox.Show("登记旷训学生成功");

                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("登记旷训学生错误:" + ex.Message);
                    connection.Close();
                   
                }
            }
        }

        //查看总训练中的某日情况(可根据界面显示需求分多个函数返回不同属性)
        public List<Trainning_schedule> QueryTrainingCondition(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<Trainning_schedule> schedules = new List<Trainning_schedule>();
                    connection.Open();
                    string query = "SELECT 日期,是否取消,是否训练,旷训名单 FROM 总训练 WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Trainning_schedule now = new Trainning_schedule(reader.GetDateTime(0),reader.GetBoolean(1), reader.GetBoolean(2), reader.IsDBNull(3)?null:reader.GetString(3));
                        schedules.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    return schedules;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询训练情况错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        //根据总训练中的旷训名单查询用户中的旷训名单
        public List<User> QueryDropUsers(string dropusers)
        {
           
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<User> users = new List<User>();
                    connection.Open();
                    string[] drop_list = dropusers.Split(' ');
                    if (drop_list == null)
                    {
                        return null;
                    }

                    // 创建查询命令构建器和参数列表
                    StringBuilder query = new StringBuilder("SELECT 用户ID,用户名 FROM 用户 WHERE 用户名 IN (");
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    // 为每个用户名创建一个命名参数
                    for (int i = 0; i < drop_list.Length; i++)
                    {
                        query.Append("@user" + i);
                        if (i < drop_list.Length - 1)
                        {
                            query.Append(",");
                        }
                        parameters.Add(new MySqlParameter("@user" + i, drop_list[i]));
                    }

                    query.Append(")");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                    // 添加参数到命令对象
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["用户ID"]);
                        string name = reader["用户名"].ToString().Trim();
                        User user = new User(id, name, null);
                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                    return users;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询到训名单错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }


        }

        //根据总训练中的旷训名单查询用户中的到训名单
        public List<User> QueryComeUsers(string dropusers)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<User> users = new List<User>();
                    connection.Open();
                    string[] drop_list = dropusers.Split(' ');

                    // 创建查询命令构建器和参数列表
                    StringBuilder query = new StringBuilder("SELECT 用户ID,用户名 FROM 用户 WHERE 用户名 NOT IN (");
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    // 为每个用户名创建一个命名参数
                    for (int i = 0; i < drop_list.Length; i++)
                    {
                        query.Append("@user" + i);
                        if (i < drop_list.Length - 1)
                        {
                            query.Append(",");
                        }
                        parameters.Add(new MySqlParameter("@user" + i, drop_list[i]));
                    }

                    query.Append(")");
                    MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);

                    // 添加参数到命令对象
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["用户ID"]);
                        string name = reader["用户名"].ToString().Trim();
                        User user = new User(id, name, null);
                        users.Add(user);
                    }
                    reader.Close();
                    connection.Close();
                    return users;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询到训名单错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
            
        }
        //计算未参训人数
        public float CountDropNum(string dropusers)
        {
            try
            {
                float count = 0;

                if(dropusers != " "& dropusers != "" & dropusers != null)
                {
                    string[] drop_list = dropusers.Split(' ');
                    count = drop_list.Length;
                }


                return count;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("计算未参训人数错误：" + ex.Message);
                return -1;
            }
        }
        
        //计算参训人数
        public float CountComeNum(string dropusers)
        {
            try
            {
                float count = CountUserNum();

                count -= CountDropNum(dropusers);

                return count;
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show("计算参训人数错误：" + ex.Message);
                return -1;
            }
        }


        //计算用户中的用户总个数
        static public int CountUserNum()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    int count = 0;
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM 用户";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                    return count;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询用户总个数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }


        //查看总排班中的某日情况
        public static Working_schedule QueryFlagCondition(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<Working_schedule> schedules = new List<Working_schedule>();
                    connection.Open();
                    string query="SELECT 日期,成员1,成员2,成员3,是否取消,文字,图片,旷训人名 FROM 总排班 WHERE 日期=@time";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    if(reader.HasRows==false)
                        return null;
                    while(reader.Read())
                    {
                        Working_schedule now=new Working_schedule(reader.GetDateTime(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetBoolean(4),reader.IsDBNull(5)?null:reader.GetString(5),reader.IsDBNull(6)?null:reader.GetString(6),reader.IsDBNull(7)?null:reader.GetString(7));
                        schedules.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    if (schedules.Count > 0)
                        return schedules[0];
                    else// 处理不存在记录的情况，例如返回 null 或抛出异常
                        return null;
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("查询排班错误:"+ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        //导出所有排班
        public static void ExportScheduleToExcel()
        {
           
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("总排班");
                        // 添加表头
                        worksheet.Cells[1, 1].Value = "日期";
                        worksheet.Cells[1, 2].Value = "成员1";
                        worksheet.Cells[1, 3].Value = "成员2";
                        worksheet.Cells[1, 4].Value = "成员3";
                        worksheet.Cells[1, 5].Value = "是否取消";
                        worksheet.Cells[1, 6].Value = "旷训人名";
                        int row = 2; // 从第二行开始写入数据
                        string query = "SELECT 日期, 成员1, 成员2, 成员3, 是否取消,  旷训人名 FROM 总排班";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(0);
                            string member1 = reader.GetString(1);
                            string member2 = reader.GetString(2);
                            string member3 = reader.GetString(3);
                            bool isCancelled = reader.GetBoolean(4);
                            string absentee = reader.IsDBNull(5) ? null : reader.GetString(7);

                            worksheet.Cells[row, 1].Value = date.ToString("yyyy-MM-dd");
                            worksheet.Cells[row, 2].Value = member1;
                            worksheet.Cells[row, 3].Value = member2;
                            worksheet.Cells[row, 4].Value = member3;
                            worksheet.Cells[row, 5].Value = isCancelled;
                            worksheet.Cells[row, 6].Value = absentee;
                            row++;
                        }
                        reader.Close();

                        // 弹出保存文件对话框
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel文件 (*.xlsx)|*.xlsx";
                        saveFileDialog.Title = "保存Excel文件";
                        saveFileDialog.FileName = "总排班.xlsx";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // 保存Excel文件
                            FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                            excelPackage.SaveAs(excelFile);
                          

                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("导出Excel发生错误: " + ex.Message);
                throw;
            }
        }
    







        //修改总排班中的当日情况
        //取消当日排班
        public void CancelFlag(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="UPDATE 总排班 SET 是否取消=TRUE WHERE 日期=@time";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("取消排班错误:"+ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        //添加评论
        static public void AddComment(DateTime time,string text)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="UPDATE 总排班 SET 文字=@text WHERE 日期=@time";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    cmd.Parameters.AddWithValue("@text",text);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("添加文字错误:"+ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        //添加照片记录
        public static void AddPicture(DateTime time,string photo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="UPDATE 总排班 SET 图片=@photo WHERE 日期=@time";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    cmd.Parameters.AddWithValue("@photo",photo);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("添加图片错误:"+ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        

        //修改总排班的当日情况以及用户排班
        //登记旷班学生
        static public void RecordNoFlagStudent(DateTime time,String name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="SELECT 旷训人名 FROM 总排班 WHERE 日期=@time";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    string text="";
                    while (reader.Read())
                    {
                        text=reader.IsDBNull(0)?null:reader.GetString(0);
                        text+=name+" ";
                    }
                    reader.Close();
                    query="UPDATE 总排班 SET 旷训人名=@Name WHERE 日期=@time";
                    cmd=new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time",time);
                    cmd.Parameters.AddWithValue("@Name",text);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("添加旷训人员错误:"+ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //获取用户已完成的排班次数
        static private Dictionary<int,int> GetDoneFlag()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Dictionary<int,int> tot= new Dictionary<int,int>();
                try
                {
                    connection.Open();
                    List<int> users = new List<int>();
                    string query="SELECT 用户ID FROM 用户";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    while(reader.Read())
                        users.Add(reader.GetInt32(0));
                    reader.Close();
                    foreach (int user in users)
                    {
                        tot[user]=0;
                        query="SELECT 当月排班次数 FROM 用户排班 WHERE 用户ID=@ID";
                        cmd=new MySqlCommand(query,connection);
                        cmd.Parameters.AddWithValue("@ID",user);
                        reader=cmd.ExecuteReader();
                        while(reader.Read())
                            tot[user]+=reader.GetInt32(0);
                        reader.Close();
                    }
                    connection.Close();
                    return tot;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("读取全体排班错误:"+ex.Message);
                    connection.Close() ;
                    return null;
                }
            }
        }

        //插入当日排班
        static private void AddFlag(DateTime date,string user1,string user2,string user3)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="INSERT INTO 总排班(日期,成员1,成员2,成员3) VALUES (@date,@user1,@user2,@user3)";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@date",date);
                    cmd.Parameters.AddWithValue("@user1",user1);
                    cmd.Parameters.AddWithValue("@user2",user2);
                    cmd.Parameters.AddWithValue("@user3",user3);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("插入新排班错误："+ex.Message);
                }
                finally { connection.Close(); }
            }
        }

        //插入用户当月排班
        public static void AddUserFlag(string date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<int> users = new List<int>();
                    string query="SELECT 用户ID FROM 用户";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    while(reader.Read())
                        users.Add(reader.GetInt32(0));
                    reader.Close();
                    foreach (int user in users)
                    {
                        query="INSERT INTO 用户排班(用户ID,月份) VALUES (@ID,@date)";
                        cmd= new MySqlCommand(query,connection);
                        cmd.Parameters.AddWithValue("@ID",user);
                        cmd.Parameters.AddWithValue("@date",date);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex) { MaterialMessageBox.Show("更新个人排班失败:"+ex.Message);}
                finally { connection.Close(); }
            }
        }
        
        //生成下个月总排班
        static public void GenerateFlag()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="SELECT * FROM 空余时间";
                    MySqlCommand cmd=new MySqlCommand(query, connection);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    Dictionary<int,Free_time> free=new Dictionary<int, Free_time>();

                    while(reader.Read())//某个人的空闲时间
                    {
                        bool[] tmp=new bool[7];
                        tmp[1]=reader.GetBoolean(1);
                        tmp[2]=reader.GetBoolean(2);
                        tmp[3]=reader.GetBoolean(3);
                        tmp[4]=reader.GetBoolean(4);
                        tmp[5]=reader.GetBoolean(5);
                        tmp[6]=reader.GetBoolean(6);
                        Free_time now=new Free_time(reader.GetInt32(0),tmp);
                        free[reader.GetInt32(0)]=now;
                    }
                    reader.Close();
                    connection.Close();

                    List<DayOfWeek> daysPerWeekday = new List<DayOfWeek>
                    {
                        DayOfWeek.Monday,DayOfWeek.Tuesday,DayOfWeek.Wednesday,DayOfWeek.Thursday,
                        DayOfWeek.Friday,DayOfWeek.Saturday,DayOfWeek.Sunday
                    };
                    DateTime currentDate = DateTime.Now;
                    DateTime nextMonth=currentDate.AddMonths(1);
                    int nextYear = nextMonth.Year;
                    int nextMonthNumber = nextMonth.Month;
                    DateTime firstDayOfNextMonth = new DateTime(nextYear, nextMonthNumber, 1);
                    DateTime lastDayOfNextMonth = firstDayOfNextMonth.AddMonths(1).AddDays(-1);

                    int totalStudent=CountUserNum();
                    Dictionary<int,int> completedAssignments = GetDoneFlag();

                    var sortedPeople=completedAssignments.OrderBy(kv =>kv.Value);

                    // 分配排班
                    foreach (var weekday in daysPerWeekday)
                    {
                        DayOfWeek dayOfWeek = weekday;
                        int dayNumber=(int)dayOfWeek;

                        for(DateTime date=firstDayOfNextMonth;date<=lastDayOfNextMonth;date=date.AddDays(1))
                        {
                            if(date.DayOfWeek!=dayOfWeek)
                                continue;
                            if(date.DayOfWeek==DayOfWeek.Sunday)
                                continue;
                            sortedPeople=completedAssignments.OrderBy(kv =>kv.Value);
                            string[] names=new string[3];
                            int[] tmp=new int[3];
                            List<string> usernames=new List<string>();
                            int top=0;
                            foreach (var person in sortedPeople)
                            {
                                if (free[person.Key].is_free[dayNumber]==false)
                                    continue;
                                usernames=QueryUsernameByID(person.Key);
                                tmp[top]=person.Key;
                                completedAssignments[person.Key]++;
                                names[top]=usernames[0];
                                top++;
                                if(top==3)
                                    break;
                            }
                            AddFlag(date, names[0], names[1], names[2]);
                        }
                    }
                    AddUserFlag(nextMonth.Year.ToString()+"年"+nextMonth.Month.ToString()+"月");
                    //MaterialMessageBox.Show("生成下月排班表成功！");
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show ("生成排班表错误:"+ex.Message);
                    connection.Close ();
                }
            }
        }

        //更新所有学生的用户排班
        public void UpdateAllUserWork(DateTime time)
        {
            List<int> IDs = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 用户ID FROM 用户";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        IDs.Add(ID);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询所有学生ID错误:" + ex.Message);
                    connection.Close();
                }
            }

            foreach (int ID in IDs)
            {
                StudentService studentService = new StudentService(ID);
                studentService.UpdateUserWork(ID, time);
            }

        }



        //更新所有学生的用户训练
        public void UpdateAllUserTraining(DateTime time)
        {
            List<int> IDs = new List<int>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 用户ID FROM 用户";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        IDs.Add(ID);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询所有学生ID错误:" + ex.Message);
                    connection.Close();
                }
            }

            foreach (int ID in IDs)
            {
                StudentService studentService = new StudentService(ID);
                studentService.UpdateUserTraining(ID, time);
            }

        }

        //向通知表中插入通知所有学生取消今日训练的消息
        public void InsertTrainCancelMessages()
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 用户名 FROM 用户";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        names.Add(name);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询所有学生姓名错误:" + ex.Message);
                    connection.Close();
                }
            }

            int ID = 0;
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(通知ID) FROM 通知";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询目前最大的通知ID错误:" + ex.Message);
                    connection.Close();
                }
            }

            for(int i = 0; i < names.Count(); i++)
            {
                ID++;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO 通知(通知ID,通知事件,通知人) VALUES (@ID,'今日训练因特殊原因取消',@name)";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@name", names[i]);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show("插入通知错误:" + ex.Message);
                        connection.Close();
                    }
                }
               
            }

        }
        //向通知表中插入通知要升旗的学生取消今日升降旗的消息
        public void InsertFlagCancelMessages(DateTime time)
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT 成员1,成员2,成员3 FROM 总排班 WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name1 = reader.GetString(0);
                        names.Add(name1);
                        string name2 = reader.GetString(1);
                        names.Add(name2);
                        string name3 = reader.GetString(2);
                        names.Add(name3);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询今日需升降旗的学生姓名错误:" + ex.Message);
                    connection.Close();
                }
            }

            int ID = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(通知ID) FROM 通知";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询目前最大的通知ID错误:" + ex.Message);
                    connection.Close();
                }
            }

            for (int i = 0; i < names.Count(); i++)
            {
                ID++;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO 通知(通知ID,通知事件,通知人) VALUES (@ID,'今日升降旗因特殊原因取消',@name)";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@name", names[i]);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show("插入通知错误:" + ex.Message);
                        connection.Close();
                    }
                }

            }
        }

        //查询用户排班&用户训练(可根据界面显示需求分多个函数返回不同属性)
        //返回所有
        public void QueryAllFTPerformance()
        {

        }
        


        //查询审批
        //返回所有
        public void QueryRequests()
        {

        }
        //查询某一申请
        public void QueryRequestByID()
        {

        }

        //根据老师ID查询老师姓名
        public List<string> QueryTeachernameByID(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<string> names = new List<string>();
                    connection.Open();
                    string query = "SELECT 用户名 FROM 老师 WHERE 用户ID=@ID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        names.Add(name);
                    }
                    reader.Close();
                    connection.Close();
                    return names;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("根据老师ID查询老师姓名错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        //添加当日训练
        private static void AddTrainning(DateTime date,bool is_train)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="INSERT INTO 总训练(日期,是否训练) VALUES (@date,@is_train)";
                    MySqlCommand cmd = new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@date",date);
                    cmd.Parameters.AddWithValue("@is_train",is_train);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) { MaterialMessageBox.Show("插入训练表错误:"+ex.Message); }
                finally { connection.Close(); }
            }
        }

        //添加用户本月训练
        static public void AddUserTrain(string date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<int> users = new List<int>();
                    string query="SELECT 用户ID FROM 用户";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    while(reader.Read())
                        users.Add(reader.GetInt32(0));
                    reader.Close();
                    foreach (int user in users)
                    {
                        query="INSERT INTO 用户训练(用户ID,月份) VALUES (@ID,@date)";
                        cmd= new MySqlCommand(query,connection);
                        cmd.Parameters.AddWithValue("@ID",user);
                        cmd.Parameters.AddWithValue("@date",date);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex) { MaterialMessageBox.Show("更新个人训练失败:"+ex.Message);}
                finally { connection.Close(); }
            }
        }
        
        //生成下月训练表
        public static void GenerateTrainning()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime nextMonth=currentDate.AddMonths(1);
                int nextYear = nextMonth.Year;
                int nextMonthNumber = nextMonth.Month;
                DateTime firstDayOfNextMonth = new DateTime(nextYear, nextMonthNumber, 1);
                DateTime lastDayOfNextMonth = firstDayOfNextMonth.AddMonths(1).AddDays(-1);
                for(DateTime date=firstDayOfNextMonth;date<=lastDayOfNextMonth;date=date.AddDays(1))
                {
                    if(date.DayOfWeek==DayOfWeek.Sunday||date.DayOfWeek==DayOfWeek.Tuesday||date.DayOfWeek==DayOfWeek.Thursday||date.DayOfWeek==DayOfWeek.Saturday)
                        AddTrainning(date,false);
                    else
                        AddTrainning(date,true);
                }
                AddUserTrain(nextMonth.Year.ToString()+"年"+nextMonth.Month.ToString()+"月");
                //MaterialMessageBox.Show("生成下月训练表成功!");
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show("生成训练表错误:"+ex.Message);
            }
        }

        public static List<TimeLineItem> GetFlagTimes(DateTime lim_date)
        {
            try
            {
                List<TimeLineItem> items = new List<TimeLineItem>();
                List<DateTime> dates=GetFlags(lim_date);
                foreach(DateTime date in dates)
                {
                    string tit=date.ToString("yyyy-MM-dd");
                    if(date>DateTime.Now.Date)
                        tit+="[未开始]";
                    string det="7:00 升旗"+Environment.NewLine+"18:00 降旗"+Environment.NewLine;
                    Working_schedule ws=QueryFlagCondition(date);
                    det+="值班人员："+ws.user1+" "+ws.user2+" "+ws.user3+Environment.NewLine;
                    det+="旷班人员:"+ws.drop_users;
                    TimeLineItem item=new TimeLineItem();
                    item.Title=tit;item.Details=det;
                    items.Add(item);
                }
                //MessageBox.Show("..."+dates.Count.ToString()+"```"+items.Count.ToString());
                return items;
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show("读取排班信息错误："+ex.Message);
                return null;
            }
        }

        private static List<DateTime> GetFlags(DateTime date)
        {
            using(MySqlConnection connection= new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<DateTime> dates=new List<DateTime>();
                    string query="select 日期 from 总排班 where 日期<=@date order by 日期 desc";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@date",date);
                    MySqlDataReader reader= cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        DateTime now=reader.GetDateTime(0);
                        dates.Add(now);
                    }
                    reader.Close();
                    return dates;
                }
                catch(Exception ex)
                {
                    MaterialMessageBox.Show("获取总排班失败:"+ex.Message);
                    return null;
                }
                finally { connection.Close(); }
            }
        }

        public static void AddMsgToALL()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    List<string> users = new List<string>();
                    string query="SELECT 用户名 FROM 用户";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    while(reader.Read())
                        users.Add(reader.GetString(0));
                    reader.Close();
                    string msg="下月排班已公布，请尽快查看个人排班信息。";
                    foreach (string user in users)
                    {
                        query="INSERT INTO 通知(通知人,通知事件) VALUES (@user,@msg)";
                        cmd= new MySqlCommand(query,connection);
                        cmd.Parameters.AddWithValue("@user",user);
                        cmd.Parameters.AddWithValue("@msg",msg);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex) { MaterialMessageBox.Show("通知用户查看下月排班错误:"+ex.Message);}
                finally { connection.Close(); }
            }
        }

    }
}
