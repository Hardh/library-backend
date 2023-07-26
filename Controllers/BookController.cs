using library_backend.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace library_backend.Controllers;

[ApiController]
[Route("book")]
public class BookController: ControllerBase
{
   
    [Authorize]
    [HttpGet(Name = "list")]
    public  IResult saveTest()
    {

        var book1 = new BookRedis { name = "Nome 1", author = "Author 1" };
        var book2 = new BookRedis { name = "Nome 2", author = "Author 2" };

        using (var redisClient = new RedisClient("localhost", 6379, "password"))
        {

            redisClient.Set<BookRedis>(book1.key.ToString(), book1);
            redisClient.Set<BookRedis>(book2.key.ToString(), book2);

            var allKeys = redisClient.GetAllKeys();
            var list = redisClient.GetValues<BookRedis>(allKeys);
            
            return Results.Ok(list);
        }
       
    }

}