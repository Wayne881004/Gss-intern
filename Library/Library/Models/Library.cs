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
        [Required(ErrorMessage = "此欄位必填")]
        public string  BookName { get; set; }
        /// <summary>
        /// 書名id
        /// </summary>
        [DisplayName("書名Id")]
        public int BookId { get; set; }

        /// <summary>
        /// 圖書類別
        /// </summary>
        [DisplayName("圖書類別")]
        public string BookClass { get; set; }
        /// 圖書類別Id
        /// </summary>
        [DisplayName("圖書類別Id")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookClassId { get; set; }

        /// <summary>
        /// 借閱人
        /// </summary>
        [DisplayName("借閱人")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookUser { get; set; }
        /// <summary>
        /// 借閱人Id
        /// </summary>
        [DisplayName("借閱人Id")]
        public string BookUserId { get; set; }

        /// <summary>
        /// 借閱狀態
        /// </summary>
        [DisplayName("借閱狀態")]

        public string BookStatus { get; set; }
        /// <summary>
        /// 借閱狀態Id
        /// </summary>
        [DisplayName("借閱狀態Id")]
        public string BookStatusId { get; set; }

        /// <summary>
        /// 購書日期
        /// </summary>
        [DisplayName("購書日期(yyyy_MM_dd) 不可亂填!!")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookBuydate { get; set; }

        /// <summary>
        /// 出版商
        /// </summary>
        [DisplayName("出版商")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookPublisher { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName("作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookAuthor { get; set; }

        /// <summary>
        /// 內容簡介
        /// </summary>
        [DisplayName("內容簡介")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookIntroduction { get; set; }
    }
}
