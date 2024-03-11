namespace ef_core_mastering.Models;

public partial class ContactsUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ContactId { get; set; }

    public string Value { get; set; } = null!;

    public Contact Contact { get; set; } = null!;

    public User User { get; set; } = null!;
}
