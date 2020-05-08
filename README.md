# GuardStatements

Removing boilerplate code when enforcing invariants.

## Usage

Download the latest version:

![Nuget](https://img.shields.io/nuget/v/guardstatements?logo=nuget)

Include the ```GuardStatements``` namespace and simply do something like this:

```csharp
// will throw when someParameter is null.
Guard.AgainstNull(someParameter);

// will throw when someString is empty.
Guard.AgainstEmpty(someString);

// will throw when someValue is greater than zero.
Guard.Against(() => someValue > 0);
```

## 3.0 Breaks Stuff

The latest version introduces a lot of breaking changes. The old version 2.2 will be retained under the old package name [SimonWendel.GuardStatements][old-package].

[old-package]: https://www.nuget.org/packages/SimonWendel.GuardStatements

## Builds

[![Master Branch Build Status](https://dev.azure.com/simonwendel-public/builds/_apis/build/status/simonwendel.guard-statements?branchName=master)](https://dev.azure.com/simonwendel-public/builds/_build/latest?definitionId=7&branchName=master)

Built by [Azure Pipelines](https://dev.azure.com/simonwendel-public/builds/_build?definitionId=7&_a=summary).
