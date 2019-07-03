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
            return View("Index");
        }
    }
}