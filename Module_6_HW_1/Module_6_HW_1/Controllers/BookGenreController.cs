using Microsoft.AspNetCore.Mvc;
using Module_6_HW_1.ClassProperties;

namespace Module_6_HW_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookGenreController : ControllerBase
    {
        private static readonly string[] BookGenreNames = new[] 
        {
            "Fiction", "Science Fiction", "Fantasy", "Mysteries", "Thrillers", "Psychological", "Poetry", "Classical Literature"
        };

        private static readonly string[] Descriptions = new[]
        {
            "Very Boring", "Boring", "Not Bad", "Cool", "Very Cool"
        };

        private readonly ILogger<BookGenreController> _logger;
        private Random _random;

        public BookGenreController(ILogger<BookGenreController> logger)
        {
            _logger = logger;
            _random = new Random();
        }

        [HttpGet(Name = "GetBookGenre")]
        public IEnumerable<BookGenre> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new BookGenre
            {
                Id = _random.Next(5, 100),
                Description = Descriptions[_random.Next(Descriptions.Length)],
                BookGenreName = BookGenreNames[_random.Next(BookGenreNames.Length)]
            })
            .ToArray();
        }
    }
}
