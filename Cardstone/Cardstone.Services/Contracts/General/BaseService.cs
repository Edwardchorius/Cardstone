using Cardstone.Data.Context;
using System;
using System.Collections.Generic;

namespace Cardstone.Services.Contracts
{
    public abstract class BaseService : IService
    {
        public BaseService(ICardstoneContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public BaseService(ICardstoneContext context, params IService[] services)
            : this (context)
        {
            this.Services = new List<IService>();

            foreach (IService service in services)
            {
                if (service == null)
                    throw new ArgumentNullException(nameof(service));

                this.Services.Add(service);
            }
        }

        public ICardstoneContext Context { get; }

        public ICollection<IService> Services { get; }
    }
}
