using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(string login, string password);
        bool IsFindLogin(string login);
        bool IsFindLoginAndPassword(string username, string password);
        UserInformationDataModel GetUserInformation(string login);
        void SetUserInformation(UserInformationDataModel userInformationDataModel);
    }
}
