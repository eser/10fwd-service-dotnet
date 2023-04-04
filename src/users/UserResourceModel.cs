public record UserResourceModel
{
  public required Guid Id { get; set; }
  public required string Username { get; set; }
  public required string Email { get; set; }
  // public required string Password { get; set; }
  public required string Fullname { get; set; }
  public required string Bio { get; set; }
  public required string ProfilePictureUri { get; set; }
  public required string WebSiteUri { get; set; }
  public required string GitHubHandle { get; set; }
  public required string TwitterHandle { get; set; }

  public static UserResourceModel FromUser(User user)
  {
    return new UserResourceModel()
    {
      Id = user.Id,
      Username = user.Username,
      Email = user.Email,
      Fullname = user.Fullname,
      Bio = user.Bio,
      ProfilePictureUri = user.ProfilePictureUri,
      WebSiteUri = user.WebSiteUri,
      GitHubHandle = user.GitHubHandle,
      TwitterHandle = user.TwitterHandle,
    };
  }

  public static IAsyncEnumerable<UserResourceModel> FromUsers(IAsyncEnumerable<User> users)
  {
    return users.Select(user => FromUser(user));
  }
}
