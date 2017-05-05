using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains;
using WebApplication.Core.Domains.MessageTemplate;
using WebApplication.Core.Domains.StatusType;
using WebApplication.Core.Domains.Tech;
using WebApplication.Identity;
using WebApplication.Infrastructure;

namespace WebApplication.Helpers
{
    public class SeedDataHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedDataHelper(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async void Initialize()
        {
            var user = new IdentityUser
            {
                Email = $"admin@example.com",
                UserName = $"admin@example.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            if ((_context.RoleCollection.Count("{}") == 0) == true)
            {
                var Roles = new List<IdentityRole>()
                {
                    new IdentityRole { Name = "Admin" } ,
                    new IdentityRole { Name = "Registered User" },
                    new IdentityRole { Name = "Domain Expert" },
                    new IdentityRole { Name = "Country Manager" },
                };


                foreach (var role in Roles)
                {
                    await _roleManager.CreateAsync(role);

                }

            }

            if ((_context.UserCollection.Count("{}") == 0) == true)
            {

                await _userManager.CreateAsync(user, $"Admin123!@#");
                await _userManager.AddToRoleAsync(user, "Admin");

            }

            if ((_context.StatusTypeCollection.Count("{}") == 0) == true)
            {
                var types = new List<StatusType>()
                {
                    new StatusType{  TypeName=$"Psychological Problem"},
                    new StatusType{  TypeName=$"Health Problem"},
                    new StatusType{  TypeName=$"Love Problem"},
                    new StatusType{  TypeName=$"Depressed"},
                    new StatusType{  TypeName=$"Happy"},
                    new StatusType{  TypeName=$"Sad"},
                    new StatusType{  TypeName=$"Angry"}
                };

                await _context.StatusTypeCollection.InsertManyAsync(types);

            }


            if ((_context.TechTypeCollection.Count("{}") == 0) == true)
            {
                var types = new List<TechType>()
                {
                    new TechType{  Name=$".NET Technologies"},
                    new TechType{  Name=$"Python"},
                    new TechType{  Name=$"CSS"},
                    new TechType{  Name=$"Angular"},
                    new TechType{  Name=$"JavaScript"},
                    new TechType{  Name=$"HTML"},
                    new TechType{  Name=$"Java"}
                };

                await _context.TechTypeCollection.InsertManyAsync(types);

            }


            if ((_context.MessageTemplateCollection.Count("{}") == 0) == true)
            {
                var messages = new List<MessageTemplate>()
                {
                    new MessageTemplate{  MessageTemplateTypeID=$"Welcome", Subject=$"Welcome" },
                };

                await _context.MessageTemplateCollection.InsertManyAsync(messages);
            }


        }   


    }
}
