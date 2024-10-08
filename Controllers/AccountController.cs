using Microsoft.AspNetCore.Authentication; // Para SignInAsync
using Microsoft.AspNetCore.Mvc;
using Gestion_Del_Presupuesto.Models;
using System.Security.Claims; // Para ClaimsIdentity
using System.Threading.Tasks;
using System.Collections.Generic; // Para List<Claim>

public class AccountController : Controller
{
    // Se eliminan UserManager y SignInManager
    public AccountController() { }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        // Definir un usuario y contraseña por defecto
        const string defaultEmail = "admin@universidadcentral.cl"; // Email predeterminado
        const string defaultPassword = "Admin123!"; // Contraseña predeterminada

        if (ModelState.IsValid)
        {
            // Verificar si las credenciales coinciden con el usuario y contraseña predeterminados
            if (model.Email == defaultEmail && model.Password == defaultPassword)
            {
                // Si coinciden, iniciar sesión manualmente
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email)
            };

                var claimsIdentity = new ClaimsIdentity(claims, "login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Iniciar sesión
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home"); // Asegúrate de redirigir aquí
            }

            ModelState.AddModelError(string.Empty, "Intento de inicio de sesión inválido.");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        // Al no tener base de datos, podemos mostrar un mensaje que no se puede registrar
        ModelState.AddModelError(string.Empty, "El registro está deshabilitado temporalmente.");
        return View(model);
    }
}
