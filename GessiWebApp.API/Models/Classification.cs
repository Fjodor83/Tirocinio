using System.ComponentModel.DataAnnotations.Schema;

namespace GessiWebApp.API.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public object ClassificationCode { get; internal set; }
        [NotMapped]
        public object ClassificationName { get; internal set; }
    }
}