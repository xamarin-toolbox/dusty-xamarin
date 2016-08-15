using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dusty
{
    [DataContract]
    public class Secrets
    {
        [DataMember] public string HockeyAppId { get; set; }
    }
}
