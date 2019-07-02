using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Library
    {
        /// <summary>
        /// 書名
        /// </summary>
        [DisplayName("書名")]
        public string  BookName { get; set; }

        /// <summary>
        /// 圖書類別
        /// </summary>
        [DisplayName("圖書類別")]
        public int EmployeeClass { get; set; }

        /// <summary>
        /// 借閱人
        /// </summary>
        [DisplayName("借閱人")]
        public int BookUser { get; set; }

        /// <summary>
        /// 借閱狀態
        /// </summary>
        [DisplayName("借閱狀態")]
        public int BookStatus { get; set; }
    }
}