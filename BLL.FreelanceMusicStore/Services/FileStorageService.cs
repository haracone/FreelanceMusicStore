using BLL.FreelanceMusicStore.EntityDTO;
using BLL.FreelanceMusicStore.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Services {
    public class FileStorageService : IFileStorageService {
        public async Task<ServerRequest> UploadFileAsync(FileDTO.FileDTO fileDTO) {
            var serverRequest = new ServerRequest();
            try {
                HttpClient _client = new HttpClient();

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));

                MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();

                await _client.PostAsync("http://files.localhost.net/api/values/PostFile?id", fileDTO, bsonFormatter);

                return serverRequest;
            }
            catch {
                serverRequest.ErrorOccured = true;
                serverRequest.Message = "Error was occcured when you try Upload File";
                return serverRequest;
            }
        }

        public async Task<HttpResponseMessage> DownloadFile(Guid id) {
            var _client = new HttpClient();
            MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
            var result = await _client.GetAsync($"http://files.localhost.net/api/values/GetFile?id={id}");
            return result;
        }
    }
}
