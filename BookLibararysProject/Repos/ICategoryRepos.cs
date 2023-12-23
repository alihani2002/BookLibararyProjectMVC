using BookLibarary.Models;

namespace BookLibarary.Repos
{
    public interface ICategoryRepos
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        void Create(Category category);
        void Update(Category category);
        void Delete(int id);
        int SaveChanges();
    }
}
