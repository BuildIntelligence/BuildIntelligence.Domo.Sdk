# Getting Started

## General Overview

All operations are done through the `DomoClient`. Within the primary domo client are individual classes for each section of the Domo API:
```Csharp
Datasets
Groups
Pages
Streams
Users
```
Initializing the primary `DomoClient` will initialize all other classes within, allowing the user to start operations on any section of the Domo API immediately. 

## Authentication
Authentication is handeled within the individual classes using the IDomoConfig Interface. After initializing `DomoClient` with the IDomoConfig class, authentication will be handled automatically.

## DomoClient Setup
```Csharp
IDomoConfig config = new DomoConfig()
{
    ClientId = "{Your Domo Client App Id}",
    ClientSecret = "{Your Domo Client App Secret}"
};
IGotDomod domo = new DomoClient(config);
```

### Stream Client

```Csharp
IDomoConfig config = new DomoConfig(){};
IGotDomod domo = new DomoClient(config);
```