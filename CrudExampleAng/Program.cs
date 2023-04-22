using CrudExampleAng.Models;
using Microsoft.EntityFrameworkCore;
using CrudExampleAng.Services.Contract;
using CrudExampleAng.Services.Implementations;
using AutoMapper;
using CrudExampleAng.DTOs;
using CrudExampleAng.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Databases
// Calling the database
builder.Services.AddDbContext<DbCrudAngContext>(options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectSQL")); // Calling the Database from app,json
});
#endregion

#region Classes with interfaces
//Relating implementations classes with interfaces
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region API REST REQUESTS 

//Office List

app.MapGet("/office/list", async (
    IOfficeService _officeService,
    IMapper _mapper
    ) =>
{
    var OfficeList = await _officeService.GetList();
    var OfficeListDTO = _mapper.Map<List<OfficeDTO>>(OfficeList);
    
    if(OfficeListDTO.Count > 0)
        return Results.Ok(OfficeListDTO);
    else
        return Results.NotFound();

});
#endregion

app.Run();
