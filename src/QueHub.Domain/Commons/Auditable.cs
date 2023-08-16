namespace QueHub.Domain.Commons;

public abstract class Auditable : BaseEntity
{
    public bool IsDeleted { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}