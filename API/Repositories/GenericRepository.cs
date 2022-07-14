﻿using API.Context;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class GenericRepository<TModel> :
        IGeneralRepository<TModel>
        where TModel : class
    {
        MyContext myContext;

        public GenericRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<TModel> Get()
        {
            var data = myContext.Set<TModel>().ToList();
            return data;
        }

        public TModel Get(int id)
        {
            var data = myContext.Set<TModel>().Find(id);
            return data;
        }

        public int Post(TModel model)
        {
            myContext.Set<TModel>().Add(model);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Put(TModel model)
        {
            myContext.Set<TModel>().Update(model);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Delete(TModel model)
        {
            myContext.Set<TModel>().Remove(model);
            var data = myContext.SaveChanges();
            return data;
        }
    }
}