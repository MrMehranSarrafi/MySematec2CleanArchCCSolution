using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanarchGeneral.Application.Dto;

public class OrderDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsPaid { get; set; }

}
