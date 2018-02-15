# Getting Started

## General Overview

```Csharp
IDomoConfig config = new DomoConfig()
{
    ClientId = "{Your Domo Client App Id}",
    ClientSecret = "{}"
};
IGotDomod domo = new DomoClient(config);
```

## Stream Client

```Csharp
IDomoConfig config = new DomoConfig(){};
IGotDomod domo = new DomoClient(config);
```