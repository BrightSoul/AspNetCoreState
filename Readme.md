# ASP.NET Core State persistence across request
This is a ASP.NET Core application for .NET 5.

This branch showcases the use of the **ISession** object to persist a value across requests.

> See the `cookie` branch on how to do the same with a cookie.

![state.gif](state.gif)

 * The session service is configured in the [Startup.cs](Startup.cs#L28) file, within the `ConfigureService` method;
 * The session middleware is also used in the [Startup.cs](Startup.cs#L58) file, within the `Configure` method;
 * Use the `ISession` object from the [HomeController.cs](Controllers/HomeController.cs#L18).

## Getting started
Download or clone this project, then open it with Visual Studio Code and hit `F5` to start debugging the app.