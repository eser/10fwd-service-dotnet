public static partial class Router
{
  public static RouteGroupBuilder MapUsersRoutes(this RouteGroupBuilder routes)
  {
    routes.MapGet("/", (UserRepository userRepository) =>
    {
      var users = userRepository.GetAll();

      return Results.Ok(users);
    });

    routes.MapGet("/{username}", async (UserRepository userRepository, string username) =>
    {
      var user = await userRepository.GetByUsername(username);

      if (user is null)
      {
        return Results.NotFound();
      }

      return Results.Ok(user);
    });

    routes.MapPost("/:add", (UserRepository userRepository, User userInput) =>
    {
      var user = userRepository.Add(userInput);

      return Results.Created($"/users/{user.Id}", user);
    });

    return routes;
  }
}
