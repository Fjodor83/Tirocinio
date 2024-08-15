namespace GessiWebApp.API.Models
{
    public class Movement
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // "In" or "Out"
        public string Notes { get; set; }
    }
}