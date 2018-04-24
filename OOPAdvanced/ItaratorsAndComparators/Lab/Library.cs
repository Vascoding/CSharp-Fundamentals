using System.Collections;
using System.Collections.Generic;


public class Library : IEnumerable<Book>
{
    private List<Book> books;
    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }
    public IEnumerator<Book> GetEnumerator()
    {
        for (int i = 0; i < this.books.Count; i++)
        {
            yield return this.books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private List<Book> books;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current
        {
            get { return this.books[this.currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}


