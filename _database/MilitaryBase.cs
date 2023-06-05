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
    
    public partial class MilitaryBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MilitaryBase()
        {
            this.Company = new HashSet<Company>();
            this.ConstructionsInMilitaryBase = new HashSet<ConstructionsInMilitaryBase>();
            this.Departament = new HashSet<Departament>();
            this.MilitaryEquipmentsInMilitaryBase = new HashSet<MilitaryEquipmentsInMilitaryBase>();
            this.MilitaryWeaponsInMilitaryBase = new HashSet<MilitaryWeaponsInMilitaryBase>();
            this.Platoon = new HashSet<Platoon>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CommanderId { get; set; }
        public Nullable<int> PlacesOfDeploymentId { get; set; }
    
        public virtual Commander Commander { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstructionsInMilitaryBase> ConstructionsInMilitaryBase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departament> Departament { get; set; }
        public virtual PlacesOfDeployment PlacesOfDeployment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MilitaryEquipmentsInMilitaryBase> MilitaryEquipmentsInMilitaryBase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MilitaryWeaponsInMilitaryBase> MilitaryWeaponsInMilitaryBase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Platoon> Platoon { get; set; }
    }
}
