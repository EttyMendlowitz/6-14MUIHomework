using _6_14MUIHomework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ReactMaaserTrackerMUI_Starter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaaserController : ControllerBase
    {
        private readonly string _connectionString;

        public MaaserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }


        [Route("addIncome")]
        [HttpPost]
        public void AddIncome(Income income)
        {
            var repo = new MaaserRepo(_connectionString);
            repo.AddIncome(income);
        }

        [Route("getincomes")]
        [HttpGet]
        public List<IncomeWithSource> GetIncomesWithSources()
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetIncomesWithSources();
        }

        [Route("getbysource")]
        [HttpGet]
        public List<Source> GetBySource()
        {
            var repo = new MaaserRepo(_connectionString);
            var list = repo.GetGroupedIncomes();
            return list;
        }

        [Route("getsources")]
        [HttpGet]
        public List<Source> GetSources()
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetSources();
        }

        [Route("addmaaser")]
        [HttpPost]
        public void AddMaaser(Maaser maaser)
        {
            var repo = new MaaserRepo(_connectionString);
            repo.AddMaaser(maaser);
        }

        [Route("getmaaser")]
        [HttpGet]
        public List<Maaser> GetMaaser()
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetMaaser();
        }

        [Route("deletesource")]
        [HttpPost]
        public void DeleteSource(Source source)
        {
            var repo = new MaaserRepo(_connectionString);
            repo.DeleteSource(source);
        }

        [Route("getsourceforstring")]
        [HttpGet]
        public Source GetSourceForString(string source)
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetSourceForString(source);
        }

        [Route("addsource")]
        [HttpPost]
        public void AddSource(Source source)
        {
            var repo = new MaaserRepo(_connectionString);
            repo.AddSource(source);
        }

        [Route("editsource")]
        [HttpPost]
        public void EditSource(Source source)
        {
            var repo = new MaaserRepo(_connectionString);
            repo.EditSource(source);
        }

        [Route("gettotalincome")]
        [HttpGet]
        public decimal GetTotalIncome()
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetTotalIncome();
        }

        [Route("gettotalmaaser")]
        [HttpGet]
        public decimal GetTotalMaaser()
        {
            var repo = new MaaserRepo(_connectionString);
            return repo.GetTotalMaaser();
        }
    }
}
