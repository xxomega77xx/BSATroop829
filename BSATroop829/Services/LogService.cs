using BSATroop829.Data;
using BSATroop829.Models;

namespace BSATroop829.Services
{
    public class LogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Log(string user, string action)
        {
            var logEntry = new LoggingViewModel
            {
                User = user ?? "Anonymous",
                Action = action,
                TimeStamp = DateTime.Now
            };
            _context.LogEnties.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
