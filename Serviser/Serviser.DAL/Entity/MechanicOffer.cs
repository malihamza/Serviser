namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MechanicOffer
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string Heading { get; set; }

        [StringLength(100)]
        public string Details { get; set; }

        public byte[] Image { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public DateTime? ExpirationDateTime { get; set; }
    }
}
