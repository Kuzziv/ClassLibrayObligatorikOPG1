using ClassLibrayObligatorikOPG1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibaryObliOPG1Test
{
    [TestClass]
    public class BookTest
    {
        Book bookNormal = new Book { Id = 1, Title = "Harry Potter", Price = 100 };
        Book bookNull = new Book { Id = 1, Title = null, Price = 100 };
        Book bookZeroId = new Book { Id = 0, Title = "Harry Potter", Price = 100 };
        Book bookNegativId = new Book { Id = -1, Title = "Harry Potter", Price = 100 };
        Book bookEmpty = new Book { Id = 1, Title = "", Price = 100 };
        Book bookShort = new Book { Id = 1, Title = "a", Price = 100 };
        Book bookPriceNegative = new Book { Id = 1, Title = "Harry Potter", Price = -100 };
        Book bookPriceZero = new Book { Id = 1, Title = "Harry Potter", Price = 0 };
        Book bookPriceOverLimet = new Book { Id = 1, Title = "Harry Potter", Price = 1300 };
        Book bookPriceOnLimet = new Book { Id = 1, Title = "Harry Potter", Price = 1200 };


        [TestMethod]
        public void Book_IdValidator_Id()
        {
            bookNormal.IdValidator(); 
            bookZeroId.IdValidator();
            Assert.ThrowsException<ArgumentException>(() => bookNegativId.IdValidator());            
        }

        [TestMethod]
        public void Book_TitleValidator_Title()
        {
            bookNormal.TitleValidator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookEmpty.TitleValidator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookShort.TitleValidator());
            Assert.ThrowsException<ArgumentNullException>(() => bookNull.TitleValidator());
        }

        [TestMethod]
        public void Book_PriceValidator_Price()
        {
            bookNormal.PriceValidator();
            bookPriceZero.PriceValidator();
            bookPriceOnLimet.PriceValidator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceOverLimet.PriceValidator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceNegative.PriceValidator());
        }

        [TestMethod]
        public void Book_Constructor()
        {
            Book book = new Book(1, "Harry Potter", 100);
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("Harry Potter", book.Title);
            Assert.AreEqual(100, book.Price);
        }

        [TestMethod]
        public void Book_ToSring()
        {
            Book bookToBeTested = bookNormal;
            Assert.AreEqual(bookToBeTested.ToString(), "Id: 1, Title: Harry Potter, Price: 100");
        }

        [TestMethod]
        public void Book_Validator()
        {
            bookNormal.BookValidator();
        }

        [TestMethod]
        public void Book_Equals()
        {
            int i = 0;
            Book bookToBeTested = bookNormal;
            Assert.IsTrue(bookToBeTested.Equals(bookNormal));
            Assert.IsFalse(bookToBeTested.Equals(i));
        }

        [TestMethod]
        public void Book_GetHashCode()
        {
            Book bookToBeTested = bookNormal;
            Assert.AreEqual(bookToBeTested.GetHashCode(), bookNormal.GetHashCode());
        }
        

    }
}
