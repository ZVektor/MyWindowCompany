using System;
using System.Collections.Generic;

namespace MyWC.DataModels.Models;

public partial class Phone
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int? PeopleId { get; set; }

    public virtual Person? People { get; set; }
}
