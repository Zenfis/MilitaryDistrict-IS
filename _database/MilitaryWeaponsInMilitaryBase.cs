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
    
    public partial class MilitaryWeaponsInMilitaryBase
    {
        public int Id { get; set; }
        public Nullable<int> MilitaryWeaponId { get; set; }
        public Nullable<int> MilitaryBaseId { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual MilitaryBase MilitaryBase { get; set; }
        public virtual MilitaryWeapon MilitaryWeapon { get; set; }
    }
}
