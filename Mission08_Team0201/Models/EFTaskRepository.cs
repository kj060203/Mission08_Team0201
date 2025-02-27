using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0201.Models;

public class EFTaskRepository : ITaskRepository
{
    private Mission08DbContext _context;
    public EFTaskRepository(Mission08DbContext context)
    {
        _context = context;
    }
    
    public List<Task> Tasks => _context.Tasks.Include(t => t.Category).ToList();
    public List<Category> Categories => _context.Categories.ToList();

    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(Task task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
    
}