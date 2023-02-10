using System.ComponentModel.DataAnnotations;
using Validation;

namespace Models;
public class Value
{
    public Guid Id { get; set; }
    public string NameFile { get; set; }
    [ValidJoinDate]
    public DateTime Date { get; set; }
    [Range(0, int.MaxValue)]
    public int Time { get; set; }
    [Range(0, float.MaxValue)]
    public float Indicator { get; set; }
}