using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Player
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Nickname не может быть меньше 3 символов и максимум 16 символов")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Токен не может быть пустым")]
        [StringLength(40, MinimumLength = 40, ErrorMessage = "Токен не валидный")]
        public string Token { get; set; }
    }
}
