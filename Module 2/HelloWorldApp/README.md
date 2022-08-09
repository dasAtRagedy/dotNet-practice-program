# Hello, World!

A simple program, with a goal to get the hang of the .NET technologies used.

## Status

This program will no longer be modified, with the exception of bugs and requested features.

## Developing the program

Please make sure you have the following prerequisites:
- A desktop platform with the [.NET 6.0 SDK](https://dotnet.microsoft.com/download) installed.
- When working with the codebase, I recommend using an IDE with intelligent code completion and syntax highlighting, such as the latest version of [Visual Studio](https://visualstudio.microsoft.com/vs/), [JetBrains Rider](https://www.jetbrains.com/rider/) or [Visual Studio Code](https://code.visualstudio.com/).

### Downloading the source code

Clone the repository:

```shell
git clone https://github.com/dasAtRagedy/dotNet-practice-program
cd "dotNet-practice-program\Module 2\HelloWorldApp\src"
```

To update the source code to the latest commit, run the following command inside the `dotNet-practice-program` directory:

```shell
git pull
```

### Building

You should use the provided Build/Run functionality of your IDE to get things going. Visual Studio / Rider users should load the project via the main `.sln` file.

You can also build and run *this project* from the command-line with a single command:

```shell
dotnet run --project "dotNet-practice-program\Module 2\HelloWorldApp\src"
```

### Code analysis

Before committing your code, please run a code formatter. This can be achieved by running `dotnet format` in the command line, or using the `Format code` command in your IDE.

JetBrains ReSharper InspectCode is also used for wider rule sets. You can run it from PowerShell with .\InspectCode.ps1. Alternatively, you can install ReSharper or use Rider to get inline support in your IDE of choice.

## License

This project is not licensed.
