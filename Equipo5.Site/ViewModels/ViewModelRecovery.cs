using System.ComponentModel.DataAnnotations;

namespace Equipo5.Site.ViewModels
{
    public class ViewModelRecovery
    {
        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        public string Email { get; set; }


    }
}