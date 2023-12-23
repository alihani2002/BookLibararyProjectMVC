using BookLibarary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.ModelConfiguration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories ");

            builder.HasKey(c => c.Id).HasName("CategoryID");

            builder.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();

            //Navigation Property => relation many to one with book
            builder.HasMany(C => C.Books).WithOne(C => C.Category);

        }
    }
}
