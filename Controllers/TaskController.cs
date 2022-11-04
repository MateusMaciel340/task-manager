using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task_manager.Context;
using task_manager.Models;

namespace task_manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ContextOrganizer _context;

        public TaskController (ContextOrganizer context)
        {
            _context = context;
        }

        // POST - Adding Task
        [HttpPost]
        public IActionResult AddingTask (Assignment assignment)
        {
            _context.Add(assignment);
            _context.SaveChanges();

            return Ok(assignment);
        }

        // GET - Get all Tasks
        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks ()
        {
            var assignment = _context.Assignment.ToList();

            return Ok(assignment);
        }

        // GET - Searching by ID
        [HttpGet("{id}")]
        public IActionResult GetByIdTask (int id)
        {
            var assignment = _context.Assignment.Find(id);

            if (assignment == null)
                return NotFound();

            return Ok(assignment);
        }

        // GET - Search by Title
        [HttpGet("GetByTitleTask")]
        public IActionResult GetByTitleTask (string title)
        {
            var assignment = _context.Assignment.Where(x => x.Title.Contains(title));
            return Ok(assignment);
        }

        // GET - Search by Date
        [HttpGet("GetByDateTask")]
        public IActionResult GetByDateTask (DateTime date)
        {
            var assignment = _context.Assignment.Where(x => x.Date == date);
            return Ok(assignment);
        }
        
        // GET - Search by Status
        [HttpGet("GetByStatusTask")]
        public IActionResult GetByStatusTask (EnumStatusTask status)
        {
            var assignment = _context.Assignment.Where(x => x.Status == status);
            return Ok(assignment);
        }

        // PUT - Update Task
        [HttpPut("{id}")]
        public IActionResult UpdateTask (int id, Assignment assignment)
        {
            var assignmentDatabase = _context.Assignment.Find(id);

            if (assignmentDatabase == null)
                return NotFound();

            assignmentDatabase.Title = assignment.Title;
            assignmentDatabase.Date = assignment.Date;
            assignmentDatabase.Status = assignment.Status;

            _context.Assignment.Update(assignmentDatabase);
            _context.SaveChanges();

            return Ok(assignmentDatabase);
        }

        // DELETE - RemoveTask
        [HttpDelete("{id}")]
        public IActionResult RemoveTask (int id) 
        {
            var assignmentDatabase = _context.Assignment.Find(id);

            if (assignmentDatabase == null)
                return NotFound();

            _context.Assignment.Remove(assignmentDatabase);
            _context.SaveChanges();

            return NoContent();
        }
    }
}