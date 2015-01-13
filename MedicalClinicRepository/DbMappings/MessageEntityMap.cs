using System;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.DbMappings
{
    [Serializable]
    public class MessageEntityMap : BaseMap<MessageEntity>
    {
        public MessageEntityMap()
        {
            Table("MESSAGE");
            Map(x => x.Message, "MESSAGE");
            Map(x => x.CreatedDate, "CREATED_DATE");
            References(x => x.From).Class<User>().Columns("FROM_ID");
            References(x => x.To).Class<User>().Columns("TO_ID");
        }
    }
}