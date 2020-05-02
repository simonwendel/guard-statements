# GuardStatements

Removing boilerplate code when enforcing invariants.

## Usage

Include the ```GuardStatements``` namespace and simply do something like this:

```csharp
// will throw when someParameter is null.
Guard.AgainstNull(someParameter);

// will throw when someString is empty.
Guard.AgainstEmpty(someString);

// will throw when someValue is greater than zero.
Guard.Against(() => someValue > 0);
```

## Next Version Breaks Stuff

Currently the ```master``` branch is taking GuardStatements from version 2.2 to 3.0. This will introduce a lot of breaking changes. The new version will be released under a new package name. The old version will be retained in the old package [SimonWendel.GuardStatements][old-package].

[old-package]: https://www.nuget.org/packages/SimonWendel.GuardStatements
