using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BogSimpleRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoegerController : ControllerBase
    {

        #region InstanceFields

        private static readonly List<Bog> _bøger = new List<Bog>()
        {
            new Bog("We are number 1", "Robbie Rotten", 1000, "lazytown12345"),
            new Bog("Za Warudo", "Dio Brando", 100, "tokiyotomare0"),
            new Bog("How to cook", "Gordon Ramsay", 437, "lambsauce6666"),
            new Bog("Know your memes", "Proffessor meme", 333, "douknowdawae5"),
            new Bog("The Swallow Zireael", "Ciri", 999, "witcherisdwae"),
            new Bog("White Wolf", "Geralt of Rivia", 597, "onthetrail908")
        };

        #endregion

        // GET: api/Bøger
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return _bøger;
        }

        // GET: api/Bøger/5
        [HttpGet]
        [Route("{isbn13}")]
        public Bog Get(string isbn13)
        {
            return _bøger.Find(b => b.Isbn13 == isbn13);
        }

        // POST: api/Bøger
        [HttpPost]
        public void Post([FromBody] Bog bog)
        {
            _bøger.Add(bog);
        }

        // PUT: api/Bøger/5
        [HttpPut]
        [Route("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog bog)
        {
            Bog bogToUpdate = Get(isbn13);
            if (bogToUpdate != null)
            {
                bogToUpdate.Titel = bog.Titel;
                bogToUpdate.Forfatter = bog.Forfatter;
                bogToUpdate.Sidetal = bog.Sidetal;
                bogToUpdate.Isbn13 = bog.Isbn13;

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog bogToDelete = Get(isbn13);
            _bøger.Remove(bogToDelete);
        }
    }
}
