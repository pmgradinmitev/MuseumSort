using Microsoft.EntityFrameworkCore;
using MuseumSort.Data.Entities;

namespace MuseumSort.Data.Seed
{
    public class PaintingSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            //Looks for any paintings. If no found, seeds the table.
            if (!context.Paintings.Any())
            {
                context.Paintings.AddRange(
                    new Painting
                    {
                        Name = "Мона Лиза",
                        Author = "Леонардо да Винчи",
                    },
                    new Painting
                    {
                        Name = "Картината в Живерние",
                        Author = "Клод Моне",
                    },
                    new Painting
                    {
                        Name = "Момиче пред огледалото",
                        Author = "Пабло Пикасо",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
