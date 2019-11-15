using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.FreelanceMusicStore.Entities
{
    public class MusicInstrument
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
