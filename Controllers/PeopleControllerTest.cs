using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PeopleApi.Models;
using PeopleApi.Controllers;

namespace PeopleApi.Tests.Controllers
{
    [TestFixture]
    public class PeopleControllerTest : Controller
    {
        private PeopleContext _context;
        private PeopleController _peopleController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase("PeopleContext")
                .Options;

            _context = new PeopleContext(options);
            _context.Database.EnsureCreated();

            _peopleController = new PeopleController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        // GET: People
        [Test]
        public async Task Index_ReturnsAViewResult_WithAListOfAllPeople()
        {
            // Arrange
            var data = new List<Person>
            {
                new Person {
                    Name = "Amora", BirthDate = new DateTime(), CPF = "111.222.333-10", Team = TeamTypeEnum.Backend,
                    Email = "a@teste.com", Gender = GenderTypeEnum.Female, StartDate = "12/2019"},
                new Person {
                    Name = "Beto", BirthDate = new DateTime(), CPF = "222.222.333-10", Team = null,
                    Email = "b@teste.com", Gender = GenderTypeEnum.Male, StartDate = "12/2019"},
                new Person {
                    Name = "Carlos", BirthDate = new DateTime(), CPF = "333.222.333-10", Team = TeamTypeEnum.Mobile,
                    Email = "c@teste.com", Gender = GenderTypeEnum.Other, StartDate = "12/2019"},
            };

            foreach (Person p in data)
            {
                _context.Person.Add(p);
            }
            _context.SaveChanges();

            // Act
            var Result = await _peopleController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Model);
            Assert.AreEqual(Result.Model, data);
            Assert.IsTrue(string.IsNullOrEmpty(Result.ViewName) || Result.ViewName == "Index");
        }

        // POST: People/Create
        [Test]
        public async Task Create_SavesNewPersonInContext_AndRedirectsToIndex()
        {
            var TestId = 4201;
            Person NewPerson = new Person
            {
                Id = TestId,
                Name = "Diego",
                BirthDate = new DateTime(),
                CPF = "444.222.333-10",
                Team = TeamTypeEnum.Frontend,
                Email = "d@teste.com",
                Gender = GenderTypeEnum.Other,
                StartDate = "11/2020"
            };

            // Act
            var Result = await _peopleController.Create(NewPerson) as RedirectToActionResult;
            var Person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == TestId);

            // Assert
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.ActionName == "Index");
            Assert.IsNotNull(Person);
        }

        // POST: People/Edit/5
        [Test]
        public async Task Edit_ModifiesExistingPersonInContext_AndRedirectsToIndex()
        {
            // Arrange
            var TestId = 506;
            var data = new List<Person>
            {
                new Person {
                    Name = "Amora", BirthDate = new DateTime(), CPF = "111.222.333-10", Team = TeamTypeEnum.Backend,
                    Email = "a@teste.com", Gender = GenderTypeEnum.Female, StartDate = "12/2019", Id = 20},
                new Person {
                    Name = "Beto", BirthDate = new DateTime(), CPF = "222.222.333-10", Team = null,
                    Email = "b@teste.com", Gender = GenderTypeEnum.Male, StartDate = "12/2019", Id = 30},
                new Person {
                    Name = "Carlos", BirthDate = new DateTime(), CPF = "333.222.333-10", Team = TeamTypeEnum.Mobile,
                    Email = "c@teste.com", Gender = GenderTypeEnum.Other, StartDate = "12/2019", Id = TestId},
            };

            foreach (Person p in data)
            {
                _context.Person.Add(p);
            }
            _context.SaveChanges();

            Person modifiedPerson = data[2];
            modifiedPerson.Name = "Carlos Silva";

            // Act
            var Result = await _peopleController.Edit(TestId, modifiedPerson) as RedirectToActionResult;
            var Person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == TestId);

            // Assert
            Assert.IsNotNull(Result);
            Assert.IsTrue(Result.ActionName == "Index");
            Assert.AreEqual(Person.Name, "Carlos Silva");
        }

        // GET: People/Details/5
        [Test]
        public async Task Details_ReturnsAViewResult_WithAPersonDetails()
        {
            // Arrange
            var TestId = 506;
            var data = new List<Person>
            {
                new Person {
                    Name = "Amora", BirthDate = new DateTime(), CPF = "111.222.333-10", Team = TeamTypeEnum.Backend,
                    Email = "a@teste.com", Gender = GenderTypeEnum.Female, StartDate = "12/2019", Id = 20},
                new Person {
                    Name = "Beto", BirthDate = new DateTime(), CPF = "222.222.333-10", Team = null,
                    Email = "b@teste.com", Gender = GenderTypeEnum.Male, StartDate = "12/2019", Id = 30},
                new Person {
                    Name = "Carlos", BirthDate = new DateTime(), CPF = "333.222.333-10", Team = TeamTypeEnum.Mobile,
                    Email = "c@teste.com", Gender = GenderTypeEnum.Other, StartDate = "12/2019", Id = TestId},
            };

            foreach (Person p in data)
            {
                _context.Person.Add(p);
            }
            _context.SaveChanges();

            // Act
            var Result = await _peopleController.Details(TestId) as ViewResult;
            Person Model = Result.Model as Person;

            // Assert
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Model);
            Assert.AreEqual(Model.Name, "Carlos");
        }
    }
}
