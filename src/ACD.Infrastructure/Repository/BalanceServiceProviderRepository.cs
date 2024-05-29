using ACD.Domain.Interfaces;
using ACD.Domain.Models;
using ACD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace ACD.Infrastructure.Repository;



/// <summary>
/// Repository class for managing BalanceServiceProvider entities, 
/// implementing specific data access methods for the object 
/// BalanceServiceProvider
/// </summary>
public class BalanceServiceProviderRepository : Repository<BalanceServiceProvider>, IBalanceServiceProviderRepository
{

    /// <summary>
    /// Initializes a new instance of the <see cref="BalanceServiceProviderRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger.</param>
    public BalanceServiceProviderRepository(ACDDbContext context, ILogger<Repository<BalanceServiceProvider>> logger) : base(context, logger)
    {
        
    }


    /// <summary>
    /// Retrieves a collection of BalanceServiceProvider entities by the specified country.
    /// </summary>
    /// <param name="country">The country to filter the BalanceServiceProviders by.</param>
    /// <returns>A collection of BalanceServiceProvider entities.</returns>
    public async Task<IEnumerable<BalanceServiceProvider>> GetBalanceServiceProvidersByCountry(string country)
    {

        try
        {

            return await _dbSet.Where(x => x.Country == country).ToListAsync();

        }
        catch (Exception e)
        {

            _logger.LogError(e, "Error getting balance service providers by country");
            throw;

        }

    }


    /// <summary>
    /// Retrieves a BalanceServiceProvider entity by the specified business ID.
    /// </summary>
    /// <param name="businessId">The business ID to filter the BalanceServiceProvider by.</param>
    /// <returns>A BalanceServiceProvider entity.</returns>
    public async Task<BalanceServiceProvider> GetByBusinessId(string businessId)
    {
        
        try
        {

            return await _dbSet.FirstOrDefaultAsync(x => x.BusinessId == businessId);
        
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting balance service provider by business id");
            throw;
        }

    }

}