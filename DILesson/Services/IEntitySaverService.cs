using DILesson.DTOs;
using System.Threading.Tasks;

namespace DILesson.Services
{
    public interface IEntitySaverService
    {
        Task SaveEntity(EntityDTO entity);
    }
}
