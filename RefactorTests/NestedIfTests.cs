using System;
using Xunit;
using Refactor;

namespace RefactorTests
{
    public class NestedIfTests
    {
        private NestedIf sut;

        [Fact]
        public void GivenNestedIf_WhenSubstanceTempBelowAbsoluteZero_ThenExceptionShouldBeThrown()
        {
            var substanceTemp = -300;
            var substanceBoilingTemp = 100;
            var substanceMeltingTemp = 0;

            sut = new NestedIf();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SubstancePhysicalState(substanceMeltingTemp, substanceBoilingTemp, substanceTemp));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SubstancePhysicalStateAfterRefactor(substanceMeltingTemp, substanceBoilingTemp, substanceTemp));
        }

        [Fact]
        public void GivenNestedIf_WhenSubstanceMeltingTempHigherThenSubstanceBoilingTemp_ThenExceptionShouldBeThrown()
        {
            var substanceTemp = 100;
            var substanceBoilingTemp = 300;
            var substanceMeltingTemp = 400;

            sut = new NestedIf();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SubstancePhysicalState(substanceMeltingTemp, substanceBoilingTemp, substanceTemp));
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SubstancePhysicalStateAfterRefactor(substanceMeltingTemp, substanceBoilingTemp, substanceTemp));
        }

        [Fact]
        public void GivenNestedIf_WhenSubstanceTempHigherThenSubstanceBoilingTemp_ThenShouldReturnGas()
        {
            var substanceTemp = 101;
            var substanceBoilingTemp = 100;
            var substanceMeltingTemp = 0;
            var expected = "Gas";

            sut = new NestedIf();

            var result = sut.SubstancePhysicalState(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);
            var resultRefactor = sut.SubstancePhysicalStateAfterRefactor(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);

            Assert.Equal(expected, result);
            Assert.Equal(expected, resultRefactor);
        }

        [Fact]
        public void GivenNestedIf_WhenSubstanceTempLowerThenSubstanceMeltingTemp_ThenShouldReturnSolid()
        {
            var substanceTemp = -10;
            var substanceBoilingTemp = 100;
            var substanceMeltingTemp = 0;
            var expected = "Solid";

            sut = new NestedIf();

            var result = sut.SubstancePhysicalState(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);
            var resultRefactor = sut.SubstancePhysicalStateAfterRefactor(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);

            Assert.Equal(expected, result);
            Assert.Equal(expected, resultRefactor);
        }

        [Fact]
        public void GivenNestedIf_WhenSubstanceTempBetweenMeltingTempAndBoilingTemp_ThenShouldReturnLiquid()
        {
            var substanceTemp = 50;
            var substanceBoilingTemp = 100;
            var substanceMeltingTemp = 0;
            var expected = "Liquid";

            sut = new NestedIf();

            var result = sut.SubstancePhysicalState(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);
            var resultRefactor = sut.SubstancePhysicalStateAfterRefactor(substanceMeltingTemp, substanceBoilingTemp, substanceTemp);

            Assert.Equal(expected, result);
            Assert.Equal(expected, resultRefactor);
        }
    }
}
