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
    public class LibrarySearch
    {
        [DisplayName("書名")]
        public string BookName { get; set; }
        [DisplayName("書籍類別")]
        public string BookClassId { get; set; }
        [DisplayName("借閱人")]
        public string BookUserId { get; set; }
        [DisplayName("借閱狀態")]
        public string BookStatusId { get; set; }
    }
}