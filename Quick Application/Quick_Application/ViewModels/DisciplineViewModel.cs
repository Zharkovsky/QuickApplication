using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quick_Application.ViewModels
{
    public class DisciplineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }




    public class DisciplineViewModelValidator : AbstractValidator<DisciplineViewModel>
    {
        public DisciplineViewModelValidator()
        {
            RuleFor(register => register.Name).NotEmpty().WithMessage("Имя дисциплины не может быть пустым");
        }
    }
}
