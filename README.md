
# .NET Standard 1.3 - Domo API SDK (BuildIntelligence.Domo.Sdk)
[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](http://www.opensource.org/licenses/MIT)

Current Release: 0.1.0

### About

* The BI Domo SDK is a .NET Standard 1.3 Library to streamline using the Domo API in a .NET project. The library provides a simple interface over the Domo API providing a basic set of functionality.
* [NuGet Package](https://www.nuget.org/packages/BuildIntelligence.Domo.Sdk/).

## What's with the interface name for the DomoClient?
It's a reference to the "You just got Domo'd!" Domo invitation email, and a funny story about how that email broke an entire Domo instance for several hours.
There was an email dataset in a Domo instance that eventually tied into some key dataflows. One morning the email dataset started having issues which started causing failures in other dataflows. For hours, a new engineer to the team was troubleshooting with no success and only seeing error messages and debug info reading "You Just Got Domod". Eventually he reached out for help and others recognized the phrase. Turns out there was a special character in the "You Just got Domo'd" email that was the cause of the problem. Once that was identified it was quickly resolved and a new dataset was pushed in via the API to get the dataflows functioning again.

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