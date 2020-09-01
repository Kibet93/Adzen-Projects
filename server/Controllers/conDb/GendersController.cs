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

  [ODataRoutePrefix("odata/conDb/Genders")]
  [Route("mvc/odata/conDb/Genders")]
  public partial class GendersController : ODataController
  {
    private Data.ConDbContext context;

    public GendersController(Data.ConDbContext context)
    {
      this.context = context;
    }
    // GET /odata/ConDb/Genders
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConDb.Gender> GetGenders()
    {
      var items = this.context.Genders.AsQueryable<Models.ConDb.Gender>();
      this.OnGendersRead(ref items);

      return items;
    }

    partial void OnGendersRead(ref IQueryable<Models.ConDb.Gender> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{GenderID}")]
    public SingleResult<Gender> GetGender(int key)
    {
        var items = this.context.Genders.Where(i=>i.GenderID == key);
        this.OnGendersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnGendersGet(ref IQueryable<Models.ConDb.Gender> items);

    partial void OnGenderDeleted(Models.ConDb.Gender item);

    [HttpDelete("{GenderID}")]
    public IActionResult DeleteGender(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Genders
                .Where(i => i.GenderID == key)
                .Include(i => i.Students)
                .FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnGenderDeleted(item);
            this.context.Genders.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnGenderUpdated(Models.ConDb.Gender item);

    [HttpPut("{GenderID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutGender(int key, [FromBody]Models.ConDb.Gender newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.GenderID != key))
            {
                return BadRequest();
            }

            this.OnGenderUpdated(newItem);
            this.context.Genders.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Genders.Where(i => i.GenderID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{GenderID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchGender(int key, [FromBody]Delta<Models.ConDb.Gender> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Genders.Where(i => i.GenderID == key).FirstOrDefault();

            if (item == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(item);

            this.OnGenderUpdated(item);
            this.context.Genders.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Genders.Where(i => i.GenderID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnGenderCreated(Models.ConDb.Gender item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConDb.Gender item)
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

            this.OnGenderCreated(item);
            this.context.Genders.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConDb/Genders/{item.GenderID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
