using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Files.FreelanceMusicStore.Models
{
    public class FileViewModel
    {
        public FileViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
    }
}