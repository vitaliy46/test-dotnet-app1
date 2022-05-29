using System.ComponentModel.DataAnnotations;

namespace Kis.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}