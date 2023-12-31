//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilitaryRegistrationInfoSystem.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recruit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recruit()
        {
            this.Action = new HashSet<Action>();
            this.Anketa = new HashSet<Anketa>();
            this.Learning = new HashSet<Learning>();
            this.MedicalConclusion = new HashSet<MedicalConclusion>();
            this.RecruitEducation = new HashSet<RecruitEducation>();
            this.Summons = new HashSet<Summons>();
        }
    
        public int ID { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public string S_Pass { get; set; }
        public string N_Pass { get; set; }
        public Nullable<System.DateTime> DateIssuePassport { get; set; }
        public string PassportIssued { get; set; }
        public string WorkPlace { get; set; }
        public string RegistrationPlace { get; set; }
        public string LivePlace { get; set; }
        public Nullable<int> IDHealthCategory { get; set; }
        public string InSummary { get; set; }
        public string Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Action> Action { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual HealthCategory HealthCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Learning> Learning { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalConclusion> MedicalConclusion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecruitEducation> RecruitEducation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Summons> Summons { get; set; }
    }
}
