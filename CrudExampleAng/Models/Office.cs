using System;
using System.Collections.Generic;

namespace CrudExampleAng.Models;

public partial class Office
{
    public int IdOffice { get; set; }

    public string? OfficeName { get; set; }

    public DateTime? DateCreation { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
