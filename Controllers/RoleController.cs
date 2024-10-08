using Microsoft.AspNetCore.Mvc;
using Gestion_Del_Presupuesto.Models;
using System.Collections.Generic;

public class RoleController : Controller
{
    public IActionResult Index()
    {
        // Lista de roles que vamos a mostrar
        var roles = new List<RoleViewModel>
        {
            new RoleViewModel { RoleName = "Director" },
            new RoleViewModel { RoleName = "Coordinador Santiago" },
            new RoleViewModel { RoleName = "Coordinador Coquimbo" }
        };

        // Enviar los roles a la vista
        return View(roles);
    }
}
