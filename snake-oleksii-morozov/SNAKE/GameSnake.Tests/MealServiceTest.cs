using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using Xunit;

namespace GameSnake.Tests
{
    public class MealServiceTest
    {
        [Fact]
        public void CreateApple_ReturnsTrue()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
        }
    }
}
