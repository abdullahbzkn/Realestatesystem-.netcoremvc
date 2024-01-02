using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WhatWeDo
    {
        [Key]
        public int WhatWeDoID { get; set; }
        public string Baslik { get; set; }
        public string NeYapiyoruzMetni { get; set; }
        public string KBaslik1 { get; set; }
        public string Metin1 { get; set; }
        public string KBaslik2 { get; set; }
        public string Metin2 { get; set; }
        public string KBaslik3 { get; set; }
        public string Metin3 { get; set; }
        public string KBaslik4 { get; set; }
        public string Metin4 { get; set; }
    }
}
