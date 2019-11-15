using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Collections.Generic;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IMusicInstrumentService
    {
        List<MusicInstrumentDTO> GetAll();
        MusicInstrumentDTO GetById(Guid Id);
    }
}
