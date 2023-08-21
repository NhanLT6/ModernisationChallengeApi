# Back end project for Modernisation Challenge

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
