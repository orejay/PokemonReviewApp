using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;

namespace ReviewApp.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _context;

    public CountryRepository(DataContext context)
    {
        _context = context;
    }

    public bool CreateCountry(Country country)
    {
        _context.Add(country);
        return Save();
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Countries.OrderBy(c => c.Id).ToList();
    }

    public Country GetCountry(int countryId)
    {
        return _context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
    }

    public Country GetCountryByOnwer(int OwnerId)
    {
        return _context.Owners.Where(o => o.Id == OwnerId).Select(c => c.Country).FirstOrDefault();
    }

    public bool GetCountryExists(int countryId)
    {
        return _context.Countries.Any(c => c.Id == countryId);
    }

    public bool GetOwnerExists(int ownerId)
    {
        return _context.Owners.Any(o => o.Id == ownerId);
    }

    public ICollection<Owner> GetOwnersFromACountry(int countryId)
    {
        return _context.Owners.Where(o => o.Country.Id == countryId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();

        return saved > 0 ? true : false;
    }
}