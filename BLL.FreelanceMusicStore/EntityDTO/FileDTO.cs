using System;

namespace BLL.FreelanceMusicStore.EntityDTO {
    public class FileDTO {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public Guid OrderId { get; set; }
    }
}
