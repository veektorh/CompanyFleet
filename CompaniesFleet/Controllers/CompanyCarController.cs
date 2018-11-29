using CompaniesFleet.Data.Repositories;
using CompaniesFleet.Models;
using DevContactDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompaniesFleet.Controllers
{
    [RoutePrefix("api/companycar")]
    public class CompanyCarController : ApiController
    {
        private CompanyCarRepository CompanyCarRepository;

        public CompanyCarController()
        {
            CompanyCarRepository = new CompanyCarRepository();
        }

        // GET: api/CompanyCar
        /// <summary>
        /// Get all CompanyCars
        /// </summary>
        public IHttpActionResult Get()
        {
            var model =  CompanyCarRepository.GetAll().Select(a => new CompanyCarViewModel{ Name = a.Name , Category = a.Category.Name , Id = a.Id });

            return Ok(model);
        }

        
        /// <summary>
        /// Gets All CompanyCars in a particular category
        /// </summary>
        /// <param name="id"></param>
        [Route("GetByCategory/{id}")]
        public IHttpActionResult GetByCategory(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var model = CompanyCarRepository.GetAll(a=>a.CategoryId == id).Select(a => new CompanyCarViewModel { Name = a.Name, Category = a.Category.Name, Id = a.Id });

            return Ok(model);
        }

        // GET: api/CompanyCar/5
        /// <summary>
        /// Gets a single CompanyCar
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult Get(int id)
        {

            if (id < 0)
            {
                return BadRequest();
            }
            var model = CompanyCarRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST: api/CompanyCar
        /// <summary>
        /// Create a new CompanyCar 
        /// </summary>
        public IHttpActionResult Post(CompanyCarCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyCar = new CompanyCar();
            CompanyCar.Name = model.Name;
            CompanyCar.CategoryId = model.Category;

            var result = CompanyCarRepository.Add(CompanyCar);

            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.CompanyCar);
        }

        /// <summary>
        /// Update an existing CompanyCar 
        /// </summary>
        public IHttpActionResult Put(CompanyCarUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyCar = CompanyCarRepository.GetAll(a=>a.Id==model.Id).FirstOrDefault();

            if (CompanyCar == null)
            {
                return NotFound();
            }

            CompanyCar.Name = model.Name;
            CompanyCar.CategoryId = model.Category;

            var result = CompanyCarRepository.Update(CompanyCar);
            return Ok(result);
        }

        // DELETE: api/CompanyCar/5
        /// <summary>
        /// Remove an existing CompanyCar 
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var model = CompanyCarRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            var result = CompanyCarRepository.Remove(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
            
        }
    }
}
        
   
