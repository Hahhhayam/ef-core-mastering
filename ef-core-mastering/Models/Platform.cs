namespace ef_core_mastering.Models;

public partial class Platform
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<GamesPlatform> GamesPlatforms { get; set; } = null!;
}
