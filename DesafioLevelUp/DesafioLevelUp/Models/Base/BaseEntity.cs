using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioLevelUp.Models.Base
{
    public class BaseEntity
    {
        [Column("CODIGO")] public int Id { get; set; }
    }
}
