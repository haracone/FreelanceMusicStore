using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Files.FreelanceMusicStore.Models;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;
using System.IO;

namespace Files.FreelanceMusicStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private IMapper _mapper;       

        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ValuesController()
        {

        }
        // GET api/values
/*        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
*/
        // GET api/values/5
        public FileDTO GetFile(Guid Id)
        {
            FileDTO file = new FileDTO();
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Files");
            using (FileStream fileStream = new FileStream(folderPath + $"/{Id}", FileMode.Open))
            {
                fileStream.CopyToAsync(file.PostedFile.InputStream);
            }
            return file;
        }

        // POST api/values
        public async void PostFile(FileDTO fileDTO)
        {
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Files");
            using (FileStream fileStream = new FileStream(folderPath + $"/{fileDTO.Id}", FileMode.Create))
            {
                await fileStream.WriteAsync(fileDTO.Data, 0, fileDTO.Data.Length);
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
