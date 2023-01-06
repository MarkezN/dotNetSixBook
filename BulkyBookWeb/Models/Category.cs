using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,22, ErrorMessage="Ne valja ti ovaj range")]
        public int DisplayOrder { get; set; }   
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
