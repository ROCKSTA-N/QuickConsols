using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
