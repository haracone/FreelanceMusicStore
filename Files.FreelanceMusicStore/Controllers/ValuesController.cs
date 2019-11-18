using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BLL.FreelanceMusicStore.Services;
using Files.FreelanceMusicStore.Models;
using BLL.FreelanceMusicStore.EntityDTO;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;

namespace Files.FreelanceMusicStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private FileStorageService _storageService;
        private IMapper _mapper;       

        ValuesController(IMapper mapper)
        {
            _storageService = new FileStorageService();
            _mapper = mapper;
        }
        // GET api/values
/*        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
*/
        // GET api/values/5
        public string GetFile(int id)
        {
            return "1";
        }

        // POST api/values
        public async Task PostFile(FileDTO fileDTO)
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Files/");

            foreach (var file in provider.Contents)
            {
                fileDTO.FileName = file.Headers.ContentDisposition.FileName;
                fileDTO.Data = await file.ReadAsByteArrayAsync();
                await _storageService.UploadFileAsync(fileDTO, folderPath + fileDTO.FileName + fileDTO.Id);
            }
        }

        // PUT api/values/5
/*        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }*/
    }
}
