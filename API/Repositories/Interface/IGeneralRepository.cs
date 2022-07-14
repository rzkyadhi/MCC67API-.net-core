using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IGeneralRepository<TModel>
        where TModel : class
    {
        // Get List of Data or Get All
        /*List<TModel> Get();*/

        // Get By Id
        TModel Get(int id);

        // Post
        int Post(TModel model);

        // Put
        int Put(TModel model);

        // Delete
        int Delete(TModel model);
    }
}