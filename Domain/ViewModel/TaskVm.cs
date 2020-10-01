using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.ViewModel
{
    public class TaskVm
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public bool IsComplete { get; set; }
        public Guid AssignedToId { get; set; }
        [ForeignKey("AssignedToId")]
        public Member member { get; set; }
        protected virtual void OnDropCallback(object e)
        {
            EventHandler<object> dropHandler = DropCallback;
            if (dropHandler != null)
            {
                dropHandler(this, e);
            }
        }
        public event EventHandler<object> DropCallback;
        public void InvokDropCallback(object e)
        {
            OnDropCallback(e);
        }

        protected virtual void OnCheckedChangeCallback(object e)
        {
            EventHandler<object> checkedChangeHandler = CheckedChangeCallback;
            if (checkedChangeHandler != null)
            {
                checkedChangeHandler(this, e);
            }
        }
        public event EventHandler<object> CheckedChangeCallback;
        public void InvokCheckedChangeCallback(object e)
        {
            OnCheckedChangeCallback(e);
        }
    }
}
