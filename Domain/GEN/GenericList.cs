namespace Domain.GEN
{
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class GenericList
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
