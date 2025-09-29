using System.ComponentModel.DataAnnotations;

namespace REstatePresentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin !")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Girin !")]
        public string password { get; set; }
    }
}
