using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer.Repository
{
    public class QueryResult<TEntity> where TEntity : BaseTable
    {
        public bool IsSuccess { get; private set; }

        public TEntity Entity { get; }

        public List<string> Errors { get; private set; }

        private QueryResult(TEntity entity)
        {
            Entity = entity;
        }

        private QueryResult()
        {
        }

        public static QueryResult<TEntity> Success(TEntity entity)
        {
            var result = new QueryResult<TEntity>(entity)
            {
                IsSuccess = true
            };
            return result;
        }

        public static QueryResult<TEntity> Failure()
        {
            var result = new QueryResult<TEntity>
            {
                IsSuccess = false, Errors = new List<string>()
            };
            return result;
        }

        public QueryResult<TEntity> AddError(params string[] errorMessages)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }
            Errors.AddRange(errorMessages);
            return this;
        }
    }
}