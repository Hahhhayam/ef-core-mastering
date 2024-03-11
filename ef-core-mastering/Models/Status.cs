namespace ef_core_mastering.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public ICollection<Approve> Approves { get; set; } = null!;
}
