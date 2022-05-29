using System;
using Abp.Authorization.Users;
using Kis.Users.Dto;
using TestRestClient.Tests;

namespace TestRestClient
{
    class Program
    {
      
      

       
        static void Main(string[] args)
        {
            
              
                 // PersonRestTest.Run();
                //  PartnershipMemberRestTest.Run(_accessToken);
                //  InvestedProjectTest.Run(_accessToken);
                 VoteTest.Run();
            
            Console.ReadKey();
        }
    }
}
