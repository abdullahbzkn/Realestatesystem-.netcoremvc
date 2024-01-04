using System.ComponentModel.DataAnnotations;

namespace REstatePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı Giriniz !")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Lütfen Mail Adresi Giriniz !")]
        public string mail { get; set; }


        [Required(ErrorMessage = "Lütfen Şifre Giriniz !")]
        public string password { get; set; }


        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz !")]
        [Compare("password",ErrorMessage ="Şifreler Uyumlu Değil, kontrol edin !")]
        public string passwordConfirm { get; set; }
    }
}
