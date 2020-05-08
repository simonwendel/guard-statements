# GuardStatements

Removing boilerplate code when enforcing invariants.

## Usage

Download the latest version:

[![Nuget][nuget-badge]][new-package]

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

## Builds

[![Azure DevOps builds (CI)][ci-build-badge]][build]
[![Azure DevOps builds (Release)][release-build-badge]][build]


[nuget-badge]: https://img.shields.io/nuget/v/guardstatements?logo=nuget
[ci-build-badge]: https://img.shields.io/azure-devops/build/simonwendel-public/4a29a0d1-45be-4c7a-b1ce-2a38e834f6fb/7/master?label=CI&logo=azuredevops&stage=CI
[release-build-badge]: https://img.shields.io/azure-devops/build/simonwendel-public/4a29a0d1-45be-4c7a-b1ce-2a38e834f6fb/7/master?label=Release&logo=azuredevops&stage=Release
[build]: https://dev.azure.com/simonwendel-public/builds/_build?definitionId=7&_a=summary
[new-package]: https://www.nuget.org/packages/GuardStatements/
[old-package]: https://www.nuget.org/packages/SimonWendel.GuardStatements/