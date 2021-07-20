using System.Collections.Generic;
using Project.Books.Interface;

namespace Project.Books
{
  public class BookRepository : IRepository<Books>
  {
    private List<Books> bookList = new List<Books>();

    public void delete(int id)
    {      
      bookList[id].setHasBeenDeleted();
    }

    public void create(Books book)
    {
      bookList.Add(book);
    }

    public List<Books> List()
    {
      return bookList;
    }

    public int NextId()
    {
      return bookList.Count;
    }

    public Books ReturnById(int id)
    {
      return bookList[id];
    }

    public void update(int id, Books book)
    {
      bookList[id] = book;
    }
  }
}