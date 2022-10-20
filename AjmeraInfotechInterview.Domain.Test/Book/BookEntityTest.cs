using AjmeraInfotech.Domain.entity;
using AjmeraInfotech.Domain.interfaces.entity;
using AjmeraInfotech.Domain.interfaces.repo;
using AjmeraInfotech.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraInfotechInterview.Domain.Test.Book
{
    [TestClass]
    public class BookEntityTest
    {
        #region PRIVATE INSTANCE FIELDS
        protected IBookEntity _entity;
        protected IBookRepo _repo;
        protected Mock<IBookRepo> _injectedRepoMock = new Mock<IBookRepo>();

        #endregion
        #region CONSTRUCTOR
        public BookEntityTest()
        {
            _entity = new BookEntity(_injectedRepoMock.Object);
        }
        #endregion
        #region MODELS and Variables
        AjmeraInfotech.Common.Book _mockbook = new AjmeraInfotech.Common.Book()
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            name ="Some Name",
            authorName="Some Author Name"
        };
        #endregion

        #region ACT
        private bool ActAdd()
        {
            return _entity.SaveBook(_mockbook);
        }
        private bool ActUpdate()
        {
            return _entity.Update(_mockbook);
        }
        private AjmeraInfotech.Common.Book ActGetById()
        {
            return _entity.GetBookById(_mockbook.Id);
        }
        private List<AjmeraInfotech.Common.Book> ActGetAll()
        {
            return _entity.GetBooks();
        }
        private bool ActDelete()
        {
            return _entity.Delete(_mockbook.Id);
        }
        #endregion

        #region TEST METHODS
        [TestMethod]
        public void Add_ReturnSuccess()
        {
            //Arrange
            _injectedRepoMock.Setup(x => x.SaveBook(_mockbook)).Returns(true);

            var expectedResult = true;

            //Act
            var returnedResult = ActAdd();

            //Assert
            Assert.AreEqual(expectedResult, returnedResult);
        }
        [TestMethod]
        public void Update_ReturnSuccess()
        {
            //Arrange
            _injectedRepoMock.Setup(x => x.Update(_mockbook)).Returns(true);

            var expectedResult = true;

            //Act
            var returnedResult = ActUpdate();

            //Assert
            Assert.AreEqual(expectedResult, returnedResult);
        }
        [TestMethod]
        public void GetById_ReturnSuccess()
        {
            //Arrange
            var expectedResult = new AjmeraInfotech.Common.Book()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                name = "Some Name",
                authorName = "Some Author Name"
            };
            _injectedRepoMock.Setup(x => x.GetBookById(_mockbook.Id)).Returns(expectedResult);
            //Act
            var returnedResult = ActGetById();

            //Assert
            Assert.AreEqual(expectedResult, returnedResult);
        }
        [TestMethod]
        public void Delete_ReturnSuccess()
        {
            //Arrange
            _injectedRepoMock.Setup(x => x.Delete(_mockbook.Id)).Returns(true);

            var expectedResult = true;

            //Act
            var returnedResult = ActDelete();

            //Assert
            Assert.AreEqual(expectedResult, returnedResult);
        }
        #endregion
    }
}
