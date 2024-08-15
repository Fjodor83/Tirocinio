namespace GessiWebApp.API.DTOs
{
    public class MissionDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public List<MissionItemDto> Items { get; set; }
        public object Materials { get; set; }
    }

    public class MissionItemDto
    {
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public int Quantity { get; set; }
        public string MaterialDescription { get; set; }
       // public global::iText.Layout.Element.Cell MaterialDescription { get; set; }
    }

    public class MissionCreateDto
    {
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<MissionItemCreateDto> Items { get; set; }
    }

    public class MissionItemCreateDto
    {
        public int MaterialId { get; set; }
        public int Quantity { get; set; }
    }

    public class MissionUpdateDto
    {
        public string DestinationType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<MissionItemCreateDto> Items { get; set; }
    }
}