using System.Text;

while (true)
{
    Console.WriteLine("Matrix Shiii");

    Console.WriteLine("Enter 'e' to encrypt or 'd' to decrypt (no no work): ");
    string choice = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Enter the key: ");
    string key = Console.ReadLine();

    if (choice == "e")
    {
        Console.WriteLine("Enter the plaintext: ");
        string plaintext = Console.ReadLine();
        Console.WriteLine("\nCipher:\n" + Encrypt(plaintext, key));
    }
    else if (choice == "d")
    {
        Console.WriteLine("Enter the ciphertext: ");
        string ciphertext = Console.ReadLine();
        Console.WriteLine("\nPlaintext:\n" + Decrypt(ciphertext, key));
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
    Console.ReadKey();
    Console.Clear();
}

static string Encrypt(string plaintext, string key)
{
    StringBuilder result = new();
    key = key.ToUpper();
    int keyIndex = 0;

    foreach (char c in plaintext)
    {
        if (char.IsLetter(c))
        {
            bool isUpper = char.IsUpper(c);
            char offset = isUpper ? 'A' : 'a';

            int p = c - offset;
            int k = key[keyIndex % key.Length] - 'A';
            char encryptedChar = (char)((p + k) % 26 + offset);

            result.Append(encryptedChar);
            keyIndex++;
        }
        else
        {
            result.Append(c);
        }
    }

    return result.ToString();
}

static string Decrypt(string ciphertext, string key)
{
    StringBuilder result = new();
    key = key.ToUpper();
    int keyIndex = 0;

    foreach (char c in ciphertext)
    {
        if (char.IsLetter(c))
        {
            bool isUpper = char.IsUpper(c);
            char offset = isUpper ? 'A' : 'a';

            int p = c - offset;
            int k = key[keyIndex % key.Length] - 'A';
            char decryptedChar = (char)((p - k + 26) % 26 + offset);

            result.Append(decryptedChar);
            keyIndex++;
        }
        else
        {
            result.Append(c);
        }
    }

    return result.ToString();
}