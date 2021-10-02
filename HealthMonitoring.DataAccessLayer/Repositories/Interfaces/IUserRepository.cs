using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        bool IsFindLogin(User user);
        bool IsFindLoginAndPassword(string username, string password);
        UserInformationDataModel GetUserInformation(string login);
        void SetUserInformation(UserInformationDataModel userInformationDataModel);
    }
}
