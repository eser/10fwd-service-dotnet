public record UserAddActionRequestModel
{
  public required string Username { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public required string Fullname { get; set; }
  public string? Bio { get; set; }
  public string? ProfilePictureUri { get; set; }
  public string? WebSiteUri { get; set; }
  public string? GitHubHandle { get; set; }
  public string? TwitterHandle { get; set; }
}
