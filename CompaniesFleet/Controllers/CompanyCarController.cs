using CompaniesFleet.Models;
using CompaniesFleet.Repositories;
using System.Linq;
using System.Web.Http;

namespace CompaniesFleet.Controllers
{
    [Authorize]
    [RoutePrefix("api/companycar")]
    public class CompanyCarController : ApiController
    {
        private ICompanyCarRepository _companyCarRepository;
        private ICategoryRepository _categoryRepository;

        public CompanyCarController(ICompanyCarRepository companyrepo, ICategoryRepository categoryrepo)
        {
            _companyCarRepository = companyrepo;
            _categoryRepository = categoryrepo;
        }

        public IHttpActionResult Get()
        {
            var model =  _companyCarRepository.GetAll();

            return Ok(model);
        }
        
        [Route("GetByCategory/{id}")]
        public IHttpActionResult GetByCategory(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var model = _companyCarRepository.GetAll(a=>a.CategoryId == id);

            return Ok(model);
        }

        public IHttpActionResult Get(int id)
        {

            if (id < 0)
            {
                return BadRequest();
            }
            var model = _companyCarRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }


            return Ok(model);
        }

        public IHttpActionResult Post(CompanyCarCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = _categoryRepository.GetById(model.Category);

            if (category == null)
            {
                return BadRequest("Invalid Category");
            }

            var CompanyCar = new CompanyCar();
            CompanyCar.Name = model.Name;
            CompanyCar.CategoryId = model.Category;

            var result = _companyCarRepository.Add(CompanyCar);

            if (result == null)
            {
                return BadRequest();
            }


            return Ok(result);
        }

        public IHttpActionResult Put(CompanyCarUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CompanyCar = _companyCarRepository.GetAll(a=>a.Id==model.Id).FirstOrDefault();

            if (CompanyCar == null)
            {
                return NotFound();
            }

            CompanyCar.Name = model.Name;
            CompanyCar.CategoryId = model.Category;

            var result = _companyCarRepository.Update(CompanyCar);
            return Ok(result);
        }

        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var model = _companyCarRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            var result = _companyCarRepository.Remove(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok(model);
            
        }
    }
}
        
   
