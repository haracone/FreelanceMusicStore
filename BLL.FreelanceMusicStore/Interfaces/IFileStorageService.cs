using BLL.FreelanceMusicStore.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IFileStorageService
    {
        Task<HttpResponseMessage> UploadFileAsync(FileDTO fileDTO);
    }
}
