using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public IProjectManagerService projectManagerService;

        public UserController(IProjectManagerService projectManagerService)
        {
            this.projectManagerService = projectManagerService;
        }

        [HttpGet]
        //[Route("Users/GetAll")]
        public IHttpActionResult GetAllUsers()
        {
            return Ok(projectManagerService.GetAllUsers());
        }

        //[Route("Users/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            return Ok(projectManagerService.GetUserById(id));
        }

        //[Route("Users/Create")]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]UserEntity entity)
        {
            return Ok(projectManagerService.AddUser(entity));
        }

        //[Route("Users/Update")]
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UpdateUser([FromBody]UserEntity entity)
        {
            if (entity.UserId > 0)
            {
                return Ok(projectManagerService.UpdateUser(entity));
            }
            return Ok(false);
        }

        //[Route("Users/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            return Ok(projectManagerService.DeleteUser(id));
        }


    }
}
