using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Management; // -> koristimo da bi smo dobili unique ID stroja - npr. ID cpu-a (umjesto korištenja cookiea tada spremamo u sql server)

namespace Probica.Models.ServiceLayer
{
    public class MachineData
    {
        public static MachineDataResponse GetMachineDataResponse()
        {
            MachineDataResponse response = new MachineDataResponse();
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            

            foreach (ManagementObject mo in mc.GetInstances())
            {
                //Get only the first CPU's ID
                response.CpuId += mo.Properties["processorID"].Value.ToString() + "\n";
                break;
            }

            string drive = "C";
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            response.VolumeSerial = dsk["VolumeSerialNumber"].ToString();

            return response;
        }






    }
}