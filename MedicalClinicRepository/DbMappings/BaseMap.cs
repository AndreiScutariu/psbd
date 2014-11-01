using System;
using FluentNHibernate.Mapping;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Factory;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class BaseMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(SequencesFactory.GetSequenceName(typeof(T)));
        }
    }
}