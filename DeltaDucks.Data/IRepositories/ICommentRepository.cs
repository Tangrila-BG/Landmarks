using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Models;

namespace DeltaDucks.Data.IRepositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        ICollection<Comment> GetCommentsByLandmarkId(int id);
    }
}
