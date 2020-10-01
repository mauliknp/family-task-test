using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.DataModels
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Please enter task")]
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid? AssignedToId { get; set; }

        [ForeignKey("AssignedToId")]
        public Member member { get; set; }


    }
}
