using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Profiles;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        IMapper _mapper;

        public UserServices()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _userRepository = new UserRepository(_healthMonitoringContext);
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }
        public void RegisterUser(string login, string password, Action<string> action)
        {
            User user = new User() { Login = login, Password = password };
            bool isUser = _userRepository.IsFindLogin(user);
            if (!isUser)
            {
                _userRepository.Add(user);
                _healthMonitoringContext.SaveChanges();
                action("Registration successful");
            }
            else
            {
                action("This login is taken");
            }            
        }

        public bool CheckUser(string login, string password)
        {
            bool isUser = _userRepository.IsFindLoginAndPassword(login, password);
            return isUser;
        }

        public UserInformationModel GetUserInformation(string login)
        {
            var userInformation = _userRepository.GetUserInformation(login);
            var mappedUserInformation = _mapper.Map<UserInformationModel>(userInformation);
            if (mappedUserInformation == null)
            {
                return new UserInformationModel();
            }
            else
            {
                return mappedUserInformation;
            }
            
        }
        public void SetUserInformation(UserInformationModel userInformationModel)
        {
            var mappedUserInformation = _mapper.Map<UserInformationDataModel>(userInformationModel);
            _userRepository.SetUserInformation(mappedUserInformation);
            _healthMonitoringContext.SaveChanges();
        }
    }
}
