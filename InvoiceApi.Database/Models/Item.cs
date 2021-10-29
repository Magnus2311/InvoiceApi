using InvoiceApi.Database.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class Item : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Measure { get; set; }
        public decimal Price { get; set; }
        public string Account { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
