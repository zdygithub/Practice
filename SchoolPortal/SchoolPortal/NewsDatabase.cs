namespace SchoolPortal
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDatabase : DbContext
    {

        public NewsDatabase()
            : base("name=NewsDatabase")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Information> Informations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var userTable = modelBuilder.Entity<User>();
            var informationTable = modelBuilder.Entity<Information>();

            userTable.HasKey(o => o.Id);
            informationTable.HasKey(o => o.Id);

            base.OnModelCreating(modelBuilder);
        }
    }


    /// <summary>
    /// 用户登录
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// 学校新闻信息
    /// </summary>
    public class Information
    {
        public int Id { get; set; }
        public string Type { get; set; } //类别
        public string Subject { get; set; } //标题
        public string Body { get; set; } //内容
        public DateTime DataCreated { get; set; } //发布时间
    }
}