YamNet is an unofficial, opinionated, Yammer REST API .NET (async) wrapper based on the the CodePlex [ContractMeow](http://yammercontractmeow.codeplex.com/) project. The goal is to provide a ready-to-use client library available via NuGet.

## Breaking Changes
  * **0.5**
    * `MessageClient` return type updated to `MessageEnvelope` from `IQueryable<Message>`
    * `RelationshipClient` now accepts `Relation[]` as a parameter from `Dictionary<string, RelationshipType>`

## Prerequisites and Installation
YamNet is available as a .NET 3.5 and Portable Class Library (PCL) binaries, which makes it available for the following build targets:

  * .NET 3.5+
  * Silverlight 5+
  * Windows Phone 8+
  * Xamarin.iOS
  * Xamarin.Android

It is available from NuGet, either via the GUI or running the following command from the Package Manager console:

```
PM> Install-Package YamNet.Client
```

**Dependencies (.NET 3.5):**

  * AsyncBridge
  * Newtonsoft.Json
  * RestSharp
  * TaskParallelLibrary

**Dependencies (PCL):**

  * Microsoft.Bcl.Async
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

**Note:** For usage in ASP.Net applications, it is recommended to chain the method with `ConfigureAwait(false)` to prevent async deadlock. More information is available on the following StackOverflow article: [An async/await example that causes a deadlock](http://stackoverflow.com/a/15022170).

Most clients have support for various optional parameters, utilising C# 4.0 language feature (Visual Studio 2010 and up). The following is an example of retrieving a list of users whose name starts with "F", in descending order:

```C#
using (var yammerClient = new Client(token))
{
    var asyncResponse = await yammerClient.Users.Get(letter: "F", reverse: true);
    var usersWhoseNameStartsWithF = asyncResponse;
}
```

## Supported Requests
YamNet currently supports the following requests:

  * Groups
  * Invitations
  * Messages (partial)
  * Networks
  * Relationships
  * Search (partial)
  * Topics
  * Users (partial) 

The goal by v1.0 is to reach completeness, i.e. 1:1 mapping of Yammer REST API to the library.

## Undocumented Requests
YamNet provides some support for Yammer requests that are not documented on the official REST API, but are known to be used by the Yammer web application itself through inspection via tools such as IE or Chrome network monitor, FireBug, Fiddler, etc. These undocumented methods can be found in separate classes under `/ClientExtensions`.

Currently there are no additional setup required in order to use them. However, in the future they may be separated into a different assembly and NuGet package (e.g. YamNet.Client.Undocumented).

**Use it with caution. As these APIs may be subject to change without notice, and may break your application.**

## Contributors
Please refer to the following [page](/Contributors.md) for a complete list of all contributors.

## Contributing
Pull requests shall be made against `develop` branch, which will be reviewed for merging into the `master` branch.

## Copyright and License
  * Code and documentation copyright YamNet [contributors](/Contributors.md).
  * Code released under [BSD3 license](/License.txt).
  * Documentation released under [Creative Commons license](/LicenseDocs.txt).

## Credits
Big thanks to [jmjc95](http://www.codeplex.com/site/users/view/jmjc95) and [tuongla](http://www.codeplex.com/site/users/view/tuongla) for creating a thoughtful, open-source sample project, and using a fork-friendly Apache 2.0 license so others can reuse and adapt the original works.

Also thanks to [tejacques](https://github.com/tejacques) for [.Net 3.5 AsyncBridge](https://github.com/tejacques/AsyncBridge), and [OmerMor](https://github.com/OmerMor) for [TaskParallelLibrary](http://www.nuget.org/packages/TaskParallelLibrary/), for providing useful libraries making it easier to backport YamNet to .NET 3.5. 

## Other Yammer-related .Net Resources
 * [Windows 8 App - ContractMeow](http://yammercontractmeow.codeplex.com/)
 * [Windows Phone OAuth SDK+Demo](https://github.com/yammer/windows-phone-oauth-sdk-demo)

## Other Tools
 * [MarkdownPad Pro](markdownpad.com) to edit markdown text
 * [Violet UML Editor](http://alexdp.free.fr/violetumleditor/page.php) to generate UML diagrams