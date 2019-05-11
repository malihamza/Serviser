namespace Serviser.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MechanicNotification
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Heading { get; set; }

        [StringLength(50)]
        public string Details { get; set; }
    }
}
