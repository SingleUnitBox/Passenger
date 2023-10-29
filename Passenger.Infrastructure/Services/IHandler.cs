using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IHandler : IService
    {
        IHandlerTask RunAsync(Func<Task> run);
        IHandlerTaskRunner ValidateAsync(Func<Task> validate);
        Task ExecuteAllAsync();
    }
}
