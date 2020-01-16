using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence {
  public class Seed {
    public static async Task SeedData (IcropalDbContext context, UserManager<User> usermanager) {

      if (!usermanager.Users.Any()) {
        var users = new List<User> {
          new User {
          Email = "admin@icropal.com",
          UserName = "admin",
          FirstName = "CEO",
          LastName = "Backend"
          },
          new User {
          Email = "josh@icropal.com",
          UserName = "HE",
          FirstName = "Icropal",
          LastName = "Engineer"
          }
          };

          foreach (var user in users)
          {
              await usermanager.CreateAsync(user,"Pa$$w0rd");
          }
          }
         
        context.SaveChanges();
      }
    }
  }
