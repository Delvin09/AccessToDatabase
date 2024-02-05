using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessToDatabase_Entity;

public partial class Address
{
    public int Id { get; set; }

    public string AddVal { get; set; } = null!;

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public override string ToString()
    {
        return $"{Id} - {AddVal} - {CompanyId}";
    }
}
