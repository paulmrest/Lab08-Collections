using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BookStore.Classes;

namespace BookStore.Classes
{
    public class Book
    {
        public enum BookGenres
        {
            [Description("History")]
            History = 1,
            [Description("Popular Fiction")]
            PopularFiction,
            [Description("Literature")]
            Literature,
            [Description("Philosophy")]
            Philosophy,
            [Description("Young Adult")]
            YoungAdult,
            [Description("Self Help")]
            SelfHelp,
            [Description("Children's")]
            Children,
            [Description("Non-Fiction")]
            NonFiction,
            [Description("Popular Science")]
            PopularScience,
            [Description("Textbooks")]
            Textbook
        }

        public string Title { get; set; }

        public Author Author { get; set; }

        public string Description { get; set; }

        public BookGenres Genre { get; set; }

        /// <summary>
        /// A constructor for a Book object that takes in a title and an Author.
        /// </summary>
        /// <param name="title">
        /// string: a title of a book
        /// </param>
        /// <param name="author">
        /// Author: an Author object
        /// </param>
        public Book(string title, Author author)
        {
            Title = title;
            Author = author;
        }

        /// <summary>
        /// A constructor for a Book object that takes in a title, an Author, and a genre.
        /// </summary>
        /// <param name="title">
        /// string: a title of a book
        /// </param>
        /// <param name="author">
        /// Author: an Author object
        /// </param>
        /// <param name="genre">
        /// Book.BookGenres: an enum signifying the genre of the book
        /// </param>
        public Book(string title, Author author, BookGenres genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }
    }
}