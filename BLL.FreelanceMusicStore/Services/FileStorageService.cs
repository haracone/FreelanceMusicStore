using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BLL.FreelanceMusicStore.EntityDTO;

namespace BLL.FreelanceMusicStore.Services
{
    public class FileStorageService
    {
        public async Task UploadFileAsync(FileDTO soundFileDTO, string folderPath)
        {
            using (FileStream fileStream = new FileStream(folderPath, FileMode.Create))
            {
                await fileStream.WriteAsync(soundFileDTO.Data, 0, soundFileDTO.Data.Length - 1);
            }
        }

/*        public byte[] DownloadFile(Guid id)
        {
            return
        }*/
    }
}
