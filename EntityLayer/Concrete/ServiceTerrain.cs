using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceTerrain
    {
        [Key]
        public int ServiceTerrainID { get; set; }
        public string Baslik { get; set; }
        public string? Gorsel { get; set; }
        public int Fiyat { get; set; }
        public bool? Status { get; set; }
        public string? TapuDurumu { get; set; }
        public bool? KatKarsiligi { get; set; }
        public bool? KrediyeUygun { get; set; }
        public int? TapuParsel { get; set; }
        public int? TapuPafta { get; set; }
        public int? TapuAda { get; set; }
        public bool? VadeVarmi { get; set; }
        public int?  IzinVerilenKatAdedi { get; set; }
        public string? BelediyeAdi { get; set; }
        public bool? TakasYapilir { get; set; }
        public bool? IskanDurumu { get; set; }
        public int? TabanInsaaAlani { get; set; }
        public int? ToplamInsaatAlani { get; set; }
        public int? MaksimumBinaYuksekligi { get; set; }
        public string? UzunAciklama { get; set; }
        public string? KonumLink { get; set; }


        public int? ServiceMapId { get; set; }
        public virtual ServiceMap ServiceMap { get; set; }


        public int? ServiceInfoId { get; set; }
        public virtual ServiceInfo ServiceInfo { get; set; }

        public virtual ICollection<ServicePhoto> ServicePhotos { get; set; }
    }
}
