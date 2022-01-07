using DesafioLevelUp.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioLevelUp.Models
{
    [Table("PEDIDOS")]
    public class Order: BaseEntity
    {
        [Column("DESCRICAO")] public string Descricao { get; set; }
        [Column("DATAPEDIDO")] public DateTime Date { get; set; }
        [Column("VALORPEDIDO")] public float Value { get; set; }
        [Column("STATUS")] public char Status { get; set; }
        // [ForeignKey("OrderId")]
        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }
    }
}
