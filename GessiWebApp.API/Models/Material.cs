namespace GessiWebApp.API.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public List<Classification> Classifications { get; set; }
        public List<string> Images { get; set; }
        public string MainImage { get; set; }
        public DateTime CreationDate { get; set; }
    }
}