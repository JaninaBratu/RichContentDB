using System.ServiceProcess;
using System;
using RCD.DAL;
using RCD.BL;
using RCD.Model;
using System.Collections.Generic;
using RCD.BL.Services;

namespace RCD.WindowsService
{
    static class MainProgram
    {

        static void Main()
        {

#if DEBUG
            //System.Diagnostics.Debugger.Launch();
            Service1 myService = new Service1();
              myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite); //keep the service alive
            
        }

#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
            new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#endif

        }
}
