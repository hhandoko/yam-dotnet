## Version 0.1.1
 * Updates to User client:
   * Split User DTO to User and UserBasicInfo to support 'include_followed_users' parameter.
   * Split DELETE to SuspendById and DeleteById to closely reflect REST API.
 * Other changes:
   * Split ConsoleTest project for each client (e.g. User, Messages, Group, etc.).

## Version 0.1.0 - 2013/08/15
  * Initial release. Provides limited functionality to User client.