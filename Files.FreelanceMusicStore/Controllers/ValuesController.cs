using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Files.FreelanceMusicStore.Controllers {
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController {
        private IMapper _mapper;

        public ValuesController(IMapper mapper) {
            _mapper = mapper;
        }

        public ValuesController() {

        }
        // GET api/values
        /*        public IEnumerable<string> Get()
                {
                    return new string[] { "value1", "value2" };
                }
        */
        // GET api/values/5
        public HttpResponseMessage GetFile(Guid Id) {
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~\\Files" + $"\\{Id}");
            string[] files = Directory.GetFiles(folderPath);
            var finalString = new List<string>();
            foreach (var file in files) {
                string sss = AppDomain.CurrentDomain.BaseDirectory;
                string f = file.Replace(AppDomain.CurrentDomain.BaseDirectory, "http:\\files.localhost.net\\");
                finalString.Add(f);
            }
            files = finalString.ToArray();
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(String.Join("/", files), Encoding.UTF8, "application/json");
            return response;
        }

        // POST api/values
        public async void PostFile(FileDTO.FileDTO fileDTO) {
            string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/Files" + $"/{fileDTO.OrderId}");
            Directory.CreateDirectory(folderPath);
            using (FileStream fileStream = new FileStream(Path.Combine(folderPath, fileDTO.FileName), FileMode.Create)) {
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
