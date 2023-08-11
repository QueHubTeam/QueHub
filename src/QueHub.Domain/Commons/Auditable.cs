namespace QueHub.Domain.Commons;

public abstract class Auditable : BaseEntity
{
    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
