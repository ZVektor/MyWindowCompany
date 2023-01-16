using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWC.DataModels.Models;

public partial class Phone
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указан номер телефона")]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Телефон")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Формат телефона не верный")]
    public string PhoneNumber { get; set; } = null!;

    public int? PeopleId { get; set; }

    public virtual Person? People { get; set; }
}
