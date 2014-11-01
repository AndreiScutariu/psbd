using System;

namespace MedicalClinicRepository.Entities
{
    public abstract class BaseEntity
    {
        public virtual Int32 Id { get; set; }
    }
}