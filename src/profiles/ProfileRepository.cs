using Microsoft.EntityFrameworkCore;

public class ProfileRepository
{
  public DataContext DataContext { get; init; }

  public ProfileRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<Profile> GetAll()
  {
    return this.DataContext.Profiles.AsAsyncEnumerable();
    // return this.DataContext.Profiles
    //   .Include(x => x.Memberships)
    //     .ThenInclude(x => x.User)
    //   .AsAsyncEnumerable();
  }

  public ValueTask<Profile?> GetById(Guid id)
  {
    return this.DataContext.Profiles.FindAsync(id);
  }

  public Task<Profile?> GetBySlug(string slug)
  {
    return this.DataContext.Profiles.FirstOrDefaultAsync(x => x.Slug == slug);
  }

  public async Task<Profile> Add(Profile profile)
  {
    var record = await this.DataContext.Profiles.AddAsync(profile);
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }

  public async Task<Profile> Update(Guid id, Profile profile)
  {
    var record = this.DataContext.Profiles.Update(profile with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }
}
