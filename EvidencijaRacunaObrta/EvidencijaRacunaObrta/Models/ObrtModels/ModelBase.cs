using System.ComponentModel.DataAnnotations;

namespace EvidencijaRacunaObrta.Models.ObrtModels
{
    public class ModelBase<T>
    {
        public T Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserId mora biti veći od 0")]
        public int UserId { get; set; }
    }
}