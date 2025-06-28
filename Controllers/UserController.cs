using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles="User")]
public class UserController : Controller
{
    public IActionResult Dashboard() => View();
    public IActionResult Profile() => View();
}