//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilitaryDistrict_IS._database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Division
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Division()
        {
            this.Brigade = new HashSet<Brigade>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> PartsOfMilDistrId { get; set; }
        public Nullable<int> CommanderId { get; set; }
        public Nullable<int> CorpsId { get; set; }
        public Nullable<int> MilitaryBaseId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brigade> Brigade { get; set; }
        public virtual Corps Corps { get; set; }
        public virtual MilitaryBase MilitaryBase { get; set; }
        public virtual PartsOfMilitaryDistrict PartsOfMilitaryDistrict { get; set; }
    }
}
