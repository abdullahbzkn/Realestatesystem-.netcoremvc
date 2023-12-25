﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string KisiAdi { get; set; }
        public string Aciklama { get; set; }
        public string FotografYolu { get; set; }

    }
}
