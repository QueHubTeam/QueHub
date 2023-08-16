using QueHub.Domain.Commons;

namespace QueHub.Domain.Entity.Category;

public class CategoryEntity : Auditable
{
    public string Name { get; set; } = string.Empty;
}