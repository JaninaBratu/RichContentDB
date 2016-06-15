using RCD.BL.Utils;
using RCD.WindowsService.SharingFiles;
using System;
using System.ServiceProcess;
using System.Timers;


namespace RCD.WindowsService
{

    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
       
            Sharing shareObject = new Sharing();
            shareObject.StartSharing();
        }

        public void OnDebug() {
            Sharing shareObject = new Sharing();
            shareObject.StartSharing();
        }

      

        protected override void OnStop()
        {
            //System.IO.Files.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
        }

        /// <summary>
        /// Initialize the cron
        /// </summary>
        private void StartSharing()
        {
            new Cron();
        }

    }
}
