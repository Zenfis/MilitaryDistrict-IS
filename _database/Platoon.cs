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
    
    public partial class Platoon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platoon()
        {
            this.Departament = new HashSet<Departament>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CommanderId { get; set; }
        public Nullable<int> MilitaryBaseId { get; set; }
        public Nullable<int> CompanyId { get; set; }
    
        public virtual Commander Commander { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departament> Departament { get; set; }
        public virtual MilitaryBase MilitaryBase { get; set; }
    }
}