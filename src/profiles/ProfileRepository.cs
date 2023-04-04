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
    var entity = await this.DataContext.Profiles.AddAsync(profile);
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }

  public async Task<Profile> Update(Guid id, Profile profile)
  {
    var entity = this.DataContext.Profiles.Update(profile with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }
}
