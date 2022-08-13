using System;
using System.Collections.Generic;

namespace nagp_devops_us.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public List<KeyValuePair<string, string>> EnvVars { get; set; }
    }
}
