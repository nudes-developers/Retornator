using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nudes.Retornator.AspnetCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Swagger.Extensions;
using System.Reflection;

var builder = WebApplication
            .CreateBuilder(args);

#region DependencyInjection
builder.Services.AddMediatR(Assembly.GetEntryAssembly());


// register an erro translator, with the default builder all pre configured errors will be translated
builder.Services
    .AddErrorTranslator(ErrorHttpTranslatorBuilder.Default
    .TranslationFor<MyNotFoundError>(e => System.Net.HttpStatusCode.NotFound));

// alternatively you can specify your translations
// builder.Services
//    .AddErrorTranslator(new ErrorHttpTranslatorBuilder()
//    .TranslationFor<Error>(e => System.Net.HttpStatusCode.BadRequest)
//    .TranslationFor<MyNotFoundError>(e => System.Net.HttpStatusCode.NotFound));


// Add controllers and configure retornator engine
builder.Services
    .AddControllers()
    .AddRetornator();

// swagger for tests
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "1.0",
        Description = "sample retornator api",
        Title = "retornator api"
    });

    setup.AddRetornatorFilters();
});

#endregion DI

var app = builder.Build();

#region Pipeline

app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

#endregion


await app.RunAsync();