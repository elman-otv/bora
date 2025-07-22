using Bora.Data;
using Bora.Domain.Dtos.Task;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Bora.Domain.Entities.Task;
using TaskStatus = Bora.Domain.Entities.TaskStatus;

namespace Bora.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TaskController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
    {
        var tasks = await _context.Tasks.ToListAsync();
        
        var taskDtos = tasks.Select(t => new TaskDto(t.Id, t.Title, t.Description)).ToList();

        return taskDtos;
    }   
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> GetTask(long id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        
        if(task == null)
            return NotFound();

        var taskDto = new TaskDto(task.Id, task.Title, task.Description);
        
        return taskDto;
    }

    [HttpPost]
    public async Task<ActionResult<Bora.Domain.Entities.Task>> CreateTask(CreateTaskDto dto)
    {
        // Пока нет авторизации
        long creatorUserId = 1; // В будущем: long.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
        
        var newTask = new Task()
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Status = TaskStatus.ToDo,
            CreatedAt = DateTime.UtcNow,
            ProjectId = dto.ProjectId,
            CreatedById = creatorUserId
        };
        
        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync();
        
        var taskDto = new TaskDto(newTask.Id, newTask.Title, newTask.Description);
        
        return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, taskDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Bora.Domain.Entities.Task>> UpdateTask(long id, Bora.Domain.Entities.Task task)
    {
        if(id != task.Id)
            return BadRequest();
        
        _context.Entry(task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tasks.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Bora.Domain.Entities.Task>> DeleteTask(long id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if(task == null)
            return NotFound();
        
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    
}