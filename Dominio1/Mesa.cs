﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Mozo Mozo { get; set; }
    }
}
