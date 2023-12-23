using BookLibarary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookLibarary.ModelConfiguration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book ");

            builder.HasKey(b => b.Id).HasName("BookId");

            builder.Property(b => b.Name).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(b => b.ISBN).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(b=>b.IsOfTheMonth).HasDefaultValue(false);

            //navigation Property 

            builder.HasOne(BD => BD.Category).WithMany(BD => BD.Books).HasForeignKey(BD => BD.CategoryId);

        }
    }
}
