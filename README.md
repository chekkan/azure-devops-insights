# azure-devops-insights

## Build solution
```cmd
$ dotnet build
```

## Run console app
```cmd
$ dotnet run --project src/Chekkan.AzureDevOpsInsights
```

### Display latest build result
```cmd
$ dotnet run --project src/Chekkan.AzureDevOpsInsights -- \
  --organization contoso --project unicorn --test-run-id 1
```