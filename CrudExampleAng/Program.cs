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

#region CORS
builder.Services.AddCors(options =>
{
    // To avoid URL conflicts
    options.AddPolicy("NewPolicity", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

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

// Employee List

app.MapGet("/employee/list", async (
    IEmployeeService _employeeService,
    IMapper _mapper
    ) => {
        var EmployeeList = await _employeeService.GetList();
        var EmployeeListDTO = _mapper.Map<List<EmployeeDTO>>(EmployeeList);

        if (EmployeeListDTO.Count > 0)
            return Results.Ok(EmployeeListDTO);
        else
            return Results.NotFound();
});

// Save entered employees

app.MapPost("/employee/save", async(
    EmployeeDTO model,
    IEmployeeService _employeeService,
    IMapper _mapper
    ) => { 
        var _employee = _mapper.Map<Employee>(model);
        var _createdEmployee = await _employeeService.Add(_employee);

        if(_createdEmployee.IdPerson != 0)
            return Results.Ok(_mapper.Map<EmployeeDTO>(_createdEmployee));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
});


// Update entered employees
app.MapPut("/employee/update/{idPerson}", async (
    int idPerson,
    EmployeeDTO model,
    IEmployeeService _employeeService,
    IMapper _mapper
    ) => { 

        var _located= await _employeeService.Get(idPerson);

        if (_located is null)
            return Results.NotFound();

        var _employee = _mapper.Map<Employee>(model);

        _located.FullName = _employee.FullName;
        _located.IdOffice = _employee.IdOffice;
        _located.Salary = _employee.Salary;
        _located.ContractDate = _employee.ContractDate;

        var response = await _employeeService.Update(_located);
        
        if (response)
            return Results.Ok(_mapper.Map<EmployeeDTO>(_located));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);

    });


// Delete entered employees
app.MapDelete("/employee/delete{idPerson}", async (
    int idPerson,
    IEmployeeService _employeeService
    ) => {

        var _located = await _employeeService.Get(idPerson);

        if (_located is null)
            return Results.NotFound();

        var response = await _employeeService.Delete(_located);

        if (response)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);

    });


#endregion

// Adding NewPolicity
app.UseCors("NewPolicity");

app.Run();
