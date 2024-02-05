using System;
using System.Collections.Generic;

namespace AccessToDatabase_Entity;

public partial class UserWithCompany
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
}
