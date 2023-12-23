using BookLibarary.Models;
using FluentValidation;
using System;

namespace BookLibarary.FluintValidtion
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Name).NotEmpty().NotNull().WithMessage("Please enter a name for the book.");
            RuleFor(book => book.ISBN).NotEmpty().NotNull().WithMessage("Please enter the ISBN.");
            RuleFor(book => book.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(book => book.CoverPhotoFile).Must(BeAValidImage).WithMessage("Invalid image format for the cover photo.");
            // Example of custom rule for CategoryId
            RuleFor(book => book.CategoryId).NotEmpty().WithMessage("Please select a category for the book.");
        }

        private bool BeAValidImage(IFormFile coverPhotoFile)
        {
            // Customize this method based on your image validation logic
            if (coverPhotoFile is null || coverPhotoFile.Length == 0)
                return false;

            return true;
        }
    }

}
