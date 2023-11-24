using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.BusinessLayer.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> TGetByIdAsync(int id);
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
    }

}
