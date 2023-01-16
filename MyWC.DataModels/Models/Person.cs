using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWC.DataModels.Models;

public partial class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указано имя")]
    [DataType(DataType.Text)]
    [Display(Name = "Имя")]
    [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Не верный формат, допускаются только буквы")]
    //TODO Переделать строку приведения. Можно дополнить пробелы, тире, апостроф
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 35 символов")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Фамилия")]
    [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Не верный формат, допускаются только буквы")]
    [StringLength(50, ErrorMessage = "Длина строки должна быть от 3 до 35 символов")]
    public string? LastName { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Город")]
    [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Не верный формат, допускаются только буквы")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 35 символов")]
    public string? City { get; set; }

    public virtual ICollection<Phone> Phones { get; } = new List<Phone>();

    //Длина имени может быть и одна буква ???

    //Валидация телефона - чтоб было ;)
    //[DataType(DataType.PhoneNumber)]
    //[Display(Name = "Phone Number")]
    //[Required(ErrorMessage = "Phone Number Required!")]
    //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", 
    //    ErrorMessage = "Entered phone format is not valid.")]

    //Валидация Email - чтоб было ;)
    //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", 
    //    ErrorMessage = "Некорректный адрес")]

    //[RegularExpression(@"([А-ЯЁ][а-яё]+)|[A-Z][a-z]+", ErrorMessage = "Не правильный формат - либо русскими буквали, ....")]
    //[Range(18, 80, ErrorMessage ="Возраст от 18 до 80")]
}
