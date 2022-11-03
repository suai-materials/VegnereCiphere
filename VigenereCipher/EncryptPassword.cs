using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace VigenereCipher;

public class EncryptPassword
{
    public List<char> alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToList();
    private string _password;

    public EncryptPassword(string password)
    {
        _password = password;
    }

    private char EncryptCh(char ch, int offset)
    {
        var ind = alphabet.IndexOf(Char.ToUpper(ch));
        if (ind + offset > alphabet.Count - 1)
            return Char.IsUpper(ch)
                ? alphabet[offset - (alphabet.Count - ind )]
                : Char.ToLower(alphabet[offset - (alphabet.Count - ind)]);

        return Char.IsUpper(ch) ? alphabet[ind + offset] : Char.ToLower(alphabet[ind + offset]);
    }

    private char DecodeCh(char ch, int offset)
    {
        var ind = alphabet.IndexOf(Char.ToUpper(ch));
        if (ind - offset < 0)
            return Char.IsUpper(ch)
                ? alphabet[^(offset - ind)]
                : Char.ToLower(alphabet[^(offset - ind)]);

        return Char.IsUpper(ch) ? alphabet[ind - offset] : Char.ToLower(alphabet[ind - offset]);
    }

    public string Encrypt(string key)
    {
        string newString = "";
        key = key.ToUpper();
        for (int i = 0; i < _password.Length; i++)
        {
            if (!alphabet.Contains(char.ToUpper(_password[i])))
            {
                newString += char.ToString(_password[i]);
                continue;
            }

            newString += char.ToString(EncryptCh(_password[i], alphabet.IndexOf(key[i % key.Length]) + 1));
        }

        return newString;
    }

    public string Decode(string key)
    {
        string newString = "";
        key = key.ToUpper();
        for (int i = 0; i < _password.Length; i++)
        {
            if (!alphabet.Contains(char.ToUpper(_password[i])))
            {
                newString += char.ToString(_password[i]);
                continue;
            }

            newString += char.ToString(DecodeCh(_password[i], alphabet.IndexOf(key[i % key.Length]) + 1));
        }

        return newString;
    }
}