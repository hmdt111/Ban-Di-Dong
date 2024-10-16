using Ban_Di_Dong.Data;
using System.ComponentModel.DataAnnotations;

namespace Ban_Di_Dong.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "ID")]
        public int UserId { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Chưa nhập tên đăng nhập")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 kí tự ")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Chưa đúng định dạng email")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 kí tự ")]
        [Required(ErrorMessage = "Chưa nhập email")]
        public string UserEmail { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [MaxLength(10,ErrorMessage ="Tối đa 10 kí tự ")]
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage ="Chưa đúng định dạng")]
        public string UserPhoneNumber { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Chưa chọn ngày sinh")]
        public DateTime NgaySinh { get; set; }
        

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Chưa nhập địa chỉ")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 kí tự ")]
        public string? DiaChi { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Chưa nhập họ và tên")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 kí tự ")]
        public string? HoTen { get; set; }

        public int? RoleId { get; set; } = 1;

        public virtual TbRole? Role { get; set; }
    }
}
