using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrayObligatorikOPG1
{
    public class BooksRepository
    {
        public List<Book> Books = new List<Book>();


        public IEnumerable<Book> Get(string? title = null, int? price = null, string? orderBy = null)
        {
            IQueryable<Book> query = Books.AsQueryable();
            if (title == null || price == null)
            {
                throw new ArgumentException("Title or price is null");
            }
            if (title != null)
            {
                query = query.Where(b => b.Title == title);
            }
            if (price != null)
            {
                query = query.Where(b => b.Price == price);
            }
                switch (orderBy.ToLower())
                {
                    case "title":
                    case "title_asc":
                        query = query.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        query = query.OrderBy(b => b.Title);
                        break;
                    case "price":
                    case "price_asc":
                        query = query.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                    query = query.OrderBy(b => b.Price);
                        break;
                    default:
                        throw new ArgumentException("Invalid orderBy parameter");
                }
            return query.ToList();
        }

        public Book GetById(int id)
        {
            return Books.Find(b => b.Id == id);
        }

        public Book Add(Book book)
        {
            book.BookValidator();
            Books.Add(book);

            return book;
        }

        public Book Update(Book book)
        {
            book.BookValidator();
            Book bookToUpdate = Books.Find(b => b.Id == book.Id);
            bookToUpdate.Title = book.Title;
            bookToUpdate.Price = book.Price;

            return bookToUpdate;
        }

        public Book Delete(int id)
        {
            Book bookToDelete = Books.Find(b => b.Id == id);
            Books.Remove(bookToDelete);

            return bookToDelete;
        }
    }
}
