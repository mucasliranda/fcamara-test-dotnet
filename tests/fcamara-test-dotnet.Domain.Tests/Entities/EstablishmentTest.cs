using fcamara_test_dotnet.Domain.Entities;
using fcamara_test_dotnet.Domain.Exceptions;

namespace fcamara_test_dotnet.Domain.Tests.Entities
{
    public class EstablishmentTest
    {
        [Fact]
        public void CanCreateEstablishment()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var establishment = new Establishment(name, cnpj, address, phone, motorcycleSpots, carSpots);

            Assert.NotNull(establishment);
            Assert.Equal(name, establishment.Name);
            Assert.Equal(cnpj, establishment.Cnpj);
            Assert.Equal(address, establishment.Address);
            Assert.Equal(phone, establishment.Phone);
            Assert.Equal(motorcycleSpots, establishment.MotorcycleSpots);
            Assert.Equal(carSpots, establishment.CarSpots);
        }

        [Fact]
        public void CannotCreateEstablishmentWithInvalidCnpj()
        {
            string name = "empresa teste";
            string invalidCnpj = "1234567890";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, invalidCnpj, address, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithEmptyName()
        {
            string emptyName = " ";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(emptyName, cnpj, address, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNullName()
        {
            string nullName = null;
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(nullName, cnpj, address, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithEmptyCnpj()
        {
            string name = "empresa teste";
            string emptyCnpj = " ";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, emptyCnpj, address, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNullCnpj()
        {
            string name = "empresa teste";
            string nullCnpj = null;
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, nullCnpj, address, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithEmptyAddress()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string emptyAddress = " ";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, emptyAddress, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNullAddress()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string nullAddress = null;
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, nullAddress, phone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithInvalidPhone()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string invalidPhone = "2799730765";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, address, invalidPhone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithEmptyPhone()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string emptyPhone = " ";
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, address, emptyPhone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNullPhone()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string nullPhone = null;
            int motorcycleSpots = 10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, address, nullPhone, motorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNegativeMotorcycleSpots()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int negativeMotorcycleSpots = -10;
            int carSpots = 20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, address, phone, negativeMotorcycleSpots, carSpots));
        }

        [Fact]
        public void CannotCreateEstablishmentWithNegativeCarSpots()
        {
            string name = "empresa teste";
            string cnpj = "12345678901234";
            string address = "Rua tal 123";
            string phone = "27997307658";
            int motorcycleSpots = 10;
            int negativeCarSpots = -20;

            var exception = Assert.Throws<ValidationException>(() => new Establishment(name, cnpj, address, phone, motorcycleSpots, negativeCarSpots));
        }
    }
}