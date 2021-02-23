using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QianChuang.CompManage.Model.Const;
using QianChuang.CompManage.Model.Flow;
using QianChuang.CompManage.Model.Framework;
using QianChuang.CompManage.Model.Product;
using WalkingTec.Mvvm.Core;

namespace QianChuang.CompManage.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }


        public DataContext(CS cs)
             : base(cs)
        {
        }
        #region 权限配置

        public DbSet<FrameworkOrg> FrameworkOrgs { get; set; }
        public DbSet<FrameworkTeam> FrameworkTeams { get; set; }
        public DbSet<FrameworkLog> FrameworkLogs { get; set; }
        #endregion

        #region 产品信息表

        public DbSet<ProductArea> ProductAreas { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<ProductAreaInfo> ProductAreaInfos { get; set; }
        #endregion

        #region 流程组件

        //public DbSet<FlowInstance> FlowInstances { get; set; }
        //public DbSet<FlowInstanceOperationHistory> FlowInstanceOperationHistories { get; set; }
        //public DbSet<FlowInstanceTransitionHistory> FlowInstanceTransitionHistories { get; set; }
        //public DbSet<FlowScheme> FlowSchemes { get; set; }
        //public DbSet<Form> Forms { get; set; }
        #endregion

        public DataContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        /// <summary>OnModelCreating</summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FrameworkOrg>()
                .HasOne(p => p.ManageUser)
                .WithMany(b => b.Orgs)
                .HasForeignKey(a => a.ManageUserId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<FrameworkOrg>()
                .HasMany(p => p.Users)
                .WithOne(b => b.Org)
                .HasForeignKey(a => a.OrgId)
                .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<FrameworkUser>()
            //    .HasOne(p => p.Org)
            //    .WithMany(b => b.Users)
            //    .OnDelete(DeleteBehavior.NoAction);

            /*
             * 设置用户和团队的关系
             * 一个团队有一个领导者，多个销售
             * 
             */
            modelBuilder.Entity<FrameworkTeam>()
                .HasOne(p => p.Leader)
                .WithOne(b => b.ManageTeam);

            modelBuilder.Entity<FrameworkTeam>()
                .HasMany(p => p.Members)
                .WithOne(b => b.Team);


            InitData(modelBuilder);

        }

        public void InitData(ModelBuilder modelBuilder)
        {

            #region 角色初始化

            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleAdminId,
                RoleCode = "011",
                RoleName = "总经理",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleFinanceId,
                RoleCode = "012",
                RoleName = "财务",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleSaleManageId,
                RoleCode = "013",
                RoleName = "销售主管",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleSaleId,
                RoleCode = "014",
                RoleName = "销售",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleBraceId,
                RoleCode = "015",
                RoleName = "设立执行人",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleCustomId,
                RoleCode = "016",
                RoleName = "客户",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleAgentId,
                RoleCode = "017",
                RoleName = "代理商",
                CreateBy = "初始化数据",
            });
            modelBuilder.Entity<FrameworkRole>().HasData(new FrameworkRole()
            {
                ID = FrameworkConst.RoleAccountingId,
                RoleCode = "018",
                RoleName = "主办会计",
                CreateBy = "初始化数据",
            });



            #endregion

            #region 系统组织初始化内容
            modelBuilder.Entity<FrameworkOrg>().HasData(new FrameworkOrg()
            {
                ID = FrameworkConst.OrgManageId,
                OrgType = OrgTypeEnum.Manage,
                OrgName = "乾创财务",
                SOrgName = "浙江乾创财务有限公司",
                ManageUserId = null,
                LinkMan = "李文哲",
                LinkPhone = "18006847261"
            });

            modelBuilder.Entity<FrameworkOrg>().HasData(new FrameworkOrg()
            {
                ID = FrameworkConst.OrgCustomId,
                OrgType = OrgTypeEnum.Manage,
                OrgName = "客户",
                SOrgName = "客户",
                ManageUserId = null,
                LinkMan = "客户",
                LinkPhone = null
            });
            #endregion


        }


        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = Set<FrameworkUser>().Count() == 0 && Set<FrameworkUserRole>().Count() == 0;
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin"
                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                await SaveChangesAsync();
            }




            return state;
        }

    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("Server=db.ekezhang.com;Database=CompManage_db;Uid=sa;Pwd=liWENqian@6304;", DBTypeEnum.SqlServer);
        }
    }

}
