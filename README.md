# Colu-dotnet
C# Implementation of the Colu SDK

A client object has been created to make calls to Colus server.  Full documenation can be found at http://documentation.colu.co

## Methods supported
1. BurnAsset
2. GetPrivateSeed
3. GetAddress
4. GetAddressInfo
5. GetAssetData
6. GetAssetHolders
7. GetAssetMetaData
8. IssueAsset
9. SendAsset

## Examples
You can view example using via the "unit tests".  However, here are some examples
```
[TestMethod]
public async Task Should_Get_Private_Seed()
{
    using (Colu.Client client = new Colu.Client("localhost")
    {
        var response = await client.GetPrivateSeed();
        Assert.IsNotNull(response);
    }
}
```

## Support
Donations can be made to 33ERRzqgfGts1iJWz44fSnAH5FkREr1qAL
