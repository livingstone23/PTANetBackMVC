using ACD.Api.Dto;
using AutoMapper;
using Newtonsoft.Json;

namespace ACD.Api.Helper;


/// <summary>
/// The ACDHelper class is a utility class for multiple functionalities. 
/// </summary>
public class AcdHelper
{

    private readonly HttpClient _httpClient;

    private readonly IMapper _mapper;

    private readonly ILogger<AcdHelper> _logger;


    /// <summary>
    /// Constructor of ACDHelper
    /// </summary>
    /// <param name="httpClient"></param>
    public AcdHelper(HttpClient httpClient, IMapper mapper, ILogger<AcdHelper> logger)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _logger = logger;
    }


    /// <summary>
    /// GetAllFromWeb
    /// The method calls the endpoint https://api.opendata.esett.com/EXP01/BalanceResponsibleParties
    /// and retrieves information about Balance Service Providers
    /// which is then saved to the database.
    /// This method is called by the endpoint GetAllFromWebPage.
    /// </summary>
    public async Task<IEnumerable<BalanceServiceProviderDTO>> GetAllFromWeb()
    {
        try
        {

            var response = await _httpClient.GetAsync("https://api.opendata.esett.com/EXP01/BalanceResponsibleParties");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var balanceServiceProvidersResponse = JsonConvert.DeserializeObject<IEnumerable<BalanceServiceProviderResponse>>(content);
                var balanceServiceProviders = _mapper.Map<IEnumerable<BalanceServiceProviderDTO>>(balanceServiceProvidersResponse);

                return balanceServiceProviders;
            }

            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method GetAllFromWeb");
            throw;
        }
    }


}

