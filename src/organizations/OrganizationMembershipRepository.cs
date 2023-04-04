public class OrganizationMembershipRepository
{
  public DataContext DataContext { get; init; }

  public OrganizationMembershipRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<OrganizationMembership> GetAll()
  {
    return this.DataContext.OrganizationMemberships.AsAsyncEnumerable();
  }

  public ValueTask<OrganizationMembership?> GetById(Guid id)
  {
    return this.DataContext.OrganizationMemberships.FindAsync(id);
  }

  public async Task<OrganizationMembership> Add(OrganizationMembership organizationMembership)
  {
    var entity = await this.DataContext.OrganizationMemberships.AddAsync(organizationMembership);
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }

  public async Task<OrganizationMembership> Update(Guid id, OrganizationMembership organizationMembership)
  {
    var entity = this.DataContext.OrganizationMemberships.Update(organizationMembership with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }
}
