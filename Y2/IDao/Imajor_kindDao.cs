﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    public interface Imajor_kindDao<T>:TSelectUpdateDelete<T> where T:class
    {
        object login(string name, string pwd);//登录
    }
}