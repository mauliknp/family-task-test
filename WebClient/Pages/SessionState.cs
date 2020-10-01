using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Pages
{
    public class SessionState
    {
        public Guid refId { get; set; }
        public Guid taskId { get; set; }
        public string subject { get; set; }
        public bool iscomplete { get; set; }
    }
}
