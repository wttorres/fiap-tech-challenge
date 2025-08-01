using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechChallenge.GameStore.Application;
using TechChallenge.GameStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); 
});

builder.Services.AddControllers(); 
builder.Services.AddInfrastructure(builder.Configuration); 
builder.Services.AddApplication(builder.Configuration); 

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();

    // Agrupar endpoints por nome de controller (sem quebrar por doc)
    c.TagActionsBy(api =>
    {
        var groupName = api.GroupName;
        return !string.IsNullOrEmpty(groupName) 
            ? new[] { groupName } 
            : [api.ActionDescriptor.RouteValues["controller"]];
    });

    c.DocInclusionPredicate((_, _) => true);
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 
app.Run();
