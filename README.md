
# .NET Standard 1.3 - Domo API SDK (BuildIntelligence.Domo.Sdk)
[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](http://www.opensource.org/licenses/MIT)

Current Release: 0.1.0

### About

* The BI Domo SDK is a .NET Standard 1.3 Library to streamline using the Domo API in a .NET project. The library provides a simple interface over the Domo API providing a basic set of functionality.
* [NuGet Package]().

## What's with the interface name for the DomoClient?
It's a reference to the "You just got Domo'd!" Domo invitation email, and a funny story about how that email broke an entire Domo instance for several hours.

### Features:
- DataSets API
	- Create, Update, Modify, Retrieve and Delete Domo DataSets
- Streams API
	- Create, Update, and Modify Domo Stream based Datasets.
- User Management API
- Group Management API
- Page API

### Limitations
- PDP Operations have not yet been implemented in this package
- StreamClient does not yet support gzip
- No CSV Serialization/Deserialization is done in this package. It takes in serialized strings and returns serialized strings.
- Activity Log API is not yet supported.

### Usage

[Getting Started](./GettingStarted.md)