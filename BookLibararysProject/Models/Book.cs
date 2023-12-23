using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibarary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public bool IsOfTheMonth { get; set; }

        [DisplayName("Cover Photo")]
        public string CoverPhoto { get; set; }
        [DisplayName("Cover Photo")]
        [NotMapped]
        public IFormFile CoverPhotoFile { get; set; }

        //Navigation Property
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
