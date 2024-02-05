using System;
using System.Collections.Generic;

namespace AccessToDatabase_Entity;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
