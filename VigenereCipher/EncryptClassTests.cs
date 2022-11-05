using NUnit.Framework;

namespace VigenereCipher;

[TestFixture, Description("Тестирования класса EncryptPassword, который шифрует русский текст шифром Веженера"),
 Author("Pankov Vasya")]
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
            Assert.AreEqual(new EncryptPassword("Вася123").Encrypt("Б"), "Гбта123");
        }

        [Test, Description("Обычная проверка шифрования")]
        public void EncryptBase()
        {
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("А"), "Вася");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("Б"), "Гбта");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("БА"), "Гатя");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("АААА"), "Вася");
            Assert.AreEqual(new EncryptPassword("Вася").Encrypt("АБВГ"), "Вбув");
        }
        [Test, Description("Шифрование с латиницей")]
        public void EncryptWithLatin()
        {
            Assert.AreEqual(new EncryptPassword("ВасяAbc").Encrypt("А"), "ВасяAbc");
            Assert.AreEqual(new EncryptPassword("ВасяAbc").Encrypt("Б"), "ГбтаAbc");
        }

        [Test]
        public void EncryptExtra()
        {
            Assert.AreEqual(new EncryptPassword("ПРОГРАММИСТЫ УЕХАЛИ В КОВОРКИНГ").Encrypt("АГДЕВСЕАГДЕВСЕ АГДЕВСЕ АГДЕВСЕ АГД"), "ПУТЗТССМЛХЧЭ ЕЙХГПН Д ЬУВСФПКЯЗ");
            Assert.AreEqual(new EncryptPassword("ИГРА В ДОМИНО УВЛЕКАТЕЛЬНА").Encrypt("ТЕСТ"), "ЫЗВТ Ф ИАЯЫТА ЁФРЦЭТЧЦЮОТС");
            
        }
    }

    [TestFixture, Description("Проверка декодирования")]
    public class DecodeTests
    {
        [Test, Description("Обычная проверка")]
        public void DecodeBase()
        {
            Assert.AreEqual(new EncryptPassword("Вася").Decode("А"), "Вася");
            Assert.AreEqual(new EncryptPassword("Гбта").Decode("Б"), "Вася");
            Assert.AreEqual(new EncryptPassword("Гатя").Decode("БА"), "Вася");
            Assert.AreEqual(new EncryptPassword("Вася").Decode("АААА"), "Вася");
            Assert.AreEqual(new EncryptPassword("Вбув").Decode("АБВГ"), "Вася");
        }

        [Test, Description("Декодирование с числами")]
        public void DecodeWithNums()
        {
            Assert.AreEqual(new EncryptPassword("123").Decode("А"), "123");
            Assert.AreEqual(new EncryptPassword("Гбта123").Decode("Б"), "Вася123");
        }
        [Test, Description("Декодирование с латиницей")]
        public void EncryptWithLatin()
        {
            Assert.AreEqual(new EncryptPassword("ГбтаAbc").Decode("Б"), "ВасяAbc");
            Assert.AreEqual(new EncryptPassword("ДвубAbc").Decode("В"), "ВасяAbc");
        }

        [Test]
        public void EncryptExtra()
        {
            Assert.AreEqual(new EncryptPassword("ПУТЗТССМЛХЧЭ ЕЙХГПН Д ЬУВСФПКЯЗ").Decode("АГДЕВСЕАГДЕВСЕ АГДЕВСЕ АГДЕВСЕ АГД"), "ПРОГРАММИСТЫ УЕХАЛИ В КОВОРКИНГ");
            Assert.AreEqual(new EncryptPassword("ЫЗВТ Ф ИАЯЫТА ЁФРЦЭТЧЦЮОТС").Decode("ТЕСТ"), "ИГРА В ДОМИНО УВЛЕКАТЕЛЬНА");
        }
    }
}