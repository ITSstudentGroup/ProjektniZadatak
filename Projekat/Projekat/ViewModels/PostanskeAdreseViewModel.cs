using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat.Models;

namespace Projekat.ViewModels
{
    public class PostanskeAdreseViewModel
    {
        public List<PostanskaAdresa> PostanskeAdrese { get; set; }
        public IEnumerable<OznakaPostanskeAdrese> OznakePostanskeAdrese { get; set; }
    }
}