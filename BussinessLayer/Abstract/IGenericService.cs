﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(int id); 
        void TUpdate(T t);   
        List<T> TGetList(); 
        T TGetById(int id);
        //List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
