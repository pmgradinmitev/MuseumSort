using MuseumSort.Common.BaseModels;
using MuseumSort.Data.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuseumSort.ViewModels
{
    public class PaintingsTableViewModel:BaseTableViewModel<Painting>
    {
        [DisplayName("Име")]
        public string Name { get; set; }
        [DisplayName("Автор")]
        public string Author { get; set; }
    }
}
