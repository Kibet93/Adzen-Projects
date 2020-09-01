using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace StudentRegistration.Controllers.ConDb
{
  using Models;
  using Data;
  using Models.ConDb;

  [ODataRoutePrefix("odata/conDb/Students")]
  [Route("mvc/odata/conDb/Students")]
  public partial class StudentsController : ODataController
  {
    private Data.ConDbContext context;

    public StudentsController(Data.ConDbContext context)
    {
      this.context = context;
    }
    // GET /odata/ConDb/Students
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConDb.Student> GetStudents()
    {
      var items = this.context.Students.AsQueryable<Models.ConDb.Student>();
      this.OnStudentsRead(ref items);

      return items;
    }

    partial void OnStudentsRead(ref IQueryable<Models.ConDb.Student> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StudentID}")]
    public SingleResult<Student> GetStudent(int key)
    {
        var items = this.context.Students.Where(i=>i.StudentID == key);
        this.OnStudentsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStudentsGet(ref IQueryable<Models.ConDb.Student> items);

    partial void OnStudentDeleted(Models.ConDb.Student item);

    [HttpDelete("{StudentID}")]
    public IActionResult DeleteStudent(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Students
                .Where(i => i.StudentID == key)
                .FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStudentDeleted(item);
            this.context.Students.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentUpdated(Models.ConDb.Student item);

    [HttpPut("{StudentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudent(int key, [FromBody]Models.ConDb.Student newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.StudentID != key))
            {
                return BadRequest();
            }

            this.OnStudentUpdated(newItem);
            this.context.Students.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Students.Where(i => i.StudentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,Class1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{StudentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudent(int key, [FromBody]Delta<Models.ConDb.Student> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Students.Where(i => i.StudentID == key).FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(item);

            this.OnStudentUpdated(item);
            this.context.Students.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Students.Where(i => i.StudentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,Class1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentCreated(Models.ConDb.Student item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConDb.Student item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnStudentCreated(item);
            this.context.Students.Add(item);
            this.context.SaveChanges();

            var key = item.StudentID;

            var itemToReturn = this.context.Students.Where(i => i.StudentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Gender,Class1");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
