using Models.EF;
using Models.Entities;
using System.Collections.Generic;

namespace Models.Repositories
{
    public interface IReviewRepository
    {
        void Add(Review r);
        void Delete(int id);
        void Edit(Review r);
        List<Review> GetAll();
        Review GetById(int id);
    }
}