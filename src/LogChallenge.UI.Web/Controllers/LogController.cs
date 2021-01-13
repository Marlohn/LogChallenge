using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LogChallenge.UI.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogApplication _LogApplication;

        public LogController(ILogApplication LogApplication)
        {
            _LogApplication = LogApplication;
        }

        // GET: LogController
        public async Task<IActionResult> Index(string host, string userAgent, DateTime? dateTime)
        {
            if (!string.IsNullOrEmpty(host))
            {
                return View(await _LogApplication.Where(a => a.Host == host));
            }

            if (!string.IsNullOrEmpty(userAgent))
            {
                return View(await _LogApplication.Where(a => a.UserAgent == userAgent));
            }

            if (dateTime != null)
            {
                return View(await _LogApplication.Where(a => a.DateTime == dateTime));
            }

            return View(await _LogApplication.List());
        }

        // GET: LogController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _LogApplication.GetById(id));
        }

        // GET: LogController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: LogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LogDto logDto)
        {
            try
            {
               await _LogApplication.LogAdd(logDto);

                if (logDto.Notifications.Any())
                {
                    foreach (var notification in logDto.Notifications)
                    {
                        ModelState.AddModelError(notification.PropertyName, notification.Message);
                    }

                    return View("Create", logDto);
                }
            }
            catch
            {
                return View("Create", logDto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LogController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _LogApplication.GetById(id));
        }

        // POST: LogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LogDto logDto)
        {
            try
            {
                await _LogApplication.LogUpdate(logDto);

                if (logDto.Notifications.Any())
                {
                    foreach (var notification in logDto.Notifications)
                    {
                        ModelState.AddModelError(notification.PropertyName, notification.Message);
                    }

                    return View("Edit", logDto);
                }
            }
            catch
            {
                return View("Edit", logDto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LogController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _LogApplication.GetById(id));
        }

        // POST: LogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, LogDto logDto)
        {
            try
            {
                await _LogApplication.Delete(await _LogApplication.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _LogApplication.GetById(id));
            }
        }

        public async Task<IActionResult> Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("file not selected");
            }

            var LogList = await _LogApplication.ConvertFileToLog(file);
            return View("Import", await _LogApplication.LogAddRange(LogList));
        }
    }
}
