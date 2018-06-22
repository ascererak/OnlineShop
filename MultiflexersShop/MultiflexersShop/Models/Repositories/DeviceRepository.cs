using Microsoft.EntityFrameworkCore;
using MultiflexersShop.Models.Data;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MultiflexersShop.Models.Repositories
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
