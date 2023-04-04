public record ProfileResourceModel
{
  public required Guid Id { get; set; }
  public required ProfileOwner Owner { get; set; }
  public required Guid OwnerId { get; set; }
  public required string Slug { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }

  public static ProfileResourceModel FromProfile(Profile profile)
  {
    return new ProfileResourceModel()
    {
      Id = profile.Id,
      Owner = profile.Owner,
      OwnerId = profile.OwnerId,
      Slug = profile.Slug,
      Title = profile.Title,
      Description = profile.Description,
    };
  }

  public static IAsyncEnumerable<ProfileResourceModel> FromProfiles(IAsyncEnumerable<Profile> profiles)
  {
    return profiles.Select(profile => FromProfile(profile));
  }
}
