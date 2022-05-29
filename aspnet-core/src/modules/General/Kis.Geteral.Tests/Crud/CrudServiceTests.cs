using Abp.EntityFrameworkCore;
using Kis.General.Api.Dto;
using Kis.General.Api.Services.Crud;
using Kis.General.Dao;
using Kis.General.Dao.Repositories;
using Kis.General.Services.Crud;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kis.General.Tests.Crud
{
   // [TestMethod]
    public class CrudServiceTests
    {
        private IAddressCrudAppService _addressCrudAppService;

        public CrudServiceTests()
        {
            var arg = new string[] { };
            var dbContext = new GeneralDbContextFactory().CreateDbContext(arg);
            _addressCrudAppService = new AddressCrudAppService(
                new AddressRepository(new SimpleDbContextProvider<GeneralDbContext>(dbContext)));
        }

      //  [TestMethod]
        public void GetAddressTest()
        {
           //Prepere
            var address = _addressCrudAppService.Create(new AddressDto()).Result;

            //Action
            var result = _addressCrudAppService.Get(address.Id).Result;

            //Assert
         //   Assert.IsNotNull(result);
        }
    }
}
