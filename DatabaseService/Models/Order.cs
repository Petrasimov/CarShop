using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseService.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [Display(Name="Имя")]
        [StringLength(50, ErrorMessage = "Превышена максимальная длина поля")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(50, ErrorMessage = "Превышена максимальная длина поля")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string SName { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(50, ErrorMessage = "Превышена максимальная длина поля")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите электронную почту")]
        public string Email { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(250, ErrorMessage = "Превышена максимальная длина поля")]
        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        [StringLength(11, ErrorMessage = "Превышена максимальная длина поля")]
        [Required(ErrorMessage = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone{ get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
