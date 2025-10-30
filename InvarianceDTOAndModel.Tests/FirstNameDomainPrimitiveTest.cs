using Xunit;
using System;


namespace InvarianceDTOAndModel.Tests
{
    public class FirstNameDomainPrimitiveTest
    {
        // Positive test - Valid length
        [Theory]
        [InlineData("IB")]
        [InlineData("Maria")]
        [InlineData("Alexander")]
        public void FirstName_ValidLength_ShouldNotThrowException(string validName)
        {
            // Act & Assert
            var exception = Record.Exception(() => new Firstname(validName));
            Assert.Null(exception);
        }

        // Positive test - Valid characters
        [Theory]
        [InlineData("Martin")]
        [InlineData("Nikolaj")]
        [InlineData("Anne")]
        public void FirstName_ValidCharacters_ShouldNotThrowException(string validName)
        {
            // Act & Assert
            var exception = Record.Exception(() => new Firstname(validName));
            Assert.Null(exception);
        }

        // Negative test - Invalid length (too short or too long)
        [Theory]
        [InlineData("J")]
        [InlineData("Thisisaverylongnamethatexceedsmaximumlength")]
        [InlineData("")]
        public void FirstName_InvalidLength_ShouldThrowArgumentException(string invalidName)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Firstname(invalidName));
        }

        // Negative test - Invalid characters (numbers and special characters)
        [Theory]
        [InlineData("Martin1")]
        [InlineData("Nikolaj?")]
        [InlineData("Anne()")]
        [InlineData("<Simon>")]
        [InlineData("Something;")]
        public void FirstName_InvalidCharacters_ShouldThrowArgumentException(string invalidName)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Firstname(invalidName));
        }

        // Negative test - Null value
        [Fact]
        public void FirstName_NullValue_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Firstname(null)); // What mistake di i make here?
        }
    }
}