//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liquid.Library.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public System.Guid Id { get; set; }
        public Nullable<System.DateTimeOffset> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedBy_Id { get; set; }
        public Nullable<System.DateTimeOffset> LastModifiedOn { get; set; }
        public Nullable<System.Guid> LastModifiedBy_Id { get; set; }
        public string Name { get; set; }
    }
}
