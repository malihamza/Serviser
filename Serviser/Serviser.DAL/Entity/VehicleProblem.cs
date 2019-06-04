namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleProblem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleProblem()
        {
            BillItems = new HashSet<BillItem>();
            MechanicProfiles = new HashSet<MechanicProfile>();
        }

        public int Id { get; set; }

        //public int VehicleNameId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        //public int MinRate { get; set; }

        //public int MaxRate { get; set; }

        public int EstimatedPrice { get; set; }

        [ForeignKey(name:"VehicleType")]
        public int VehicleTypeId { get; set; }

        //public virtual VehicleName VehicleName { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillItem> BillItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MechanicProfile> MechanicProfiles { get; set; }
    }
}
