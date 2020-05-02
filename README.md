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
