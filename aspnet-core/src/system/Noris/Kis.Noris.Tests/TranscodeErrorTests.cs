using System;
using System.ComponentModel.DataAnnotations;
using Moq;
using NUnit.Framework;
using Urish.Core.Api.Dao;
using Urish.Noris.Api.Attribute;
using Urish.Noris.Api.Constants;
using Urish.Noris.Api.Entity;
using Urish.Noris.Api.Service;
using Urish.Noris.Management.Dao.Repositories;
using Urish.Noris.Management.Services;

namespace Urish.Noris.Test
{
    [TestFixture]
    public class TranscodeErrorTests
    {
        [Reference("TestReferenceCode", "TestReferenceName")]
        public class TestReferenceEntity : ReferenceEntity{}

        [Reference("1.2.643.5.1.13.2.1.1.156", "Классификатор половой принадлежности")]
        public class TestMasterReferenceEntity : ReferenceEntity { }

        [Test]
        public void CodeEmptyError_GenerateErrorCorrectly()
        {
            //Data prepare
            var errorManagerMock = new Mock<IReferenceErrorManager>();
            errorManagerMock.Setup(x => x.Create(It.IsAny<ReferenceError>(), true)).Returns(new ReferenceError());

            var referenceBookMock = new Mock<IReferenceBook<TestReferenceEntity>>();
            referenceBookMock.Setup(x => x.GetReferenceEntityType()).Returns(typeof (TestReferenceEntity));
            var referenceBook = referenceBookMock.Object;

            IReferenceErrorQualifier qualifier = new ReferenceErrorQualifier(errorManagerMock.Object, null);

            //Act
            var error = qualifier.CodeEmptyError(referenceBook, new[] { "232"});

            //Assert
            Assert.AreEqual(error.Description, "Отсутствие кода: 232" );
            Assert.AreEqual(error.Idenifier, referenceBook.GetType().Name +":232");
            Assert.AreEqual(error.ReferenceName, "TestReferenceName (TestReferenceCode)");
            Assert.AreEqual(error.ReferenceTypeName, typeof(TestReferenceEntity).Name);
            Assert.AreEqual(error.Type, ReferenceErrors.CodeIsMissing);
            Assert.AreEqual(error.State, ReferenceErrorStates.New);
        }

        [Test]
        public void TranscodeEmptyError_GenerateErrorCorrectly()
        {
            //Data prepare
            var errorManagerMock = new Mock<IReferenceErrorManager>();
            errorManagerMock.Setup(x => x.Create(It.IsAny<ReferenceError>(), true)).Returns(new ReferenceError());

            var referenceBookMock = new Mock<IReferenceBook<TestReferenceEntity>>();
            referenceBookMock.Setup(x => x.GetReferenceEntityType()).Returns(typeof(TestReferenceEntity));
            var referenceBook = referenceBookMock.Object;

            var masterReferenceBookMock = new Mock<IReferenceBook<TestMasterReferenceEntity>>();
            masterReferenceBookMock.Setup(x => x.GetReferenceEntityType()).Returns(typeof(TestMasterReferenceEntity));
            var masterReferenceBook = masterReferenceBookMock.Object;

            IReferenceErrorQualifier qualifier = new ReferenceErrorQualifier(errorManagerMock.Object, null);

            //Act
            var error = qualifier.TranscodeEmptyError(referenceBook, new[] { "111"}, masterReferenceBook);

            //Assert
            Assert.AreEqual(error.Description, "Отсутствие кода перекодировки: 111 на справочник - Классификатор половой принадлежности (1.2.643.5.1.13.2.1.1.156)");
            Assert.AreEqual(error.Idenifier, referenceBook.GetType().Name + ":111");
            Assert.AreEqual(error.ReferenceName, "TestReferenceName (TestReferenceCode)");
            Assert.AreEqual(error.ReferenceTypeName, typeof(TestReferenceEntity).Name);
            Assert.AreEqual(error.Type, ReferenceErrors.TranscodeIsMissing);
            Assert.AreEqual(error.State, ReferenceErrorStates.New);
        }

        [Test]
        public void UpdateReferenceError_GenerateErrorCorrectly()
        {
            //Data prepare
            var errorManagerMock = new Mock<IReferenceErrorManager>();
            errorManagerMock.Setup(x => x.Create(It.IsAny<ReferenceError>(), true)).Returns(new ReferenceError());

            var referenceBookMock = new Mock<IReferenceBook<TestReferenceEntity>>();
            referenceBookMock.Setup(x => x.GetReferenceEntityType()).Returns(typeof(TestReferenceEntity));
            var referenceBook = referenceBookMock.Object;

            var ex = new Exception(); 

            IReferenceErrorQualifier qualifier = new ReferenceErrorQualifier(errorManagerMock.Object, null);

            //Act
            var error = qualifier.UpdateReferenceError(referenceBook, ex);

            //Assert
            Assert.AreEqual(error.Description, "Ошибка при обновлении справочника");
            Assert.AreEqual(error.Idenifier, referenceBook.GetType().Name);
            Assert.AreEqual(error.ReferenceName, "TestReferenceName (TestReferenceCode)");
            Assert.AreEqual(error.ReferenceTypeName, typeof(TestReferenceEntity).Name);
            Assert.AreEqual(error.Type, ReferenceErrors.UpdateError);
            Assert.AreEqual(error.State, ReferenceErrorStates.New);
        }
    }
}
