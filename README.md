# 10fwd-service-dotnet

# Secrets

This project uses the [Secret Manager tool](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=linux) to store secrets. The secrets are stored in a file called `secrets.json` in the local system. The file is not checked into source control. The file is created by running the following commands:

```bash
$ dotnet user-secrets init # only needs to be run once
$ dotnet user-secrets set ConnectionStrings:DataContext "User Id=postgres;Password=[PASSWORD];Server=[HOST];Port=5432;Database=postgres"
```
