using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore;
using BookStore.Models;

namespace BookStoreWebApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genreToAdd)
        {
            try
            {
                //BookStoreBasicFunctions.AddGenre(genreToAdd);
                return RedirectToAction("Genres", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            //var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View();
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
            try
            {
                //BookStoreBasicFunctions.EditGenre(genreToEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            var genre = BookStoreBasicFunctions.GetGenreById(id);
            return View();
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genreToDelete)
        {
            try
            {
                BookStoreAdminFunctions.DeleteGenre(genreToDelete.GenreId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
