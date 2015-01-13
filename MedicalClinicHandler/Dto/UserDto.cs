using System.Collections.Generic;

namespace MedicalClinicHandler.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleDto UserRole { get; set; }
        public List<SpecializationDto> Specializations { get; set; }
        public List<MessageDto> MessageDtos { get; set; }
        public int Notification { get; set; }
    }
}
