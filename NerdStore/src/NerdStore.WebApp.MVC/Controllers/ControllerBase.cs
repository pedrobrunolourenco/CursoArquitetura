using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = new Guid("c3c77fad-0528-47dc-b3b0-296144b80480");

    }
}
