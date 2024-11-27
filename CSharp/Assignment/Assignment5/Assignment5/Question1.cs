using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookname, string authorname)
        {
            BookName = bookname;
            AuthorName = authorname;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] a = new Books[5];

        public Books this[int index]
        {
            get { 
                return a[index]; 
            }
            set { 
                a[index] = value; 
            }
        }

        public void  displaybook()
        {
            foreach (var book in a)
            {
                book.Display();
            }
        }
    }
    internal class Question1
    {
        static void Main(string[] args)
        {
            BookShelf b = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the name of Book {i+1}: ");
                string bookname = Console.ReadLine();

                Console.Write($"Enter the author of Book {i + 1}: ");
                string authorname = Console.ReadLine();

                b[i] = new Books(bookname, authorname);
            }

            
            b.displaybook();
            Console.ReadLine();

        }
    }
}
