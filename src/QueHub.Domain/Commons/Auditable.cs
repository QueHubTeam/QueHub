namespace QueHub.Domain.Commons;

public abstract class Auditable : BaseEntity
{
    public bool IsDeleted { get; set; } = false;

    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdateAt { get; set; }
}