﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public interface ISpecialOffer
    {
        Item ItemOffer { get; set; }
        int Quantity { get; set; }
    }
}
