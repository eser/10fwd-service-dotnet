using Microsoft.EntityFrameworkCore;

public class PageRepository
{
  public DataContext DataContext { get; init; }

  public PageRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<Page> GetAll()
  {
    return this.DataContext.Pages.AsAsyncEnumerable();
  }

  public ValueTask<Page?> GetById(Guid id)
  {
    return this.DataContext.Pages.FindAsync(id);
  }

  public Task<Page?> GetBySlug(string slug)
  {
    return this.DataContext.Pages.FirstOrDefaultAsync(x => x.Slug == slug);
  }

  public async Task<Page> Add(Page page)
  {
    var entity = await this.DataContext.Pages.AddAsync(page);
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }

  public async Task<Page> Update(Guid id, Page page)
  {
    var entity = this.DataContext.Pages.Update(page with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return entity.Entity;
  }
}
