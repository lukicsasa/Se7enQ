//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Se7enQ.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public int Id { get; set; }
        public int FirstPlayerId { get; set; }
        public int SecondPlayerId { get; set; }
        public decimal FirstPlayerPoints { get; set; }
        public decimal SecondPlayerPoints { get; set; }
        public System.DateTime DatePlayed { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
