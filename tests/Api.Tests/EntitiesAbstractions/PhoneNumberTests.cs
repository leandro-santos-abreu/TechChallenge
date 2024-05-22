using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Validators;
using FluentValidation;
using System.Collections.ObjectModel;

namespace Domain.Tests.EntitiesAbstractions
{
    public class PhoneNumberTests
    {
        private static PhoneNumberValidator _phoneNumberValidator = new();

        [Fact]
        public void PhoneNumberShouldNotCreateWithEmptyContactId()
        {
            var phoneNumber = new PhoneNumberInput(
                Guid.Empty,
                "27",
                "passwords");

            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'ContactId' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void PhoneNumberShouldNotCreateWithNullAreaCode()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                null,
                "999654674");

            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'AreaCode' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void PhoneNumberShouldNotCreateWithEmptyStringAreaCode()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                "",
                "999654674");

            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'AreaCode' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }


        [Fact]
        public void PhoneNumberShouldNotCreateWithAreaCodeLenghDifferentOfTwo()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                "345",
                "999654674");
            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'AreaCode' Needs to Have It's Lenght Equals To 2 Characters", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void PhoneNumberShouldNotCreateWithNullCellPhone()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                "27",
                null);

            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'CellPhone' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void PhoneNumberShouldNotCreateWithEmptyStringCellPhone()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                "21",
                "");

            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'CellPhone' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }


        [Fact]
        public void PhoneNumberShouldNotCreateWithCellPhoneLenghDifferentOfNine()
        {
            var guid = Guid.NewGuid();
            var phoneNumber = new PhoneNumberInput(
                guid,
                "55",
                "99965467415332255");
            var result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'CellPhone' Needs to Have It's Lenght Equals To 9 Characters", result.Errors[0].ErrorMessage);

            phoneNumber.CellPhone = "1234";
            result = _phoneNumberValidator.Validate(phoneNumber);

            Assert.Equal("Field 'CellPhone' Needs to Have It's Lenght Equals To 9 Characters", result.Errors[0].ErrorMessage);

        }


    }
}
