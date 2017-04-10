using System;

namespace DeltaDucks.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DeltaDucksContext Init();
    }
}
