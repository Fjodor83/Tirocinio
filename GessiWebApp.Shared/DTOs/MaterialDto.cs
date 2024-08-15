namespace GessiWebApp.API.DTOs
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<string> Classifications { get; set; }
        public List<string> Images { get; set; }
        public string MainImage { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalInventory { get; set; }
    }

    public class MaterialCreateDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<string> Classifications { get; set; }
        public List<string> Images { get; set; }
        public string MainImage { get; set; }

    }

    public class MaterialUpdateDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<string> Classifications { get; set; }
        public List<string> Images { get; set; }
        public string MainImage { get; set; }
    }
}