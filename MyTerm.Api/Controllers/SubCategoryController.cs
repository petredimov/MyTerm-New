using DataContextNamespace.Models;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTerm.Api.Controllers
{
    public class SubCategoryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            SubCategoryService service = new SubCategoryService();
            IEnumerable<SubCategory> subCategories = service.GetSubCategories();
            if (subCategories.Count() > 0)
            {
                result = Ok(subCategories);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult result = null;

            SubCategoryService service = new SubCategoryService();

            SubCategory subCategory = service.GetSubCategory(id);

            if (subCategory != null)
            {
                result = Ok(subCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(SubCategory subCategory)
        {
            IHttpActionResult result = null;
            SubCategoryService service = new SubCategoryService();
            SubCategory newSubCategory = service.InsertSubCategory(subCategory);

            if (newSubCategory != null)
            {
                result = Created<SubCategory>(Request.RequestUri + newSubCategory.ID.ToString(), newSubCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(SubCategory subCategory)
        {
            IHttpActionResult result = null;
            SubCategoryService service = new SubCategoryService();

            if (service.GetSubCategory(subCategory.ID) != null)
            {
                service.UpdateSubCategory(subCategory);
                result = Ok(subCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult result = null;
            SubCategoryService service = new SubCategoryService();

            SubCategory subCategory = service.GetSubCategory(id);
            if (subCategory != null)
            {
                service.RemoveSubCategory(id);

                result = Ok(true);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }
    }
}
