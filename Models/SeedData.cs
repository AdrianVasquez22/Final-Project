using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Players.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Players.Any()) 
        {
            return;
        }

        context.Players.AddRange(
            new Player { Name = "Jose Ramirez", Age = 32, BA = .279m, HR = 39, KRate = 12.0M, WalkRate = 7.9M},
            new Player { Name = "Shohei Ohtani", Age = 30, BA = .310M, HR = 54, KRate = 22.2M, WalkRate = 11.1M},
            new Player { Name = "Mike Trout", Age = 33, BA = .220M, HR = 10, KRate = 21.4M, WalkRate = 12.7M},
            new Player { Name = "Aaron Judge", Age = 32, BA = .322M, HR = 58, KRate = 24.3M, WalkRate = 18.9M},
            new Player { Name = "Mookie Betts", Age = 32, BA = .289M, HR = 19, KRate = 11.0M, WalkRate = 11.8M},
            new Player { Name = "Jose Miranda", Age = 26, BA = .284M, HR = 9, KRate = 15.4M, WalkRate = 4.2M},
            new Player { Name = "Wilyer Abreu", Age = 25, BA = .253M, HR = 15, KRate = 28.0M, WalkRate = 8.9M},
            new Player { Name = "Brent Rooker", Age = 30, BA = .293M, HR = 39, KRate = 28.8M, WalkRate = 9.6M},
            new Player { Name = "Kerry Carpenter", Age = 27, BA = .284M, HR = 18, KRate = 25.6M, WalkRate = 6.9M},
            new Player { Name = "Luis Arraez", Age = 27, BA = .314M, HR = 4, KRate = 6.8M, WalkRate = 6.9M},
            new Player { Name = "Pete Alonso", Age = 29, BA = .240M, HR = 34, KRate = 24.7M, WalkRate = 10.1M},
            new Player { Name = "Randy Arozarena", Age = 29, BA = .219M, HR = 20, KRate = 26.1M, WalkRate = 11.3M},
            new Player { Name = "Julio Rodriguez", Age = 23, BA = .273M, HR = 20, KRate = 25.4M, WalkRate = 6.2M},
            new Player { Name = "Brenton Doyle", Age = 26, BA = .260M, HR = 23, KRate = 25.4M, WalkRate = 7.6M},
            new Player { Name = "Bobby Witt Jr.", Age = 24, BA = .332M, HR = 32, KRate = 15.0M, WalkRate = 8.0M},
            new Player { Name = "Luis Robert Jr.", Age = 27, BA = .224M, HR = 14, KRate = 33.2M, WalkRate = 6.6M},
            new Player { Name = "Bryce Harper", Age = 32, BA = .285M, HR = 30, KRate = 21.9M, WalkRate = 12.0M},
            new Player { Name = "Ozzy Albies", Age = 27, BA = .251M, HR = 10, KRate = 14.9M, WalkRate = 6.2M},
            new Player { Name = "George Springer", Age = 35, BA = .220M, HR = 19, KRate = 18.7M, WalkRate = 9.8M},
            new Player { Name = "Jose Altuve", Age = 34, BA = .295M, HR = 20, KRate = 17.4M, WalkRate = 6.9M},
            new Player { Name = "Adolis Garcia", Age = 31, BA = .224M, HR = 25, KRate = 27.8M, WalkRate = 7.1M},
            new Player { Name = "Jack Suwinski", Age = 26, BA = .182M, HR = 9, KRate = 28.5M, WalkRate = 9.7M},
            new Player { Name = "Jake Burger", Age = 28, BA = .250M, HR = 29, KRate = 25.9M, WalkRate = 5.7M},
            new Player { Name = "Dansby Swanson", Age = 30, BA = .242M, HR = 16, KRate = 24.3M, WalkRate = 9.1M},
            new Player { Name = "Eugenio Suarez", Age = 33, BA = .256M, HR = 30, KRate = 27.5M, WalkRate = 7.7M},
            new Player { Name = "Elly De La Cruz", Age = 22, BA = .259M, HR = 25, KRate = 31.3M, WalkRate = 9.9M},
            new Player { Name = "Willy Adames", Age = 29, BA = .251M, HR = 32, KRate = 25.1M, WalkRate = 10.8M},
            new Player { Name = "Mike Yastrzemski", Age = 34, BA = .231M, HR = 18, KRate = 26.2M, WalkRate = 8.0M},
            new Player { Name = "Paul Goldschmidt", Age = 37, BA = .245M, HR = 22, KRate = 26.5M, WalkRate = 7.2M},
            new Player { Name = "CJ Abrams", Age = 24, BA = .246M, HR = 20, KRate = 21.3M, WalkRate = 6.6M},
            new Player { Name = "Bo Naylor", Age = 24, BA = .201M, HR = 13, KRate = 31.4M, WalkRate = 7.5M},
            new Player { Name = "Matt Olson", Age = 30, BA = .247M, HR = 29, KRate = 24.8M, WalkRate = 10.4M},
            new Player { Name = "Manny Machado", Age = 32, BA = .275M, HR = 29, KRate = 19.3M, WalkRate = 7.0M},
            new Player { Name = "Juan Soto", Age = 26, BA = .288M, HR = 41, KRate = 16.7M, WalkRate = 18.1M},
            new Player { Name = "Steven Kwan", Age = 27, BA = .292M, HR = 14, KRate = 9.4M, WalkRate = 9.8M},
            new Player { Name = "Josh Jung", Age = 26, BA = .264M, HR = 7, KRate = 25.5M, WalkRate = 4.3M},
            new Player { Name = "Isiah Kiner-Falefa", Age = 29, BA = .269M, HR = 8, KRate = 15.7M, WalkRate = 3.2M},
            new Player { Name = "Freddie Freeman", Age = 35, BA = .282M, HR = 22, KRate = 15.7M, WalkRate = 12.2M},
            new Player { Name = "Francisco Lindor", Age = 31, BA = .273M, HR = 33, KRate = 18.4M, WalkRate = 8.1M},
            new Player { Name = "Adley Rutschman", Age = 26, BA = .250M, HR = 19, KRate = 16.1M, WalkRate = 9.1M}
            
        );

        context.SaveChanges();

        
        Team ClevelandGuardians = new Team {
            TeamName = "Cleveland Guardians",
            Player = context.Players.Where(m => m.Name == "Jose Ramirez").Single()
        };
        context.Add(ClevelandGuardians);
        context.SaveChanges();
    }
}
