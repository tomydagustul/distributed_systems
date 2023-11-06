using DevicesAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

////serializare json
//builder.Services.ConfigureHttpJsonOptions(options => {
//    options.SerializerOptions.WriteIndented = true;
//    options.SerializerOptions.IncludeFields = true;
//});

//adds the database context to the dependency injection (DI) container and enables displaying database-related exceptions
builder.Services.AddDbContext<DevicesDb>(opt => opt.UseInMemoryDatabase("Devices"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

var devices = app.MapGroup("/devices");

//Gets
devices.MapGet("/", async (DevicesDb db) =>
    await db.Devices.ToListAsync());

devices.MapGet("/{id}", async (int id, DevicesDb db) =>
    await db.Devices.FindAsync(id)
    is Devices device
    ? Results.Ok(device)
    : Results.NotFound());

//Posts
devices.MapPost("/", async (Devices device, DevicesDb db) =>
{
    db.Devices.Add(device);
    await db.SaveChangesAsync();

    return Results.Created($"/devices/{device.id}", device);
});

//Put - Update
devices.MapPut("/{id}", async (int id, Devices input_device, DevicesDb db) =>
{
    var device = await db.Devices.FindAsync(id);

    if (device is null) return Results.NotFound();

    if (!String.IsNullOrEmpty(input_device.description))
        device.description = input_device.description;

    if (!String.IsNullOrEmpty(input_device.adress))
        device.adress = input_device.adress;

    if (!String.IsNullOrEmpty(input_device.maximum_hourly_energy_consumption))
        device.maximum_hourly_energy_consumption = input_device.maximum_hourly_energy_consumption;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

//Delete
devices.MapDelete("/{id}", async (int id, DevicesDb db) =>
{
    if(await db.Devices.FindAsync(id) is Devices device)
    {
        db.Devices.Remove(device);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
