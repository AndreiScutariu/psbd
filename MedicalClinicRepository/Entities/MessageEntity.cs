using System;

namespace MedicalClinicRepository.Entities
{
    public class MessageEntity : BaseEntity
    {
        public virtual User From { get; set; }
        public virtual User To { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}