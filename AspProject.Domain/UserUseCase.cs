using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class UserUseCase : BaseEntity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public virtual User User { get; set; }
    }
}
