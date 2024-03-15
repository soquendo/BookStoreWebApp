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
    public class AuthorController : Controller
    {
        // GET: AuthorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author authorToAdd)
        {
            try
            {
                BookStoreAdminFunctions.AddAuthor(authorToAdd);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = BookStoreBasicFunctions.GetAuthorById(id);
            return View();
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author authorToEdit)
        {
            try
            {
                BookStoreAdminFunctions.EditAuthor(authorToEdit);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = BookStoreBasicFunctions.GetAuthorById(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
            try
            {
                BookStoreAdminFunctions.DeleteAuthor(author.AuthorId);
                return RedirectToAction("Authors", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
