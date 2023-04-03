public static partial class Router
{
  public static RouteGroupBuilder MapHomeRoutes(this RouteGroupBuilder routes)
  {
    routes.MapGet("/", () => Results.Ok());

    return routes;
  }
}
