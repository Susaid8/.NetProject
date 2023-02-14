using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.DataAccess
{
    public class SampleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SampleText { get; set; }
        public DateTime Created { get; set; }
    }
}