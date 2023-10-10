using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrayObligatorikOPG1
{
    public class Book
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public Book()
        {
            
        }

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }


        public void IdValidator()
        {
            if (Id < 0)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
        }

        public void TitleValidator()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title must not be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Title must be longer than 2 characters");
            }
        }

        public void PriceValidator()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be greater than 0");
            }
            if (Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price must be lower than 1200");
            }
        }

        public void BookValidator()
        {
            IdValidator();
            TitleValidator();
            PriceValidator();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Book)
            {
                Book book = (Book)obj;
                return Id == book.Id && Title == book.Title && Price == book.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price: {Price}";
        }

    }
}
