using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nudes.Retornator.AspnetCore;
using Nudes.Retornator.Sample.Errors;

var builder = WebApplication
            .CreateBuilder(args);

#region DependencyInjection
///There are 4 ways to register the response manager and his errors:

///Creating one, registering errors and passing it to AddResponseManager:
//ResponseManager responseManager = new ResponseManager();
//responseManager.RegisterError<NotFoundError>(error => System.Net.HttpStatusCode.NotFound);
//services.AddResponseManager(responseManager);

///Invoking AddResponseManager (which returns a new already registered ResponseManager) and then registering errors:
builder.Services.AddResponseManager()
  .RegisterError<NotFoundError>(error => System.Net.HttpStatusCode.NotFound);


///Creating one and passing it along with a type who inherits from ResponseManagerConfigurator and knows how to register errors:
//ResponseManager responseManager = new ResponseManager();
//services.AddResponseManager<SampleResponseManagerConfigurator>(responseManager);


///Invoking AddResponseManager passing a type who inherits from ResponseManagerConfigurator and knows how to register errors (thats what we'll use):

//services.AddResponseManager<SampleResponseManagerConfigurator>();

// Add controllers and configure retornator
builder.Services
    .AddControllers() 
    .AddRetornator();

#endregion DI

var app = builder.Build();

#region Pipeline

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

#endregion