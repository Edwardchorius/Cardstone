﻿using Cardstone.Data.Context;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public interface IService
    {
        ICardstoneContext Context { get; }

        IDictionary<string, IService> Services { get; }
    }
}
