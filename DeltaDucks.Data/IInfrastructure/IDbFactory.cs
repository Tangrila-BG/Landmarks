using System;

namespace DeltaDucks.Data.IInfrastructure
{
    public interface IDbFactory : IDisposable
    {
        DeltaDucksContext Init();
    }
}
