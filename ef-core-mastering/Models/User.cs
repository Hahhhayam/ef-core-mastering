namespace ef_core_mastering.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public int CountryId { get; set; }

    public ICollection<Approve> Approves { get; set; } = null!;

    public ContactsUser? ContactsUser { get; set; }

    public Country Country { get; set; } = null!;

    public LanguagesUser? LanguagesUser { get; set; }

    public ICollection<Team> Teams { get; set; } = null!;
}
