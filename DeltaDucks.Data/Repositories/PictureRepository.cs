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
    public class PictureRepository : RepositoryBase<Picture>, IPictureRepository
    {
        public PictureRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void AddPicture(Picture picture)
        {
            this.DbContext.Pictures.Add(picture);
        }
    }
}
