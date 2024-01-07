using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REstatePresentation.Models
{
    public class TeamAddViewModel
    {
        public Team Team {  get; set; }
        [NotMapped]
        public IFormFile Gorsel { get; set; }
        public string GorselYolu { get; set; }

    }
}
