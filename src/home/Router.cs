public static partial class Router
{
  public static RouteGroupBuilder MapHomeRoutes(this RouteGroupBuilder routes)
  {
    var resourceGetAll = () => Results.Ok();

    routes.MapGet("/", resourceGetAll);

    return routes;
  }
}
