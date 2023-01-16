using System;
using System.Collections.Generic;

namespace MyWC.DataModels.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Phone> Phones { get; } = new List<Phone>();
}
