using Microsoft.EntityFrameworkCore;

public class UserRepository
{
  public DataContext DataContext { get; init; }

  public UserRepository(DataContext dataContext)
  {
    this.DataContext = dataContext;
  }

  public IAsyncEnumerable<User> GetAll()
  {
    return this.DataContext.Users.AsAsyncEnumerable();
  }

  public ValueTask<User?> GetById(Guid id)
  {
    return this.DataContext.Users.FindAsync(id);
  }

  public Task<User?> GetByUsername(string username)
  {
    return this.DataContext.Users.FirstOrDefaultAsync(x => x.Username == username);
  }

  public async Task<User> Add(User user)
  {
    var record = await this.DataContext.Users.AddAsync(user);
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }

  public async Task<User> Update(Guid id, User user)
  {
    var record = this.DataContext.Users.Update(user with { Id = id });
    await this.DataContext.SaveChangesAsync();

    return record.Entity;
  }
}
