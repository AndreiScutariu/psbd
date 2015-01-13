using System;

namespace MedicalClinicHandler.Dto
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string FromUserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}