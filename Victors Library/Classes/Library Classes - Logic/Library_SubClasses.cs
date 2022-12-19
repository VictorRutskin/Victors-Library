using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victors_Library
{
    public class Book_Class : Library_Class //derieved classes of library, these are type of books
    {
        int localDiscount = BookDiscount;

        public Book_Class(string name, int numpages, double price, string Genres, Brush color = null, string author = "Unknown", bool AddedToday = true) : base(name, numpages, price, Genres, color, author, AddedToday)
        { 

            if(CalculateDiscount()> localDiscount)
            {
                Discount = CalculateDiscount();
            }
            else
            {
                Discount = localDiscount;
            }
        }

        public override string ToString()
        {
            return Name + ",the Book has a " + Discount +"% discount, and its total price will be: " + (Price-(Price*(Discount/100)) + " Thanks for purchasing from Victor's Library!");
        }

    }
    public class Comic_Class : Library_Class
    {
        int localDiscount = ComicDiscount;

        public Comic_Class(string name, int numpages, double price, string Genres, Brush color = null, string author = "Unknown", bool AddedToday = true) : base(name, numpages, price, Genres, color, author, AddedToday)
        {
            if (CalculateDiscount() > localDiscount)
            {
                Discount = CalculateDiscount();
            }
            else
            {
                Discount = localDiscount;
            }
        }

        public override string ToString()
        {
            return Name + ",the Comic has a " + Discount + "% discount, and its total price will be: " + (Price - (Price * (Discount / 100)) + " Thanks for purchasing from Victor's Library!");
        }
    }
    public class Manga_Class : Library_Class
    {
        int localDiscount = MangaDiscount;

        public Manga_Class(string name, int numpages, double price, string Genres, Brush color = null, string author = "Unknown", bool AddedToday = true) : base(name, numpages, price, Genres, color, author, AddedToday)
        {
            if (CalculateDiscount() > localDiscount)
            {
                Discount = CalculateDiscount();
            }
            else
            {
                Discount = localDiscount;
            }
        }

        public override string ToString()
        {
            return Name + ",the Manga has a " + Discount + "% discount, and its total price will be: " + (Price - (Price * (Discount / 100))+" Thanks for purchasing from Victor's Library! ");
        }
    }
    public class Journal_Class : Library_Class
    {
        int localDiscount = JournalDiscount;

        public Journal_Class(string name, int numpages, double price, string Genres, Brush color = null, string author = "Unknown", bool AddedToday = true) : base(name, numpages, price, Genres, color, author, AddedToday)
        {
            if (CalculateDiscount() > localDiscount)
            {
                Discount = CalculateDiscount();
            }
            else
            {
                Discount = localDiscount;
            }
        }

        public override string ToString()
        {
            return Name + ",the Journal has a " + Discount + "% discount, and its total price will be: " + (Price - (Price * (Discount / 100)) + " Thanks for purchasing from Victor's Library!");
        }
    }

    

}
