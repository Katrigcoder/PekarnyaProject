namespace PekarnyaProject.Models
{
    public class Product
    {
        public int Id { get; set; } // Унікальний номер
        public required string Name { get; set; } // Назва товару 
        public decimal Price { get; set; } // Ціна
        public int Count { get; set; }
        public required string Description { get; set; }
    }
}
