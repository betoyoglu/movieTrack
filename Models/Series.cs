using System.ComponentModel.DataAnnotations;
    
    namespace WebProject.Models
{
    public class Series
    {
        [Key]

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public string Description { get; set; }

        [Required]

        public string Genre { get; set; }

        [Required]

        public string OriginalLanguage { get; set; }
    }
}
