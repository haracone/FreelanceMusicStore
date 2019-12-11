using System;
using System.Collections.Generic;

namespace TestProject.Models {
    public class ClientViewModel {
        public Guid Id { get; set; }
        public Guid Guid { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
        public ICollection<OrderViewModel> OrdersViewModel { get; set; }
    }
}