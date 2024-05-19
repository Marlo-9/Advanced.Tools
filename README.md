# Advanced.Tools Library

`Advanced.Tools` is a C# library is an assistant for working with user input in the WPF application. There is support for the WPF-UI library

## Installation

To install the `Advanced.Tools` library, add the following to your project:

```bash
dotnet add package Advanced.Tools
```

## Usage

### Methods

#### `IsLength`

Checks if the length of the given string falls within the specified minimum and maximum length constraints.

##### Example

```csharp
string example = "Hello";
bool isValid = example.IsLength(minLength: 3, maxLength: 10); // Returns true
bool isTooShort = example.IsLength(minLength: 6); // Returns false
bool isTooLong = example.IsLength(maxLength: 4); // Returns false
bool isValidWithoutConstraints = example.IsLength(); // Returns true
```

#### `Hash`

Computes the SHA-512 hash of the given string and returns it as a Base64-encoded string.

##### Example

```csharp
string example = "HelloWorld";
string hashedValue = example.Hash();
// hashedValue will contain the Base64-encoded SHA-512 hash of "HelloWorld"
```

#### `IsCorrectPassword`

Validates the given password string against a specified regular expression or a default pattern.

##### Example

```csharp
string password = "Passw0rd";
bool isValidDefault = password.IsCorrectPassword(); // Returns true if password matches default pattern

Regex customRegex = new Regex(@"^[a-zA-Z0-9]{6,12}$");
bool isValidCustom = password.IsCorrectPassword(customRegex); // Returns true if password matches custom pattern
```