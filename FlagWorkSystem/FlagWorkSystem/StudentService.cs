using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public class StudentService
    {

        public int ID;


        //学生用户的构造
        public StudentService(int studentID)
        {
            ID = studentID;

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

        //根据学生ID查询学生姓名
        static public List<string> QueryUsernameByID(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<string> names = new List<string>();
                    connection.Open();
                    string query = "SELECT 用户名 FROM 用户 WHERE 用户ID=@ID";
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
                    MaterialMessageBox.Show("根据学生ID查询学生姓名错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }
      
        //向审批中添加本人升降旗申请
        public void AddFlagRequest(int type, string applicant, string reason, DateTime applicant_time, string replacement, DateTime? replacement_time, DateTime requeset_time)
        {
            int id;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand countCmd = new MySqlCommand("SELECT COUNT(*) FROM 审批", conn);
                id = Convert.ToInt32(countCmd.ExecuteScalar()) + 1;
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO 审批 (审批ID, 请假类型, 申请人, 原因, 时间1, 替换人, 时间2, 学生发起时间) VALUES (@审批ID, @请假类型, @申请人, @原因, @时间1, @替换人, @时间2, @学生发起时间)";

                    MySqlCommand insertCmd = new MySqlCommand(sql, conn);
                    insertCmd.Parameters.AddWithValue("@审批ID", id);
                    insertCmd.Parameters.AddWithValue("@请假类型", type);
                    insertCmd.Parameters.AddWithValue("@申请人", applicant);
                    insertCmd.Parameters.AddWithValue("@原因", reason);
                    insertCmd.Parameters.AddWithValue("@时间1", applicant_time);
                    insertCmd.Parameters.AddWithValue("@替换人", replacement);
                    insertCmd.Parameters.AddWithValue("@时间2", replacement_time);
                    insertCmd.Parameters.AddWithValue("@学生发起时间", requeset_time);
                    insertCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("添加本人升降旗申请错误:" + ex.Message);
                }


            }
            //MessageBox.Show("申请已提交！");
        }

        //向审批中添加本人训练申请
        public void AddTrainingRequest(string applicant, string reason, DateTime applicant_time, string replacement, DateTime requeset_time)
        {
            int id;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand countCmd = new MySqlCommand("SELECT COUNT(*) FROM 审批", conn);
                id = Convert.ToInt32(countCmd.ExecuteScalar()) + 1;
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO 审批 (审批ID, 请假类型, 申请人, 原因, 时间1, 学生发起时间) VALUES (@审批ID, @请假类型, @申请人, @原因, @时间1, @学生发起时间)";
                    MySqlCommand insertCmd = new MySqlCommand(sql, conn);
                    insertCmd.Parameters.AddWithValue("@审批ID", id);
                    insertCmd.Parameters.AddWithValue("@请假类型", 2);
                    insertCmd.Parameters.AddWithValue("@申请人", applicant);
                    insertCmd.Parameters.AddWithValue("@原因", reason);
                    insertCmd.Parameters.AddWithValue("@时间1", applicant_time);
                    insertCmd.Parameters.AddWithValue("@学生发起时间", requeset_time);
                    insertCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("添加本人训练申请错误:" + ex.Message);
                }
            }

            //MessageBox.Show("申请已提交！");

        }


        //查询总排班中的本人排班（本人班次、本人旷班）

        //计算总排班中的某用户截至到某日前一天的此月要升旗总数
        public int CountUserWorkDayNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    int comeNum = 0;

                    string username = "";
                    List<string> names = QueryUsernameByID(ID);

                    foreach (string name in names)
                    {
                        username = name;
                    }

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 总排班 WHERE 日期<@time AND 日期>=@startTime AND 是否取消 = 0 AND (成员1=@name OR 成员2=@name OR 成员3=@name)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@name", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comeNum = reader.GetInt32(0);

                    }
                    reader.Close();
                    connection.Close();
                    return comeNum;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算总排班中的某用户截至到某日前一天的此月要升旗总数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }
        //计算总排班中的某用户截至到某日前一天的此月未到班次数
        public int CountUserWorkDropNum(int ID, DateTime time)
        {

            try
            {
                int dropNum = 0;

                dropNum += CountUserWorkAskNum(ID, time);
                dropNum -= CountUserWorkNegNum(ID, time);

                return dropNum;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("计算总排班中的某用户截至到某日前一天的此月未到班次数错误:" + ex.Message);

                return -1;
            }

        }
        //计算总排班中的某用户截至到某日前一天的此月到班总数
        public int CountUserWorkComeNum(int ID, DateTime time)
        {
            try
            {
                int dayNum = 0;

                dayNum += CountUserWorkDayNum(ID, time);
                dayNum -= CountUserWorkDropNum(ID, time);

                return dayNum;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("计算总排班中的某用户截至到某日前一天的此月到班总数错误:" + ex.Message);

                return -1;
            }
        }
        //计算审批中的某用户截至到某日前一天的此月替班总数
        public int CountUserWorkAskNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    string username = "";
                    List<string> names = QueryUsernameByID(ID);

                    foreach (string name in names)
                    {
                        username = name;
                    }


                    int leaveCount = 0;
                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 审批 WHERE 时间1 < @time AND 时间1 >= @startTime AND 申请人 = @name AND 请假类型 = 1 AND 审批状态=1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@name", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        leaveCount = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                    return leaveCount;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算审批中的某用户截至到某日前一天的此月替班总数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }
        
        //计算某用户截至到某日前一天的此月旷班次数
        public int CountUserWorkNegNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    int dropNum = 0;

                    string username = "";
                    List<string> names = QueryUsernameByID(ID);

                    foreach (string name in names)
                    {
                        username = name;
                    }

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 总排班 WHERE 日期<@time AND 日期>=@startTime AND 是否取消 = 0 AND locate(@name, 旷训人名) > 0 AND (成员1=@name OR 成员2=@name OR 成员3=@name)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@name", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropNum = reader.GetInt32(0);

                    }
                    reader.Close();
                    connection.Close();
                    return dropNum;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算某用户截至到某日前一天的此月旷班次数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }
        

        //更新用户排班中的某用户某月的信息
        public void UpdateUserWork(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();

                    int dayNum = CountUserWorkDayNum(ID, time);
                    int comeNum = CountUserWorkComeNum(ID, time);
                    int dropNum = CountUserWorkDropNum(ID, time);
                    int negNum = CountUserWorkNegNum(ID, time);


                    connection.Open();

                    string query = "UPDATE 用户排班 SET 当月排班次数=@dayNum,缺勤次数=@dropNum,旷班次数=@negNum,实到次数=@comeNum WHERE 用户ID=@ID AND 月份=@yearMonth";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@dayNum", dayNum);
                    cmd.Parameters.AddWithValue("@comeNum", comeNum);
                    cmd.Parameters.AddWithValue("@dropNum", dropNum);
                    cmd.Parameters.AddWithValue("@negNum", negNum);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@yearMonth", yearMonth);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("更新用户排班中的某用户某月的信息错误:" + ex.Message);
                    connection.Close();
                }
            }
        }

        //申请显示
        public Examine[] QueryFlagSchedule(int id)
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
                    string sql = "select 请假类型, 申请人, 原因, 审批状态, 时间1, 替换人, 时间2, 学生发起时间, 老师处理时间 from 审批 where 审批ID = @id"; // 删除多余的逗号
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
                        int is_examine = Convert.ToInt32(reader["审批状态"]);
                        DateTime requeset_time = reader.GetDateTime(reader.GetOrdinal("学生发起时间"));
                        DateTime examine_time = reader.GetDateTime(reader.GetOrdinal("老师处理时间"));
                        Examine exam = new Examine(id, type, applicant, reason, applicant_time, is_examine, replacement, replacement_time, requeset_time, examine_time); // 创建一个Examine对象
                        ExamineList.Add(exam); // 将exam对象添加到ExamineList列表中
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // 在这里处理异常，可以记录日志或者采取其他适当的措施
                    Console.WriteLine("发生异常: " + ex.Message);
                }
            }
            return ExamineList.ToArray();
        }



        //查询总排班中某学生未来需要升降旗的日期
        public List<DateTime> QueryFtutureFlagDates(DateTime time, string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 日期 FROM 总排班 WHERE 日期>@time AND 是否取消 = 0 AND (成员1=@name OR 成员2=@name OR 成员3=@name)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime now = reader.GetDateTime(0);
                        dates.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    return dates;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询某学生未来需要升降旗的日期错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }
        //查询总排班中某学生某日是否需要升降旗
        public bool QueryTodayShallFlag(DateTime time, string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    bool shallWork = false;
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 是否取消,成员1,成员2,成员3 FROM 总排班 WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((!reader.GetBoolean(0)) && (reader.GetString(1) == name || reader.GetString(2) == name || reader.GetString(3) == name))
                        {
                            shallWork = true;
                        }


                    }
                    reader.Close();
                    connection.Close();
                    return shallWork;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询某人某日是否需要升降旗错误:" + ex.Message);
                    connection.Close();
                    return false;
                }
            }
        }

        //查询总排班中过去某学生需要升降旗的日期
        public List<DateTime> QueryPastFlagDates(DateTime time, string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 日期 FROM 总排班 WHERE 日期<@time AND 是否取消 = 0 AND (成员1=@name OR 成员2=@name OR 成员3=@name)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime now = reader.GetDateTime(0);
                        dates.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    return dates;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询某学生过去需要升降旗的日期错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        //查询总训练中的本人训练（“本人”训练、本人旷训）
        public void QueryTrainingSchedule()
        {

        }
        //查询总训练中未来需要训练的日期
        public List<DateTime> QueryFtutureTrainingDates(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 日期 FROM 总训练 WHERE 日期>@time AND 是否取消 = 0 AND 是否训练 = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime now = reader.GetDateTime(0);
                        dates.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    return dates;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询未来需要训练的日期错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }
        //查询总训练中某日是否需要训练
        public bool QueryTodayShallTrain(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    bool shallTrain = false;
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 是否取消,是否训练 FROM 总训练 WHERE 日期=@time";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((!reader.GetBoolean(0)) && reader.GetBoolean(1))
                        {
                            shallTrain = true;
                        }


                    }
                    reader.Close();
                    connection.Close();
                    return shallTrain;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询某日是否需要训练错误:" + ex.Message);
                    connection.Close();
                    return false;
                }
            }
        }

        //查询总训练中过去需要训练的日期
        public List<DateTime> QueryPastTrainingDates(DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<DateTime> dates = new List<DateTime>();
                    connection.Open();
                    string query = "SELECT 日期 FROM 总训练 WHERE 日期<@time AND 是否取消 = 0 AND 是否训练 = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime now = reader.GetDateTime(0);
                        dates.Add(now);
                    }
                    reader.Close();
                    connection.Close();
                    return dates;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("查询过去需要训练的日期错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }



        //查询用户排班中的某月本人排班表现
        public void QueryFlagPerformance()
        {

        }


        //查询用户训练中的某月本人训练表现
        public void QueryTraingPerformance()
        {

        }

        //计算总训练中的某用户截至到某日前一天的此月要训总数
        public int CountUserTrainDayNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    int comeNum = 0;

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 总训练 WHERE 日期<@time AND 日期>=@startTime AND 是否取消 = 0 AND 是否训练 = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comeNum = reader.GetInt32(0);

                    }
                    reader.Close();
                    connection.Close();
                    return comeNum;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算总训练中的某用户截至到某日前一天的此月要训总数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }
        //计算总训练中的某用户截至到某日前一天的此月未到训次数
        public int CountUserTrainDropNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    int dropNum = 0;

                    string username = "";
                    List<string> names = QueryUsernameByID(ID);

                    foreach (string name in names)
                    {
                        username = name;
                    }

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 总训练 WHERE 日期<@time AND 日期>=@startTime AND 是否取消 = 0 AND 是否训练 = 1 AND locate(@username, 旷训名单 ) > 0";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dropNum = reader.GetInt32(0);

                    }
                    reader.Close();
                    connection.Close();
                    return dropNum;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算总训练中的某用户截至到某日前一天的此月未到训次数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }
        //计算总训练中的某用户截至到某日前一天的此月到训总数
        public int CountUserTrainComeNum(int ID, DateTime time)
        {
            try
            {
                int dayNum = 0;

                dayNum += CountUserTrainDayNum(ID, time);
                dayNum -= CountUserTrainDropNum(ID, time);

                return dayNum;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("计算总训练中的某用户截至到某日前一天的此月到训总数错误:" + ex.Message);

                return -1;
            }
        }
        //计算审批中的某用户截至到某日前一天的此月请假总数
        public int CountUserTrainAskNum(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    string username = "";
                    List<string> names = QueryUsernameByID(ID);

                    foreach (string name in names)
                    {
                        username = name;
                    }


                    int leaveCount = 0;
                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();
                    yearMonth += "1日";
                    DateTime startTime = DateTime.Parse(yearMonth);
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM 审批 WHERE 时间1 < @time AND 时间1 >= @startTime AND 申请人 = @name AND 请假类型 = 2 AND 审批状态=1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", time);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@name", username);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        leaveCount = reader.GetInt32(0);
                    }
                    reader.Close();
                    connection.Close();
                    return leaveCount;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("计算审批中的某用户截至到某日前一天的此月请假总数错误:" + ex.Message);
                    connection.Close();
                    return -1;
                }
            }
        }

        //计算某用户截至到某日前一天的此月旷训次数
        public int CountUserTrainNegNum(int ID, DateTime time)
        {
            try
            {
                int negNum = 0;

                negNum += CountUserTrainDropNum(ID, time);
                negNum -= CountUserTrainAskNum(ID, time);

                return negNum;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("计算某用户截至到某日前一天的此月旷训次数错误:" + ex.Message);

                return -1;
            }
        }

        //更新用户训练中的某用户某月的信息
        public void UpdateUserTraining(int ID, DateTime time)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    string yearMonth = time.GetDateTimeFormats('y')[0].ToString();

                    int dayNum = CountUserTrainDayNum(ID, time);
                    int comeNum = CountUserTrainComeNum(ID, time);
                    int askNum = CountUserTrainAskNum(ID, time);
                    int negNum = CountUserTrainNegNum(ID, time);


                    connection.Open();

                    string query = "UPDATE 用户训练 SET 训练总数=@dayNum,请假次数=@askNum,旷训次数=@negNum,实到次数=@comeNum WHERE 用户ID=@ID AND 月份=@yearMonth";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@dayNum", dayNum);
                    cmd.Parameters.AddWithValue("@comeNum", comeNum);
                    cmd.Parameters.AddWithValue("@askNum", askNum);
                    cmd.Parameters.AddWithValue("@negNum", negNum);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@yearMonth", yearMonth);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("更新用户训练中的某用户某月的信息错误:" + ex.Message);
                    connection.Close();
                }
            }
        }







        //查询申请
        public List<Examine> GetApprovalData(int ID)
        {
            List<Examine> ExamineList = new List<Examine>();
            // 根据学生ID在用户表中查询用户名
            List<string> usernames = QueryUsernameByID(ID);

            if (usernames.Count == 0)
            {
                return ExamineList; // 如果未找到用户名，则返回空列表
            }

            string username = usernames[0];

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // 设置MySQL连接编码
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SET NAMES utf8";
                    cmd.ExecuteNonQuery();
                    string sql = "SELECT 学生发起时间, 请假类型, 老师处理时间, 审批状态,审批ID FROM 审批 WHERE 申请人 = @Username";
                    // 使用MySqlCommand
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@Username", username);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime requeset_time = reader.GetDateTime(reader.GetOrdinal("学生发起时间"));//提交时间
                        int type = Convert.ToInt32(reader["请假类型"]);
                        DateTime examine_time = reader.GetDateTime(reader.GetOrdinal("老师处理时间"));//审核时间
                        int is_examine = Convert.ToInt32(reader["审批状态"]);
                        int id = Convert.ToInt32(reader["审批ID"]);
                        Examine exam = new Examine(type, id, is_examine, requeset_time, examine_time); // 创建一个Examine对象
                        ExamineList.Add(exam);
                    }

                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("发生异常: " + ex.Message);
                }
            }

            // 对ExamineList按时间逆序
            ExamineList = ExamineList.OrderByDescending(x => x.requeset_time).ToList();


            return ExamineList;
        }









        //向审批中添加本人申请
        public void AddRequest()
        {

        }
        //根据学生ID查询学生密码
        public List<string> QueryPasswordByID(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<string> passwords = new List<string>();
                    connection.Open();
                    string query = "SELECT 密码 FROM 用户 WHERE 用户ID=@ID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string password = reader.GetString(0);
                        passwords.Add(password);
                    }
                    reader.Close();
                    connection.Close();
                    return passwords;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("根据学生ID查询学生密码错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }
        }


        //修改用户中的本人信息

        public void EditInformation(int ID, string newUsername, string newPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    // 查询用户的原密码
                    cmd.CommandText = $"SELECT `密码` FROM `{"用户"}` WHERE `用户ID` = @ID";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    string oldPassword = cmd.ExecuteScalar()?.ToString();

                    if (oldPassword == null)
                    {
                        MaterialMessageBox.Show("用户ID不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (newPassword == oldPassword)
                    {
                        MaterialMessageBox.Show("新密码不能与原密码相同！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 更新用户表
                    cmd.CommandText = $"UPDATE `{"用户"}` SET `用户名` = @newUsername, `密码` = @newPassword WHERE `用户ID` = @ID";
                    cmd.Parameters.Clear(); // 清除参数集合
                    cmd.Parameters.AddWithValue("@newUsername", newUsername);
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MaterialMessageBox.Show("修改用户成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MaterialMessageBox.Show("修改用户失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // 在这里处理异常，可以记录日志或者采取其他适当的措施
                    Console.WriteLine("发生异常: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        // 修改空余时间中的本人空余时间
        public void EditFreeTime(bool[] freeTime)
        {
            // 检查是否在排班结束的前三天内
            if (IsWithinThreeDaysBeforeScheduleEnd())
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = conn.CreateCommand();

                        // 检查用户ID是否存在
                        cmd.CommandText = $"SELECT * FROM `用户` WHERE `用户ID` = @ID";
                        cmd.Parameters.AddWithValue("@ID", ID);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            reader.Close(); // 关闭数据读取器
                            MaterialMessageBox.Show("用户ID不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        reader.Close(); // 关闭数据读取器

                        // 更新空余时间表
                        cmd.CommandText = $"UPDATE `空余时间` SET `周一` = @周一, `周二` = @周二, `周三` = @周三, `周四` = @周四, `周五` = @周五, `周六` = @周六 WHERE `用户ID` = @ID";
                        cmd.Parameters.Clear(); // 清除参数集合
                        cmd.Parameters.AddWithValue("@周一", freeTime[0] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@周二", freeTime[1] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@周三", freeTime[2] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@周四", freeTime[3] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@周五", freeTime[4] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@周六", freeTime[5] ? "true" : "false");
                        cmd.Parameters.AddWithValue("@ID", ID);

                        int rows = cmd.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show("修改空余时间错误:" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MaterialMessageBox.Show("非修改时间，无法修改空余时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 检查是否在排班结束的前三天内的方法
        public bool IsWithinThreeDaysBeforeScheduleEnd()
        {
            // 查询总排班表，获取日期最晚的排班结束日期
            DateTime? scheduleEndDate = GetScheduleEndDate();

            // 检查是否在排班结束的前三天内
            return scheduleEndDate != null && DateTime.Now.AddDays(3) > scheduleEndDate;
        }

        // 获取总排班表的最大排班结束日期的方法
        public DateTime? GetScheduleEndDate()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT MAX(`日期`) FROM `总排班`";
                    return cmd.ExecuteScalar() as DateTime?;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        //从通知表中查询某用户的通知信息
        public List<Inform> QueryMessage(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    List<Inform> messages = new List<Inform>();
                    connection.Open();
                    string query = "SELECT 通知ID,通知事件 FROM 通知 WHERE 通知人=@name";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Inform message = new Inform(reader.GetInt32(0), name, reader.GetString(1));

                        messages.Add(message);
                    }
                    reader.Close();
                    connection.Close();
                    return messages;
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("从通知表中查询某用户的通知信息错误:" + ex.Message);
                    connection.Close();
                    return null;
                }
            }

        }
        //从通知表中删去某ID的通知信息
        public void DeleteMessageByID(int ID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM 通知 WHERE 通知ID=@ID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("从通知表中删去某ID的通知信息错误:" + ex.Message);
                    connection.Close();
                }
            }
        }

    }

}

