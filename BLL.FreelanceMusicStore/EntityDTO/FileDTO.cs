using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.FreelanceMusicStore.EntityDTO
{
    public class FileDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public Guid OrderId { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
    }
}
