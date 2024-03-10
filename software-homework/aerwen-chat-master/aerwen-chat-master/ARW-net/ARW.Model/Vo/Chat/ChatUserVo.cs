﻿using Newtonsoft.Json;
using OfficeOpenXml.Attributes;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARW.Model.Models.Business;
using ARW.Model.Models.Business.Crawler;
using Newtonsoft.Json.Linq;

namespace ARW.Model.Vo.Chat
{
    public class ChatUserVo
    {
        public int ChatUserId { get; set; }

        [JsonConverter(typeof(ValueToStringConverter))]
        public long ChatUserGuId { get; set; }

        public string ChatUserName { get; set; }

        public string ChatUserNickName { get; set; }

        public string ChatUserImg { get; set; }

        public string Sex { get; set; }

        public int? Age { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? Status { get;set; }
    }
}
