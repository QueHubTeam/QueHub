using System;
namespace QueHub.Domain.Entities;

public abstract class Auditable : BaseEntity
{

    public DateTime Create_at { get; set; }

    public DateTime Update_at { get; set; }
}
