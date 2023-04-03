public static partial class Router
{
  public static RouteGroupBuilder MapOrganizationsRoutes(this RouteGroupBuilder routes)
  {
    routes.MapGet("/", (OrganizationRepository organizationRepository) =>
    {
      var organizations = organizationRepository.GetAll();

      return Results.Ok(organizations);
    });

    routes.MapGet("/{slug}", async (OrganizationRepository organizationRepository, string slug) =>
    {
      var organization = await organizationRepository.GetBySlug(slug);

      if (organization is null)
      {
        return Results.NotFound();
      }

      return Results.Ok(organization);
    });

    routes.MapPost("/:add", (OrganizationRepository organizationRepository, Organization organizationInput) =>
    {
      var organization = organizationRepository.Add(organizationInput);

      return Results.Created($"/orgs/{organization.Id}", organization);
    });

    routes.MapPost("/:update", (OrganizationRepository organizationRepository, Guid id, Organization organizationInput) =>
    {
      var organization = organizationRepository.Update(id, organizationInput);

      return Results.Created($"/orgs/{organization.Id}", organization);
    });

    routes.MapPost("/:follow", async (OrganizationRepository organizationRepository, UserRepository userRepository, OrganizationMembershipRepository organizationMembershipRepository, string slug, Guid userId) =>
    {
      var organization = await organizationRepository.GetBySlug(slug);

      if (organization is null)
      {
        return Results.NotFound();
      }

      var user = await userRepository.GetById(userId);

      if (user is null)
      {
        return Results.NotFound();
      }

      var organizationMembership = organizationMembershipRepository.Add(new OrganizationMembership
      {
        Id = Guid.NewGuid(),
        Organization = organization,
        User = user,
        Role = OrganizationMembershipRole.Follower,
      });

      return Results.Ok();
    });

    return routes;
  }
}
