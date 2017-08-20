﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Models
{
    [Serializable]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}