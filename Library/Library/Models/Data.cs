using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Models
{
    public class Data
    {
        [DisplayName("借閱日期")]
        public string BookLendDate { get; set; }

        [DisplayName("借閱人Id")]
        public string BookUserId { get; set; }

        [DisplayName("英文姓名")]
        public string BookUserEName { get; set; }

        [DisplayName("中文姓名")]
        public string BookUserCName { get; set; }
    }
}