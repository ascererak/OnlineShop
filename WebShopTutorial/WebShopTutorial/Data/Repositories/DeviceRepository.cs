using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext appDbContext;
        public DeviceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Device> Devices => appDbContext.Devices.Include(c => c.Category);

        public Device GetDeviceById(int id) => appDbContext.Devices.FirstOrDefault(p => p.Id == id);
    }
}
