using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Classes
{
    public class Library<Book> : IEnumerable<Book>
    {
        public IEnumerator<Book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
