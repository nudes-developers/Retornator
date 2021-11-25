# Retornator

**Retornator** is a C# library for handling the return of business logic data and its possible errors. It is very coupled with ASP.NET Core but not required to do so, we recommend using [MediatR](https://github.com/jbogard/MediatR) as well.

## Installation

```properties
dotnet add package Nudes.Retornator.AspnetCore
```

## Usage

Inject necessary services on `Startup.cs`:

```csharp
services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
{
    IgnoreNullValues = true,
    WriteIndented = true,
});

services.AddControllers().AddRetornator();
```

This will inject two OutputFormatters to your ASP.NET Core configuration:

- `RetornatorStreamOutputFormatter` will handle `StreamResult`;
- `RetornatorOutputFormatter` will handle serializable results.

Create your result class inhering from `BaseResult<T>` where `T` is your result type. New methods will be available in your result class, like `.Throw(Error)`.

```csharp
class MyResult : BaseResult<MyResult>
{
    public string Id { get; set; }
    public string SomeOtherValue { get; set; }
}
```

In your business logic handler, return an instance of that class or throw some errors using `.Throw(Error)`:

```csharp
public MyResult HandleMyBusinessLogic(SomeInputData data)
{
    // ...
    // do some business logic here


    // something wrong with the request or with the logic per se? then throw some errors
    return MyResult.Throw(new SomeError());

    // or do you need to add more information like field errors?
    return MyResult.Throw(new SomeError())
                    .AddFieldError("FieldName", "The field name must have at least 30 characters.")
                    .AddFieldError("Id", "The field Id cannot be altered."));

    // everything according to the plan? then return your result
    return new MyResult();
}
```

In your controller, map the request and send to your business logic handler, we recommend using [MediatR](https://github.com/jbogard/MediatR) to do that:

```csharp
[HttpGet("someroute")]
public async Task<MyResult> SomeAction(SomeInputData data)
{
    var result = await businessLogicHandler.HandleMyBusinessLogic(data);
    return result;
}
```

**Retornator** will handle your result and if there is any error on it the error will be serialized; if everything goes well it will serialize your result class.

If you are using ASP.NET Core you will need a way to translate errors to the according HTTP Status Code. For that you can use Retornator base errors and the `BasicHttpResponseManagerConfigurator` or create and inject your own. To use it, on `Startup.cs` add:

```csharp
services.AddResponseManager<BasicHttpResponseManagerConfigurator>();
```

If you need help to create your own, check our samples.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
