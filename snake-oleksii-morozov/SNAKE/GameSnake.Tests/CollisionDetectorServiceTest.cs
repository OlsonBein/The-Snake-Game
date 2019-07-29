using GameSnake.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace GameSnake.Tests
{
    public class CollisionDetectorServiceTest
    {
        [Fact]
        public void WallCollisionCheck_NextPoint_ReturnsFalse()
        {
            //Arrange
            SnakeService.SnakeBody = new List<Point>
            {
                new Point(3,2),
                new Point(3,3),
                new Point(3,4)
            };

            SnakeService.SnakeBody.Insert(0, new Point(2, 2));

            var collisionDetectorService = new CollisionDetectorService();

            //Act
            var expected = collisionDetectorService.WallCollisionCheck();

            //Assert
            Assert.False(expected);
        }

        [Fact]
        public void WallCollisionCheck_NextPoint_ReturnsException()
        {
            //Arrange
            SnakeService.SnakeHead = new Point(0, 2);

            var collisionDetectorService = new CollisionDetectorService();

            //Act and Assert
            Assert.Throws<Exception>(() => collisionDetectorService.WallCollisionCheck());
        }

        [Fact]
        public void CheckSelfCollision_NextPoint_ReturnsException()
        {
            //Arrange
            SnakeService.SnakeBody = new List<Point>
            {

                new Point(3,3),
                new Point(2,3),
                new Point(2,2),
                new Point(10,10)
            };
            var collisionDetectorService = new CollisionDetectorService();

            //Act and Assert
            Assert.Throws<Exception>(() => collisionDetectorService.CheckSelfCollision());
        }

        [Fact]
        public void CheckSelfCollision_NextPoint_ReturnsFalse()
        {
            //Arrange
            SnakeService.SnakeBody = new List<Point>
            {

                new Point(3,3),
                new Point(3,4)
            };

            var snakeNextPoint = new Point(3, 2);

            var collisionDetectorService = new CollisionDetectorService();

            //Act
            var expected = collisionDetectorService.CheckSelfCollision();

            //Assert
            Assert.False(expected);
        }
    }
}

