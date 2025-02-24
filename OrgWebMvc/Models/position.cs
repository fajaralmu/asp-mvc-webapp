//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrgWebMvc.Models
{
    using InstApp.Annotation;
    using System;
    using System.Collections.Generic;
    [Entity]
    public partial class position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position()
        {
            this.members = new HashSet<member>();
            this.position1 = new HashSet<position>();
        }

        [FieldAttribute(FieldType = AttributeConstant.TYPE_ID_AI)]
        public int id { get; set; }
        [FieldAttribute(FieldType = AttributeConstant.TYPE_TEXTBOX, Required = true)]
        public string name { get; set; }
        [FieldAttribute(Required = true, FieldType = AttributeConstant.TYPE_DROPDOWN, FieldName = "Section", ClassReference = "section", ClassAttributeConverter = "name")]
        public int section_id { get; set; }
        [FieldAttribute(Required = false, FieldType = AttributeConstant.TYPE_DROPDOWN, FieldName = "Parent_Section", ClassRefPropName = "position2", ClassReference = "position", ClassAttributeConverter = "name")]
        public Nullable<int> parent_position_id { get; set; }
        [FieldAttribute(FieldType = AttributeConstant.TYPE_TEXTAREA, Required = true)]
        public string description { get; set; }

        public position positionParent
        {
            get
            {
                if (position1.Count > 0)
                {
                    return position1.GetEnumerator().Current;
                }
                return null;
            }
        }

        //public int id { get; set; }
        //public string name { get; set; }
        //public int section_id { get; set; }
        //public Nullable<int> parent_position_id { get; set; }
        //public string description { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<member> members { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<position> position1 { get; set; }
        public virtual position position2 { get; set; }
        public virtual section section { get; set; }
    }
}
