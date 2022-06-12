using Microsoft.EntityFrameworkCore;

namespace WebStoreAutomobiles.Models
{
    public static class SeedProductData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            WebStoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WebStoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "270R '94",
                        Description = "The complete tuned Silvia; a 30-car limited release by Nismo on the eve of Japanese regulation reform.",
                        Price = 34000M,
                        Category = "NISMO"
                    },
                    new Product
                    {
                        Name = "NISMO 400R '96",
                        Description = "NISMO planned on releasing 100 units of this fastest street-spec GT-R of its generation, but it's said only 44 examples were ever made.",
                        Price = 36000M,
                        Category = "NISMO"

                    },
                    new Product
                    {
                        Name = "Mitsubishi Lancer Evolution VII RS '01",
                        Description = "With AYC and ACD optional; the competition spec Lancer Evo VII with minimal equipment.",
                        Price = 84500M,
                        Category = "MITSUBISHI"
                    },
                    new Product
                    {
                        Name = "Mitsubishi Lancer Evolution VI RS '99",
                        Description = "Equipped with close-ratio gears; the competition spec 6th generation Lancer Evo.",
                        Price = 41000M,
                        Category = "MITSUBISHI"
                    },
                    new Product
                    {
                        Name = "Acura NSX '91",
                        Description = "The ultimate road-going sportscar.",
                        Price = 91000M,
                        Category = "ACURA"
                    },
                    new Product
                    {
                        Name = "Acura RSX Type-S '04",
                        Description = "The top model of the RSX, balancing both comfort and sporty elements.",
                        Price = 102000M,
                        Category = "ACURA"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
