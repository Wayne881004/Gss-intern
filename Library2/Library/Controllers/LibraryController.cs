using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        Models.BookService bookService = new Models.BookService();

        public ActionResult Index()
        {
            return View("");
        }

        [HttpPost]
        public JsonResult GetClass()
        {
            return Json(this.bookService.GetClassTable());
        }
        [HttpPost]
        public JsonResult GetUser()
        {
            return Json(this.bookService.GetUserTable());
        }
        [HttpPost]
        public JsonResult GetStatus()
        {
            return Json(this.bookService.GetStatusTable());
        }
        [HttpPost]
        public JsonResult GetSearch(Models.LibrarySearch DataTmp)
        {
            return Json(this.bookService.GetBookByCondtionTable(DataTmp));
        }
        [HttpPost]
        public JsonResult DeleteBook(int BookId)
        {
            try
            {
                bookService.DeleteBookId(BookId);
                return this.Json(true);
            }

            catch (Exception ex)
            {
                return this.Json(false);
            }
        }
    
  
    }
}