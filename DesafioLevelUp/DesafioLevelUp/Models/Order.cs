using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioLevelUp.Models
{
    [Table("PEDIDOS")]
    public class Order
    {
        [Column("CODIGO")] public int Id { get; set; }
        [Column("DESCRICAO")] public string Descricao { get; set; }
        [Column("DATAPEDIDO")] public DateTime date { get; set; }
        [Column("VALORPEDIDO")] public float value { get; set; }
        [Column("STATUS")] public char status { get; set; }

    }
}
