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

  [ODataRoutePrefix("odata/conDb/Class1s")]
  [Route("mvc/odata/conDb/Class1s")]
  public partial class Class1sController : ODataController
  {
    private Data.ConDbContext context;

    public Class1sController(Data.ConDbContext context)
    {
      this.context = context;
    }
    // GET /odata/ConDb/Class1s
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConDb.Class1> GetClass1s()
    {
      var items = this.context.Class1s.AsQueryable<Models.ConDb.Class1>();
      this.OnClass1sRead(ref items);

      return items;
    }

    partial void OnClass1sRead(ref IQueryable<Models.ConDb.Class1> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ClassID}")]
    public SingleResult<Class1> GetClass1(int key)
    {
        var items = this.context.Class1s.Where(i=>i.ClassID == key);
        this.OnClass1sGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnClass1sGet(ref IQueryable<Models.ConDb.Class1> items);

    partial void OnClass1Deleted(Models.ConDb.Class1 item);

    [HttpDelete("{ClassID}")]
    public IActionResult DeleteClass1(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Class1s
                .Where(i => i.ClassID == key)
                .Include(i => i.Students)
                .FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnClass1Deleted(item);
            this.context.Class1s.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnClass1Updated(Models.ConDb.Class1 item);

    [HttpPut("{ClassID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutClass1(int key, [FromBody]Models.ConDb.Class1 newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ClassID != key))
            {
                return BadRequest();
            }

            this.OnClass1Updated(newItem);
            this.context.Class1s.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Class1s.Where(i => i.ClassID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ClassID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchClass1(int key, [FromBody]Delta<Models.ConDb.Class1> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Class1s.Where(i => i.ClassID == key).FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(item);

            this.OnClass1Updated(item);
            this.context.Class1s.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Class1s.Where(i => i.ClassID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnClass1Created(Models.ConDb.Class1 item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConDb.Class1 item)
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

            this.OnClass1Created(item);
            this.context.Class1s.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConDb/Class1s/{item.ClassID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
