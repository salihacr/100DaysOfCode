using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.WebUI.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public string Name { get; set; }
    }
}
