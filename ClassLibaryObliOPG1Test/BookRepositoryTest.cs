using ClassLibrayObligatorikOPG1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibaryObliOPG1Test
{
    [TestClass]
    public class BookRepositoryTest
    {
        private BooksRepository repo = new BooksRepository();
        Book book1 = new Book { Id = 1, Title = "Harry Potter", Price = 100 };
        Book book2 = new Book { Id = 2, Title = "Sponges Bob", Price = 200 };
        Book book3 = new Book { Id = 3, Title = "10 rules of life", Price = 300 };

        [TestMethod]
        public void BookRepository_Get()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Assert.AreEqual(book1, repo.Get("Harry Potter", 100, "title").First());
        }

        [TestMethod]
        public void BookRepository_GetById()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Assert.AreEqual(book1, repo.GetById(1));
        }

        [TestMethod]
        public void BookRepository_Add()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Assert.AreEqual(book1, repo.GetById(1));
            Assert.AreEqual(book2, repo.GetById(2));
            Assert.AreEqual(book3, repo.GetById(3));
        }

        [TestMethod]
        public void BookRepository_GetByTitle()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Assert.AreEqual(book1, repo.Get("Harry Potter", 100, "title").First());
        }

        [TestMethod]
        public void BookRepository_GetByPrice()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Assert.AreEqual(book1, repo.Get("Harry Potter", 100, "price").First());
        }

        [TestMethod]
        public void BookRepository_Update()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            Book book4 = new Book { Id = 1, Title = "Harry Potter", Price = 100 };
            repo.Update(book4);
            Assert.AreEqual(book4, repo.GetById(1));
        }

        [TestMethod]
        public void BookRepository_Delete()
        {
            repo.Add(book1);
            repo.Add(book2);
            repo.Add(book3);
            repo.Delete(1);
            Assert.AreEqual(book2, repo.GetById(2));
            Assert.AreEqual(book3, repo.GetById(3));
        }



    }
}
