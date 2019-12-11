using System;

namespace TestProject.Models {
    public class FileViewModel {
        public FileViewModel() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public Guid OrderId { get; set; }
    }
}