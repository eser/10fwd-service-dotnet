using Microsoft.EntityFrameworkCore;

public class OrganizationRepository
{
  public DataContext DataContext { get; init; }

  public OrganizationRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<Organization> GetAll()
  {
    return this.DataContext.Organizations
      .Include(x => x.Memberships)
        .ThenInclude(x => x.User)
      .AsAsyncEnumerable();
  }

  public ValueTask<Organization?> GetById(Guid id)
  {
    return this.DataContext.Organizations.FindAsync(id);
  }

  public Task<Organization?> GetBySlug(string slug)
  {
    return this.DataContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
  }

  public async Task<Organization> Add(Organization organization)
  {
    var entity = await this.DataContext.Organizations.AddAsync(organization);
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }

  public async Task<Organization> Update(Guid id, Organization organization)
  {
    var entity = this.DataContext.Organizations.Update(organization with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }
}
