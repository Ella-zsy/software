using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlagWorkSystem.classes;

namespace FlagWorkSystem
{
    public class ApplyService
    {
                //处理审批
        static public void DealRequest(int ID,int status)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="UPDATE 审批 SET 审批状态=@status 审批时间=@date WHERE 审批ID=@ID";
                    MySqlCommand cmd = new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@status",status);
                    cmd.Parameters.AddWithValue("@ID",ID);
                    cmd.Parameters.AddWithValue("@date",DateTime.Now.Date);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) { MaterialMessageBox.Show("修改审批状态错误:"+ex.Message);}
                finally { connection.Close(); }
            }
        }

        public static void ChangeFlag(DateTime date,string user1,string user2)//这里是要把1换成2
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="SELECT 成员1,成员2,成员3 FROM 总排班 WHERE 日期=@date";
                    MySqlCommand cmd = new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@date",date);
                    MySqlDataReader reader=cmd.ExecuteReader();
                    if(reader.HasRows==false)
                        return ;
                    string u1="",u2="",u3="";
                    while(reader.Read())
                    {
                        u1=reader.GetString(0);
                        u2=reader.GetString(1);
                        u3=reader.GetString(2);
                    }
                    reader.Close();
                    string USER="成员";
                    if(u1==user1)
                        USER+="1";
                    if(u2==user1)
                        USER+="2";
                    if(u3==user1)
                        USER+="3";
                    query="UPDATE 总排班 SET "+USER+"=@user2 WHERE 日期=@date";
                    cmd=new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@user2",user2);
                    cmd.Parameters.AddWithValue("@date",date);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) { MaterialMessageBox.Show("修改排班成员错误:"+ex.Message); }
                finally{connection.Close();}
            }
        }

        public static void AddMessage(string user,string msg)
        {
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query="INSERT INTO 通知(通知人,通知事件) VALUES (@user,@msg)";
                    MySqlCommand cmd=new MySqlCommand(query,connection);
                    cmd.Parameters.AddWithValue("@user",user);
                    cmd.Parameters.AddWithValue("@msg",msg);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) { MaterialMessageBox.Show("插入通知错误:"+ex.Message); }
                finally{connection.Close();}
            }
        }
    }
}
