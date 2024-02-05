using System;
using System.Collections.Generic;

namespace AccessToDatabase_Entity;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
