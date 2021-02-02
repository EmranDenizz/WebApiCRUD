using Bogus;
using GetPostPutDeleteWebApi.Controllers;
using GetPostPutDeleteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace GetPostPutDeleteWebApi.FakeData
{
    public static class FakeData
    {
        private static List<Users> users;     // Users sınıfım için dinamik bir dizi tanımladım  
        public static List<Users> GetUsers(int number) // numbder parametresine gelen sayı neyse o kadar data oluşturcak
        {
            if(users==null)
            {
                users = new Faker<Users>()
                .RuleFor(x => x.Id, f => f.IndexFaker + 1)
                .RuleFor(x => x.Firstname, f => f.Name.FirstName())
                .RuleFor(x => x.Lastname, f => f.Name.LastName())
                .Generate(number);  //Aldığı parametre kaç ise o kadar fake data üretir.
            }
            
            return users;
        }
    }
}
