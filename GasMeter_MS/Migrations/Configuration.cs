namespace GasMeter_MS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GasMeter_MS.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<GasMeter_MS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GasMeter_MS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var User1 = new ApplicationUser()
            {
                UserName = "123434@qq.com",
                Name = "曾兆奇",
                Email = "123434@qq.com"
            };
            var idManager = new IdentityManager();
            try
            {
                idManager.CreateUser(User1, "123456");
                idManager.CreateRole("管理员");
                idManager.AddUserToRole(User1.Id, "管理员");
            }
            catch { }
            context.SysInfos.AddOrUpdate(
              p => p.SiteName,
              new SysInfo { SiteName = "物联网燃气表管理系统", Port = 80, Baud = 2400, Memo = "网站备注" }
            );
            context.KeyValues.AddOrUpdate(
              p => p.Key,
              new KeyValue { Key = "参数组名", Value = "参数1", BMemo = "备注" },
              new KeyValue { Key = "档案修改历史", Value = "是", BMemo = "备注" },
              new KeyValue { Key = "付款方式", Value = "在线", BMemo = "备注" }
            );
            context.Price.AddOrUpdate(
              p => p.PName,
              new Price { PName = "商业", SinPrice = 12.00F, Describe = "没有说明", StartDateTime = DateTime.Now, UpdateDateTime = DateTime.Now, HandlerBy = "曾兆奇", Memo = "备注" },
               new Price { PName = "民用", SinPrice = 12.00F, Describe = "没有说明", StartDateTime = DateTime.Now, UpdateDateTime = DateTime.Now, HandlerBy = "曾兆奇2", Memo = "备注" },
               new Price { PName = "公用", SinPrice = 12.00F, Describe = "没有说明", StartDateTime = DateTime.Now, UpdateDateTime = DateTime.Now, HandlerBy = "曾兆奇", Memo = "备注" }
              );
        }
    }
}
