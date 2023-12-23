using BookLibarary.Data_Context;
using BookLibarary.Models;
using BookLibarary.Repos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.Controllers
{
    public class BookController : Controller
    {
        private readonly DB_Context _context;
        private readonly IBookRepos _bookRepos;
        private readonly ICategoryRepos _categoryRepos;
        private readonly IValidator<Book> _validator;
        private readonly IWebHostEnvironment webHostEnvironment;


        public BookController(DB_Context context,
            IBookRepos bookRepos,
            ICategoryRepos categoryRepos,
            IValidator<Book> validator ,
             IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _bookRepos = bookRepos;
            _categoryRepos = categoryRepos;
            _validator = validator;
            this.webHostEnvironment =webHostEnvironment;
        }


        #region GetAllBooks
        public IActionResult Index()
        {
            var allBooks = _bookRepos.GetAll();
            return View(allBooks);
        }
        #endregion

        #region Detail Of Book
        public IActionResult Details(int? id)
        {
            if (!id.HasValue || !BookExists(id.Value))
                return NotFound();

            var book = _bookRepos.GetById(id.Value);
            return View(book);
        }
        #endregion

        #region + Create New Book
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepos.GetAll(), nameof(Category.Id), nameof(Category.Name));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            var validate = _validator.Validate(book);
            if (ModelState.IsValid && validate.IsValid)
            {
                // Handle file upload
             
                    // Upload logic: Save the file to wwwroot/images/cover folder
                    var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "covers");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + book.CoverPhotoFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        book.CoverPhotoFile.CopyTo(fileStream);
                    }

                    // Save the file path to the database
                    book.CoverPhoto = "/images/covers/" + uniqueFileName;

                    _context.Add(book);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
            }
            foreach (var item in validate.Errors) 
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            ViewData["CategoryId"] = new SelectList(_categoryRepos.GetAll(),
                nameof(Category.Id), nameof(Category.Name), book.CategoryId);
            return View(book);
        }
        #endregion

        #region For Edit book
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue || _context.Books is null)
                return NotFound();

            var book = _bookRepos.GetById(id.Value);
            if (book is null)
                return NotFound();

            ViewData["CategoryId"] = new SelectList(_categoryRepos.GetAll(), nameof(Category.Id), nameof(Category.Name), book.CategoryId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_categoryRepos.GetAll(), nameof(Category.Id), nameof(Category.Name), book.CategoryId);
            return View(book);
        }
        #endregion

        #region To Remove Book 
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue || _context.Books is null)
                return NotFound();

            var book = _bookRepos.GetById(id.Value);
            if (book is null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Books == null)
                return Problem("Entity set 'DB_Context.Books'  is null.");

            var book = _bookRepos.GetById(id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region To Check if Book is Exists
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
        #endregion
    }
}
