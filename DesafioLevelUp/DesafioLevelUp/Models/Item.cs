using DesafioLevelUp.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioLevelUp.Models
{
    [Table("ITEMS")]
    public class Item: BaseEntity
    {
 
        [Column("CODIGOPEDIDO")] public int OrderId { get; set; }

        [ForeignKey("OrderId")] public Order Order { get; set; }

        [Column("DESCRICAO")] public string Description { get; set; }

        [Column("VALORITEM")] public float Value { get; set; }
    }
}
