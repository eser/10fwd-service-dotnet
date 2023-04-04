using Microsoft.AspNetCore.Mvc;

public static partial class Router
{
  public static RouteGroupBuilder MapOrganizationsRoutes(this RouteGroupBuilder routes)
  {
    var resourceGetAll = ([FromServices] OrganizationRepository organizationRepository) =>
    {
      var organizations = organizationRepository.GetAll();

      var result = OrganizationResourceModel.FromOrganizations(organizations);

      return Results.Ok(result);
    };

    var resourceGetBySlug = async ([FromServices] OrganizationRepository organizationRepository, [FromRoute] string slug) =>
    {
      var organization = await organizationRepository.GetBySlug(slug);

      if (organization is null)
      {
        return Results.NotFound();
      }

      var result = OrganizationResourceModel.FromOrganization(organization);

      return Results.Ok(result);
    };

    // var actionAdd = ([FromServices] OrganizationRepository organizationRepository, [FromBody] Organization organizationInput) =>
    // {
    //   var organization = organizationRepository.Add(organizationInput);

    //   return Results.Created($"/orgs/{organization.Id}", organization);
    // };

    // var actionUpdate = ([FromServices] OrganizationRepository organizationRepository, [FromBody] Guid id, [FromBody] Organization organizationInput) =>
    // {
    //   var organization = organizationRepository.Update(id, organizationInput);

    //   return Results.Created($"/orgs/{organization.Id}", organization);
    // };

    // var actionFollow = async ([FromServices] OrganizationRepository organizationRepository, [FromServices] UserRepository userRepository, [FromServices] OrganizationMembershipRepository organizationMembershipRepository, [FromBody] string slug, [FromBody] Guid userId) =>
    // {
    //   var organization = await organizationRepository.GetBySlug(slug);

    //   if (organization is null)
    //   {
    //     return Results.NotFound();
    //   }

    //   var user = await userRepository.GetById(userId);

    //   if (user is null)
    //   {
    //     return Results.NotFound();
    //   }

    //   var organizationMembership = organizationMembershipRepository.Add(new OrganizationMembership
    //   {
    //     Id = Guid.NewGuid(),
    //     Organization = organization,
    //     User = user,
    //     Role = OrganizationMembershipRole.Follower,
    //   });

    //   return Results.Ok();
    // };

    routes.MapGet("/", resourceGetAll);
    routes.MapGet("/{slug}", resourceGetBySlug);

    // routes.MapPost("/:add", actionAdd);
    // routes.MapPost("/:update", actionUpdate);
    // routes.MapPost("/:follow", actionFollow);

    return routes;
  }
}
