using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void IsNotNull()
        {
            TacoParser challenger = new TacoParser();
            var cells = "30.416551,-86.607497,Taco Bell Fort Walton Beac...";

            Assert.NotNull(challenger.Parse(cells));
        }

        //[Theory]
        //[InlineData("34.018008,-86.079099,Taco Bell Attall... (Free trial * Add to Cart for a full POI info)", "Attall")]
        //[InlineData("34.376395,-84.913185,Taco Bell Adairsvill... (Free trial * Add to Cart for a full POI info)", "Adairsvill")]
        //[InlineData("33.635282,-86.684056,Taco Bell Birmingham/... (Free trial * Add to Cart for a full POI info)", "Birmingham")]
        //[InlineData("33.715798,-84.215646,Taco Bell Decatur/... (Free trial * Add to Cart for a full POI info)", "Decatur")]
        //[InlineData("31.440529,-86.953648,Taco Bell Evergreen/... (Free trial * Add to Cart for a full POI info)", "Evergreen")]
        //[InlineData("30.39371,-87.68332,Taco Bell Fole... (Free trial * Add to Cart for a full POI info)", "Fole")]
        //public void ParseName(string line, string expected)
        //{
        //    // TODO: Complete Should Parse

        //    // Arrange
        //    var name = new TacoParser();

        //    // Act
        //    var actual = name.Parse(line);

        //    // Assert
        //    Assert.Equal(expected, actual.Name); 
        //}
        [Theory]
        [InlineData("34.039588,-84.283254,Taco Bell Alpharetta/... (Free trial * Add to Cart for a full POI info)", "Alpharetta")]
        [InlineData("32.072974,-84.222921,Taco Bell Americu... (Free trial * Add to Cart for a full POI info)", "Americu")]
        [InlineData("33.671982,-85.826674,Taco Bell Annisto... (Free trial * Add to Cart for a full POI info)", "Annisto")]
        [InlineData("34.324462,-86.503055,Taco Bell Ara... (Free trial * Add to Cart for a full POI info)", "Ara")]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore/... (Free trial * Add to Cart for a full POI info)", "Ardmore")]
        [InlineData("34.795116,-86.97191,Taco Bell Athens/... (Free trial * Add to Cart for a full POI info)", "Athens")]
        public void Parse(string line, string expected)
        {
            //Arrange
            TacoParser challenger = new TacoParser();
            //Act
            ITrackable actual = challenger.Parse(line);
            //Assert
            Assert.Equal(actual.Name, expected);
        }

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("31.440529,-86.953648")]
        //[InlineData("30.39371,Taco Bell,Foley")]
        //[InlineData("Taco Bell,-84.215646,Decatur")]
        //[InlineData(" , , ")]
        //public void ShouldFailParse(string line)
        //{
        //    // TODO: Complete Should Parse

        //    // Arrange
        //    var name = new TacoParser();

        //    // Act
        //    var actual = name.Parse(line);

        //    // Assert
        //    Assert.Null(actual);
        //}

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("34.1234,-65.2345", null)]
        public void TacoParse(string line, ITrackable expected)
        {
            //Arrange
            TacoParser challenger = new TacoParser();
            //Act
            ITrackable actual = challenger.Parse(line);
            //Assert
            Assert.Equal(actual, expected);
        }

    }
}
