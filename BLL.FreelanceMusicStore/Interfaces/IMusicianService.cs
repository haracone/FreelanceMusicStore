using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface IMusicianService {
        Task<ServerRequest> CreateMusician(ApplicationUserDTO user);
        MusicianDTO GetMusicianById(Guid id);
        Task AddMusicInstrumentsToMusician(ICollection<MusicInstrumentDTO> musicInstrumentDTOs, /*MusicianDTO musicianDTO*/Guid guid);
    }
}
