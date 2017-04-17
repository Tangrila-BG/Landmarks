using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.Infrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public ICollection<Comment> GetCommentsByLandmarkId(int id)
        {
            return DbContext
                .Comments
                .Where(comment => comment.Landmark.LandmarkId == id)
                .OrderByDescending(comment => comment.DateCreated).ToList();
        }
    }
}
