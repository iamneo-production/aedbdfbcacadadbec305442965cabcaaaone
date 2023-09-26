using System;
using System.Collections.Generic;

namespace dotnetmicroserviceone.Models;
public class Call
{
    public int CallID { get; set; }
    public string ExecutiveID { get; set; }
    public string CustomerID { get; set; }
    public string CallType { get; set; }
    public DateTime CallDate { get; set; }
    public string CallStatus { get; set; }

}
