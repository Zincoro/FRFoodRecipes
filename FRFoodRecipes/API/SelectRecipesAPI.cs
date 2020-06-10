using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Runtime.Serialization;

namespace FRFoodRecipes.API
{

    [DataContract]
    public partial class SingleRootObject
    {
        [DataMember]
        public string Uri { get; set; }
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string ShareAs { get; set; }
        [DataMember]
        public long Yield { get; set; }
        [DataMember]
        public List<string> DietLabels { get; set; }
        [DataMember]
        public List<string> HealthLabels { get; set; }
        [DataMember]
        public List<string> Cautions { get; set; }
        [DataMember]
        public List<string> IngredientLines { get; set; }
        [DataMember]
        public List<Ingredient> Ingredients { get; set; }
        [DataMember]
        public double Calories { get; set; }
        [DataMember]
        public double TotalWeight { get; set; }
        [DataMember]
        public long TotalTime { get; set; }
        [DataMember]
        public TotalNutrients TotalNutrients { get; set; }
        [DataMember]
        public TotalDaily TotalDaily { get; set; }
        [DataMember]
        public List<Digest> Digest { get; set; }
    }

    [DataContract]
    public partial class Digest
    {
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public string SchemaOrgTag { get; set; }
        [DataMember]
        public double Total { get; set; }
        [DataMember]
        public bool HasRdi { get; set; }
        [DataMember]
        public double Daily { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public List<Sub> Sub { get; set; }
    }

    [DataContract]
    public partial class Sub
    {
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public string SchemaOrgTag { get; set; }
        [DataMember]
        public double Total { get; set; }
        [DataMember]
        public bool HasRdi { get; set; }
        [DataMember]
        public double Daily { get; set; }
        [DataMember]
        public string Unit { get; set; }
    }

    [DataContract]
    public partial class Ingredient
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public double Weight { get; set; }
    }

    [DataContract]
    public partial class TotalDaily
    {
        [DataMember]
        public Ca EnercKcal { get; set; }
        [DataMember]
        public Ca Fat { get; set; }
        [DataMember]
        public Ca Fasat { get; set; }
        [DataMember]
        public Ca Chocdf { get; set; }
        [DataMember]
        public Ca Fibtg { get; set; }
        [DataMember]
        public Ca Procnt { get; set; }
        [DataMember]
        public Ca Chole { get; set; }
        [DataMember]
        public Ca Na { get; set; }
        [DataMember]
        public Ca Ca { get; set; }
        [DataMember]
        public Ca Mg { get; set; }
        [DataMember]
        public Ca K { get; set; }
        [DataMember]
        public Ca Fe { get; set; }
        [DataMember]
        public Ca Zn { get; set; }
        [DataMember]
        public Ca P { get; set; }
        [DataMember]
        public Ca VitaRae { get; set; }
        [DataMember]
        public Ca Vitc { get; set; }
        [DataMember]
        public Ca Thia { get; set; }
        [DataMember]
        public Ca Ribf { get; set; }
        [DataMember]
        public Ca Nia { get; set; }
        [DataMember]
        public Ca Vitb6A { get; set; }
        [DataMember]
        public Ca Foldfe { get; set; }
        [DataMember]
        public Ca Vitb12 { get; set; }
        [DataMember]
        public Ca Vitd { get; set; }
        [DataMember]
        public Ca Tocpha { get; set; }
        [DataMember]
        public Ca Vitk1 { get; set; }
    }

    [DataContract]
    public partial class Ca
    {
        [DataMember]
        public string Label { get; set; }
        [DataMember]
        public double Quantity { get; set; }
        [DataMember]
        public string Unit { get; set; }
    }

    [DataContract]
    public partial class TotalNutrients
    {
        [DataMember]
        public Ca EnercKcal { get; set; }
        [DataMember]
        public Ca Fat { get; set; }
        [DataMember]
        public Ca Fasat { get; set; }
        [DataMember]
        public Ca Fatrn { get; set; }
        [DataMember]
        public Ca Fams { get; set; }
        [DataMember]
        public Ca Fapu { get; set; }
        [DataMember]
        public Ca Chocdf { get; set; }
        [DataMember]
        public Ca Fibtg { get; set; }
        [DataMember]
        public Ca Sugar { get; set; }
        [DataMember]
        public Ca SugarAdded { get; set; }
        [DataMember]
        public Ca Procnt { get; set; }
        [DataMember]
        public Ca Chole { get; set; }
        [DataMember]
        public Ca Na { get; set; }
        [DataMember]
        public Ca Ca { get; set; }
        [DataMember]
        public Ca Mg { get; set; }
        [DataMember]
        public Ca K { get; set; }
        [DataMember]
        public Ca Fe { get; set; }
        [DataMember]
        public Ca Zn { get; set; }
        [DataMember]
        public Ca P { get; set; }
        [DataMember]
        public Ca VitaRae { get; set; }
        [DataMember]
        public Ca Vitc { get; set; }
        [DataMember]
        public Ca Thia { get; set; }
        [DataMember]
        public Ca Ribf { get; set; }
        [DataMember]
        public Ca Nia { get; set; }
        [DataMember]
        public Ca Vitb6A { get; set; }
        [DataMember]
        public Ca Foldfe { get; set; }
        [DataMember]
        public Ca Folfd { get; set; }
        [DataMember]
        public Ca Folac { get; set; }
        [DataMember]
        public Ca Vitb12 { get; set; }
        [DataMember]
        public Ca Vitd { get; set; }
        [DataMember]
        public Ca Tocpha { get; set; }
        [DataMember]
        public Ca Vitk1 { get; set; }
        [DataMember]
        public Ca Water { get; set; }
    }
}
