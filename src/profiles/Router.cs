using Microsoft.AspNetCore.Mvc;

public static partial class Router
{
  public static RouteGroupBuilder MapProfilesRoutes(this RouteGroupBuilder routes)
  {
    var resourceGetAll = ([FromServices] ProfileRepository profileRepository) =>
    {
      var profiles = profileRepository.GetAll();

      var result = ProfileResourceModel.FromProfiles(profiles);

      return Results.Ok(result);
    };

    var resourceGetBySlug = async ([FromServices] ProfileRepository profileRepository, [FromRoute] string slug) =>
    {
      var profile = await profileRepository.GetBySlug(slug);

      if (profile is null)
      {
        return Results.NotFound();
      }

      var result = ProfileResourceModel.FromProfile(profile);

      return Results.Ok(result);
    };

    // var actionAdd = ([FromServices] ProfileRepository profileRepository, [FromBody] Profile profileInput) =>
    // {
    //   var profile = profileRepository.Add(profileInput);

    //   return Results.Created($"/profiles/{profile.Id}", profile);
    // };

    // var actionUpdate = ([FromServices] ProfileRepository profileRepository, [FromBody] Guid id, [FromBody] Profile profileInput) =>
    // {
    //   var profile = profileRepository.Update(id, profileInput);

    //   return Results.Created($"/profiles/{profile.Id}", profile);
    // };

    routes.MapGet("/", resourceGetAll);
    routes.MapGet("/{slug}", resourceGetBySlug);

    // routes.MapPost("/:add", actionAdd);
    // routes.MapPost("/:update", actionUpdate);

    return routes;
  }
}
