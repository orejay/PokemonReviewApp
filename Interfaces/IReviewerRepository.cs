using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int reviewerId);
    ICollection<Review> GetReviewsByAReviewer(int reviewerId);
    bool ReviewerExists(int reviewerId);

}