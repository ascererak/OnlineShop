using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebShopNetCore2.Models.Data;
using WebShopNetCore2.Models.Entities;
using WebShopNetCore2.Models.Interfaces;

namespace WebShopNetCore2.Models.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext appDbContext;

        public IEnumerable<Device> Devices => appDbContext.Devices.Include(c => c.Category);
        public IEnumerable<Device> PopularDevices => appDbContext.Devices.Include(c => c.Category).Where(p => p.IsPopular);

        public DeviceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Device GetDeviceById(int deviceId) => appDbContext.Devices.FirstOrDefault(p => p.DeviceId == deviceId);
    }
}
