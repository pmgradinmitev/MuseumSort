using System.ComponentModel.DataAnnotations;

namespace MuseumSort.Data.Entities
{
    public class Painting
    {
        public int Id {  get; set; }

        //Sets the max length of the string. In SQL Server, EF Core will create the column as nvarchar(50).
        [StringLength(50)]
        public string Name { get; set; }
        //Sets the max length of the string. In SQL Server, EF Core will create the column as nvarchar(60).
        [StringLength(60)]
        public string Author { get; set; }
    }
}
