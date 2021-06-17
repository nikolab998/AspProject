using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class UseCaseLog : BaseEntity
    {
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public string Actor { get; set; }
    }
}
