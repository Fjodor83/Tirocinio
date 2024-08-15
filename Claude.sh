#!/bin/bash

# Crea la soluzione
dotnet new sln -n GessiWebApp

# Crea i progetti
dotnet new webapi -n GessiWebApp.API
dotnet new webapp -n GessiWebApp.Web
dotnet new classlib -n GessiWebApp.Shared

# Aggiungi i progetti alla soluzione
dotnet sln add GessiWebApp.API/GessiWebApp.API.csproj
dotnet sln add GessiWebApp.Web/GessiWebApp.Web.csproj
dotnet sln add GessiWebApp.Shared/GessiWebApp.Shared.csproj

# Crea la struttura delle cartelle e i file per GessiWebApp.API
mkdir -p GessiWebApp.API/Controllers GessiWebApp.API/Models GessiWebApp.API/Services GessiWebApp.API/Data

touch GessiWebApp.API/Controllers/WarehouseController.cs
touch GessiWebApp.API/Controllers/MaterialController.cs
touch GessiWebApp.API/Controllers/MovementController.cs
touch GessiWebApp.API/Controllers/MissionController.cs
touch GessiWebApp.API/Controllers/ClassificationController.cs

touch GessiWebApp.API/Models/Warehouse.cs
touch GessiWebApp.API/Models/Material.cs
touch GessiWebApp.API/Models/Movement.cs
touch GessiWebApp.API/Models/Mission.cs
touch GessiWebApp.API/Models/Classification.cs

touch GessiWebApp.API/Services/IWarehouseService.cs
touch GessiWebApp.API/Services/WarehouseService.cs
touch GessiWebApp.API/Services/IMaterialService.cs
touch GessiWebApp.API/Services/MaterialService.cs
touch GessiWebApp.API/Services/IMovementService.cs
touch GessiWebApp.API/Services/MovementService.cs
touch GessiWebApp.API/Services/IMissionService.cs
touch GessiWebApp.API/Services/MissionService.cs
touch GessiWebApp.API/Services/IClassificationService.cs
touch GessiWebApp.API/Services/ClassificationService.cs

touch GessiWebApp.API/Data/ApplicationDbContext.cs

# Crea la struttura delle cartelle e i file per GessiWebApp.Web
mkdir -p GessiWebApp.Web/Pages/Warehouses GessiWebApp.Web/Pages/Materials GessiWebApp.Web/Pages/Movements GessiWebApp.Web/Pages/Missions GessiWebApp.Web/Services GessiWebApp.Web/Helpers

touch GessiWebApp.Web/Pages/Warehouses/Index.cshtml
touch GessiWebApp.Web/Pages/Warehouses/Index.cshtml.cs
touch GessiWebApp.Web/Pages/Warehouses/Create.cshtml
touch GessiWebApp.Web/Pages/Warehouses/Create.cshtml.cs
touch GessiWebApp.Web/Pages/Warehouses/Edit.cshtml
touch GessiWebApp.Web/Pages/Warehouses/Edit.cshtml.cs
touch GessiWebApp.Web/Pages/Warehouses/Delete.cshtml
touch GessiWebApp.Web/Pages/Warehouses/Delete.cshtml.cs

touch GessiWebApp.Web/Pages/Materials/Index.cshtml
touch GessiWebApp.Web/Pages/Materials/Index.cshtml.cs
touch GessiWebApp.Web/Pages/Materials/Create.cshtml
touch GessiWebApp.Web/Pages/Materials/Create.cshtml.cs
touch GessiWebApp.Web/Pages/Materials/Edit.cshtml
touch GessiWebApp.Web/Pages/Materials/Edit.cshtml.cs
touch GessiWebApp.Web/Pages/Materials/Delete.cshtml
touch GessiWebApp.Web/Pages/Materials/Delete.cshtml.cs

touch GessiWebApp.Web/Pages/Movements/Index.cshtml
touch GessiWebApp.Web/Pages/Movements/Index.cshtml.cs
touch GessiWebApp.Web/Pages/Movements/Create.cshtml
touch GessiWebApp.Web/Pages/Movements/Create.cshtml.cs

touch GessiWebApp.Web/Pages/Missions/Index.cshtml
touch GessiWebApp.Web/Pages/Missions/Index.cshtml.cs
touch GessiWebApp.Web/Pages/Missions/Create.cshtml
touch GessiWebApp.Web/Pages/Missions/Create.cshtml.cs
touch GessiWebApp.Web/Pages/Missions/Edit.cshtml
touch GessiWebApp.Web/Pages/Missions/Edit.cshtml.cs

touch GessiWebApp.Web/Services/IWarehouseApiService.cs
touch GessiWebApp.Web/Services/WarehouseApiService.cs
touch GessiWebApp.Web/Services/IMaterialApiService.cs
touch GessiWebApp.Web/Services/MaterialApiService.cs
touch GessiWebApp.Web/Services/IMovementApiService.cs
touch GessiWebApp.Web/Services/MovementApiService.cs
touch GessiWebApp.Web/Services/IMissionApiService.cs
touch GessiWebApp.Web/Services/MissionApiService.cs

touch GessiWebApp.Web/Helpers/QRCodeGenerator.cs

# Crea la struttura delle cartelle e i file per GessiWebApp.Shared
mkdir -p GessiWebApp.Shared/DTOs

touch GessiWebApp.Shared/DTOs/WarehouseDto.cs
touch GessiWebApp.Shared/DTOs/MaterialDto.cs
touch GessiWebApp.Shared/DTOs/MovementDto.cs
touch GessiWebApp.Shared/DTOs/MissionDto.cs
touch GessiWebApp.Shared/DTOs/ClassificationDto.cs
touch GessiWebApp.Shared/DTOs/MaterialCreateDto.cs
touch GessiWebApp.Shared/DTOs/MaterialUpdateDto.cs
touch GessiWebApp.Shared/DTOs/MovementCreateDto.cs
touch GessiWebApp.Shared/DTOs/MissionCreateDto.cs
touch GessiWebApp.Shared/DTOs/MissionUpdateDto.cs

echo "Struttura del progetto creata con successo!"