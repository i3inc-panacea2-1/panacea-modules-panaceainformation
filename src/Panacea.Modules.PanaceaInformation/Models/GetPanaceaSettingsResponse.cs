using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Modules.PanaceaInformation.Models
{
    [DataContract]
    public class GetPanaceaSettingsResponse
    {
        [DataMember(Name = "PanaceaInformation")]
        public PanaceaInfo PanaceaInfo { get; set; }
    }

    [DataContract]
    public class PanaceaInfo
    {
        [DataMember(Name = "panaceaCategories")]
        public List<PanaceaInfoCategory> PanaceaCategories { get; set; }

        [DataMember(Name = "pluginSettings")]
        public PanaceaInfoSettings Settings { get; set; }
    }

    [DataContract]
    public class PanaceaInfoSettings
    {
        [DataMember(Name = "showServicesPopup")]
        public bool ShowPopup { get; set; }
    }

    [DataContract]
    public class PanaceaInfoCategory
    {
        [DataMember(Name = "items")]
        public List<PanaceaInfoItemWrapper> Items { get; set; }
    }


    [DataContract]
    public class PanaceaInfoItemWrapper
    {
        [DataMember(Name = "item")]
        public PanaceaInfoItem Item { get; set; }
    }


    [DataContract]
    public class PanaceaInfoItem
    {
        [DataMember(Name = "dataUrl")]
        public string DataUrl { get; set; }
    }
}
