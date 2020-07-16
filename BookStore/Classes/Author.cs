using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Classes;

namespace BookStore.Classes
{
    public class Author
    {
     
        public enum Genders
        {
            Other = 1,
            NonBinary,
            Female,
            Male
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearBorn { get; set; }

        public Genders Gender { get; set; }

        /// <summary>
        /// A constructor for a new Author object.
        /// </summary>
        /// <param name="firstName">
        /// string: a first name
        /// </param>
        /// <param name="lastName">
        /// string: a last name
        /// </param>
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}