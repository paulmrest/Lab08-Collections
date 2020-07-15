using System;
using System.Collections.Generic;
using BookStore.Classes;

namespace BookStore
{
    class Program
    {
        Library<Book> Library = new Library<Book>();
        List<Book> BookBag = new List<Book>();

        static void Main(string[] args)
        {
            UserInterface();
        }

        static void UserInterface()
        {
            Console.WriteLine("Welcome to Phil's Bookstore.");
        }
    }
}
