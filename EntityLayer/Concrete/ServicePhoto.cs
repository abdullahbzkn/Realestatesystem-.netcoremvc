using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServicePhoto
    {
        [Key]
        public int ServicePhotoID { get; set; }
        public string FotografYolu { get; set; }

        public int ServiceInfoId { get; set; }
        [ForeignKey("ServiceInfoId")]
        public virtual ServiceInfo ServiceInfo { get; set; }
    }
}
