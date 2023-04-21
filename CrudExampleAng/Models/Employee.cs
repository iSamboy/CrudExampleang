using System;
using System.Collections.Generic;

namespace CrudExampleAng.Models;

public partial class Employee
{
    public int IdPerson { get; set; }

    public string? FullName { get; set; }

    public int? IdOffice { get; set; }

    public int? Salary { get; set; }

    public DateTime? ContractDate { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Office? IdOfficeNavigation { get; set; }
}
