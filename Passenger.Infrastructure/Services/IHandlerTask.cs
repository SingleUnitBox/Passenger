using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IHandlerTask
    {
        IHandlerTask AlwaysAsync(Func<Task> always);
        IHandlerTask OnCustomErrorAsync(Func<PassengerException, Task> onCustomError,
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnErrorAsync(Func<Exception, Task> onError,
            bool propagateException = false, bool executeOnError = false);
        IHandlerTask OnSuccessAsync(Func<Task> onSuccess);
        IHandlerTask PropagateException();
        IHandlerTask DoNotPropagateException();
        IHandler Next();
        Task ExecuteAsync();
    }
}
