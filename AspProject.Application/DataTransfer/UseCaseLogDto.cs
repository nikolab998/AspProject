using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.DataTransfer
{
    public class UseCaseLogDto 
    {
        public string UseCaseName { get; set; }
        public string Actor { get; set; }
        public DateTime Date { get; set; }
        public string Data { get; set; }
    }
}
