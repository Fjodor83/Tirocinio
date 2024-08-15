namespace GessiWebApp.API.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public List<MissionItem> Items { get; set; }
    }

    public class MissionItem
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int Quantity { get; set; }
    }
}