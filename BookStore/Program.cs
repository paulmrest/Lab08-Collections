using System;
using System.Collections.Generic;
using BookStore.Classes;

namespace BookStore
{
    public class Program
    {
        private static Library<Book> Library = null;
        private static List<Book> BookBag = null;

        static void Main(string[] args)
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();
            LoadBooks();
            UserInterface();
        }

        /// <summary>
        /// Displays a menu to the user.
        /// </summary>
        static void UserInterface()
        {
            bool libraryMenu = true;
            while (libraryMenu)
            {
                Console.WriteLine("Welcome to Phil's Library.");
                Console.WriteLine("Please choose an option (1 to 6):");
                Console.WriteLine("1. View a list of all books in the library");
                Console.WriteLine("2. Add a new book to the library");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. View your book bag");
                Console.WriteLine("6. Exit");
                int menuChoice;
                while (true)
                {
                    string userChoice = Console.ReadLine();
                    if (Int32.TryParse(userChoice, out int result))
                    {
                        if (result < 1 || result > 6)
                        {
                            Console.WriteLine("Please choose a valid menu item (1 - 6)");
                        }
                        else
                        {
                            menuChoice = result;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }
                libraryMenu = SelectMenuItem(menuChoice);
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Helper method of UserInterface(). Processes the user's menu choice.
        /// </summary>
        /// <param name="menuChoice">
        /// int: a menu choice
        /// </param>
        /// <returns>
        /// bool: true if the user wants to stay in the menu, false if not
        /// </returns>
        private static bool SelectMenuItem(int menuChoice)
        {
            switch (menuChoice)
            {
                case 1:
                    PrintLibraryBooks();
                    break;
                case 2:
                    AddNewBookToLibrary();
                    break;
                case 3:
                    ChooseBookToBorrow();
                    break;
                case 4:
                    ReturnBook();
                    break;
                case 5:
                    PrintBookBag();
                    break;
                case 6:
                    Console.WriteLine("Thanks for visiting. Hope to see you again soon.");
                    return false;
                default:
                    Console.WriteLine("Something went wrong with the menu");
                    break;
            }
            return true;
        }

        /// <summary>
        /// Loads pre-determined books into the Library.
        /// </summary>
        private static void LoadBooks()
        {
            Author author1 = new Author("Kazuo", "Ishiguro");
            Book book1 = new Book("The Remains of the Day", author1, Book.BookGenres.Literature);
            Library.Add(book1);

            Author author2 = new Author("Gunter", "Grass");
            Book book2 = new Book("The Tin Drum", author2, Book.BookGenres.Literature);
            Library.Add(book2);

            Author author3 = new Author("Douglas", "Hofstadter");
            Book book3 = new Book("I Am a Strange Loop", author3, Book.BookGenres.Philosophy);
            Library.Add(book3);

            Author author4 = new Author("Kathleen", "Dunn");
            Book book4 = new Book("Geek Love", author4, Book.BookGenres.PopularFiction);
            Library.Add(book4);

            Author author5 = new Author("Caroline", "Criado-Perez");
            Book book5 = new Book("Invisible Women", author5, Book.BookGenres.NonFiction);
            Library.Add(book5);
        }

        /// <summary>
        /// Prints to the console all the books in the Library.
        /// </summary>
        private static void PrintLibraryBooks()
        {
            Console.WriteLine("Phil's Library presently has the following books:");
            foreach (Book oneBook in Library)
            {
                Console.WriteLine("\"{0}\", in the genre of {1}, by (Last, First): {2}, {3}", oneBook.Title, oneBook.Genre, oneBook.Author.LastName, oneBook.Author.FirstName);
            }
        }

        /// <summary>
        /// Gets user input for new book to add to the Library.
        /// </summary>
        private static void AddNewBookToLibrary()
        {
            Console.Write("Enter the new book's title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the book's author's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter the book's author's last name: ");
            string lastName = Console.ReadLine();
            Author author = new Author(firstName, lastName);
            Book newBook;
            Console.WriteLine("Would you like to the new book a genre? (y/n)");
            string addGenre = Console.ReadLine();
            if (addGenre.ToLower() == "y" || addGenre.ToLower() == "yes")
            {
                Book.BookGenres genre = ChooseGenre();
                newBook = new Book(title, author, genre);
            }
            else
            {
                newBook = new Book(title, author);
            }
            Library.Add(newBook);
        }

        /// <summary>
        /// Allows user to select from the genres in the Book.BookGenre enum.
        /// </summary>
        /// <returns>
        /// enum Book.BookGenres: a book genre
        /// </returns>
        private static Book.BookGenres ChooseGenre()
        {
            Console.WriteLine("The available genres are:");
            int count = 0;
            foreach (Book.BookGenres oneGenre in Book.BookGenres.GetValues(typeof(Book.BookGenres)))
            {
                Console.WriteLine("{0}. {1}", count + 1, oneGenre);
                count++;
            }
            Console.Write("Please choose a genre for the new book with the corresponding number (1 - {0}): ", count);
            int genreNumber = 0;
            while (true)
            {
                string userGenreEntry = Console.ReadLine();
                if (Int32.TryParse(userGenreEntry, out int result))
                {
                    if (result < 1 || result > count)
                    {
                        Console.WriteLine("Please enter a number between 1 and {0}", count);
                    }
                    else
                    {
                        genreNumber = result;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            return (Book.BookGenres)genreNumber;
        }

        /// <summary>
        /// Prompts the user for which book they'd like to borrow.
        /// </summary>
        private static void ChooseBookToBorrow()
        {
            PrintLibraryBooks();
            Console.Write("Enter the title of the book you'd like to borrow: ");
            bool validTitle = false;
            while (!validTitle)
            {
                string userEntryTitle = Console.ReadLine();
                foreach (Book oneBook in Library)
                {
                    if (userEntryTitle.ToLower() == oneBook.Title.ToLower())
                    {
                        validTitle = true;
                        Borrow(oneBook.Title);
                    }
                }
                if (!validTitle)
                {
                    Console.WriteLine("We couldn't find that title, please try another.");
                }
            }
        }

        /// <summary>
        /// Borrows a book by moving it from the Library to the BookBag.
        /// </summary>
        /// <param name="title">
        /// string: the title of the book to be borrowed
        /// </param>
        private static void Borrow(string title)
        {
            BookBag.Add(Library.Remove(title));
        }

        /// <summary>
        /// Displays to the user the books in their BookBag, and moves their selection from the BookBag to the Library.
        /// </summary>
        private static void ReturnBook()
        {
            Dictionary<int, Book> bookBagDict = new Dictionary<int, Book>();
            Console.WriteLine("Your book bag currently has these books:");
            int count = 0;
            foreach (Book oneBook in BookBag)
            {
                bookBagDict.Add(++count, oneBook);
                Console.WriteLine("{0}. \"{1}\", in the genre of {2}, by (Last, First): {3}, {4}", count, oneBook.Title, oneBook.Genre, oneBook.Author.LastName, oneBook.Author.FirstName);
            }
            Console.Write("Which book would you like to return? (1 - {0}): ", count);
            int returnBookNum = 0;
            while (true)
            {
                string userEntry = Console.ReadLine();
                if (Int32.TryParse(userEntry, out int result))
                {
                    if (result < 1 || result > count)
                    {
                        Console.WriteLine("Please enter a number between 1 and {0}", count);
                    }
                    else
                    {
                        returnBookNum = result;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            if (bookBagDict.TryGetValue(returnBookNum, out Book value))
            {
                Library.Add(value);
                BookBag.Remove(value);
            }
        }

        /// <summary>
        /// Prints to the console the books in the BookBag.
        /// </summary>
        private static void PrintBookBag()
        {
            Console.WriteLine("Your book bag currently has the following books:");
            foreach (Book oneBook in BookBag)
            {
                Console.WriteLine("\"{0}\", in the genre of {1}, by (Last, First): {2}, {3}", oneBook.Title, oneBook.Genre, oneBook.Author.LastName, oneBook.Author.FirstName);
            }
        }
    }
}
