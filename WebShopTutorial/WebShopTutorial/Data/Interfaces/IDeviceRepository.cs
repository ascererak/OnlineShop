using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data.Interfaces
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> Devices { get; }
        IEnumerable<Device> PopularDevices { get; }
        Device GetDeviceById(int id);
    }
}
