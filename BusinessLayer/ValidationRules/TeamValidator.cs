using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.KisiAdi).NotEmpty().WithMessage("Takım Arkadaşı İsim Bilgileri Boş Geçilemez");
            RuleFor(x => x.Aciklama).NotEmpty().WithMessage("Açıklama Bilgisi Boş Geçilemez");
            RuleFor(x => x.KisiAdi).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter veri girişi yapın");
            RuleFor(x => x.KisiAdi).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapın");
            RuleFor(x => x.Aciklama).MinimumLength(8).WithMessage("Lütfen en az 8 karakter veri girişi yapın");
           
        }
    }
}
