using System.ComponentModel.DataAnnotations;
using Validation;

namespace TaskTestWebApi.Models;

public class Value
{
    public Guid Id { get; set; }
    [ValidJoinDate]
    public DateTime Date { get; set; }
    [Range(0, int.MaxValue)]
    public int Time { get; set; }
    [Range(0, float.MaxValue)]
    public float Indicator { get; set; }
    public string Namefile { get; set; }  
}