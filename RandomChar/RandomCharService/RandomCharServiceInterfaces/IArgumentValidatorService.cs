using System;
using System.Collections.Generic;
using System.Text;

namespace RandomCharServiceInterfaces
{
    public interface IArgumentValidatorService
    {
        IWorker Validation(string connectionType, string port);
    }
}
