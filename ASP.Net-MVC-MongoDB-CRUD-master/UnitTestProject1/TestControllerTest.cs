using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbCRUD.Controllers;
using MongoDbCRUD.Models; // Adjust the namespace as per your project structure
using System.Web.Mvc;

[TestClass]
public class TestControllerTests
{
    [TestMethod]
    public void Create_ValidData_RedirectsToViewTestUser()
    {
        // Arrange
        var controller = new MongoDbCRUD.Controllers.TestController(); // Create an instance of your controller.
        var collection = new FormCollection
        {
            { "UserName", "TestUser" },
            { "Id", "TestId" }
            // Add other form values as needed for your test.
        };

        // Act
        var result = controller.Create(collection) as RedirectToRouteResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("ViewTestUser", result.RouteValues["action"]);
        Assert.AreEqual("TestUser", result.RouteValues["controller"]);
        // Add more assertions as needed.
    }

    [TestMethod]
    public void Create_InvalidData_RedirectsToViewTest()
    {
        // Arrange
        var controller = new TestController();
        var collection = new FormCollection(); // Simulate an empty or invalid form.

        // Act
        var result = controller.Create(collection) as RedirectToRouteResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("ViewTest", result.RouteValues["action"]);
        // Add more assertions as needed.
    }
    [TestMethod]
    public void EditTestUser_ReturnsView()
    {
        // Arrange
        TestUserController controller = new TestUserController();
        Test testModel = new Test(); // Crea un oggetto Test vuoto per il test.
        FormCollection formCollection = new FormCollection();

        // Act
        ActionResult result = controller.EditTestUser(testModel, formCollection);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
}
