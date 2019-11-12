using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FreelanceMusicStore.Interfaces
{
    public interface IConvertEntityToDTO<T, K>
    {
        K ConvertEntityToDTO(T Entity);
    }
}
