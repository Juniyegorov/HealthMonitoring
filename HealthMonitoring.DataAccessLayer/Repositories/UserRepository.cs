using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HealthMonitoringContext _healthMonitoringContext;
        public UserRepository(HealthMonitoringContext healthMonitoringContext)
        {
            _healthMonitoringContext = healthMonitoringContext;
        }
        public void Add(User user)
        {
            _healthMonitoringContext.Users.Add(user);
        }
        public bool IsFindLogin(User user)
        {
            var selectUser = _healthMonitoringContext.Users.SingleOrDefault(u => u.Login == user.Login);
            return selectUser != null;
        }

        public bool IsFindLoginAndPassword(string username, string password)
        {
            var selectUser = _healthMonitoringContext.Users.SingleOrDefault(u => u.Login == username && u.Password == password);
            return selectUser != null;
        }

        public UserInformationDataModel GetUserInformation(string login)
        {
            var userInformation = from userCharact in _healthMonitoringContext.UserCharacteristics
                                  join u in _healthMonitoringContext.Users on userCharact.UserId equals u.Id
                                  where u.Login == login
                                  select new UserInformationDataModel
                                  {
                                      Id = u.Id,
                                      Name = userCharact.Name,
                                      Surname = userCharact.Surname,
                                      Growth = userCharact.Growth,
                                      Weight = userCharact.Weight
                                  };
            if (userInformation.FirstOrDefault() == null)
            {
                var user = _healthMonitoringContext.Users.FirstOrDefault(u => u.Login == login);
                return new UserInformationDataModel
                {
                    Id = user.Id
                };

            }
            else
            {
                return userInformation.FirstOrDefault();
            }

        }
        public void SetUserInformation(UserInformationDataModel userInformationDataModel)
        {
            UserCharacteristic selectUserCharacteristic = _healthMonitoringContext.UserCharacteristics.FirstOrDefault(u => u.UserId == userInformationDataModel.Id);
            if (selectUserCharacteristic == null)
            {
                UserCharacteristic userCharacteristic = new UserCharacteristic()
                {
                    Name = userInformationDataModel.Name,
                    Surname = userInformationDataModel.Surname,
                    Growth = userInformationDataModel.Growth,
                    UserId = userInformationDataModel.Id,
                    Weight = userInformationDataModel.Weight
                };
                _healthMonitoringContext.UserCharacteristics.Add(userCharacteristic);
            }
            else
            {
                selectUserCharacteristic.Name = userInformationDataModel.Name;
                selectUserCharacteristic.Surname = userInformationDataModel.Surname;
                selectUserCharacteristic.Growth = userInformationDataModel.Growth;
                selectUserCharacteristic.Weight = userInformationDataModel.Weight;
            }
        }
        public List<UserCharacteristic> GetUserInformationa()
        {
            var usersInfo = _healthMonitoringContext.UserCharacteristics.FromSqlRaw("GetUsersByCompany").ToList();
            return usersInfo;
        }
    }
}
