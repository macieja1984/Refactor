using Xunit;
using Refactor;

namespace RefactorTests
{
    public class PeselValidatorTests
    {
        private PeselValidator sut;
        
        [Theory]
        [InlineData("59060202697")]
        [InlineData("71010211771")]
        [InlineData("10210400653")]
        public void GivenPeselValidator_WhenCheckingCorrectPESEL_ThenResultIsTrue(string pesel)
        {
            sut = new PeselValidator();

            var result = sut.PeselValid(pesel);

            Assert.True(result);
        }

        [Fact]
        public void GivenPeselValidator_WhenCheckingNonNumericPESEL_ThenResultIsFalse()
        {
            var pesel = "abcdeabcdef";
            sut = new PeselValidator();

            bool result = sut.PeselValid(pesel);

            Assert.False(result);
        }

        [Theory]
        [InlineData("5906020")]
        [InlineData("710102117711212")]
        [InlineData("")]
        public void GivenPeselValidator_WhenCheckingIncorrectLengthPESEL_ThenResultIsFalse(string pesel)
        {
            sut = new PeselValidator();

            var result = sut.PeselValid(pesel);

            Assert.False(result);
        }

        [Fact]
        public void GivenPeselValidator_WhenCheckingIncorrectDateInPESEL_ThenResultIsFalse()
        {
            var pesel = "23781903775";
            sut = new PeselValidator();

            var result = sut.PeselValid(pesel);

            Assert.False(result);
        }

        [Fact]
        public void GivenPeselValidator_WhenCheckingAllZerosPESEL_ThenResultIsFalse()
        {
            var pesel = "00000000000";
            sut = new PeselValidator();

            var result = sut.PeselValid(pesel);

            Assert.False(result);
        }

        [Fact]
        public void GivenPeselValidator_WhenCheckingNullPESEL_ThenResultIsFalse()
        {
            sut = new PeselValidator();

            var result = sut.PeselValid(null);

            Assert.False(result);
        }             
    }
}

