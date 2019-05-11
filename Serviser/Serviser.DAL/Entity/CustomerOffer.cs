namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerOffer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerOffer()
        {
            CustomerProfiles = new HashSet<CustomerProfile>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Heading { get; set; }

        [StringLength(50)]
        public string Details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerProfile> CustomerProfiles { get; set; }
    }
}
