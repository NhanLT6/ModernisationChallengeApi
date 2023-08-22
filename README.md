# Modernisation Challenge

Rewrite Modernisation Challenge back end with net core 6

## How to run

Update database using this command

```powershell
dotnet ef database update `
    --project ModernisationChallengeApi\ModernisationChallengeApi.csproj `
    --startup-project ModernisationChallengeApi\ModernisationChallengeApi.csproj `
    --context ModernisationChallengeApi.Data.ModernisationChallengeContext `
    --configuration Debug `
    20230821053014_Initial
```

## Features

- Built with net core 6, SQL server and EF core 6
- Use DTOs to communicate with client, DTOs validation supported by [FluentValidation](https://fluentvalidation.net/)
- Auto type mapping supported by [AutoMapper](https://automapper.org/)
- Global exception filter available
