using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TodoApi.Controllers;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoTestProject.Controllers
{
    [TestFixture]
    public class TodoControllerTests
    {
        private MockRepository mockRepository;

        private Mock<GenericRepository<Todo>> mockGenericRepository;
        private Mock<TodoRepository> mockTodoRepository;
        private TodoRepository todoRepository;


        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGenericRepository = this.mockRepository.Create<GenericRepository<Todo>>();
            this.mockTodoRepository = this.mockRepository.Create<TodoRepository>();
            this.todoRepository = new TodoRepository();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private TodoController CreateTodoController()
        {
            return new TodoController();
        }

        [Test]
        public async Task GetTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateTodoController();

            // Act
            var result = await unitUnderTest.GetTodo();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetTodo_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var unitUnderTest = this.CreateTodoController();
            int id = 1;

            // Act
            var result = await unitUnderTest.GetTodo(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task PutTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateTodoController();
            string todoName = "Clean room";
            DateTime due = new DateTime(2019, 6, 6);
            int userId = 5;

            var todo = todoRepository.CreateNewTodo(todoName, due, userId);

            // Act
            var result = await unitUnderTest.PutTodo(
                todo.Id,
                todo);

            // Assert
            Assert.AreEqual(result.ToString(), "");
        }

        [Test]
        public async Task PostTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateTodoController();
            string todoName = "Clean room";
            DateTime due = new DateTime(2019, 6, 6);
            int userId = 5;
            var todo = todoRepository.CreateNewTodo(todoName, due, userId);
            // Act
            var result = unitUnderTest.PostTodo(todo);

            // todo fix the assert
            Assert.AreEqual(todo, result.Result);
        }

        [Test]
        public async Task DeleteTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateTodoController();
            int id = 4;

            // Act
            var result = await unitUnderTest.DeleteTodo(
                id);

            // Assert
            Assert.Fail();
        }
    }
}
