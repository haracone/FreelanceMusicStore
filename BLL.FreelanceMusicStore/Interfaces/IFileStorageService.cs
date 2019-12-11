using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces {
    public interface IFileStorageService {
        Task<ServerRequest> UploadFileAsync(FileDTO.FileDTO fileDTO);
        Task<HttpResponseMessage> DownloadFile(Guid id);
    }
}
