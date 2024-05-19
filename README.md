# Advanced.Tools Library

`Advanced.Tools` is a C# library that provides utility methods and classes for various common tasks, including string validation and user notifications.

## Installation

To install the `Advanced.Tools` library, add the following to your project:

```bash
dotnet add package Advanced.Tools
```

---

## Usage

### `Validations` Class

#### `IsLength`

Checks if the length of the given string falls within the specified minimum and maximum length constraints.

```csharp
public static bool IsLength(this string text, int? minLength = null, int? maxLength = null)
```

##### Parameters

- `text` (string): The string to check the length of.
- `minLength` (int, optional): The optional minimum length constraint. If null, no minimum length constraint is applied.
- `maxLength` (int, optional): The optional maximum length constraint. If null, no maximum length constraint is applied.

##### Returns

- `bool`: True if the length of the string is greater than 0 and within the specified length constraints, otherwise false.

##### Example

```csharp
string example = "Hello";
example.IsLength(minLength: 3, maxLength: 10); // true
example.IsLength(minLength: 6); // false
example.IsLength(maxLength: 4); // false
example.IsLength(); // true
```

#### `IsCorrectEmail`

Validates the given string as an email address using the specified regular expression or a default pattern.

```csharp
public static bool IsCorrectEmail(this string text, Regex? regex = null)
```

##### Parameters

- `text` (string): The email address string to validate.
- `regex` (Regex, optional): The optional regular expression to use for validation. If null, the default pattern `EmailRegex` is used.

##### Returns

- `bool`: True if the email address matches the provided or default regular expression, otherwise false.

##### Example

```csharp
string email = "example@example.com";
bool isValid = email.IsCorrectEmail(); // Returns true if email matches default pattern

Regex customRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
bool isValidCustom = email.IsCorrectEmail(customRegex); // Returns true if email matches custom pattern
```

#### `IsCorrectPhone`

Validates the given string as a Russian phone number using the specified regular expression or a default pattern.

```csharp
public static bool IsCorrectPhone(this string text, Regex? regex = null)
```

##### Parameters

- `text` (string): The phone number string to validate.
- `regex` (Regex, optional): The optional regular expression to use for validation. If null, the default pattern `PhoneRegex` is used.

##### Returns

- `bool`: True if the phone number matches the provided or default regular expression, otherwise false.

##### Example

```csharp
string phoneNumber = "+7 123 456-78-90";
bool isValid = phoneNumber.IsCorrectPhone(); // Returns true if phone number matches default pattern

Regex customRegex = new Regex(@"^\+7\d{10}$");
bool isValidCustom = phoneNumber.IsCorrectPhone(customRegex); // Returns true if phone number matches custom pattern
```

#### `IsCorrectPassword`

Validates the given password string against a specified regular expression or a default pattern.

```csharp
public static bool IsCorrectPassword(this string text, Regex? regex = null)
```

##### Parameters

- `text` (string): The password string to validate.
- `regex` (Regex, optional): . The optional regular expression to use for validation. If null, the default pattern is used.

##### Returns

- `bool`: True if the password matches the provided or default regular expression, otherwise false.

##### Example

```csharp
string password = "Passw0rd";
bool isValidDefault = password.IsCorrectPassword(); // Returns true if password matches default pattern

Regex customRegex = new Regex(@"^[a-zA-Z0-9]{6,12}$");
bool isValidCustom = password.IsCorrectPassword(customRegex); // Returns true if password matches custom pattern
```

#### Regular Expressions

The library also includes default regular expression patterns for validating email addresses and Russian phone numbers.

```csharp
public static string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
public static string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
public static string PhoneRegex = @"^(\+7|8)?[\s-]?(\(?\d{3}\)?[\s-]?)?[\d\s-]{7,10}$";
```

---

### `Notify` Class

The `Notify` class provides methods for displaying different types of notifications to the user, such as errors, successes, information, and warnings.

#### Methods

##### `SetGlobalSnackbarPresenter`

Sets the global `SnackbarPresenter` to be used for displaying notifications.

```csharp
public static void SetGlobalSnackbarPresenter(SnackbarPresenter snackbarPresenter)
```

###### Parameters

- `snackbarPresenter` (SnackbarPresenter): The `SnackbarPresenter` instance.

##### `HasGlobalSnackbarPresenter`

Checks if a global `SnackbarPresenter` has been set.

```csharp
public static bool HasGlobalSnackbarPresenter()
```

###### Returns

- `bool`: True if a global `SnackbarPresenter` has been set, otherwise false.

##### `ShowNotification`

Displays a notification with the specified text, title, and type.

```csharp
public static void ShowNotification(string text, string title, NotificationType type)
```

###### Parameters

- `text` (string): The text content of the notification.
- `title` (string): The title of the notification.
- `type` (NotificationType): The type of the notification (Error, Success, Info, Warning).

###### Example

```csharp
Notify.ShowNotification("Operation completed successfully", "Success", Notify.NotificationType.Success);
```

##### `ShowError`

Displays an error notification with the specified text and title.

```csharp
public static void ShowError(string text, string title)
```

###### Parameters

- `text` (string): The text content of the error notification.
- `title` (string): The title of the error notification.

###### Example

```csharp
Notify.ShowError("An error occurred", "Error");
```

##### `ShowSuccess`

Displays a success notification with the specified text and title.

```csharp
public static void ShowSuccess(string text, string title)
```

###### Parameters

- `text` (string): The text content of the success notification.
- `title` (string): The title of the success notification.

###### Example

```csharp
Notify.ShowSuccess("Operation successful", "Success");
```

##### `ShowInfo`

Displays an info notification with the specified text and title.

```csharp
public static void ShowInfo(string text, string title)
```

###### Parameters

- `text` (string): The text content of the info notification.
- `title` (string): The title of the info notification.

###### Example

```csharp
Notify.ShowInfo("Here is some information", "Info");
```

##### `ShowWarning`

Displays a warning notification with the specified text and title.

```csharp
public static void ShowWarning(string text, string title)
```

###### Parameters

- `text` (string): The text content of the warning notification.
- `title` (string): The title of the warning notification.

###### Example

```csharp
Notify.ShowWarning("This is a warning", "Warning");
```

---

### `PasswordHelper` Class

#### `GenerateSalt`

Generates a cryptographically secure salt.

```csharp
public static byte[] GenerateSalt()
```

##### Returns

- `byte[]`: A byte array containing the generated salt.

##### Example

```csharp
byte[] salt = PasswordHelper.GenerateSalt();
```

#### `HashPassword`

Hashes the given password using the specified salt.

```csharp
public static string HashPassword(this string password, byte[] salt)
```

##### Parameters

- `text` (string): The string to hash.
- `salt` (string): The salt to use in the hashing process.

##### Returns

- `string`: A Base64 encoded string representing the hashed password.

##### Example

```csharp
string password = "securePassword";
byte[] salt = PasswordHelper.GenerateSalt();
string hashedPassword = password.HashPassword(salt);
```

#### `AuthenticateUser`

Authenticates a user by comparing the entered password with the stored password hash and salt.

```csharp
public static bool AuthenticateUser(string enteredPassword, string storedPasswordHash, byte[] storedSalt)
```

##### Parameters

- `enteredPassword` (string): The password entered by the user.
- `storedPasswordHash` (string): The stored hash of the user's password.
- `storedSalt` (byte[]): The salt used when the user's password was hashed.

##### Returns

- `bool`: True if the entered password matches the stored password hash, otherwise false.

##### Example

```csharp
string enteredPassword = "securePassword";
string storedPasswordHash = "hashedPasswordFromDatabase";
byte[] storedSalt = GetSaltFromDatabase(); // Retrieve the salt from the database
bool isAuthenticated = PasswordHelper.AuthenticateUser(enteredPassword, storedPasswordHash, storedSalt);
```