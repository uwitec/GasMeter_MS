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
            context.SysInfos.AddOrUpdate(
              p => p.SiteName,
              new SysInfo { SiteName = "������ȼ�������ϵͳ", Port=80, Baud=2400, Memo="��վ��ע" }
            );

        }
    }
}
