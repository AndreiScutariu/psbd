using System;
using MedicalClinicExceptions;
using MedicalClinicRepository.Entities;

namespace MedicalClinicRepository.Managers
{
    public interface IMessagesManager : IManagerBase<MessageEntity>
    {
        void SaveMessage(int userId, int toId, string message);
    }

    public class MessagesManager : ManagerBase<MessageEntity>, IMessagesManager
    {
        public void SaveMessage(int userId, int toId, string message)
        {
            try
            {
                var query = Session.CreateSQLQuery("BEGIN CLINIC.ADD_MESSAGE(:userId, :toId, :message); END;");
                query.SetParameter("userId", userId);
                query.SetParameter("toId", toId);
                query.SetParameter("message", message);
                query.ExecuteUpdate();
            }
            catch (Exception ex)
            {
                throw new McDatabaseQueryException();
            }
        }
    }
}