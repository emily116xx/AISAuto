using AISAutoForms.Constants;
using Microsoft.AspNetCore.Identity;
using System.Data;
using static AISAutoForms.Constants.MyConstants;



namespace AISAutoForms.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Seed Roles
            // Bryan: This is creating a method that will create a role as power user or admin user. 
            // So here, we are getting the instance of userManager and roleManager
            // And then we are adding a role which is Admin and User

            var userManager = service.GetService<UserManager<IdentityUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Approver.ToString()));

            // Bryan: This will create a default record for Admin user since we don't want to 
            //        give functionality to create admin from the user interface. 
            //        If we don't do this, anybody can be admin. 

            var user = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            // Bryan: We are finding this user from the database with the method FindByEmailAsync 
            //        with the help of Email. If we do not have any user of this username in the database, 
            //        it will create a user for us with the username admin@gmail.com and the password Admin@123 below.
            //        Additionally, we are assigning the Admin role to it. 
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }

        }
    }
}



