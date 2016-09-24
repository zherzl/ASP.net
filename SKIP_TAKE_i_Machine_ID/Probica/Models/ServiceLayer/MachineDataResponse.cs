namespace Probica.Models.ServiceLayer
{
    public class MachineDataResponse
    {
        public string CpuId { get; internal set; }
        public string VolumeSerial { get; internal set; }
        public string Combined { get { return CpuId + "-" + VolumeSerial; } }
    }
}