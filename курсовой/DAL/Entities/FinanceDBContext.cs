using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class FinanceDBContext : DbContext
    {
        public FinanceDBContext()
            : base("name=FinanceDBContext")
        {
        }

        public virtual DbSet<EXPENSE> EXPENSE { get; set; }
        public virtual DbSet<EXPENSE_GUIDE> EXPENSE_GUIDE { get; set; }
        public virtual DbSet<EXPENSE_PLAN> EXPENSE_PLAN { get; set; }
        public virtual DbSet<INCOME> INCOME { get; set; }
        public virtual DbSet<INCOME_GUIDE> INCOME_GUIDE { get; set; }
        public virtual DbSet<INCOME_PLAN> INCOME_PLAN { get; set; }
        public virtual DbSet<PLAN_TYPE> PLAN_TYPE { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EXPENSE>()
                .Property(e => e.expense_size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EXPENSE_GUIDE>()
                .Property(e => e.expense_type)
                .IsUnicode(false);

            modelBuilder.Entity<EXPENSE_GUIDE>()
                .HasMany(e => e.EXPENSE)
                .WithRequired(e => e.EXPENSE_GUIDE)
                .HasForeignKey(e => e.expense_guide_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EXPENSE_PLAN>()
                .Property(e => e.plan_expense_size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<INCOME>()
                .Property(e => e.income_size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<INCOME_GUIDE>()
                .Property(e => e.income_type)
                .IsUnicode(false);

            modelBuilder.Entity<INCOME_GUIDE>()
                .HasMany(e => e.INCOME)
                .WithRequired(e => e.INCOME_GUIDE)
                .HasForeignKey(e => e.income_guide_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INCOME_PLAN>()
                .Property(e => e.plan_income_size)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PLAN_TYPE>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<PLAN_TYPE>()
                .HasMany(e => e.EXPENSE_PLAN)
                .WithRequired(e => e.PLAN_TYPE)
                .HasForeignKey(e => e.plan_expense_type_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLAN_TYPE>()
                .HasMany(e => e.INCOME_PLAN)
                .WithRequired(e => e.PLAN_TYPE)
                .HasForeignKey(e => e.plan_income_type_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.EXPENSE)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.expense_user_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.EXPENSE_GUIDE)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.userFk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.EXPENSE_PLAN)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.plan_expense_user_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.INCOME)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.income_user_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.INCOME_GUIDE)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.userFk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.INCOME_PLAN)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.plan_income_user_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
