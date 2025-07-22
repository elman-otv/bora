namespace Bora.Domain.Dtos.Task;

public record CreateTaskDto(string Title, string Description, DateTime DueDate, long ProjectId);