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
    
    public partial class LogicArray
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LogicArray()
        {
            this.GameQuestions = new HashSet<GameQuestion>();
            this.GameQuestions1 = new HashSet<GameQuestion>();
            this.GameQuestions2 = new HashSet<GameQuestion>();
            this.GameQuestions3 = new HashSet<GameQuestion>();
        }
    
        public int Id { get; set; }
        public string Array { get; set; }
        public int CorrectNumber { get; set; }
        public int WrongNumber1 { get; set; }
        public int WrongNumber2 { get; set; }
        public int WrongNumber3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestions1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestions2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameQuestion> GameQuestions3 { get; set; }
    }
}
