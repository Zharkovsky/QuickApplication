using DAL.Models;
using FluentValidation;


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
