public static partial class Router
{
  public static RouteGroupBuilder MapPagesRoutes(this RouteGroupBuilder routes)
  {
    routes.MapGet("/", (PageRepository pageRepository) =>
    {
      var pages = pageRepository.GetAll();

      return Results.Ok(pages);
    });

    routes.MapGet("/{slug}", async (PageRepository pageRepository, string slug) =>
    {
      var page = await pageRepository.GetBySlug(slug);

      if (page is null)
      {
        return Results.NotFound();
      }

      return Results.Ok(page);
    });

    routes.MapPost("/:add", (PageRepository pageRepository, Page pageInput) =>
    {
      var page = pageRepository.Add(pageInput);

      return Results.Created($"/orgs/{page.Id}", page);
    });

    routes.MapPost("/:update", (PageRepository pageRepository, Guid id, Page pageInput) =>
    {
      var page = pageRepository.Update(id, pageInput);

      return Results.Created($"/orgs/{page.Id}", page);
    });

    return routes;
  }
}
