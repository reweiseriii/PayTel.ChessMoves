using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PayTel.ChessMoves.Library.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayTel.ChessMoves.API
{
    [Route("[controller]")]
    public class ChessMovesController : Controller
    {
        private static readonly Library.Lib.ChessMovesLib ChessMoves = new Library.Lib.ChessMovesLib();
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<ChessCoordinatesEntity> _validMoves = ChessMoves.GetValidMoves("King", "a1");
            yield return ChessMoves.GetChessMovesString(_validMoves);
        }

        // GET api/<controller>/5/a3
        [HttpGet("{chessPiece}/{coordinate}")]
        public IEnumerable<string> Get(string chessPiece, string coordinate)
        {
            List<ChessCoordinatesEntity> _validMoves = ChessMoves.GetValidMoves($"{chessPiece}", $"{coordinate}");
            yield return ChessMoves.GetChessMovesString(_validMoves);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
