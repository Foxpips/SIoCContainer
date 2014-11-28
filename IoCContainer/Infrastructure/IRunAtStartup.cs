using System;

namespace SIoCContainer.Infrastructure
{
    public interface IRunAtStartup
    {
        void ExecuteOnStartup();
        void ExecuteOnShutdown();
        void ExecuteOnStartup(object sender, AssemblyLoadEventArgs args);
        void ExecuteOnShutdown(object sender, AssemblyLoadEventArgs args);
    }
}