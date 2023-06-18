using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DataContext _context;
    public ReviewerRepository(DataContext context)
    {
        _context = context;
    }

    public Reviewer GetReviewer(int reviewerId)
    {
        return _context.Reviewers.Where(r => r.Id == reviewerId)
            .Include(e => e.Reviews)
            .FirstOrDefault();
    }

    public ICollection<Reviewer> GetReviewers()
    {
        return _context.Reviewers.OrderBy(r => r.Id).ToList();
    }

    public ICollection<Review> GetReviewsByAReviewer(int reviewerId)
    {
        return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).OrderBy(r => r.Id).ToList();
    }

    public bool ReviewerExists(int reviewerId)
    {
        return _context.Reviews.Any(r => r.Id == reviewerId);
    }
}