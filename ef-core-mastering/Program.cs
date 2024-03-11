using ef_core_mastering.Context;
using ef_core_mastering.DatedServices;
using ef_core_mastering.Models;
using System.Diagnostics.Metrics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

prev11032024 service = new prev11032024();
foreach (var item in service.GetProfiles())
{
    Console.WriteLine(item);
};
