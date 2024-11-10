using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Question3
    {
        public static void Main()
        {
          

            Console.Write("Doctor Registration No: ");
            int regnNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Doctor Name: ");
            string name = Console.ReadLine();

            Console.Write("Fees Charged: ");
            double feesCharged = Convert.ToDouble(Console.ReadLine());

            Doctor doctor = new Doctor(regnNo, name, feesCharged);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nEnter details for Book {i + 1}:");

                Console.Write("Book Name: ");
                string bookName = Console.ReadLine();

                Console.Write("Author Name: ");
                string authorName = Console.ReadLine();

                Books book = new Books(bookName, authorName);

                doctor.AddBookToShelf(i, book);
            }

            doctor.DisplayDoctorDetails();
            Console.ReadLine();
        }
    }
        public class Books
        {
            public string BookName { get; set; }
            public string AuthorName { get; set; }

            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }

            public void Display()
            {
                Console.WriteLine($"Book Name: {BookName}, Author: {AuthorName}");
            }
        }

        public class BookShelf
        {
            private Books[] bookCollection = new Books[5];

            public Books this[int index]
            {
                get
                {
                    if (index >= 0 && index < bookCollection.Length)
                        return bookCollection[index];
                    else
                        throw new IndexOutOfRangeException("Index out of range!");
                }
                set
                {
                    if (index >= 0 && index < bookCollection.Length)
                        bookCollection[index] = value;
                    else
                        throw new IndexOutOfRangeException("Index out of range!");
                }
            }

            public void DisplayShelf()
            {
                Console.WriteLine("Books in the Shelf:");
                foreach (var book in bookCollection)
                {
                    if (book != null)
                    {
                        book.Display();
                    }
                }
            }
        }

        public class Doctor
        {
            private int regnNo;
            private string name;
            private double feesCharged;
            private BookShelf bookShelf;

            public int RegnNo
            {
                get { return regnNo; }
                set { regnNo = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public double FeesCharged
            {
                get { return feesCharged; }
                set { feesCharged = value; }
            }

            public Doctor(int regnNo, string name, double feesCharged)
            {
                this.regnNo = regnNo;
                this.name = name;
                this.feesCharged = feesCharged;
                this.bookShelf = new BookShelf();
            }

            public void DisplayDoctorDetails()
            {
                Console.WriteLine($"Doctor Registration No: {RegnNo}, Name: {Name}, Fees Charged: {FeesCharged}");
                bookShelf.DisplayShelf();
            }

            public void AddBookToShelf(int index, Books book)
            {
                bookShelf[index] = book;
            }
        }
    }
      


    

