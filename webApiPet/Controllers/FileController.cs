using Microsoft.AspNetCore.Mvc;
using webApiPet.Model;

namespace webApiPet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpPost]
    public ActionResult Post([FromForm] FileModel file)
    {
        try
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.FormFile.CopyTo(stream);
            }

            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #region
    // GET: api/<FileController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/<FileController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    // POST api/<FileController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    // PUT api/<FileController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<FileController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
    #endregion
}
