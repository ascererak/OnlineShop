﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopTutorial.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Devices.Any())
            {
                context.AddRange
                (
                    new Device
                    {
                        Name = "iPhone",
                        Price = 1100M,
                        ShortDescription = "Apple iPhone",
                        LongDescription = "A long description about bla-bla iphone something bla-bla characteristics bla-bla",
                        Category = Categories["Smartphones"],
                        ImageUrl = "https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP770/iphonex.png",
                        InStok = 4,
                        ImageThumbnailUrl = "https://cdn2.gsmarena.com/vv/bigpic/apple-iphone-x.jpg"
                    },
                    new Device
                    {
                        Name = "Pixel",
                        Price = 1000M,
                        ShortDescription = "Google Pixel",
                        LongDescription = "A long description about bla-bla pixel something bla-bla characteristics bla-bla",
                        Category = Categories["Smartphones"],
                        ImageUrl = "http://www.directd.com.my/images/thumbs/0020331_google-pixel-2-xl-64gb128gb-kaw-kaw-raya-2018.jpeg",
                        InStok = 2,
                        ImageThumbnailUrl = "https://i-cdn.phonearena.com/images/phones/69466-specs/Google-Pixel-2-XL.jpg"
                    }
                );
            }



            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Alcoholic", Description="All alcoholic drinks" },
                        new Category { CategoryName = "Non-alcoholic", Description="All non-alcoholic drinks" }
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
    }
}
