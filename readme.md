![adminlte for blazor](docs/img/blazor-adminlte.svg)

[![nuget](https://img.shields.io/nuget/v/Blazorized.AdminLte)](https://www.nuget.org/packages/Blazorized.AdminLte/)
[![.NET Core](https://github.com/sjefvanleeuwen/blazor-adminlte/workflows/.NET%20Core/badge.svg)](https://github.com/sjefvanleeuwen/blazor-adminlte/actions)

# What is it?

ADMINLTE for Blazor is a collection of reusable components, with which you can easily develop digital services as a designer or developer. Think of buttons, form elements and page templates. This project adapts ADMINLTE 3 so the components can be used from dotnet core Blazor.

For a quick impression visite the **demo site** at: https://blazorize-adminlte.morstead.nl/

# Status

The project is in early stage currently, but expanded almost daily. Feel free to follow the project and receive updates as they arrive.
**Note** that components and their naming conventions might change until a major version is released.

We also provide various integrations in a seperate project, to help you started with more complex web applications Here:

https://github.com/sjefvanleeuwen/blazorized-adminlte-plugins

# Installation

## Nuget

Start a new Blazor APP and simply install the nuget package.

```
Install-Package Blazorized.AdminLte
```
or visit https://www.nuget.org/packages/Blazorized.AdminLte/ for more installation options.

If you want to include the current supported ADMINLTE 3.0.5 static css / js / icons content etc.:

```
Install-Package Blazorized.AdminLte.Content -Version 3.0.5
```
or visit https://www.nuget.org/packages/Blazorized.AdminLte.Content/ for more installation options.

**!NOTE** this does not include profile and other specific images from the sample site. You will need to manually add them to your wwwroot.
If you want these you will need to get them from the shared sample site's wwwroot

The extra sample content is located here:
https://github.com/sjefvanleeuwen/blazor-adminlte/tree/master/src/Blazor.AdminLte.Site.Shared/wwwroot

## Getting Started


Depending on running WASM or Server, change your 
[`index.html`](./src/Blazor.AdminLte.Wasm/wwwroot/index.html) or
[`_Host.cshtml`](./src/Blazor.AdminLte.Site/Pages/_Host.cshtml).
Contents from the Blazor Component Library are served from : `_content/Blazor.AdminLte`

The site shared components [`MainLayout.razor`](./src/Blazor.AdminLte.Site.Shared/MainLayout.razor) includes markup that shows how to setup your starter page in Blazor.

With such markup you can render something like this:

![screenshot](docs/img/adminlte-screenshot.png)
