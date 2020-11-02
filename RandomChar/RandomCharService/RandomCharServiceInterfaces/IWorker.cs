using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RandomCharServiceInterfaces
{
    public interface IWorker
    {
        void Connect();

        Task SendAsync();

        Task GetAsync();
    }
}
