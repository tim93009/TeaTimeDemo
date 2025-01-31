using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.Models;
using TeaTimeDemo.Utility;

namespace TeaTimeDemo.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        //使用依賴注入的方式來引入我們會用到的服務
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {            
            try
            {
                //檢查是否有待處理的 migration，如果有就進行資料遷移 migration。
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {                    
                    _db.Database.Migrate();
                    Console.WriteLine("資料遷移成功！");
                }
                else
                {
                    Console.WriteLine("沒有待處理的資料遷移。");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"資料遷移失敗: {ex.Message}");
            }

            if (!_db.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("所有遷移已成功執行！");
            }
            else
            {
                Console.WriteLine("仍然有未執行的遷移！");
            }


            //檢查角色是否存在，如果不存在就建立所有角色以及我們的管理者帳號
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Manager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Administrator",
                    PhoneNumber = "0911111111",
                    Address = "test address 123",
                    EmailConfirmed = true
                }, "Admin123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
