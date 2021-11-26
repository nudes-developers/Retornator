# Retornator

**Retornator** is a C# library for handling the return of business logic data and its possible errors. It is very coupled with ASP.NET Core but not required to do so, we recommend using [MediatR](https://github.com/jbogard/MediatR) as well.

## Installation

```properties
dotnet add package Nudes.Retornator.AspnetCore
```

## Usage

Inject necessary services on `Program.cs`:

```csharp
builder.Services.AddControllers().AddRetornator();
```

This will inject an `RetornatorResultOutputFormatter` to your ASP.Net list of outputformatters

Create your service returning `ResultOf<T>` or Result where `T` is your DTO type. From your service you will be able to return an `Error` or your Result (type of `T`) and implicit conversions will take place to `ResultOf<T>` or `Result`

```csharp
class MyResult
{
    public string Id { get; set; }
    public string SomeOtherValue { get; set; }
}
```

In your business logic handler, return an instance of that class or throw some errors using `.Throw(Error)`:

```csharp
public ResultOf<MyResult> HandleMyBusinessLogic(SomeInputData data)
{
    // ...
    // do some business logic here


    // something wrong with the request or with the logic per se? then throw some errors
    return new SomeError();

    // or do you need to add more information like field errors?
    return new SomeError()
            .AddFieldError("FieldName", "The field name must have at least 30 characters.")
            .AddFieldError("Id", "The field Id cannot be altered."));

    // everything according to the plan? then return your result
    return new MyResult();
}
```

In your controller, map the request and send to your business logic handler, we recommend using [MediatR](https://github.com/jbogard/MediatR) to do that (check the samples):

```csharp
[HttpGet("someroute")]
public async Task<ResultOf<MyResult>> SomeAction(SomeInputData data)
{
    var result = await businessLogicHandler.HandleMyBusinessLogic(data);
    return result;
}
```

**Retornator** will handle your result and if there is any error on it the error will be serialized; if everything goes well it will serialize your result class.

If you are using ASP.NET Core you will need a way to translate errors to the according HTTP Status Code. For that you can use Retornator base errors and the `ErrorHttpTranslatorBuilder` or create and inject your own. To use it, on `Program.cs` add:

```csharp
builder.Services
    .AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);
```

If you need help to create your own, check our samples.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
