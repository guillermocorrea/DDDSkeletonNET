using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDSkeletonNET.Portal.Repository.Memory.Database
{
    public interface IObjectContextFactory
    {
        InMemoryDatabaseObjectContext Create();
    }
}
