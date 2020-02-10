using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Areas.Identity.Data;

namespace Agency.Models
{
    public partial class AgencyContext : IdentityDbContext<MojIdentityUser>
    {
        public AgencyContext()
        {
        }

        public AgencyContext(DbContextOptions<AgencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractEmployees> ContractEmployees { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Flat> Flat { get; set; }
        public virtual DbSet<ListOfEmployees> ListOfEmployees { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Whishlist> Whishlist { get; set; }
        public virtual DbSet<PersonDetail> PersonDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Agency;Trusted_Connection=True;MultipleActiveResultSets=true");
            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Address>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.City)
            //        .WithMany(p => p.Address)
            //        .HasForeignKey(d => d.CityId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKAddress207613");
            //});

            //modelBuilder.Entity<Branch>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(32)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Address)
            //        .WithMany(p => p.Branch)
            //        .HasForeignKey(d => d.AddressId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKBranch312490");
            //});

            //modelBuilder.Entity<City>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Country)
            //        .WithMany(p => p.City)
            //        .HasForeignKey(d => d.CountryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKCity241283");
            //});

            //modelBuilder.Entity<Client>(entity =>
            //{
            //    entity.HasIndex(e => e.TransactionId)
            //        .HasName("Client_TransactionID");

            //    entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            //    entity.HasOne(d => d.Address)
            //        .WithMany(p => p.Client)
            //        .HasForeignKey(d => d.AddressId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKClient630570");

            //    entity.HasOne(d => d.Transaction)
            //        .WithMany(p => p.Client)
            //        .HasForeignKey(d => d.TransactionId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKClient954239");
            //});

            //modelBuilder.Entity<Contract>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.BranchId).HasColumnName("BranchID");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.Desciption).HasMaxLength(255);

            //    entity.HasOne(d => d.Rent)
            //        .WithMany(p => p.Contract)
            //        .HasForeignKey(d => d.RentId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKContract501170");
            //});

            //modelBuilder.Entity<ContractEmployees>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ContractId).HasColumnName("ContractID");

            //    entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

            //    entity.HasOne(d => d.Contract)
            //        .WithMany(p => p.ContractEmployees)
            //        .HasForeignKey(d => d.ContractId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKContractEm681735");

            //    entity.HasOne(d => d.Employer)
            //        .WithMany(p => p.ContractEmployees)
            //        .HasForeignKey(d => d.EmployerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKContractEm543605");
            //});

            //modelBuilder.Entity<Country>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);
            //});



            //modelBuilder.Entity<Flat>(entity =>
            //{
            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(32)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Address)
            //        .WithMany(p => p.Flat)
            //        .HasForeignKey(d => d.AddressId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKFlat301194");

            //    entity.HasOne(d => d.Category)
            //        .WithMany(p => p.Flat)
            //        .HasForeignKey(d => d.CategoryId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKFlat622316");
            //});

            //modelBuilder.Entity<ListOfEmployees>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.BranchId).HasColumnName("BranchID");

            //    entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

            //    entity.HasOne(d => d.Branch)
            //        .WithMany(p => p.ListOfEmployees)
            //        .HasForeignKey(d => d.BranchId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKListOfEmpl24379");

            //    entity.HasOne(d => d.Employer)
            //        .WithMany(p => p.ListOfEmployees)
            //        .HasForeignKey(d => d.EmployerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKListOfEmpl561296");
            //});

            //modelBuilder.Entity<PaymentMethod>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.CardNumber).HasColumnName("cardNumber");

            //    entity.Property(e => e.Other).HasColumnName("other");
            //});



            //modelBuilder.Entity<Picture>(entity =>
            //{
            //    entity.Property(e => e.Url)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Rent>(entity =>
            //{
            //    entity.Property(e => e.From).HasColumnType("datetime");

            //    entity.Property(e => e.To).HasColumnType("datetime");

            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.Rent)
            //        .HasForeignKey(d => d.ClientId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKRent248237");

            //    entity.HasOne(d => d.Flat)
            //        .WithMany(p => p.Rent)
            //        .HasForeignKey(d => d.FlatId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKRent524608");
            //});

            //modelBuilder.Entity<Review>(entity =>
            //{
            //    entity.HasKey(e => new { e.FlatId, e.ClientId })
            //        .HasName("PK__Review__22B10C1318FECC53");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasMaxLength(64)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.Review)
            //        .HasForeignKey(d => d.ClientId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKReview696251");

            //    entity.HasOne(d => d.Flat)
            //        .WithMany(p => p.Review)
            //        .HasForeignKey(d => d.FlatId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKReview497506");
            //});

            //modelBuilder.Entity<Room>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.FaltId).HasColumnName("faltID");

            //    entity.Property(e => e.Kvadratura).HasColumnName("kvadratura");

            //    entity.HasOne(d => d.Falt)
            //        .WithMany(p => p.Room)
            //        .HasForeignKey(d => d.FaltId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKRoom134672");

            //    entity.HasOne(d => d.Picture)
            //        .WithMany(p => p.Room)
            //        .HasForeignKey(d => d.PictureId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKRoom571835");
            //});

            //modelBuilder.Entity<Whishlist>(entity =>
            //{
            //    entity.HasOne(d => d.Client)
            //        .WithMany(p => p.Whishlist)
            //        .HasForeignKey(d => d.ClientId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKWhishlist532025");

            //    entity.HasOne(d => d.Flat)
            //        .WithMany(p => p.Whishlist)
            //        .HasForeignKey(d => d.FlatId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FKWhishlist730770");
            //});

        }
    }
}
