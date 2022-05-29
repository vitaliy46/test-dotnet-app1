using System;
using System.Collections.Generic;
using System.Text;
using Kis.General.Api.Constant;
using Kis.General.Api.Dto;
using Kis.General.Api.Dto.PersonUser;
using Kis.General.Api.Entity;
using Kis.Users.Dto;

namespace TestRestClient
{
    class ResponseContent<TDto>
    {
        public TDto result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public object error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
        
    }

}
