using System.ComponentModel.DataAnnotations;

namespace Rentsas.Api.Core.Entities;
internal abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
