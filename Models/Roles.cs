using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class Roles
    {
        public Roles() { }
        public Roles(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}