using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeLibrary
{
    public static class OrderAnalyzer
    {
        public static List<DateTime> GetPopularMonths(List<DateTime> orderDates)
        {

            var groupedDates = orderDates.GroupBy(date => new { date.Year, date.Month });

            var monthlyOrderCounts = groupedDates.Select(group => new { Month = group.Key, Count = group.Count() });

            var sortedMonths = monthlyOrderCounts.OrderByDescending(month => month.Count);

            var result = sortedMonths.Select(month => new DateTime(month.Month.Year, month.Month.Month, 1));

            return result.ToList();
        }
    }
}