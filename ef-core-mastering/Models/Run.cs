namespace ef_core_mastering.Models;

public partial class Run
{
    public int Id { get; set; }

    public int GamePlatformId { get; set; }

    public int CategoryId { get; set; }

    public string VideoUrl { get; set; } = null!;

    public TimeOnly Result { get; set; }

    public DateTime Uploaded { get; set; }

    public ICollection<Approve> Approves { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public GamesPlatform GamePlatform { get; set; } = null!;
    public ICollection<Team> Teams { get; set; } = null!;
}
