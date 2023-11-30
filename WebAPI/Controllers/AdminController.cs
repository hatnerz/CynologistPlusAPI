using Microsoft.AspNetCore.Mvc;
using WebAPI.DI;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Others.GlobalEnums;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDbControlService _dbControlService;

        public AdminController(IDbControlService dbControlService)
        {
            _dbControlService = dbControlService;
        }

        [HttpPost("db/backup")]
        public IActionResult BackupDb()
        {
            try
            {
                _dbControlService.CreateDbBackup();
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Internal error during DB backup", details = ex.ToString() });
            }
        }

        [HttpPost("db/restore")]
        public IActionResult RestoreDb()
        {
            try
            {
                _dbControlService.RestoreDbFromLastBackup();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error during restoring DB", details = ex.ToString() });
            }
        }

        [HttpGet("db/lastbackup")]
        public async Task<ActionResult<DateTime?>> GetLastBackupDate()
        {
            DateTime? backupDate = _dbControlService.GetLastBackupDate();
            if (backupDate == null)
                return NotFound();
            else
                return backupDate;
        }
    }
}

