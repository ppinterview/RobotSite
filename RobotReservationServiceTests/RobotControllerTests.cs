using RobotReservationService.Controllers;
using RobotReservationService.Models;
using RobotReservationService.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace RobotReservationServiceTests
{
    [TestClass]
    public class RobotControllerTests
    {
        
        [TestMethod]
        public void CanAddRobot()
        {
            var repo = Substitute.For<IRobotRepository>();
            repo.Add(new Robot()).ReturnsForAnyArgs(true);
            repo.Update(new Robot()).ReturnsForAnyArgs(false);

            var controller = new RobotController(repo);
            var id = Guid.NewGuid();
            Assert.IsTrue(controller.Put(id, new Robot { Id = id, Name = "Clarence", RobotType = "Cleaning", Description = "Cleaner Bot" }));
            repo.Received().Add(Arg.Any<Robot>());
        }

        [TestMethod]
        public void CanUpdateRobot()
        {
            var repo = Substitute.For<IRobotRepository>();
            repo.Update(new Robot()).ReturnsForAnyArgs(true);

            var controller = new RobotController(repo);
            var id = Guid.NewGuid();
            repo.GetById(id).Returns(new Robot { Id = id, Name = "Clarence", RobotType = "Cleaning", Description = "Cleaner Bot" });
            controller.Put(id, new Robot { Id = id, Name = "Randy", RobotType = "Removal", Description = "Removal Bot" });
            repo.Received().Update(Arg.Any<Robot>());

        }

        [TestMethod]
        public void CanDeleteRobot()
        {
            var repo = Substitute.For<IRobotRepository>();
            var id = Guid.NewGuid();
            repo.Delete(id).Returns(true);

            var controller = new RobotController(repo);
            repo.GetById(id).Returns(new Robot { Id = id, Name = "Barry", RobotType = "Bashing", Description = "Bashing Bot" });
            controller.Delete(id);
            repo.Received().Delete(id);
        }
    }
}
