namespace GessiWebApp.API.DTOs
{
    public class ClassificationDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public object ClassificationCode { get; set; }
        public object ClassificationName { get; set; }
    }

    public class ClassificationCreateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public object ClassificationCode { get; set; }
        public object ClassificationName { get; set; }
    }

    public class ClassificationUpdateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public object ClassificationCode { get; set; }
        public object ClassificationName { get; set; }
    }
}