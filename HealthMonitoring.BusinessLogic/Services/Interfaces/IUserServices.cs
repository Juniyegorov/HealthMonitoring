using HealthMonitoring.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services.Interfaces
{
    public interface IUserServices
    {
        bool RegisterUser(string login, string password);
        bool CheckUser(string login, string password);
        UserInformationModel GetUserInformation(string login);
        void SetUserInformation(UserInformationModel userInformationModel);
    }
}
