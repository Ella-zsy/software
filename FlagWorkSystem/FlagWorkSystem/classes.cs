using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlagWorkSystem
{
    public static class classes

    {

        //数据库连接
        public static string connectionString = "server=localhost;database=net_homework;uid=root;password=zsy20030105";

        //学生类
        public class User
        {
            public int id;
            public string name;
            public string password;
            public User(int id, string name, string password)
            {
                this.id = id;
                this.name = name;
                this.password = password;
            }
        }

        //老师类
        public class Teacher
        {
            public int id;
            public string name;
            public string password;
            public Teacher(int id, string name, string password)
            {
                this.id = id;
                this.name = name;
                this.password = password;
            }
        }

        //审批类
        public class Examine
        {
            public int id;
            public int type;
            public string applicant; // 申请人
            public string reason;
            public DateTime applicant_time; // 申请时间
            public int is_read;
            public int is_examine;
            public string replacement; // 替换人
            public DateTime replacement_time; // 替换时间
            public DateTime requeset_time; // 提交时间
            public DateTime examine_time; // 审核时间

            public Examine(int id, int type, string applicant, string reason, DateTime applicant_time, int is_read, int is_examine, string replacement, DateTime? replacement_time, DateTime requeset_time)
            {
                this.id = id;
                this.type = type;
                this.applicant = applicant;
                this.reason = reason;
                this.applicant_time = applicant_time;
                this.is_read = is_read;
                this.is_examine = is_examine;
                this.replacement = replacement;
                this.replacement_time = replacement_time ?? DateTime.MinValue; // 使用空合并运算符处理可空类型
                this.requeset_time = requeset_time;
            }

            public Examine(object value1, int type, string applicant, object value2, object value3, int is_examine, int is_read, object value4, object value5, DateTime requeset_time, DateTime examine_time)
            {
                this.type = type;
                this.applicant = applicant;
                this.is_examine = is_examine;
                this.is_read = is_read;
                this.requeset_time = requeset_time;
                this.examine_time = examine_time;
            }
            public Examine(int id, int type, string applicant, int is_read, int is_examine, DateTime requeset_time, DateTime examine_time)
            {
                this.id = id;
                this.type = type;
                this.applicant = applicant;
                this.is_read = is_read;
                this.is_examine = is_examine;
                this.requeset_time = requeset_time;
                this.examine_time = examine_time;
            }
            public Examine(int type, int id,  int is_examine, DateTime requeset_time, DateTime examine_time)
            {
               
                this.type = type;
                this.id = id;
                this.is_examine = is_examine;
                this.requeset_time = requeset_time;
                this.examine_time = examine_time;
            }
            public Examine(int id, int type, string applicant, string reason, DateTime applicant_time,  int is_examine, string replacement, DateTime? replacement_time, DateTime requeset_time, DateTime examine_time)
            {
                this.id = id;
                this.type = type;
                this.applicant = applicant;
                this.reason = reason;
                this.applicant_time = applicant_time;
                this.examine_time = examine_time;
                this.is_examine = is_examine;
                this.replacement = replacement;
                this.replacement_time = replacement_time ?? DateTime.MinValue; // 使用空合并运算符处理可空类型
                this.requeset_time = requeset_time;
            }
        }


        //总排班类
        public class Working_schedule
        {
            public DateTime time;
            public string user1;
            public string user2;
            public string user3;
            public bool is_cancle;
            public string Text;//文字记录
            public string Photo;//图片记录（大概是图片路径？）
            public string drop_users;//缺勤人员
            public Working_schedule(DateTime time, string user1, string user2, string user3,bool is_cancle, string text, string photo,string drop_user)
            {
                this.time = time;
                this.user1 = user1;
                this.user2 = user2;
                this.user3 = user3;
                this.is_cancle = is_cancle;
                Text = text;
                Photo = photo;
                this.drop_users = drop_user;
            }
        }

        //总训练类
        public class Trainning_schedule
        {
            public DateTime time;
            public bool is_cancle;
            public bool shallTrain;
            public string drop_users;//缺勤人员
            public Trainning_schedule(DateTime time, bool is_cancle, bool shallTrain, string drop_users)
            {
                this.time = time;
                this.is_cancle=is_cancle;
                this.shallTrain=shallTrain;
                this.drop_users = drop_users;
            }
        }
        //用户排班类
        public class Personal_work
        {
            public int id;
            public string time;
            public int total;//总次数
            public int drop;//旷训次数
            public int leave;//请假次数
            public int actualtime;//实到次数

            public Personal_work(int id, string time)
            {
                this.id = id;
                this.time = time;
                this.total = 0;
                this.drop = 0;
                this.leave = 0;
            }
            public Personal_work(string time, int total, int drop, int leave, int actualtime)
            {
                this.time = time;
                this.total = total;
                this.drop = drop;
                this.leave = leave;
                this.actualtime = actualtime;
            }
        }
        //用户训练类
        public class Personal_train
        {
            public int id;
            public string time;
            public int total;//总次数
            public int drop;//旷训次数
            public int leave;//请假次数
            public int actualtime;//实到次数
            public Personal_train(int id, string time)
            {
                this.id = id;
                this.time = time;
                this.total = 0;
                this.drop = 0;
                this.leave = 0;
            }
            public Personal_train(string time, int total, int drop, int leave, int actualtime)
            {
                this.time = time;
                this.total = total;
                this.drop = drop;
                this.leave = leave;
                this.actualtime = actualtime;
            }
        }
        //空余时间类
        public class Free_time
        {
            public int id;
            public bool[] is_free;//要是不好实现就改成6个bool类型的属性
            public Free_time(int id, bool[] is_free)//这里传一个记录六天空闲的数组
            {
                this.id = id;
                this.is_free = is_free;
            }
        }
        //通知类
        public class Inform
        {
            public int id;
            public string username;
            public string events;
            public Inform(int id, string username, string events)
            {
                this.id = id;
                this.username = username;
                this.events = events;
            }
        }

    }
}
