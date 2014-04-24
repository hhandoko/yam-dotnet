## Version 0.4 - In Progress
  * Added Topic and Search client.

## Version 0.3 - 2014/04/09
  * Created YamNet.Client35 project to use in .Net 3.5 solutions. Using RestSharp, TaskParallelLibrary, and AsyncBridge to keep similar method signatures.
  * Updated all client's return void methods to return 'Task' instead so it can be awaited, instead of fire-and-forget. 

## Version 0.2 - 2014/04/04
  * Added Message, Relationship, and Network client. Updated ConsoleTest project to provide some usage example.
  * Updated all client methods to async.

## Version 0.1 - 2013/08/15
  * Initial release. Provides limited functionality to User client.