﻿using System.Collections.Generic;
using DeltaDucks.Data.IInfrastructure;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;

namespace DeltaDucks.Data.Repositories
{
    using System.Linq;
    using Infrastructure;

    public class LandmarkRepository : RepositoryBase<Landmark>, ILandmarkRepository
    {
        public LandmarkRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Landmark GetLandmarkById(int id)
        {
            return DbContext.Landmarks.FirstOrDefault(l => l.LandmarkId == id);
        }

        public Landmark GetLandmarkByName(string landmarkName)
        {
            return DbContext.Landmarks.FirstOrDefault(l => l.Name == landmarkName);
        }

        public IQueryable<Landmark> GetPageOfLendmarks(int take, int skip)
        {
            return DbContext.Landmarks.OrderBy(x => x.Number).Skip(skip).Take(take);
        }

        public IQueryable<Landmark> GetUserVisitedLandmarks(string id)
        {
            return DbContext.Users.FirstOrDefault(u => u.Id == id)
                .VisitedLandmarks
                .AsQueryable();
        }

        public IQueryable<Landmark> GetUserNotVisitedLandmarks(string id)
        {
            ApplicationUser user = DbContext.Users.FirstOrDefault(u => u.Id == id);
            var visitedLandmarks = user.VisitedLandmarks.Select(l => l.LandmarkId);
            var allLandmarks = this.GetAll();

            return allLandmarks.Where(l => !visitedLandmarks.Contains(l.LandmarkId));
        }

        public Landmark GetLandmarkByNumber(int number)
        {
            return DbContext.Landmarks.FirstOrDefault(x => x.Number == number);
        }

        public void IncreaseVisits(int id)
        {
            this.GetLandmarkById(id).Visits++;
            DbContext.Commit();
        }

        // Hardcode number 
        public override void Update(Landmark entity)
        {
            entity.Number = 34;
            base.Update(entity);
        }
    }
}
