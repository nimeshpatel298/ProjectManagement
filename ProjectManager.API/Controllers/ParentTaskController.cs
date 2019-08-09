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
    public class ParentTaskController : ApiController
    {
        public IProjectManagerService projectManagerService;

        public ParentTaskController(IProjectManagerService projectManagerService)
        {
            this.projectManagerService = projectManagerService;
        }

        [HttpGet]
       // [Route("ParentTasks/GetAll")]
        public IHttpActionResult GetAllParentTasks()
        {
            return Ok(projectManagerService.GetAllParentTasks());
        }

       // [Route("ParentTasks/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetParentTaskById(int id)
        {
            return Ok(projectManagerService.GetParentTaskById(id));
        }

        //[Route("ParentTasks/Create")]
        [HttpPost]
        public IHttpActionResult AddParentTask([FromBody]TaskEntity taskEntity)
        {
            return Ok(projectManagerService.AddParentTask(taskEntity));
        }

        //[Route("ParentTasks/Update")]
        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UpdateParentTask([FromBody]TaskEntity taskEntity)
        {
            if (taskEntity.TaskId > 0)
            {
                return Ok(projectManagerService.UpdateParentTask(taskEntity));
            }
            return Ok(false);
        }


    }
}
