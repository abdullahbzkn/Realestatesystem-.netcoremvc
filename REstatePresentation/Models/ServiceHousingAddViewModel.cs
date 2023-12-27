using System.ComponentModel.DataAnnotations;

namespace REstatePresentation.Models
{
    public class ServiceHousingAddViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public string Baslik { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat boş geçilemez")]
        public int Fiyat { get; set; }

        [Display(Name = "Uzun Açıklama")]
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string UzunAciklama { get; set; }

    }
}
