
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GasMeter_MS.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "真实姓名")]
        public string Name { get; set; }

        [Display(Name = "性别")]
        public string Sex { get; set; }

        [Display(Name = "联系电话")]
        public string Tel { get; set; }

        [Display(Name = "类型（经理、员工等）")]
        public string Type { get; set; }

        [Display(Name = "备注")]
        public string Memo { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<SysInfo> SysInfos { get; set; }
        public System.Data.Entity.DbSet<KeyValue> KeyValues { get; set; }
        public System.Data.Entity.DbSet<Tree> Trees { get; set; }
        public System.Data.Entity.DbSet<Price> Price { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       // public System.Data.Entity.DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
    public class IdentityManager
    {
        // 判断角色是否已在存在
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }
        // 新增角色
        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }
        // 新增用户
        public bool CreateUser(ApplicationUser user, string pass)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.Create(user, pass);
            return idResult.Succeeded;
        }
        // 将使用者加入角色中，即权限
        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        //根据身份自动加入角色
        public void AutoAddUserToRole(string userId, string name)
        {
            if (name == "超级管理员")                  //注册时根据身份赋予权限
                AddUserToRole(userId, "SAdmin");
            if (name == "管理员")
                AddUserToRole(userId, "Admin");
            if (name == "煤矿企业")
                AddUserToRole(userId, "煤矿企业权限");
            if (name == "培训部门")
                AddUserToRole(userId, "培训部门权限");
            if (name == "监察监督部门")
                AddUserToRole(userId, "监察监督权限");

        }
        // 清除使用者的角色设定
        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
               // um.RemoveFromRole(userId, role.Role.Name);
            }
        }
        // 查找某一用户的角色
        public List<IdentityUserRole> FindUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            return currentRoles;
        }
    }
}