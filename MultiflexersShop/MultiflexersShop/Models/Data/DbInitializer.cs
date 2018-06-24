using MultiflexersShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MultiflexersShop.Models.Data
{
    public static class DbInitializer
    {
        private static Dictionary<string, Category> categories;

        private static readonly string loremIpsum = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
           "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a " +
           "galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also " +
           "the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the " +
           "release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software " +
           "like Aldus PageMaker including versions of Lorem Ipsum.";

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category{CategoryName = "Smartphones", Description = "Smartphones"},
                        new Category{CategoryName = "Tablets", Description = "Tablets"},
                        new Category{CategoryName = "Laptops", Description = "Laptops"},
                        new Category{CategoryName = "Wearable Technology", Description = "Smart watches, fintness trackers and stuff"},
                        new Category{CategoryName = "Game consoles", Description = "Devices to play games"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }

        public static void Seed(AppDbContext context)
        {
            if (!context.Devices.Any())
            {
                context.AddRange
                (
                    new Device
                    {
                        Name = "iPhone X",
                        Price = 1149M,
                        ShortDescription = "Apple iPhone",
                        LongDescription = loremIpsum,
                        Category = Categories["Smartphones"],
                        ImageUrl = "https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP770/iphonex.png",
                        InStok = 4,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 40,
                        Promotional = 0,
                        ImageThumbnailUrl = "https://cdn2.gsmarena.com/vv/bigpic/apple-iphone-x.jpg"

                    },
                    new Device
                    {
                        Name = "Pixel",
                        Price = 499M,
                        ShortDescription = "Google Pixel",
                        LongDescription = loremIpsum,
                        Category = Categories["Smartphones"], 
                        ImageUrl = "http://www.directd.com.my/images/thumbs/0020331_google-pixel-2-xl-64gb128gb-kaw-kaw-raya-2018.jpeg",
                        InStok = 2,
                        IsPopular = false,
                        AddDate = DateTime.Now,
                        Bought = 1,
                        Promotional = 25,
                        ImageThumbnailUrl = "https://d2j6tswx2otu6e.cloudfront.net/F2dEZ1l35k3VgJj9Wy1__5c-5P8=/160x212/4774/47747c6d2c104a9394d2ed571387570c.jpg"
                    },
                    new Device
                    {
                        Name = "Apple Watch Series 3",
                        Price = 399M,
                        ShortDescription = "Apple Watch",
                        LongDescription = loremIpsum,
                        Category = Categories["Wearable Technology"],
                            ImageUrl = "https://www.bhphotovideo.com/images/images2500x2500/apple_mqk62ll_a_watch_series_3_42mm_1362215.jpg",
                        InStok = 8,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 37,
                        Promotional = 0,
                        ImageThumbnailUrl = "https://smartzoz.com/wp-content/uploads/2018/01/apple-watch-sport-42mm2-160x212.jpg"
                    },
                    new Device
                    {
                        Name = "Samsung Galaxy S9",
                        Price = 719M,
                        ShortDescription = "Samsung",
                        LongDescription = loremIpsum,
                        Category = Categories["Smartphones"],
                        ImageUrl = "https://cdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-s9-1.jpg",
                        InStok = 4,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 12,
                        Promotional = 1,
                        ImageThumbnailUrl =  "https://smartzoz.com/wp-content/uploads/2018/01/samsung-galaxy-s8--160x212.jpg"
                    },
                    new Device
                    {
                        Name = "iPad Pro 12.9",
                        Price = 799M,
                        ShortDescription = "Apple iPad",
                        LongDescription = loremIpsum,
                        Category = Categories["Tablets"],
                            ImageUrl = "https://assets.pcmag.com/media/images/549842-apple-ipad-pro-12-9-inch-2017.jpg?thumb=y&width=740&height=416",
                        InStok = 5,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 24,
                        Promotional = 0,
                        ImageThumbnailUrl = "https://i0.wp.com/techenroll.com/wp-content/uploads/2017/03/DTz9w1489222672-160x212.jpg"
                    },
                    new Device
                    {
                        Name = "Acer Predator",
                        Price = 8999M,
                        ShortDescription = "Gaming laptop form Acer",
                        LongDescription = loremIpsum,
                        Category = Categories["Laptops"],
                          ImageUrl = "https://assets.pcmag.com/media/images/413583-acer-predator-15.jpg?width=740&height=416",
                        InStok = 5,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 20,
                        Promotional = 18,
                        ImageThumbnailUrl = "https://images-na.ssl-images-amazon.com/images/G/01/aplusautomation/vendorimages/d68b60f4-40f1-4d8d-94d3-93b97fb41567.jpg._CB278436535__SR285,285_.jpg"
                    },
                    new Device
                    {
                        Name = "OnePlus 6",
                        Price = 529M,
                        ShortDescription = "OnePlus",
                        LongDescription = loremIpsum,
                        Category = Categories["Smartphones"],
                          ImageUrl = "https://cdn2.gsmarena.com/vv/pics/oneplus/oneplus-6-5.jpg",
                        InStok = 4,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 14,
                        Promotional = 0,
                        ImageThumbnailUrl = "https://smartzoz.com/wp-content/uploads/2018/05/oneplus-6--160x212.jpg"
                    },
                    new Device
                    {
                        Name = "Playstation 4 Pro",
                        Price = 399M,
                        ShortDescription = "Sony Playstation",
                        LongDescription = loremIpsum,
                        Category = Categories["Game consoles"],
                         ImageUrl = "https://media.wired.com/photos/5a99f809b4bf6c3e4d405abc/master/pass/PS4-Pro-SOURCE-Sony.jpg",
                        InStok = 8,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 34,
                        Promotional = 48,
                        ImageThumbnailUrl = "https://rukminim1.flixcart.com/image/312/312/je4k5u80/gamingconsole/h/r/g/1-ps4-pro-sony-na-original-imaf2vzcrrxnhps9.jpeg?q=70"
                    },
                    new Device
                    {
                        Name = "Samsung Gear S3",
                        Price = 349M,
                        ShortDescription = "Samsung watch",
                        LongDescription = loremIpsum,
                        Category = Categories["Wearable Technology"],
                        ImageUrl = "http://www.samsung.com/global/galaxy/gear-s3/images/gear-s3_highlights_kv_ft_l.jpg",
                        InStok = 7,
                        IsPopular = true,
                        AddDate = DateTime.Now,
                        Bought = 23,
                        Promotional = 10,
                        ImageThumbnailUrl = "https://smartzoz.com/wp-content/uploads/2018/01/samsung-gear-sport1-160x212.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}