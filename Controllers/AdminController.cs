using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles="Admin")]
public class AdminController : Controller
{
    public IActionResult UserManagement() => View();
    public IActionResult Reports() => View();
}