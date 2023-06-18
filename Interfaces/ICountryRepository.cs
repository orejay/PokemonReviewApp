using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();

    Country GetCountry(int countryId);
    Country GetCountryByOnwer(int OwnerId);
    ICollection<Owner> GetOwnersFromACountry(int countryId);
    bool GetCountryExists(int countryId);
    bool CreateCountry(Country country);
    bool Save();
}