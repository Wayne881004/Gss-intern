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
        [DisplayName("*書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string  BookName { get; set; }

        [DisplayName("書名Id")]
        public int BookId { get; set; }

        [DisplayName("*圖書類別")]
        public string BookClass { get; set; }

        [DisplayName("圖書類別Id")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookClassId { get; set; }

        [DisplayName("借閱人")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookUser { get; set; }

        [DisplayName("借閱人Id")]
        public string BookUserId { get; set; }

        [DisplayName("借閱狀態")]

        public string BookStatus { get; set; }

        [DisplayName("借閱狀態Id")]
        public string BookStatusId { get; set; }

        [DisplayName("*購書日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookBuyDate { get; set; }

        [DisplayName("*出版商")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookPublisher { get; set; }

        [DisplayName("*作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookAuthor { get; set; }

        [DisplayName("*內容簡介")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookIntroduction { get; set; }

        [DisplayName("借閱日期")]
        public string BookLendDate { get; set; }

        [DisplayName("英文姓名")]
        public string BookUserEName { get; set; }

        [DisplayName("中文姓名")]
        public string BookUserCName { get; set; }
    }
}