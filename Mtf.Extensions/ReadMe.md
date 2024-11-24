# WinForms Extension Methods

This project contains a collection of extension methods specifically designed for WinForms applications. These methods enhance the functionality of various types, making development more efficient and intuitive.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Available Extension Methods](#available-extension-methods)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Mortens4444/Mtf.Extensions.git
   ```
   
2. Add the project to your WinForms solution.

3. Reference the namespace in your files:
   ```csharp
   using Mtf.Extensions;
   ```

## Usage

Simply call the extension methods on the respective types as needed in your WinForms application. For example:

```csharp
// Using an extension method on a byte array
byte[] data = new byte[] { ... };
string hexString = data.ToHexString();
```

## Available Extension Methods

### ByteArray
- `ToHexString()` - Converts a byte array to a hexadecimal string.

### Byte
- `ToInt()` - Converts a byte to an integer.
- `IsEven()` - Checks if the byte is even.

### Char
- `ToString()` - Converts a char to a string.
- `IsVowel()` - Checks if the character is a vowel.

### Color
- `ToHex()` - Converts a Color to its hexadecimal string representation.
- `IsBright()` - Determines if the color is bright.

### ComboBox
- `SelectItemByValue(string value)` - Selects an item in the ComboBox by its value.
- `ClearItems()` - Clears all items in the ComboBox.

### DateTime
- `ToFormattedString(string format)` - Converts DateTime to a formatted string.
- `IsWeekend()` - Checks if the DateTime falls on a weekend.

### Double
- `RoundTo(int decimals)` - Rounds the double to a specified number of decimal places.
- `IsPositive()` - Checks if the double is positive.

### Exception
- `ToErrorMessage()` - Converts the exception to a user-friendly error message.
- `Log()` - Logs exception details to a specified log file.

### Int64
- `ToFormattedString()` - Converts Int64 to a string with thousand separators.

### Int
- `IsEven()` - Checks if the integer is even.
- `ToHex()` - Converts an integer to a hexadecimal string.

### ListViewItem
- `Select()` - Selects the ListViewItem.
- `Deselect()` - Deselects the ListViewItem.

### Object
- `IsNull()` - Checks if the object is null.

### ObjectArray
- `GetFirstNonNull()` - Returns the first non-null object from the array.

### Panel
- `ToggleVisibility()` - Toggles the visibility of the panel.

### Rectangle
- `Area()` - Calculates the area of the rectangle.

### UShort
- `IsEven()` - Checks if the ushort is even.

### String
- `IsNullOrEmpty()` - Checks if the string is null or empty.
- `ToTitleCase()` - Converts the string to title case.

## Contributing

Contributions are welcome! If you have suggestions for improvements or new methods, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.