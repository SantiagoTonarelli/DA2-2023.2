﻿using Domain;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        User CreateUser(User user);
        IEnumerable<User> GetAllUsers(string nameOrEmpty);
    }
}