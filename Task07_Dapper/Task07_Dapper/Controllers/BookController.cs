using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Task07_Dapper.Models;

namespace Task07_Dapper.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<BookModel>("BookViewAll"));
        }

        //Book/AddOrEdit - Insert
        //Book/AddOrEdit/id

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if(id == 0)

            return View();

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@BookId", id);
                return View(DapperORM.ReturnList<BookModel>("BookViewByID",param).FirstOrDefault<BookModel>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(BookModel book)

        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BookId",book.BookId);
            param.Add("@BookName", book.BookName);
            param.Add("@AuthorName", book.AuthorName);
            param.Add("@BookPublication", book.BookPublication);
            param.Add("@BookYear", book.BookYear);
            param.Add("@BookPrice", book.BookPrice);
            DapperORM.ExecuteWithoutReturn("BookAddOrEdit", param);
            return RedirectToAction("Index");

       
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@BookId", id);
            DapperORM.ExecuteWithoutReturn("BookDeleteByID", param);
            return RedirectToAction("Index");
        }
    }
}