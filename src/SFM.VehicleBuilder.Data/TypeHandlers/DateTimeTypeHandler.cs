using System;
using System.Data;
using Dapper;

namespace SFM.VehicleBuilder.Data.TypeHandlers
{
    /// <summary>
    ///   A type handler for dapper to deserialize/&gt; objects.
    /// </summary>
    public class DateTimeTypeHandler : SqlMapper.TypeHandler<DateTime?>
    {
        /// <inheritdoc/>
        public override DateTime? Parse(object value)
        => (DateTime?)(value == null ? (DateTime?)null : value is DateTime? ? value : DateTime.Parse(value.ToString()));

        /// <inheritdoc/>
        public override void SetValue(IDbDataParameter parameter, DateTime? value)
        {
            parameter.DbType = DbType.AnsiString;
            parameter.Value = (value ?? DateTime.MinValue) == DateTime.MinValue ? null : value;
        }
    }
}