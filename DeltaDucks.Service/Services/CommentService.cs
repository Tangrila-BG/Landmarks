using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository,IUnitOfWork unitOfWork)
        {
            this._commentRepository = commentRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Delete(Comment comment)
        {
            _commentRepository.Delete(comment);
        }

        public ICollection<Comment> GetCommentsByLandmarkId(int id)
        {
            return _commentRepository.GetCommentsByLandmarkId(id);
        }

        public Comment GetCommentById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public void Update(Comment comment)
        {
            _commentRepository.Update(comment);
        }
    }
}
