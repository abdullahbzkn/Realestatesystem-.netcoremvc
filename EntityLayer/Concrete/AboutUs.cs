using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutUs
    {
        [Key] public int AboutUsID { get; set; }
        public string HakkimizdaMetni { get; set; }
    }
}
