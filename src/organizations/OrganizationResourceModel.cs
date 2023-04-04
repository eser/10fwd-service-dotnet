public record OrganizationResourceModel
{
  public required Guid Id { get; set; }
  public required OrganizationType Type { get; set; }
  public required string Slug { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }

  public static OrganizationResourceModel FromOrganization(Organization organization)
  {
    return new OrganizationResourceModel()
    {
      Id = organization.Id,
      Type = organization.Type,
      Slug = organization.Slug,
      Name = organization.Name,
      Description = organization.Description,
    };
  }

  public static IAsyncEnumerable<OrganizationResourceModel> FromOrganizations(IAsyncEnumerable<Organization> organizations)
  {
    return organizations.Select(organization => FromOrganization(organization));
  }
}
