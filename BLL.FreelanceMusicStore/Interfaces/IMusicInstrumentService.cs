using BLL.FreelanceMusicStore.EntityDTO;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IMusicInstrumentService
    {
        List<MusicInstrumentDTO> GetAll();
        MusicInstrumentDTO GetById(int Id);
    }
}
