using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceTerrain
    {
        public int ServiceTerrainID { get; set; }
        public string Baslik { get; set; }
        public string Gorsel { get; set; }
        public int Fiyat { get; set; }
        public string TapuDurumu { get; set; }
        public bool KatKarsiligi { get; set; }
        public bool KrediyeUygun { get; set; }
        public int TapuParsel { get; set; }
        public int TapuPafta { get; set; }
        public int TapuAda { get; set; }
        public int VadeVarmi { get; set; }
        public int IzinVerilenKatAdedi { get; set; }
        public string BelediyeAdi { get; set; }
        public bool TakasYapilir { get; set; }
        public bool IskanDurumu { get; set; }
        public int TabanInsaaAlani { get; set; }
        public int ToplamInsaatAlani { get; set; }
        public int MaksimumBinaYuksekligi { get; set; }
        public string UzunAciklama { get; set; }
        public string KonumLink { get; set; }
        public int KonumId { get; set; }
        public int BilgiId { get; set; }
        [ForeignKey("KonumId")]
        public virtual Konum Konum { get; set; }
        [ForeignKey("BilgiId")]
        public virtual Bilgi Bilgi { get; set; }
    }
}
