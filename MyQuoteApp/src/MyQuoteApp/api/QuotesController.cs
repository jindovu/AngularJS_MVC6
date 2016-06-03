using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MyQuoteApp.models;
using System.Linq;

namespace MyQuoteApp.api
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private QuotesAppContext _dbContext;
        public QuotesController(QuotesAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            //return new List<Quote>()
            //{
            //    new Quote {Id = 1, Content = "Content 1 ", Author = "HoaVT1" },
            //    new Quote {Id = 2, Content = "Content 2 ", Author = "ChinhBV" },
            //    new Quote {Id = 3, Content = "Content 3 ", Author = "TuanVM" },
            //};
            return _dbContext.Quotes;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quote = _dbContext.Quotes.FirstOrDefault(c => c.Id == id);
            if (quote != null)
            {
                return new ObjectResult(quote);
            }

            return new HttpNotFoundResult();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            if (ModelState.IsValid)
            {
                if (quote.Id == 0)
                {
                    _dbContext.Add(quote);
                    _dbContext.SaveChanges();

                    return new ObjectResult(quote);
                }
                else
                {
                    var existQuote = _dbContext.Quotes.FirstOrDefault(c => c.Id == quote.Id);
                    existQuote.Content = quote.Content;
                    existQuote.Author = quote.Author;
                    _dbContext.SaveChanges();

                    return new ObjectResult(quote);
                }
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Quote quote)
        {
            var existQuote = _dbContext.Quotes.FirstOrDefault(c => c.Id == quote.Id);
            existQuote.Content = quote.Content;
            existQuote.Author = quote.Author;
            _dbContext.SaveChanges();

            return new ObjectResult(quote);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quocte = _dbContext.Quotes.FirstOrDefault(c => c.Id == id);
            if(quocte != null)
            {
                _dbContext.Quotes.Remove(quocte);
                _dbContext.SaveChanges();

                return new HttpStatusCodeResult(200);
            }
            return new HttpNotFoundResult();
        }
    }
}
