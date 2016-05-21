using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Repositories;
using Models.EF;

namespace Models.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private EFDbContext _context;
        public ReviewRepository(EFDbContext context)
        {
            this._context = context;
        }
        public void Add(Review r)
        {
            _context.Reviews.Add(r);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public void Edit(Review r)
        {
            _context.Entry(r).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.First(r => r.Id.Equals(id));
        }
    }
}
