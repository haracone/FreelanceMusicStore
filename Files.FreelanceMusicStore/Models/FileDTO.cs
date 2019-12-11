using System;
using System.Web;

namespace Files.FreelanceMusicStore.Models {
    public class FileDTO {
        public FileDTO() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
        public string FileType { get; set; }
        public Guid OrderId { get; set; }
    }
}