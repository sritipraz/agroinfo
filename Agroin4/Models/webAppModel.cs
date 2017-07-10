namespace Agroin4.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class webAppModel : DbContext
    {
        // Your context has been configured to use a 'webAppModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Agroin4.Models.webAppModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'webAppModel' 
        // connection string in the application configuration file.
        public webAppModel()
            : base("name=webAppModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<registration_tb> registrations { get; set; }
        public virtual DbSet<typedef> typedefs { get; set; }
        public virtual DbSet<topography>topographys { get; set; }
        public virtual DbSet<district>districts { get; set; }
        public virtual DbSet<crop>crops { get; set; }
        public virtual DbSet<seasondef> seasondefs { get; set; }
        
        public virtual DbSet<article>articles { get; set; }
        public virtual DbSet<shop> shops { get; set; }

        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<sub_comment> sub_comments { get; set; }
        public virtual DbSet<log> logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<registration_tb>().MapToStoredProcedures();
        }

        public System.Data.Entity.DbSet<Agroin4.Models.login_as> login_as { get; set; }


        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}