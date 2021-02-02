using GetPostPutDeleteWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetPostPutDeleteWebApi.FakeData;

namespace GetPostPutDeleteWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<Users> users = FakeData.FakeData.GetUsers(10);

        [HttpGet]
        public List<Users> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public Users Get(int id) // Alacağı id değerine göre veriyi çekecek.
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public Users Post([FromBody] Users user)
        {
            users.Add(user);
            return user;
        }

        [HttpPut]
        public Users Put([FromBody] Users user)
        {
            var guncellenenUser = users.FirstOrDefault(x => x.Id == user.Id);
            guncellenenUser.Firstname = user.Firstname;
            guncellenenUser.Lastname = user.Lastname;
            return user;
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var deleted = users.FirstOrDefault(x => x.Id == id);
            users.Remove(deleted);
        }

    }
}
