using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace BookStore.Classes
{
    public class Library<T> : IEnumerable<Book>
    {
        private Book[] Books = new Book[5];
        private int count;

        /// <summary>
        /// Adds a Book object to the Library.
        /// </summary>
        /// <param name="newBook">
        /// Book: the new book to be added
        /// </param>
        public void Add(Book newBook)
        {
            if (count == Books.Length)
            {
                Array.Resize(ref Books, Books.Length * 2);
            }
            Books[count++] = newBook;
        }

        /// <summary>
        /// Removes a book from the Library and returns it.
        /// </summary>
        /// <param name="title">
        /// string: the title of the book to be removed
        /// </param>
        /// <returns>
        /// Book: the book object removed from the Library
        /// </returns>
        /// <remarks>
        /// Solution for removing the Book from the array from here: https://stackoverflow.com/a/8983311/2149946
        /// </remarks>
        public Book Remove(string title)
        {
            Book removedBook = null;
            foreach (Book oneBook in Books)
            {
                if (oneBook != null && oneBook.Title == title)
                {
                    removedBook = oneBook;
                    count--;
                    Books = Books.Except(new Book[] { oneBook }).ToArray();
                    break;
                }
            }
            return removedBook;
        }

        /// <summary>
        /// Returns the number of Books in the Library.
        /// </summary>
        /// <returns>
        /// int: the number of Books presently in the Library
        /// </returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Implementation of the IEnumerator interface. Gets an IEnumerator<Book>
        /// </summary>
        /// <returns>
        /// IEnumerator<Book>: an IEnumerator that allows the collection to be iterated over
        /// </returns>
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return Books[i];
            }
        }

        //Old magic. No touchie.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}