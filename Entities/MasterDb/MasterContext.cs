using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace BookListRazor.Entities.MasterDb
{
    public partial class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<ArsTblColumn> ArsTblColumn { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Server==10.4.89.188;Port=5432;User Id=postgres;Password= Crist@ll@prog!@#;Database=sugarcanedb");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

        //    modelBuilder.Entity<ArsTblColumn>(entity =>
        //    {
        //        entity.HasKey(e => new { e.Columnid, e.Tableid, e.Schemaid })
        //            .HasName("ars_tbl_column_pkey");

        //        entity.ToTable("ars_tbl_column", "master");

        //        entity.Property(e => e.Columnid).HasColumnName("columnid");

        //        entity.Property(e => e.Tableid).HasColumnName("tableid");

        //        entity.Property(e => e.Schemaid).HasColumnName("schemaid");

        //        entity.Property(e => e.Columnname)
        //            .IsRequired()
        //            .HasColumnName("columnname")
        //            .HasColumnType("character(40)");

        //        entity.Property(e => e.Columntype)
        //            .IsRequired()
        //            .HasColumnName("columntype")
        //            .HasColumnType("character(40)");
        //    });

      




   
          
     
          
   
         
           

           

          

        //    modelBuilder.HasSequence<int>("ars_tbl_data_type_data_type_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_emailaddress_email_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_function_function_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_logs_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_menu_menu_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_parameter_source_parameter_source_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_parameter_type_parameter_type_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_report_report_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_template_parameter_ma_template_parameter_mapping_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_template_report_mapping_template_report_mapping_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbl_template_template_id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbs_RoleClaim_Id_seq");

        //    modelBuilder.HasSequence<int>("ars_tbs_UserClaim_Id_seq");
        //}
    }
}
