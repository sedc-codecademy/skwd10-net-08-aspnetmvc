﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Domain.Models
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}