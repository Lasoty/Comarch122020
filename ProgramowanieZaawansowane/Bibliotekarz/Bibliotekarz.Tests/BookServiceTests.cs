using Autofac;
using Bibliotekarz.Model;
using Bibliotekarz.Services;
using Bibliotekarz.ViewModel;
using NUnit.Framework;
using System.Collections.Generic;

namespace Bibliotekarz.Tests
{
    public class Tests
    {
        IContainer testContainer;

        [SetUp]
        public void Setup()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<FakeBookService>().As<IBookService>();
            builder.RegisterType<MainViewModel>().AsSelf();

            testContainer = builder.Build();
        }

        [Test]
        public void MainViewModelShouldHaveAnyBooksTest()
        {
            //Arrange

            MainViewModel mainViewModel = testContainer.Resolve<MainViewModel>();

            //Act

            //Asert
            Assert.IsNotNull(mainViewModel);
            Assert.IsNotNull(mainViewModel.BookList);
            Assert.IsTrue(mainViewModel.BookList.Count >= 0);
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
    

    class FakeBookService : IBookService
    {
        public void AddBook(Book item)
        {
        }

        public ICollection<Book> GetAll()
        {
            return new List<Book>();
        }

        public ICollection<Book> GetBorrowedBooks()
        {
            return null;
        }
    }
}