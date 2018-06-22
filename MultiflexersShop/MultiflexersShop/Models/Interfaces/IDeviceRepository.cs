using MultiflexersShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiflexersShop.Models.Interfaces
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> Devices { get; }
        IEnumerable<Device> PopularDevices { get; }

        Device GetDeviceById(int deviceId);
    }
}
