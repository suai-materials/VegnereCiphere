using NUnit.Framework;

namespace VigenereCipher;

public class EncryptClassTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestFixture, Description("Проверка шифрования")]
    public class EncryptTests
    {
        [Test, Description("Проверка шифрования, при наличии там чисел")]
        public void EncryptWithNums()
        {
            Assert.AreEqual(new EncryptPassword("123").Encrypt("А"), "123");
            Assert.AreEqual(new EncryptPassword("Вася123").Encrypt("А"), "Гбта123");
        }
        [Test, Description("Проверка шифрования")]
        public void EncryptBase()
        {
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("А"), "Гбта");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("Б"), "Двуб");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("БА"), "Дбуа");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("АААА"), "Гбта");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("АБВГ"), "Гвфг");
        }
    }

    [TestFixture, Description("Проверка декодирования")]
    public class DecodeTests
    {
        [Test]
        public void DecodeBase()
        {
            Assert.AreEqual(new EncryptPassword("Гбта").Decode("А"), "Вася");
            Assert.AreEqual(new EncryptPassword("Двуб").Decode("Б"), "Вася");
            Assert.AreEqual(new EncryptPassword("Дбуа").Decode("БА"), "Вася");
            Assert.AreEqual(new EncryptPassword("Гбта").Decode("АААА"), "Вася");
            Assert.AreEqual(new EncryptPassword("Гвфг").Decode("АБВГ"), "Вася");
        }
    }
}