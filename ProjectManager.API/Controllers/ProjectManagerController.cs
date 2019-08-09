using ProjectManager.BusinessLayer;
using ProjectManager.BusinessLayer.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {
        public IProjectManagerService projectManagerService;
        public ProjectManagerController(IProjectManagerService projectManagerService)
        {
            this.projectManagerService = projectManagerService;
        }
        // GET: api/ProjectManager

        [HttpGet]
        //[Route("Projects/GetAll")]
        public IHttpActionResult GetAllProjects()
        {
            return Ok(projectManagerService.GetAllProject());
        }

       // [Route("Projects/GetById/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjectById(int id)
        {
            return Ok(projectManagerService.GetProjectById(id));
        }
       
       // [Route("Projects/Create")]
        [HttpPost]
        public IHttpActionResult CreateProject([FromBody]ProjectEntity entity)
        {
            return Ok(projectManagerService.AddProject(entity));
        }

       // [Route("Projects/Update")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult UpdateProject([FromBody]ProjectEntity entity)
        {
            if (entity.ProjectId > 0)
            {
                return Ok(projectManagerService.UpdateProject(entity));
            }
            return Ok(false);
        }


        //[Route("Projects/Suspend/{id}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public IHttpActionResult SuspendProject(int id)
        {
            return Ok(projectManagerService.SuspendProject(id));
        }

       // [Route("Projects/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            return Ok(projectManagerService.DeleteProject(id));
        }

       


    }
}
