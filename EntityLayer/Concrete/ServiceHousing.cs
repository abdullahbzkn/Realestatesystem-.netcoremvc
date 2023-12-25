using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceHousing
    {
        [Key]
        public int ServiceHousingID { get; set; }
        public string Baslik { get; set; }
        public string Gorsel { get; set; }
        public int Fiyat { get; set; }
        public bool Status { get; set; }
        public string TapuDurumu { get; set; }
        public string YapininDurumu { get; set; }
        public string Isitma { get; set; }
        public int BinaKatSayisi { get; set; }
        public string YapininCephesi { get; set; }
        public string YapininSekli { get; set; }
        public int TuvaletSayisi { get; set; }
        public int BalkonSayisi { get; set; }
        public int BanyoSayisi { get; set; }
        public int SalonSayisi { get; set; }
        public int OdaSayisi { get; set; }
        public int KiraGetirisi { get; set; }
        public bool TakasYapilir { get; set; }
        public string KullanimDurumu { get; set; }
        public string YakitTipi { get; set; }
        public int BulunduguKat { get; set; }
        public int Aidat { get; set; }
        public bool KrediyeUygun { get; set; }
        public bool Devren { get; set; }
        public string UzunAciklama { get; set; }
        public string KonumLink { get; set; }

        public int ServiceMapId { get; set; }
        [ForeignKey("ServiceMapId")]
        public virtual ServiceMap ServiceMap { get; set; }


        public int ServiceInfoId { get; set; }
        [ForeignKey("ServiceInfoId")]
        public virtual ServiceInfo ServiceInfo { get; set; }
    }
}
