using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGeoApplication.Data;

namespace MyGeoApplication.Controllers;

[Route("api/cities")]
public class CitiesController
{
    [HttpGet("{cityId:guid}")]
    public async Task<CityInfo> GetCityAsync([FromRoute] Guid cityId, [FromServices] MyGeoDbContext context,
        CancellationToken token)
    {
        var city = await context.Cities.Where(c => c.ExternalId == cityId)
            .Select(a => new CityInfo
            {
                ExternalId = a.ExternalId,
                Center = a.Center,
                Name = a.Name
            }).FirstOrDefaultAsync(token);
        if (city is null) throw new Exception("City was not found");
        return city;
    }
}