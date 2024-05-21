using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Validators;
using System.Collections.ObjectModel;

namespace Domain.Tests.EntitiesAbstractions
{
    public class ContactTests
    {
        private static ContactValidator _contactValidator = new ContactValidator();

        [Fact]
        public void ContactShouldNotCreateWithNullName()
        {
            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                null,
                "Abreu",
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });

            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Name' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ContactShouldNotCreateWithEmptyStringName()
        {
            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "",
                "Abreu",
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });

            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Name' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ContactShouldNotCreateNameWithMoreThanOneFiftyCharacters()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non commodo ipsum. Nullam rutrum maximus mattis. Etiam sapien ex, hendrerit ac nibhasdt.",
                "Abreu",
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Name' Needs to Have It's Lenght Equal Or Lower Than 150 Characters", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithNullSurname()
        {
            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                null,
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });

            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Surname' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ContactShouldNotCreateWithEmptyStringSurname()
        {
            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "",
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });

            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Surname' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ContactShouldNotCreateSurnameWithMoreThanOneFiftyCharacters()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non commodo ipsum. Nullam rutrum maximus mattis. Etiam sapien ex, hendrerit ac nibhasdt.",
                "emailgames27@gmail.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Surname' Needs to Have It's Lenght Equal Or Lower Than 150 Characters", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithNullCPF()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "emailgames27@gmail.com",
                null,
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'CPF' Needs to Be Filed", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithEmptyStringCPF()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "emailgames27@gmail.com",
                "",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'CPF' Needs to Be Filed", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithCPFLenghDifferentFromEleven()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "emailgames27@gmail.com",
                "123456789013453464",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'CPF' Is Invalid", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithInvalidCPF()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "emailgames27@gmail.com",
                "14735553736",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'CPF' Is Invalid", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithNullEmail()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                null,
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Email' Needs to Be Filed", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithEmptyStringEmail()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Email' Needs to Be Filed", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithEmailWithLessThanEightharacters()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "l@g.com",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Email' Needs to Have It's Lenght Equal Or Higher Than 8 Characters", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithEmailWithMoreThanOneFiftyCharacters()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non commodo ipsum. Nullam rutrum maximus mattis. Etiam sapien ex, hendrerit ac nibhasdt.",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Email' Needs to Have It's Lenght Equal Or Lower Than 150 Characters", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithInvalidEmail()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "leandro.com.br",
                "41067818081",
                guid,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'Email' Is Invalid", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void ContactShouldNotCreateWithEmptyUserId()
        {

            var guid = Guid.NewGuid();
            var contact = new ContactInput(
                "Leandro",
                "Abreu",
                "emailgames27@gmail.com",
                "41067818081",
                Guid.Empty,
                new Collection<PhoneNumberInput>() { new(guid, "27", "999327274") });


            var result = _contactValidator.Validate(contact);

            Assert.Equal("Field 'UserId' Needs to Be Filed", result.Errors[0].ErrorMessage);

        }


    }
}
