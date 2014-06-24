using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Turton.DAL.Context;
using Turton.Domain.DAL;
using Turton.Domain.Models;

namespace Turton.DAL.Repositories
{
    public class InMemoryRepository<TEntity> : ITurtonRepository<TEntity> 
                                                where TEntity: class
    {

        private InMemoryContext _context;
        internal List<TEntity> _list;

        public InMemoryRepository(InMemoryContext context)
        {
            _context = context;

            _list = ((List<TEntity>)//cast to ienumerable (list)
                                _context.EntityDictionary[typeof(TEntity)]);//entry in dictionary where of type tentity
            
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            if (filter != null)
                _list = _list
                          .Where(filter.Compile()).ToList();//add where clause, compile to correct syntax

            //difficult to include for static
            //foreach (var includeProperty in includeProperties.Split
            //    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
                      
            //}

            //if (orderBy != null)
            //    return list.OrderBy(g => g.Equals)

            return
                _list;
        }

        public TEntity GetByID(object id)
        {

            return
                _list
                    .FirstOrDefault(x => 
                                        Int32.Parse((x.GetType().GetProperty("ID").GetValue(x, null)).ToString()) //use refelction to get value of ID
                                        == Int32.Parse(id.ToString())); //where id = id
        }

        public TEntity Insert(TEntity entity)
        {
            /*****get last id added so can give entity new id*****/
            var lastelement = _list.OrderBy(x => x.GetType().GetProperty("ID")).Last(); //get last element

            //get last element added to list
            PropertyInfo lastelementobject = lastelement.GetType().GetProperty("ID");

            //get value of last element
            //www.devx.com/vb2themax/Tip/19598
            var lastelementval = lastelementobject.GetValue(lastelement, null);

            //add 1 to id of last element's id
            lastelementval = (int)lastelementval + 1;
            
            /******get value of entity to be added, set id to the new one created above*****/
            PropertyInfo newid = entity.GetType().GetProperty("ID");
            newid.SetValue(entity, lastelementval);
            _list.Add(entity);
            return entity;
        }

        public void Delete(object id)
        {
            TEntity entity = _list
                                .FirstOrDefault(x =>
                                        Int32.Parse((x.GetType().GetProperty("ID").GetValue(x, null)).ToString()) //use refelction to get value of ID
                                        == Int32.Parse(id.ToString())); //where id = id
            _list.Remove(entity);
        }

        public void Delete(TEntity entityToDelete)
        {
            _list.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            TEntity entity = _list.SingleOrDefault(x => x == entityToUpdate);
            entity = entityToUpdate;
        }
    }
}
