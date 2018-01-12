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
    public class BranchController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            BranchService service = new BranchService();
            IEnumerable<Branch> branches = service.GetBranches();
            if(branches.Count() > 0)
            {
                result = Ok(branches);
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

            BranchService service = new BranchService();

            Branch branch = service.GetBranch(id);

            if (branch != null)
            {
                result = Ok(branch);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Branch branch)
        {
            IHttpActionResult result = null;
            BranchService service = new BranchService();
            Branch newBranch = service.InsertBranch(branch);

            if (newBranch != null)
            {
                result = Created<Branch>(Request.RequestUri + newBranch.ID.ToString(), newBranch);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Branch branch)
        {
            IHttpActionResult result = null;
            BranchService service = new BranchService();

            if(service.GetBranch(branch.ID)  != null)
            {
                service.UpdateBranch(branch);
                result = Ok(branch);
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
            BranchService service = new BranchService();

            Branch branch = service.GetBranch(id);
            if(branch != null)
            {
                service.RemoveBranch(id);

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
