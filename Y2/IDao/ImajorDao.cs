﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    public interface ImajorDao<T>:TSelectUpdateDelete<T> where T:class
    {
    }
}
