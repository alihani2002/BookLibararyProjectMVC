using BookLibarary.Data_Context;
using BookLibarary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        readonly DB_Context _context;

        public CategoryRepos(DB_Context context) => _context = context;

        public void Create(Category category) => _context.Categories.Add(category);

        public IEnumerable<Category> GetAll() => _context.Categories;

        public Category GetById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);

        public Category GetByName(string name) =>
            _context.Categories.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));

        public void Update(Category category) => _context.Entry(category).State = EntityState.Modified;

        public void Delete(int id) => _context.Categories.Remove(_context.Categories.Find(id));

        public int SaveChanges() => _context.SaveChanges();
    }
}
