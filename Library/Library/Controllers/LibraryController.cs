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
            ViewBag.BookClassData = this.bookService.GetClassTable("");
            ViewBag.BookUserData = this.bookService.GetUserTable("");
            ViewBag.BookStatusData = this.bookService.GetStatusTable("");
            return View("");
        }

        [HttpPost()]
        public ActionResult Index(Models.LibrarySearch arg)
        {
            ViewBag.BookClassData = this.bookService.GetClassTable("");
            ViewBag.BookUserData = this.bookService.GetUserTable("");
            ViewBag.BookStatusData = this.bookService.GetStatusTable("");
            ViewBag.SearchResult = this.bookService.GetBookByCondtioin(arg);
            return View("");
        }

        [HttpGet()]
        public ActionResult InsertBook()
        {
            ViewBag.BookClassData = this.bookService.GetClassTable("");
            ViewBag.InsertResult = false;
            return View("InsertBook");
        }

        [HttpPost()]
        public ActionResult InsertBook(Models.Library arg)
        {
            ViewBag.BookClassData = this.bookService.GetClassTable("");
            ViewBag.InsertResult =  bookService.CheckInsertBook(arg);
            return View("InsertBook");
        }

        [HttpPost()]
        public JsonResult DeleteBook(string BookID)
        {
            try
            {
                bookService.DeleteBookId(BookID);
                return this.Json(true);
            }

            catch (Exception ex)
            {
                return this.Json(false);
            }
        }

        [HttpGet()]
        public ActionResult Data(int BookId)
        {
            ViewBag.DataResult = this.bookService.GetDataByCondtioin(BookId);
            return View("Data");
        }


    }
}