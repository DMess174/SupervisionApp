using System;

namespace Supervision.Commands
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
