using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Validators;

namespace Domain.Tests.EntitiesAbstractions
{
    public class UserTests
    {
        private static UserValidator _userValidator = new();

        [Fact]
        public void UserShouldNotCreateWithNullName()
        {
            var user = new UserInput(
                null,
                "passwords");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'UserName' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreateWithEmptyStringName()
        {
            var user = new UserInput(
                "",
                "passwords");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'UserName' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreateNameWithLessThanEightCharacters()
        {
            var user = new UserInput(
                "lsa",
                "passwords");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'UserName' Needs to Have It's Lenght Equal Or Higher Than 8 Characters", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreateNameWithMoreThanOneFiftyCharacters()
        {

            var user = new UserInput(
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non commodo ipsum. Nullam rutrum maximus mattis. Etiam sapien ex, hendrerit ac nibhasdt.",
            "passwords");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'UserName' Needs to Have It's Lenght Equal Or Lower Than 150 Characters", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void UserShouldNotCreateWithNullPassword()
        {
            var user = new UserInput(
                "leandro_abreu",
                null);

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'Password' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreateWithEmptyStringPassword()
        {
            var user = new UserInput(
                "leandro_abreu",
                "");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'Password' Needs to Be Filed", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreatePasswordWithLessThanEightCharacters()
        {
            var user = new UserInput(
                "leandro_abreu",
                "pswd");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'Password' Needs to Have It's Lenght Equal Or Higher Than 8 Characters", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void UserShouldNotCreatePasswordWithMoreThanOneFiftyCharacters()
        {
            var user = new UserInput(
            "leandro_abreu",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non commodo ipsum. Nullam rutrum maximus mattis. Etiam sapien ex, hendrerit ac nibhasdt.");

            var result = _userValidator.Validate(user);

            Assert.Equal("Field 'Password' Needs to Have It's Lenght Equal Or Lower Than 150 Characters", result.Errors[0].ErrorMessage);
        }


    }
}
