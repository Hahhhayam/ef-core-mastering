using System;
using System.Collections.Generic;

namespace ef_core_mastering.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public ICollection<ContactsUser> ContactsUsers { get; set; } = null!;
}
