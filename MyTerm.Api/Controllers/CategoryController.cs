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
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            CategoryService service = new CategoryService();
            IEnumerable<Category> categories = service.GetCategories();
            if (categories.Count() > 0)
            {
                result = Ok(categories);
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

            CategoryService service = new CategoryService();

            Category category = service.GetCategory(id);

            if (category != null)
            {
                result = Ok(category);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        public IHttpActionResult Post(Category category)
        {
            IHttpActionResult result = null;
            CategoryService service = new CategoryService();
            Category newCategory = service.InsertCategory(category);

            if (newCategory != null)
            {
                result = Created<Category>(Request.RequestUri + newCategory.ID.ToString(), newCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Category category)
        {
            IHttpActionResult result = null;
            CategoryService service = new CategoryService();

            if (service.GetCategory(category.ID) != null)
            {
                service.UpdateCategory(category);
                result = Ok(category);
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
            CategoryService service = new CategoryService();

            Category category = service.GetCategory(id);
            if (category != null)
            {
                service.RemoveCategory(id);

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