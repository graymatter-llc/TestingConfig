# TestingConfig

## Highlights
- ConfigurationBuilder is being used to assemble Config options
- Leveraging default appconfig.json pattern from ASP.NET
- Using an environment variable to signify the Type of Run
- Type of Run used to select different configuration files
- Enabled dotNET user-secrect mechanism, as an override in ConfigurationBuilder

## Intended next steps
- The Main Program to utilize "using" to allocate the DB connection
- Apply "using" mechanism with the delegate object allocation

## Secrets
Use the following to set the Secret value for the default ConnectionStrings

```
dotnet user-secrets set "ConnectionStrings:default" "FROM Secrets"
```
The user-secrets init has already been performed for this project.

The Secrets value overrides the "default" in the appsettings.json