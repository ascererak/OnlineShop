using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data.Mocks
{
    public class MockDeviceRepository : IDeviceRepository
    {
        private readonly ICategoryRepository categoryRepository = new MockCategoryRepository();
        public IEnumerable<Device> Devices
        {
            get
            {
                return new List<Device>
                {
                    new Device{
                        Name = "iPhone",
                        Price = 1100M,
                        ShortDescription = "Apple iPhone",
                        LongDescription = "A long description about bla-bla iphone something bla-bla characteristics bla-bla",
                        Category = categoryRepository.Categories.First(), ImageUrl = "https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP770/iphonex.png",
                        InStok = 4, ImageThumbnailUrl = "https://cdn2.gsmarena.com/vv/bigpic/apple-iphone-x.jpg"
                    },
                    new Device{
                        Name = "Pixel",
                        Price = 1000M,
                        ShortDescription = "Google Pixel",
                        LongDescription = "A long description about bla-bla pixel something bla-bla characteristics bla-bla",
                        Category = categoryRepository.Categories.First(), ImageUrl = "http://www.directd.com.my/images/thumbs/0020331_google-pixel-2-xl-64gb128gb-kaw-kaw-raya-2018.jpeg",
                        InStok = 2, ImageThumbnailUrl = "https://d2j6tswx2otu6e.cloudfront.net/F2dEZ1l35k3VgJj9Wy1__5c-5P8=/160x212/4774/47747c6d2c104a9394d2ed571387570c.jpg"
                    },
                    new Device{
                        Name = "iPhone",
                        Price = 1100M,
                        ShortDescription = "Apple iPhone",
                        LongDescription = "A long description about bla-bla iphone something bla-bla characteristics bla-bla",
                        Category = categoryRepository.Categories.First(), ImageUrl = "https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP770/iphonex.png",
                        InStok = 4, ImageThumbnailUrl = "https://cdn2.gsmarena.com/vv/bigpic/apple-iphone-x.jpg"
                    },
                    new Device{
                        Name = "Pixel",
                        Price = 1000M,
                        ShortDescription = "Google Pixel",
                        LongDescription = "A long description about bla-bla pixel something bla-bla characteristics bla-bla",
                        Category = categoryRepository.Categories.First(), ImageUrl = "http://www.directd.com.my/images/thumbs/0020331_google-pixel-2-xl-64gb128gb-kaw-kaw-raya-2018.jpeg",
                        InStok = 2, ImageThumbnailUrl = "https://d2j6tswx2otu6e.cloudfront.net/F2dEZ1l35k3VgJj9Wy1__5c-5P8=/160x212/4774/47747c6d2c104a9394d2ed571387570c.jpg"
                    }
                };
            }
        }

        public IEnumerable<Device> PopularDevices { get; }

        public Device GetDeviceById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
