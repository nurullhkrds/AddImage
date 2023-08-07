using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApi.DTOs;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StundetsController : Controller
    {

        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository ımageRepository;



        public StundetsController(IStudentRepository studentRepository, IMapper mapper, IImageRepository ımageRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.ımageRepository = ımageRepository;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));
        }



        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            var validExtensions = new List<string>
            {
               ".jpeg",
               ".png",
               ".gif",
               ".jpg"
            };

            if (profileImage != null && profileImage.Length > 0)
            {
                var extension = Path.GetExtension(profileImage.FileName);
                if (validExtensions.Contains(extension))
                {
                    var res = studentRepository.GetStudentAsync(studentId);
                    if (await res!=null)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                        var fileImagePath = await ımageRepository.Upload(profileImage, fileName);

                        if (await studentRepository.UpdateProfileImage(studentId, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }

                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }

                return BadRequest("This is not a valid Image format");
            }

            return NotFound();
        }



    }
}
