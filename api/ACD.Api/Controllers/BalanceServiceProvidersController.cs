using ACD.Api.Dto;
using ACD.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;



namespace ACD.Api.Controllers;



/// <summary>
/// Controller to manage Balance Service Providers.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BalanceServiceProvidersController : ControllerBase
{

    private readonly IBalanceServiceProviderService _balanceServiceProviderService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor of Balance Service Providers Controller
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="balanceServiceProviderService"></param>
    public BalanceServiceProvidersController(IMapper mapper,
        IBalanceServiceProviderService balanceServiceProviderService)
    {
        _mapper = mapper;
        _balanceServiceProviderService = balanceServiceProviderService;
    }


    /// <summary>
    /// Get all register of Balance Service Provider
    /// </summary>
    /// <remarks>
    /// Get all register of Balance Service Provider
    /// </remarks>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetAllFromDatabase")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BalanceServiceProviderDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {

        try
        {

            var balanceServiceProviders = await _balanceServiceProviderService.GetAll();

            if (balanceServiceProviders == null || !balanceServiceProviders.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<BalanceServiceProviderDTO>>(balanceServiceProviders));

        }
        catch (System.Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all register of Balance Service Provider from web page "https://api.opendata.esett.com/#/Market%20Parties/get_EXP01_BalanceResponsibleParties"
    /// </summary>
    /// <remarks>
    /// Get all register of Balance Service Provider
    /// </remarks>
    /// <response code="200">Success - JSON Array of BRPs</response>
    /// <response code="204">If no data exists but the request is otherwise valid</response>
    /// <response code="400">If validation failed for any reason</response>
    /// <response code="500">Server Error</response>
    [HttpGet]
    [Route("GetAllFromWebPage")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BalanceServiceProviderDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllFromWeb()
    {

        try
        {

            return NoContent();

        }
        catch (System.Exception)
        {

            throw;
        }
    }


}

