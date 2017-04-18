using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        void Save();
        void Update(Comment comment);
        IQueryable<Comment> GetCommentsByLandmarkId(int id);
        Comment GetCommentById(int id);
    }
}
