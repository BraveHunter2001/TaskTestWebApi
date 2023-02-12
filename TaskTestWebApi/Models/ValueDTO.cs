using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using Validation;

namespace TaskTestWebApi.Models;
[Delimiter(";")]
public class ValueDTO
{
    [Format("yyyy-MM-dd_hh-mm-ss")]
    [ValidJoinDate]
    [Index(0)]
    public DateTime Date { get; set; }
    [Range(0, int.MaxValue)]
    [Index(1)]
    public int Time { get; set; }
    [Range(0, float.MaxValue)]
    [Index(2)]
    public float Indicator { get; set; }
}

