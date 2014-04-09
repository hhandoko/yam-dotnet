YamNet is an unofficial Yammer REST API .Net (async) wrapper based on the the CodePlex [ContractMeow](http://yammercontractmeow.codeplex.com/) project. The goal is to provide a ready-to-use client library available via NuGet.

## Prerequisites and Installation
YamNet is available as a .Net 3.5 and Portable Class Library (PCL) binaries, which makes it available for the following build targets:

  * .Net 3.5+
  * Silverlight 5+
  * Windows Phone 8+
  * Xamarin.iOS
  * Xamarin.Android

It is available from NuGet, either via the GUI or running the following command from the Package Manager console:

```
PM> Install-Package YamNet.Client
```

**Dependencies (.Net 3.5):**

  * AsyncBridge
  * Newtonsoft.Json
  * RestSharp
  * TaskParallelLibrary

**Dependencies (PCL):**

  * Microsoft.Bcl
  * Microsoft.Bcl.Async
  * Microsoft.Bcl.Build
  * Microsoft.Net.Http
  * Newtonsoft.Json

## Configuration
YamNet requires the OAuth access token to access the Yammer REST endpoints. You will need to:

  1. Register an application profile - [Yammer Developers Docs: Getting Started](https://developer.yammer.com/introduction/)
  2. Obtain a test access token - [Yammer Developer Docs: Authentication](https://developer.yammer.com/authentication/#a-testtoken)

## Usage
With the access token obtained, you can instantiate the YamNet client and obtain the current user info, for example, as follows:

```C#
using (var yammerClient = new Client(token))
{
    // Calling async method synchronously
    var currentUser = yammerClient.Users.Current().Result;

    // Calling async method
    var asyncResponse = await yammerClient.Users.Current();
    var currentUserAsync = asyncResponse;
}
```

**Note:** For usage in ASP.Net applications, it is recommended to chain the method with ```ConfigureAwait(false)``` to prevent async deadlock. More information is available on the following StackOverflow article: [An async/await example that causes a deadlock](http://stackoverflow.com/a/15022170).

Most clients have support for various optional parameters, utilising C# 4.0 language feature (Visual Studio 2010 and up). The following is an example of retrieving a list of users whose name starts with "F", in descending order:

```C#
using (var yammerClient = new Client(token))
{
    var asyncResponse = await yammerClient.Users.Get(letter: "F", reverse: true);
    var usersWhoseNameStartsWithF = asyncResponse;
}
```

## Supported Requests
YamNet currently supports the following requests: Messages (partial), Groups, Users (partial), Relationships (partial), and Networks. 

The goal by v1.0 is to reach completeness, i.e. 1:1 mapping of Yammer REST API to the library.

## Credits
Big thanks to [jmjc95](http://www.codeplex.com/site/users/view/jmjc95) and [tuongla](http://www.codeplex.com/site/users/view/tuongla) for creating a thoughtful, open-source sample project, and using a fork-friendly Apache 2.0 license so others can reuse and adapt the original works.

Also thanks to [tejacques](https://github.com/tejacques) for [.Net 3.5 AsyncBridge](https://github.com/tejacques/AsyncBridge), and [OmerMor](https://github.com/OmerMor) for [TaskParallelLibrary](http://www.nuget.org/packages/TaskParallelLibrary/), for providing useful libraries making it easier to backport YamNet to .Net 3.5. 

## Other Yammer-related .Net Resources
 * [Windows 8 App - ContractMeow](http://yammercontractmeow.codeplex.com/)
 * [Windows Phone OAuth SDK+Demo](https://github.com/yammer/windows-phone-oauth-sdk-demo)