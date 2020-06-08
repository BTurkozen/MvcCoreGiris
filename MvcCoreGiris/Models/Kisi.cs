using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Models
{
    public class Kisi
    {
        public int Id { get; set; }

        [Required, DisplayName("Kişi Adı")]
        public string KisiAd { get; set; }
    }
}
