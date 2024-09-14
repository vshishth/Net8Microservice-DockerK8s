using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepository
{
    bool SaveChanges();
    IQueryable<Platform> GetPlatforms();
    Platform GetPlatform(int id);
    void CreatePlatform(Platform platform);
}
