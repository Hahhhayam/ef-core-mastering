namespace ef_core_mastering.Models;

public partial class LanguagesUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int LanguageId { get; set; }

    public Language Language { get; set; } = null!;

    public User User { get; set; } = null!;
}
