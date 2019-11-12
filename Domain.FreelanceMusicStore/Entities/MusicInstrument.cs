using System.ComponentModel.DataAnnotations;

namespace Domain.FreelanceMusicStore.Entities
{
    public class MusicInstrument
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
