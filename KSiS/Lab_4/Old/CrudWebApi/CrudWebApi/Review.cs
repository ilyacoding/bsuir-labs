//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CrudWebApi
{
    using System;
    using System.Collections.Generic;

    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true)]
    public partial class Review
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public virtual Post Posts { get; set; }

        [DataMember]
        public virtual User Users { get; set; }
    }
}
