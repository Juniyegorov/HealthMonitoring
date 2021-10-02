using HealthMonitoring.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services.Interfaces
{
    public interface IUserServices
    {
        void RegisterUser(string login, string password, Action<string> action);
        bool CheckUser(string login, string password);
        UserInformationModel GetUserInformation(string login);
        void SetUserInformation(UserInformationModel userInformationModel);
    }
}
