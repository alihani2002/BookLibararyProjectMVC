using BookLibarary.Models;

namespace BookLibarary.Repos
{
    public interface IBookRepos
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book GetByName(string name);
        void Create(Book Book);
        void Update(Book Book);
        void Delete(int id);
        int SaveChanges();
    }
}
