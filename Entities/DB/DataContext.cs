using Entity.Models.EntityModels.Adm;
using Entity.Models.EntityModels.Auth;
using Entity.Models.QueryModels.Auth;
using Microsoft.EntityFrameworkCore;

namespace Entitys.DB
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionQueryModel>().HasNoKey().ToView("no_name");
        }

        #region AdmMainTables
        public DbSet<Adm> Adms { get; set; }
        public DbSet<AdmGroup> AdmGroups { get; set; }
        public DbSet<AdmOwner> AdmOwners { get; set; }
        public DbSet<AdmActivationHistory> AdmActivationHistories { get; set; }
        public DbSet<AdmApplication> AdmApplications { get; set; }
        public DbSet<AdmEncashmentInfo> AdmEncashmentInfos { get; set; }
        public DbSet<AdmLoginHistory> AdmLoginHistories { get; set; }
        public DbSet<AdmOpenCloseDay> AdmOpenCloseDays { get; set; }
        public DbSet<AdmTransaction> AdmTransactions { get; set; }
        public DbSet<AdmVariable> AdmVariables { get; set; }
        public DbSet<NciBillingService> NciBillingServices { get; set; }
        #endregion

        #region QueryModel
        public DbSet<PermissionQueryModel> PermissionQuery { get; set; }
        #endregion

        #region Auth
        public DbSet<AuthUIElement> AuthUIElements { get; set; }
        public DbSet<AuthModule> AuthModules { get; set; }
        public DbSet<AuthPermission> AuthPermissions { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<AuthUserRToken> AuthUserRTokens { get; set; }

        #endregion
    }
}
