//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaoEntitySql
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<long> ProducerId { get; set; }
        public string Propulsion { get; set; }
        public string Material { get; set; }
        public Nullable<long> Velocity { get; set; }
    }
}
