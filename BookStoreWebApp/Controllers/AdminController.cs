using BookStore;
using BookStore.Models;
using BookStoreWebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace BookStoreWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var book = BookStoreBasicFunctions.GetFullBookById(id);
            return View(book);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bookToCreate)
        {
            try
            {
                BookStoreAdminFunctions.AddBook(bookToCreate);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BookStoreBasicFunctions.GetFullBookById(id);
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
            return View(book);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bookToEdit)
        {
            try
            {
                BookStoreAdminFunctions.EditBook(bookToEdit);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BookStoreBasicFunctions.GetFullBookById(id);
            return View(book);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                BookStoreAdminFunctions.DeleteBook(book.BookId);
                return RedirectToAction("Books","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
