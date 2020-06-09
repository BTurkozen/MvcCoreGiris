using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.EntityFrameworkCore;
using MvcCoreGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreGiris.Components
{
    public enum TextColor { danger, info, warning, success, primary, secondary, dark, light}
    public class SansliKisiViewComponent : ViewComponent
    {
        private readonly OkulDbContex okulDbContex;

        public SansliKisiViewComponent(OkulDbContex okulDbContex)
        {
            this.okulDbContex = okulDbContex;
        }
        public async Task<IViewComponentResult> InvokeAsync(TextColor renk)
        {
            var adet = await okulDbContex.Kisiler.CountAsync();
            var index = new Random().Next(adet);
            var kisi = await okulDbContex.Kisiler.Skip(index).FirstOrDefaultAsync();
            ViewBag.renk = Enum.GetName(renk.GetType(), renk);
            return View(kisi);
        }
    }
}
