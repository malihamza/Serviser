namespace Serviser.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Serviser.DAL.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Infrastructure.Annotations;

    public partial class ServiserDbContext : IdentityDbContext<User>
    {
        public ServiserDbContext()
            : base("ServiserDbContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<CustomerOffer> BustomerOffers { get; set; }
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public virtual DbSet<MechanicOffer> MechanicOffers { get; set; }
        public virtual DbSet<MechanicProfile> MechanicProfiles { get; set; }
        public virtual DbSet<MechanicNotification> MechanicNotifications { get; set; }
        public virtual DbSet<OfferMechanicBridge> OfferMechanicBridges { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<VehicleName> VehicleNames { get; set; }
        public virtual DbSet<VehicleProblem> VehicleProblems { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<BillItem> BillItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Booking>()
                .HasMany(e => e.BillItems)
                .WithRequired(e => e.Booking)
                .HasForeignKey(e => e.BookingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookingStatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<BookingStatus>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.BookingStatus)
                .HasForeignKey(e => e.BookingStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerOffer>()
                .Property(e => e.Heading)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerOffer>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerOffer>()
                .HasMany(e => e.CustomerProfiles)
                .WithMany(e => e.CustomerOffers)
                .Map(m => m.ToTable("offerCustomerBridge").MapLeftKey("offer_id").MapRightKey("customer_id"));

            modelBuilder.Entity<CustomerProfile>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.CustomerProfile)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CustomerProfile>()
            //    .HasMany(e => e.VehicleNames)
            //    .WithMany(e => e.CustomerProfiles)
            //    .Map(m => m.ToTable("CustomerVehicleName").MapLeftKey("customer_id").MapRightKey("vehicle_name_id"));

            modelBuilder.Entity<MechanicOffer>()
                .Property(e => e.Heading)
                .IsFixedLength();

            modelBuilder.Entity<MechanicOffer>()
                .Property(e => e.Details)
                .IsFixedLength();

            modelBuilder.Entity<MechanicProfile>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.MechanicProfile)
                .HasForeignKey(e => e.MechanicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MechanicProfile>()
                .HasMany(e => e.OfferMechanicBridges)
                .WithRequired(e => e.MechanicProfile)
                .HasForeignKey(e => e.MechanicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MechanicProfile>()
                .HasMany(e => e.VehicleProblems)
                .WithMany(e => e.MechanicProfiles)
                .Map(m => m.ToTable("mechanic_vehicle_problems").MapLeftKey("mechanic_id").MapRightKey("problem_id"));

            modelBuilder.Entity<MechanicNotification>()
                .Property(e => e.Heading)
                .IsUnicode(false);

            modelBuilder.Entity<MechanicNotification>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .HasColumnType("varchar").HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            //modelBuilder.Entity<Role>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Role>()
            //    .HasMany(e => e.Users)
            //    .WithMany(e => e.Roles)
            //    .Map(m => m.ToTable("userRole").MapRightKey("user_id"));

            //modelBuilder.Entity<User>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .Property(e => e.FirstName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .Property(e => e.LastName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<VehicleName>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<VehicleName>()
            //    .HasMany(e => e.VehicleProblems)
            //    .WithRequired(e => e.VehicleName)
            //    .HasForeignKey(e => e.VehicleNameId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleProblem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleProblem>()
                .HasMany(e => e.BillItems)
                .WithRequired(e => e.VehicleProblem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.VehicleProblems)
                .WithRequired(e => e.VehicleType)
                .WillCascadeOnDelete(false);
        }

        public static ServiserDbContext Create()
        {
            return new ServiserDbContext();
        }
    }
}
