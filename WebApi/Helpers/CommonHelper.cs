using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public static class CommonHelper
    {
        public static IEnumerable<TodoTask> GetQueryableList(IEnumerable<Filter> filters, IQueryable<TodoTask> todoTask)
        {
            var conditions = new List<Expression<Func<TodoTask, bool>>>();
            foreach (var filter in filters)
            {
                if (filter.Key == "City")
                {
                    Expression<Func<TodoTask, bool>> c1 = p => p.City.Equals(filter.Value);
                    conditions.Add(c1);
                }
                if (filter.Key == "assignedTo")
                {
                    Expression<Func<TodoTask, bool>> c2 = p => p.AssignedTo.Equals(filter.Value);
                    conditions.Add(c2);
                }
            }

            var query = new List<TodoTask>();
            foreach (var andQuery in conditions)
            {
                var subQuery = todoTask;
                subQuery = subQuery.Where(andQuery);
                query.AddRange(subQuery.AsEnumerable<TodoTask>());
            }

            return query;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidRequest(TodoTaskModel model)
        {
            return model != null && IsValidEmail(model.AssignedTo);
        }
    }
}
