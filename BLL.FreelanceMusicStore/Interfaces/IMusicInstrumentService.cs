using BLL.FreelanceMusicStore.EntityDTO;
using Domain.FreelanceMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IMusicInstrumentService
    {
        ICollection<MusicInstrumentDTO> GetAll();
        MusicInstrumentDTO GetById(int Id);
    }
}
