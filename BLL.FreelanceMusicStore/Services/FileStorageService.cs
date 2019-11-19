using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;

namespace BLL.FreelanceMusicStore.Services
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<HttpResponseMessage> UploadFileAsync(FileDTO fileDTO)
        {
            HttpClient _client = new HttpClient();

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

            MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();

            fileDTO.FileName = Path.GetFileName(fileDTO.PostedFile.FileName);
            fileDTO.FileType = fileDTO.PostedFile.ContentType;
            using (var binaryReader = new BinaryReader(fileDTO.PostedFile.InputStream))
            {
                fileDTO.Data = binaryReader.ReadBytes(fileDTO.PostedFile.ContentLength);
            }
            fileDTO.PostedFile = null;

            var result = await _client.PostAsync("http://files.localhost.net/api/values/PostFile?id=1", fileDTO, bsonFormatter);

            return result;
        }

/*        public byte[] DownloadFile(Guid id)
        {
            return
        }*/
    }
}
