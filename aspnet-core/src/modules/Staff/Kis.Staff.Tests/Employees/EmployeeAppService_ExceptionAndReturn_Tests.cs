using System;
using Abp.Domain.Entities;
using Abp.ObjectMapping;
using FakeItEasy;
using Kis.General.Api.Dao.Repositories;
using Kis.General.Api.Dto;
using Kis.Staff.Api.Dao.Repositories;
using Kis.Staff.Api.Dto;
using Kis.Staff.Api.Entity;
using Kis.Staff.Services;
using Kis.Staff.Tests.Extentions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kis.Staff.Tests.Employees
{
    // NOTE: Реализованы тесты только на проверку генерации исключений и возвращаемых значений методов.

    [TestClass]
    public sealed class EmployeeAppService_ExceptionAndReturn_Tests
    {
        private IPersonRepository _personRepository;
        private IPositionRepository _positionRepository;
        private IPositionAppointmentRepository _positionAppointmentRepository;
        private IEmployeeRepository _employeeRepository;

        private EmployeeAsyncCrudAppService _appService;

        [TestInitialize]
        public void Initialize()
        {
            _personRepository = A.Fake<IPersonRepository>();
            _positionRepository = A.Fake<IPositionRepository>();
            _positionAppointmentRepository = A.Fake<IPositionAppointmentRepository>();
            _employeeRepository = A.Fake<IEmployeeRepository>();

            _appService = new EmployeeAsyncCrudAppService(_personRepository, 
                _positionRepository, _positionAppointmentRepository, _employeeRepository);

            _appService.ObjectMapper = A.Fake<IObjectMapper>();
            A.CallTo(() => _appService.ObjectMapper.Map<EmployeeDto>(A<Employee>.Ignored)).Returns(A.Fake<EmployeeDto>());
        }

        //
        // RecruitPerson

        [TestMethod]
        public void RecruitPerson_ArgumentNullPersonDto_ThrowException()
        {
            // Arrange
            PersonDto personDto = null;

            // Act => Asserts
            ExceptionAssert.Throws(() => { _appService.RecruitPerson(personDto, new PositionDto(), new DateTime()); }, nameof(personDto));
        }

        [TestMethod]
        public void RecruitPerson_ArgumentNullPositionDto_ThrowException()
        {
            // Arrange 
            PositionDto positionDto = null;

            // Act => Assert
            ExceptionAssert.Throws(() => { _appService.RecruitPerson(new PersonDto(), positionDto, new DateTime()); }, nameof(positionDto));
        }

        [TestMethod]
        public void RecruitPerson_NotFoundPerson_ThrowException()
        {
            // Arrange
            A.CallTo(() => _personRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Assert
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitPerson_NotFoundPosition_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitPerson_InsertToRepositoryEmployee_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.Insert(A<Employee>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitPerson_InsertToRepositoryPositionAppointment_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitPerson_CanInsetToRepository_ReturnNewEmployeeDto()
        {
            // Arrenge
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).Returns(A.Fake<PositionAppointment>());

            // Act
            var newEmployeeDto = _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime());

            // Asserts
            Assert.IsNotNull(newEmployeeDto);
            Assert.IsNotNull(newEmployeeDto.Id);
            Assert.IsInstanceOfType(newEmployeeDto, typeof(EmployeeDto));

            A.CallTo(() => _employeeRepository.Insert(A<Employee>.Ignored)).MustHaveHappened();
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).MustHaveHappened();
        }

       

      

        [TestMethod]
        public void RecruitCandidate_NotFoundPosition_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitCandidate_InsertToRepositoryEmployee_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.Insert(A<Employee>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        [TestMethod]
        public void RecruitCandidate_InsertToRepositoryPositionAppointment_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.RecruitPerson(A.Fake<PersonDto>(), A.Fake<PositionDto>(), new DateTime()); });
        }

        //
        // Dismiss

        [TestMethod]
        public void Dismiss_ArgumentNullEmployeeDto_ThrowException()
        {
            // Arrange
            EmployeeDto employeeDto = null;

            // Act => Asserts
            ExceptionAssert.Throws(() => { _appService.Dismiss(employeeDto); }, nameof(employeeDto));
        }

        [TestMethod]
        public void Dismiss_NotFoundEmployee_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Assert
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.Dismiss(A.Fake<EmployeeDto>()); });
        }

        [TestMethod]
        public void Dismiss_CanDeteteEmployee()
        {
            // Arrenge
            A.CallTo(() => _employeeRepository.Delete(A<Employee>.Ignored));

            // Act
            _appService.Dismiss(A.Fake<EmployeeDto>());

            // Asserts
            A.CallTo(() => _employeeRepository.Delete(A<Employee>.Ignored)).MustHaveHappened();
        }

        //
        // Reassignment

        [TestMethod]
        public void Reassignment_ArgumentNullEmployeeDto_ThrowException()
        {
            // Arrange
            EmployeeDto employeeDto = null;

            // Act => Asserts
            ExceptionAssert.Throws(() => { _appService.Reassignment(employeeDto, new PositionDto()); }, nameof(employeeDto));
        }

        [TestMethod]
        public void Reassignment_ArgumentNullPositionDto_ThrowException()
        {
            // Arrange
            PositionDto newPositionDto = null;

            // Act => Assert
            ExceptionAssert.Throws(() => { _appService.Reassignment(new EmployeeDto(), newPositionDto); }, nameof(newPositionDto));
        }

        [TestMethod]
        public void Reassignment_NotFoundEmployee_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.Reassignment(A.Fake<EmployeeDto>(), A.Fake<PositionDto>()); });
        }

        [TestMethod]
        public void Reassignment_NotFoundPosition_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.Reassignment(A.Fake<EmployeeDto>(), A.Fake<PositionDto>()); });
        }

        [TestMethod]
        public void Reassignment_InsertToRepositoryPositionAppointment_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.Reassignment(A.Fake<EmployeeDto>(), A.Fake<PositionDto>()); });

        }

        [TestMethod]
        public void Reassignment_CanInsertToRepository_ReturnNewEmploeeDto()
        {
            // Arrenge
            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).Returns(A.Fake<PositionAppointment>());

            // Act
            var newEmployeeDto = _appService.Reassignment(A.Fake<EmployeeDto>(), A.Fake<PositionDto>());

            // Asserts
            Assert.IsNotNull(newEmployeeDto);
            Assert.IsNotNull(newEmployeeDto.Id);
            Assert.IsInstanceOfType(newEmployeeDto, typeof(EmployeeDto));

            A.CallTo(() => _positionAppointmentRepository.Insert(A<PositionAppointment>.Ignored)).MustHaveHappened();
        }

        //
        // SetEmploymentDate

        [TestMethod]
        public void SetEmploymentDate_ArgumentNullEmployeeDto_ThrowException()
        {
            // Arrange
            EmployeeDto employeeDto = null;

            // Act => Asserts
            ExceptionAssert.Throws(() => { _appService.SetEmploymentDate(employeeDto, new DateTime()); }, nameof(employeeDto));
        }

        [TestMethod]
        public void SetEmploymentDate_NotFoundEmployee_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.FirstOrDefault(A<Guid>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<EntityNotFoundException>(() => { _appService.SetEmploymentDate(A.Fake<EmployeeDto>(), new DateTime()); });
        }

        [TestMethod]
        public void SetEmploymentDate_UpdateInRepositoryEmployee_ReturnNull_ThrowException()
        {
            // Arrange
            A.CallTo(() => _employeeRepository.Update(A<Employee>.Ignored)).Returns(null);

            // Act => Asserts
            ExceptionAssert.Throws<InvalidOperationException>(() => { _appService.SetEmploymentDate(A.Fake<EmployeeDto>(), new DateTime()); });

        }

        [TestMethod]
        public void SetEmploymentDate_CanUpdateInRepository_ReturnNewEmploeeDto()
        {
            // Arrenge
            A.CallTo(() => _employeeRepository.Update(A<Employee>.Ignored)).Returns(A.Fake<Employee>());

            // Act
            var newEmployeeDto = _appService.SetEmploymentDate(A.Fake<EmployeeDto>(), new DateTime());

            // Asserts
            Assert.IsNotNull(newEmployeeDto);
            Assert.IsNotNull(newEmployeeDto.Id);
            Assert.IsInstanceOfType(newEmployeeDto, typeof(EmployeeDto));

            A.CallTo(() => _employeeRepository.Update(A<Employee>.Ignored)).MustHaveHappened();
        }
    }
}
