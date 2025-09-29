using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceHousingPhoto
    {
        [Key]
        public int ServiceHousingPhotoID { get; set; }
        public string? FotografYolu { get; set; }
        public int? ServiceHousingId { get; set; }
        public virtual ServiceHousing ServiceHousing { get; set; }
    }
}
