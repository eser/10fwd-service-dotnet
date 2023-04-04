using Microsoft.AspNetCore.Mvc;

public static partial class Router
{
  public static RouteGroupBuilder MapUsersRoutes(this RouteGroupBuilder routes)
  {
    var resourceGetAll = ([FromServices] UserRepository userRepository) =>
    {
      var users = userRepository.GetAll();

      var result = UserResourceModel.FromUsers(users);

      return Results.Ok(result);
    };

    var resourceGetByUsername = async ([FromServices] UserRepository userRepository, [FromRoute] string username) =>
    {
      var user = await userRepository.GetByUsername(username);

      if (user is null)
      {
        return Results.NotFound();
      }

      var result = UserResourceModel.FromUser(user);

      return Results.Ok(result);
    };

    var actionAdd = ([FromServices] UserRepository userRepository, [FromBody] UserAddActionRequestModel requestModel) =>
    {
      var user = new User()
      {
        Id = Guid.NewGuid(),
        Username = requestModel.Username,
        Email = requestModel.Email,
        Password = requestModel.Password,
        Fullname = requestModel.Fullname,
        Bio = requestModel.Bio ?? "",
        ProfilePictureUri = requestModel.ProfilePictureUri ?? "",
        WebSiteUri = requestModel.WebSiteUri ?? "",
        GitHubHandle = requestModel.GitHubHandle ?? "",
        TwitterHandle = requestModel.TwitterHandle ?? "",
      };

      var createdUser = userRepository.Add(user);

      var result = UserResourceModel.FromUser(user);

      return Results.Created($"/users/{result.Id}", result);
    };

    routes.MapGet("/", resourceGetAll)
      .Produces<UserResourceModel[]>();

    routes.MapGet("/{username}", resourceGetByUsername)
      .Produces<UserResourceModel>();

    routes.MapPost("/:add", actionAdd)
      .Accepts<UserAddActionRequestModel>(false, "application/json");

    return routes;
  }
}
