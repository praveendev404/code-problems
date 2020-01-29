using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models.ViewModels
{
    public class UIEmployee
    {
        public List<Gender> Gender { get; set; }
        public List<Country> Country { get; set; }
    }
}