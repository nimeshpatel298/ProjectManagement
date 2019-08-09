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
    public class TaskController : ApiController
    {
        public IProjectManagerService projectManagerService;

        public TaskController(IProjectManagerService projectManagerService)
        {
            this.projectManagerService = projectManagerService;
        }

        [HttpGet]
       // [Route("Tasks/GetAll")]
        public IHttpActionResult GetAllTasks()
        {
            var parentTasks = projectManagerService.GetAllParentTasks();
            var tasks = projectManagerService.GetAllTasks();
            parentTasks.AddRange(tasks);
            return Ok(parentTasks);
        }

       // [Route("Tasks/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int id)
        {
            return Ok(projectManagerService.GetTaskById(id));
        }

        //[Route("Tasks/Create")]
        [HttpPost]
        public IHttpActionResult AddTask([FromBody]TaskEntity taskEntity)
        {
            return Ok(projectManagerService.AddTask(taskEntity));
        }

        //[Route("Tasks/Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult UpdateTask([FromBody]TaskEntity taskEntity)
        {
            if (taskEntity.TaskId > 0)
            {
                return Ok(projectManagerService.UpdateTask(taskEntity));
            }
            return Ok(false);
        }

        // [Route("Tasks/End/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult EndTask(int id)
        {
            return Ok(projectManagerService.EndTask(id));
        }

       // [Route("Tasks/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            return Ok(projectManagerService.DeleteTask(id));
        }
    }
}
