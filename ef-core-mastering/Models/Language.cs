namespace ef_core_mastering.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public ICollection<LanguagesUser> LanguagesUsers { get; set; } = null!;
}
