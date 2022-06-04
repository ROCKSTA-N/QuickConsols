using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Millennial")]
    public class Millennial
    {
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string IsMillennial { get; set; }
    }
}
