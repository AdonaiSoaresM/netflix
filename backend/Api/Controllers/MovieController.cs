using API.Extensions;
using Domain.Commands.AddMovie;
using Domain.Commands.DeleteMovie;
using Domain.Commands.GetMovies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new GetMoviesRequest());

            if (response.Sucess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize]
        [HttpGet("files/{id}/{filename}")]
        public Task<FileStreamResult> Media(string id, string filename)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", id, filename);

            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1000, false);

            var mimeType = Path.GetExtension(path) == ".m3u8" ? "application/vnd.apple.mpegurl" : "image/jpeg";

            var file = File(stream, contentType: mimeType, enableRangeProcessing: true);

            return Task.FromResult(file);
        }


        [HttpPost("add")]
        [DisableRequestSizeLimit,
        RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Add(IFormCollection formData)
        {
            AddMovieRequest requestMediator;

            try
            {
                if (formData == null) throw new Exception("Out");
                requestMediator = new AddMovieRequest(formData);
            }
            catch
            {
                return BadRequest(new { err = "Check the fields" });
            }

            var response = await _mediator.Send(requestMediator);

            if (response.Sucess)
            {
                await MovieFiles.SaveFiles(response.Data, formData.Files);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(IFormFile arquivo)
        {
            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            string pathMp4 = Path.Combine(pathFolder, "teste.mp4");

            using (var stream = new FileStream(pathMp4, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return Ok();
        }
        [HttpDelete("files/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteMovieRequest(id));

            if (response.Sucess)
            {
                await MovieFiles.DeleteFiles(id);
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}