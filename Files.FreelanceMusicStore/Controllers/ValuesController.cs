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
using System.Web;
using System.IO.Compression;
using System.Text;

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
        public HttpResponseMessage GetFile(Guid Id)
        {
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~\\Files" + $"\\{Id}");
            var files = Directory.GetFiles(folderPath);
            List<string> finalString = new List<string>();
            foreach (var file in files)
            {
                string f = file.Replace(Directory.GetCurrentDirectory(), "http:\\files.localhost.net\\");
                finalString.Add(f);
                
            }
            files = finalString.ToArray();
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(String.Join("/", files), Encoding.UTF8, "application/json");
            return response;
        }

        // POST api/values
        public async void PostFile(FileDTO fileDTO)
        {
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Files" +  $"/{fileDTO.OrderId}");
            Directory.CreateDirectory(folderPath);
            using (FileStream fileStream = new FileStream(folderPath + $"/{fileDTO.FileName}", FileMode.Create))
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
