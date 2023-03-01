using System.ComponentModel.DataAnnotations;
using Validation;

namespace TaskTestWebApi.Models;

public class Value
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int Time { get; set; }
    public float Indicator { get; set; }
    public string Namefile { get; set; }  
}