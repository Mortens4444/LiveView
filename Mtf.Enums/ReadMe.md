# Enums

This project contains a collection of enums. These enums enhance the functionality of various types, making development more efficient and intuitive.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Enums](#enums)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Mortens4444/Mtf.Enums.git
   ```
   
2. Add the project to your solution.

3. Reference the namespace in your files:
   ```csharp
   using Mtf.Enums;
   ```

## Usage

Simply call the extension methods on the respective types as needed in your WinForms application. For example:

```csharp
// Using an extension method on a byte array
byte[] data = new byte[] { ... };
string hexString = data.ToHexString();
```

## Enums

### ByteArray
- `ToHexString()` - Converts a byte array to a hexadecimal string.

### Byte
- `ToInt()` - Converts a byte to an integer.
- `IsEven()` - Checks if the byte is even.

## Contributing

Contributions are welcome! If you have suggestions for improvements or new methods, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.