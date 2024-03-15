using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookStoreBasicFunctions
    {
        public static Book GetBookById(int BookId)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.Find(BookId);
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.ToList();
            }
        }

        public static Book GetBookByTitle(String BookTitle)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.Where(b => b.BookTitle == BookTitle).FirstOrDefault();
            }
        }

        public static List<Book> GetBooksByAuthor(String AuthorLast)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.Where(b => b.Author.AuthorLast == AuthorLast).ToList();
            }
        }

        public static List<Book> GetAllBooksFull()
        {
            using (var db = new SE407_BookStoreContext())
            {
                var books = db.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .ToList();

                return books;
            }
        }

        public static Book GetFullBookById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var book = db.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Where(b => b.BookId == id)
                    .FirstOrDefault();

                return book;
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Genres.ToList();
            }
        }

        public static Genre GetGenreById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var genre = db.Genres
                    .Where(genre => genre.GenreId == id)
                    .FirstOrDefault();

                return genre;
            }
        }

        public static List<Author> GetAllAuthors()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Authors.ToList();
            }
        }


    }
}
