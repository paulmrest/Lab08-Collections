using System;
using Xunit;
using BookStore.Classes;

namespace BookStoreTests
{
    public class BookStoreTests
    {
        [Fact]
        public void AddBookToLibrary()
        {
            //Arrange
            Library<Book> testLibrary = new Library<Book>();
            Author testAuthor = new Author("Kazuo", "Ishiguro");
            Book testBook = new Book("The Remains of the Day", testAuthor);

            //Act
            testLibrary.Add(testBook);

            //Assert
            Assert.Equal(1, testLibrary.Count());
            Assert.Equal(testBook, testLibrary.Remove(testBook.Title));
        }

        [Fact]
        public void RemoveABookFromLibrary()
        {
            //Arrange
            Library<Book> testLibrary = new Library<Book>();

            Author firstAuthor = new Author("Kazuo", "Ishiguro");
            Book firstBook = new Book("The Remains of the Day", firstAuthor);

            Author secondAuthor = new Author("Gunter", "Grass");
            Book secondBook = new Book("The Tin Drum", secondAuthor);

            Author thirdAuthor = new Author("Virginia", "Woolf");
            Book thirdBook = new Book("To the Lighthouse", thirdAuthor);

            testLibrary.Add(firstBook);
            testLibrary.Add(secondBook);
            testLibrary.Add(thirdBook);

            //Act
            Book result = testLibrary.Remove(secondBook.Title);

            //Assert
            Assert.Equal(2, testLibrary.Count());
            Assert.Equal(secondBook, result);
        }

        [Fact]
        public void CannotRemoveNonexistantBookFromLibrary()
        {
            //Arrange
            Library<Book> testLibrary = new Library<Book>();
            Author realAuthor = new Author("Kazuo", "Ishiguro");
            Book realBook = new Book("The Remains of the Day", realAuthor);

            Author fakeAuthor = new Author("Gunter", "Grass");
            Book fakeBook = new Book("The Tin Drum", fakeAuthor);

            //Act
            testLibrary.Add(realBook);
            Book result = testLibrary.Remove(fakeBook.Title);

            //Assert
            Assert.Equal(1, testLibrary.Count());
            Assert.Null(result);
        }

        [Fact]
        public void CanSetAndGetBookProperities()
        {
            //Arrange
            Author firstAuthor = new Author("Kazuo", "Ishiguro");
            Book testBook = new Book("The Remains of the Day", firstAuthor);

            string expectedTitle = "The Tin Drum";
            Author expectedAuthor = new Author("Gunter", "Grass");
            Book.BookGenres expectedGenre = Book.BookGenres.SelfHelp;

            //Act
            testBook.Title = expectedTitle;
            testBook.Author = expectedAuthor;
            testBook.Genre = Book.BookGenres.SelfHelp;

            //Assert
            Assert.Equal(expectedTitle, testBook.Title);
            Assert.Equal(expectedAuthor, testBook.Author);
            Assert.Equal(expectedGenre, testBook.Genre);
        }

        [Fact]
        public void CanSetAndGetAuthorProperities()
        {
            //Arrange
            Author testAuthor = new Author("Kazuo", "Ishiguro");

            string expectedFirstName = "Barbara";
            string expectedLastName = "Bush";
            int expectedYearBorn = 1995;
            Author.Genders expectedGender = Author.Genders.Female;

            //Act
            testAuthor.FirstName = expectedFirstName;
            testAuthor.LastName = expectedLastName;
            testAuthor.YearBorn = expectedYearBorn;
            testAuthor.Gender = expectedGender;

            //Assert
            Assert.Equal(expectedFirstName, testAuthor.FirstName);
            Assert.Equal(expectedLastName, testAuthor.LastName);
            Assert.Equal(expectedYearBorn, testAuthor.YearBorn);
            Assert.Equal(expectedGender, testAuthor.Gender);
        }

        [Fact]
        public void CorrectlyTracksNumberOfBooksInLibrary()
        {
            //Arrange
            Library<Book> testLibrary = new Library<Book>();

            Author firstAuthor = new Author("Kazuo", "Ishiguro");
            Book firstBook = new Book("The Remains of the Day", firstAuthor);

            Author secondAuthor = new Author("Gunter", "Grass");
            Book secondBook = new Book("The Tin Drum", secondAuthor);

            Author thirdAuthor = new Author("Virginia", "Woolf");
            Book thirdBook = new Book("To the Lighthouse", thirdAuthor);

            //Act
            testLibrary.Add(firstBook);
            testLibrary.Add(secondBook);
            testLibrary.Add(thirdBook);

            //Assert
            Assert.Equal(3, testLibrary.Count());
        }
    }
}
