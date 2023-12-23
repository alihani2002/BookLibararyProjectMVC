using BookLibarary.Data_Context;
using BookLibarary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.Repos
{
    public class BookRepos : IBookRepos
    {
        readonly DB_Context _Context;
        public BookRepos(DB_Context context) => _Context = context ;
        public void Create(Book Book) => _Context.Add(Book);
        public IEnumerable<Book> GetAll() => _Context.Books.Include(b => b.Category);
        public Book GetById(int id) => _Context.Books.Include(b => b.Category).FirstOrDefault(c => c.Id == id);
        public Book GetByName(string name) =>
            _Context.Books.Include(b => b.Category).FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        public void Update(Book book) => _Context.Entry(book).State = EntityState.Modified;
        public void Delete(int id) => _Context.Books.Remove(_Context.Books.Find(id));
        public int SaveChanges() => _Context.SaveChanges();
    }
}
