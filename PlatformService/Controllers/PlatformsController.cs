using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;
public class PlatformsController : PlatformsControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platforms = _repository.GetPlatforms().ToList();
        var response = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetPlatform(int id)
    {
        var platform = _repository.GetPlatform(id);
        if (platform == null)
            return NotFound();
        var response = _mapper.Map<PlatformReadDto>(platform);
        return Ok(response);
    }
    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto request)
    {
        var platform = _mapper.Map<Platform>(request);
        _repository.CreatePlatform(platform);
        _repository.SaveChanges();
        var response = _mapper.Map<PlatformReadDto>(platform);
        return CreatedAtAction(nameof(GetPlatform), new { id = response.Id }, response);
    }
}