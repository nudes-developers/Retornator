# Retornator

Retornator is a c# lib for handling return of business logic data and it's possible errors, it is very coupled with ASPNET CORE but not required to do so, we recommend using MediatR as well.

## Installation

```
dotnet add package Nudes.Retornator.AspnetCore
```




## Usage

Inject necessary services on Startup.cs
```csharp
services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
{
    IgnoreNullValues = true,
    WriteIndented = true,
});

services.AddControllers().AddRetornator();
```
This will inject two OutputFormatters to your aspnet core configuration `RetornatorStreamOutputFormatter` that will handle StreamResult and `RetornatorOutputFormatter` that will handle serializable results

Create your result class inhering from `BaseResult<T>` where T is your result type this will make your Result have some interesting methods like `.Throw(Error)`
```csharp
class MyResult : BaseResult<MyResult>
{
    public string Id { get; set; }
    public string SomeOtherValue { get; set; }
}
```

In your bussines logic handler return that class or throw some errors with it
```csharp
public MyResult HandleMyBusinessLogic(SomeInputData data)
{
    //...
    //do some business logic here


    //something wrong if the request or with the logic per se? then throw some errors
    return MyResult.Throw(new SomeError());

    //need to add more information like field errors?
    return MyResult.Throw(new SomeError())
                    .AddFieldError("FielName", "The field name must have 30 or more characters.")
                    .AddFieldError("Id", "The field Id cannot be altered."));

    //everything according to plan? then return you result
    return new MyResult();
}
```

In your controller map the request and send to your business logic handler, we recomend to use MediatR to do that

```csharp
[HttpGet("someroute")]
public Task<MyResult> SomeAction(SomeInputData data)
{
    var result = businessLogicHandler.HandleMyBusinessLogic(data); 
    return result;
}
```

Retornator will handle your result and if there is any error on it we will serialize the error, if everything went well we will serialize your result class.

If you are using AspnetCore you will need a way to translate errors to the according HTTPSTATUS Code for that you can use our base errors and our `BasicHttpResponseManagerConfigurator` or create and inject your own
On startup add
```csharp
services.AddResponseManager<BasicHttpResponseManagerConfigurator>();
```
if you need help to create your own check our samples


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.