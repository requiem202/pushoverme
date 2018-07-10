# PushoverMe

Simple and testable Pushover library for .NET standard 2.0

## Example
```csharp
private const string ApiKey = "";
private const string UserKey = "";

[Fact]
public async Task Send_Get_Ok()
{
    var client = new PushoverClient(ApiKey);
    var message = client.NewMessage("Hello world");
    var response = await client.SendAsync(message, UserKey);

    Assert.Equal(response.StatusCode, HttpStatusCode.OK);
}
```