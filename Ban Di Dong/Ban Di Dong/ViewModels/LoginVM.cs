using System.ComponentModel.DataAnnotations;

namespace Ban_Di_Dong.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Chưa nhập tên đăng nhập")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 kí tự ")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { get; set; }
    }
}
