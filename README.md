### ASP.NET sample API

### Requirements:
- MySQL 8.0.25
- .NET SDK 6.0.201
- Visual Studio Code
- Git

### Steps to run the API:
1. Download and install [.NET SDK 6.0.201](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Download, run the installer and configure [MySQL 8.0.25](https://downloads.mysql.com/archives/installer/)
3. Clone this repository and access it
4. In the repository folder, run the following commands:

```shell
dotnet --version            # Checking if the SDK version is 6.0.201

dotnet restore              # Restore the dependencies

dotnet tool install -g ef   # Install the Entity Framework Core CLI tool

dotnet ef database update   # Execute the migrations

dotnet build                # Compiles the program

dotnet watch run            # Runs the program and launches an API tester
```

### Important commands and their flags
- `dotnet-aspnet-codegenerator controller`: Generates a controller

|Flag|Description|
|--|--|
|`-name`| Controller name |
|`-api`| Specifies that will be an API with no views |
|`-dc <dataContext>`| DataContext that will be used |
|`-m <model>`| Model used to generate the controller |
|`-outDir <directory>`| Directory the controller will be generated |