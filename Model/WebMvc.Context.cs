﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebMvcEntities : DbContext
    {
        public WebMvcEntities()
            : base("name=WebMvcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EM_Employee> EM_Employee { get; set; }
        public virtual DbSet<JF_Tasks> JF_Tasks { get; set; }
        public virtual DbSet<JF_TasksLog> JF_TasksLog { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsColumn> NewsColumn { get; set; }
        public virtual DbSet<SYS_DD> SYS_DD { get; set; }
    }
}
