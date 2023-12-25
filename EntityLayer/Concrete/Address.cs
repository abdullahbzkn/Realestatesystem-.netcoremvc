using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Address
    {
        [Key]
        public int AdressID { get; set; }
        public string Aciklama1 { get; set; }
        public string Mail { get; set; }
        public string HaritaLink { get; set; }
        public string Tel { get; set; }
        
    }
}
