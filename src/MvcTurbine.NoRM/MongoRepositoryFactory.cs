﻿using System;

namespace MvcTurbine.NoRM
{
    public interface IMongoRepositoryFactory : IDisposable
    {
    }

    public class MongoRepositoryFactory : IMongoRepositoryFactory
    {
        public void Dispose()
        {
        }
    }
}