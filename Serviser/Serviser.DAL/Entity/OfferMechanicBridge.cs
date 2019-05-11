namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OfferMechanicBridge
    {
        public int MechanicId { get; set; }

        public int OfferId { get; set; }

        public int Id { get; set; }

        public virtual MechanicProfile MechanicProfile { get; set; }
    }
}
