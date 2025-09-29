using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactUs
    {
        [Key]
        public int ContactUsID { get; set; }
        public string? IletisimMetni { get; set; }
    }
}
