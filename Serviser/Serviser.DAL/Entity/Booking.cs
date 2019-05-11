namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            BillItems = new HashSet<BillItem>();
        }

        public int Id { get; set; }

        public int MechanicId { get; set; }

        public int CustomerId { get; set; }

        public int BookingStatusId { get; set; }

        public DateTime CreationDateIime { get; set; }

        public double? BaseFare { get; set; }

        public double? MechanicLatitude { get; set; }

        public double? MechanicLongitude { get; set; }

        public double? CustomerLongitude { get; set; }

        public double? CustomerLatitude { get; set; }

        public double? Distance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillItem> BillItems { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }

        public virtual CustomerProfile CustomerProfile { get; set; }

        public virtual MechanicProfile MechanicProfile { get; set; }
    }
}
