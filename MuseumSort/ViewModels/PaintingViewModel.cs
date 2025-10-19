using MuseumSort.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuseumSort.ViewModels
{
    public class PaintingViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Име")]
        [StringLength(50, MinimumLength = 5)]
        public string Name {  get; set; }
        [DisplayName("Автор")]
        [StringLength(60, MinimumLength = 10)]
        public string Author {  get; set; }

        public void MapTo(Painting entity)
        {
            entity.Name = Name;
            entity.Author = Author;
        }
        public void MapFrom(Painting entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Author = entity.Author;
        }
    }
}
