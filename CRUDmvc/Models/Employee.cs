using System.ComponentModel.DataAnnotations;
namespace CRUDmvc.Models

{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="**Name should be filled**")]
        public string Name { get; set; }

        [Required(ErrorMessage = "**City should be filled**")]
        public string City { get; set; }

        [Required(ErrorMessage = "**Position should be filled**")]
        public string Position { get; set; }

        [Required]
        public decimal? Salary { get; set; }

    }
}
