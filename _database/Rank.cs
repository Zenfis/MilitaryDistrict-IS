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
    
    public partial class Rank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rank()
        {
            this.Commander = new HashSet<Commander>();
            this.Soldier = new HashSet<Soldier>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual CategoriesOfRank CategoriesOfRank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commander> Commander { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soldier> Soldier { get; set; }
    }
}