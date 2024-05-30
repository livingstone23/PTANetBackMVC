using ACD.Domain.Models;



namespace ACD.Api.Dto;



/// <summary>
/// Represents the data transfer object for the BalanceServiceProvider entity.
/// </summary>
public class BalanceServiceProviderDTO : Entity
{

    /// <summary>
    /// Property that represents the unique identifier for the business Id.
    /// </summary>
    /// <value></value>
    public required string businessId { get; set; }

    /// <summary>
    /// Property that represents the code assigned to the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string bspCode { get; set; }

    /// <summary>
    /// Property that represents the name of the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string bspName { get; set; }

    /// <summary>
    /// Property that represents the coding scheme used by the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string codingScheme { get; set; }

    /// <summary>
    /// Property that represents the country associated with the BalanceServiceProvider.
    /// </summary>
    /// <value></value>
    public required string country { get; set; }

}
