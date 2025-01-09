using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Request;

namespace Domain.Helpers
{
    public static class FilterDataHelper
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, FiltersClientRequest filter)
        {
            if (string.IsNullOrWhiteSpace(filter.PropertyName) || string.IsNullOrEmpty(filter.PropertyName) || !PropertyExists<T>(filter.PropertyName))
                throw new InvalidOperationException($"No se puede filtrar por la propiedad {filter.PropertyName}.");

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression predicate = null;

            var propertyType = typeof(T).GetProperty(filter.PropertyName).PropertyType;


            if (propertyType.Name.ToLower().Contains("string") || propertyType.Name.ToLower().Contains("int"))
            {
                var property = Expression.Property(parameter, filter.PropertyName);

                if (propertyType.Name.ToLower().Contains("int"))
                {
                    var toStringMethod = propertyType.GetMethod("ToString", Type.EmptyTypes);
                    var propertyToString = Expression.Call(property, toStringMethod);

                    var value = Expression.Constant(filter.PropertyValue.ToLower());
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    predicate = Expression.Call(propertyToString, containsMethod, value);
                }
                else { 
                    var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                    var propertyToLower = Expression.Call(property, toLowerMethod);

                    var value = Expression.Constant(filter.PropertyValue.ToLower());
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    predicate = Expression.Call(propertyToLower, containsMethod, value);
                }
            }
            else if (propertyType.Name.ToLower().Contains("date"))
            {
                var property = Expression.Property(parameter, filter.PropertyName);
                var startDate = Expression.Constant(filter.StartDate);
                var endDate = Expression.Constant(filter.EndDate);

                var greaterThanOrEqual = Expression.GreaterThanOrEqual(property, startDate);
                var lessThanOrEqual = Expression.LessThanOrEqual(property, endDate);

                predicate = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);
            }


            if (predicate == null)
                throw new InvalidOperationException("La información enviada para realizar el filtro no es correcta; por favor verifique la información enviada en el filtro.");

            var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);

            query = query.Where(lambda);

            if (!string.IsNullOrWhiteSpace(filter.PropertyOrderBy) && !string.IsNullOrEmpty(filter.PropertyOrderBy) && PropertyExists<T>(filter.PropertyOrderBy))
            {
                query = query.ApplySorting(filter.PropertyOrderBy, filter.AscendingOrderBy);
            }

            return query;
        }


        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string orderByColumn, bool ascending)
        {
            if (string.IsNullOrWhiteSpace(orderByColumn))
                return query; // No aplicar orden si no se especifica columna

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, orderByColumn); // Accede a la propiedad
            var lambda = Expression.Lambda(property, parameter);

            // Construye el método de orden dinámico
            var methodName = ascending ? "OrderBy" : "OrderByDescending";
            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            return (IQueryable<T>)method.Invoke(null, new object[] { query, lambda });
        }


        public static bool PropertyExists<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName) != null;
        }

    }
}
