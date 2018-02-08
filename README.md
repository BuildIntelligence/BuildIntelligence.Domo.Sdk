
# .NET Standard - Domo API SDK (BIDomoDotnet)
[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](http://www.opensource.org/licenses/MIT)

Current Release: 0.1.0

### Notice - Python 3 Compatibility

* PyDomo is written for Python3, and is not compatible with Python2
* Execute scripts via 'python3', and updates via 'pip3'

### About

* BI Domo dotnet is an unofficial .NET Standard Library to streamline using the Domo API in a .NET project. The library provides a simple interface over the Domo API providing a basic set of functionality.
* [NuGet Package]().

### Features:
- DataSets API
	- Create, Update, Modify and Retrieve Domo DataSets
- Streams API
	- Create, Update, and Modify Domo Stream based Datasets.
- User Management API
	- CRUD
- Group Management API
	- CRUD
- Page API
	- CRUD

### Usage

```Csharp
IDomoConfig config = new DomoConfig(){};
IGotDomod domo = new DomoClient(config);


```