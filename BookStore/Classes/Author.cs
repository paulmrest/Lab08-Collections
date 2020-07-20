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
            Male,
            NotSpecified
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearBorn { get; set; }

        public Genders Gender { get; set; }

        /// <summary>
        /// Instantiates a new 
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
            Gender = Genders.NotSpecified;
        }


        public Author(string firstName, string lastName, Genders gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }
    }
}