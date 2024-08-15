namespace GessiWebApp.API.DTOs
{
    public class MovementDto
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }

    public class MovementCreateDto
    {
        public int MaterialId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }
}