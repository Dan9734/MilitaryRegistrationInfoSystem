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
    
    public partial class Learning
    {
        public int ID { get; set; }
        public Nullable<int> IDRecruit { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> IDMethodLearning { get; set; }
        public Nullable<int> IDResultLearning { get; set; }
    
        public virtual MethodLearning MethodLearning { get; set; }
        public virtual Recruit Recruit { get; set; }
        public virtual ResultLearning ResultLearning { get; set; }
    }
}
