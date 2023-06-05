using System.Collections.Generic;
using System.Text;

namespace SFM.VehicleBuilder.Data.Extensions
{
    internal static class QueryExtensions
    {
        /// <summary>
        ///   Adds pagination support to a query.
        /// </summary>
        /// <param name="sql">The sql string to add paging support to.</param>
        /// <returns>Returns the updated query.</returns>
        public static string AddPagination(this string sql)
        {
            return $@"
                {sql}
                OFFSET (@pageNumber-1) * @pageSize ROWS
                FETCH NEXT @pageSize ROWS ONLY";
        }

        /// <summary>
        ///   Adds pagination support to a query.
        /// </summary>
        /// <param name="sql">The sql string to add paging support to.</param>
        /// <param name="columnMapping">The mapping of the Sort Column name to the database column name.</param>
        /// <returns>Returns the updated query.</returns>
        public static string AddSorting(this string sql, IDictionary<string, string> columnMapping)
        {
            var sb = new StringBuilder(sql);

            sb.Append(" ORDER BY ");

            foreach (var item in columnMapping)
            {
                sb.Append($@"
                    CASE WHEN @sortColumn = '{item.Key}' AND @sortDirection = 'ASC' THEN {item.Value} END,
                    CASE WHEN @sortColumn = '{item.Key}' AND @sortDirection = 'DESC' THEN {item.Value} END DESC,");
            }

            if (sb.ToString().EndsWith(","))
                sb.Length -= 1;

            return sb.ToString();
        }

        /// <summary>
        ///   Gets a query to retrive the total count of the records returned.
        /// </summary>
        /// <param name="sql">The sql string to get the Count of.</param>
        /// <returns>Returns the count query.</returns>
        public static string ToCountQuery(this string sql)
            => $@"SELECT COUNT (*) FROM ({sql}) AS query";
    }
}