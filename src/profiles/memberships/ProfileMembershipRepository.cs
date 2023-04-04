public class ProfileMembershipRepository
{
  public DataContext DataContext { get; init; }

  public ProfileMembershipRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<ProfileMembership> GetAll()
  {
    return this.DataContext.ProfileMemberships.AsAsyncEnumerable();
  }

  public ValueTask<ProfileMembership?> GetById(Guid id)
  {
    return this.DataContext.ProfileMemberships.FindAsync(id);
  }

  public async Task<ProfileMembership> Add(ProfileMembership profileMembership)
  {
    var record = await this.DataContext.ProfileMemberships.AddAsync(profileMembership);
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }

  public async Task<ProfileMembership> Update(Guid id, ProfileMembership profileMembership)
  {
    var record = this.DataContext.ProfileMemberships.Update(profileMembership with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }
}
