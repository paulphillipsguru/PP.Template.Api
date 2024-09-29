# Clean Architecture Template (API) - WIP

A complete starter project to create a API project based on Clean Architecture.

> [!NOTE]
>
> This solution is based on a single domain called "Example" and just to provide enough to validate solution.

> [!TIP]
>
> You can install the package via dotnet:
>
> dotnet new install PP.Template.Api::1.0.0

Tech Stack:

.NET 9

.NET ASPIRE 

Entity Framework V9

FluentMigrator

MediatR

Podman Desktop

	1. SQL Server (Database)
	1. Keycloak (Security / Auth)
	1. MailHog (Dummy Email Server)

## Setup

Providing Podman is up and running, you should only to perform a single step and you should have everything you need.

To setup, navigate to the infra and type in the following command:

**docker-compose up -d**

# Folder structure:

## infrastructure (infra folder)

* Setup local services via Podman (docker compose)

## Projects (src folder):

* PP.Common.Shared
  * Custom Exceptions 
* PP.Template.Api
  * API Project
* PP.Template.AppHost (default project)
  * .NET Aspire Host
* PP.Template.ServiceDefaults
  * .NET Aspire Defaults
* PP.Template.Application
* PP.Template.Domain
* PP.Template.infrastructure 
  * Contains Database Migrations
  * Other infrastructure concerns
* PP.Template.Messages
  * MediatR -**CQRS**
* PP.Tools.Database
  * Database Management





