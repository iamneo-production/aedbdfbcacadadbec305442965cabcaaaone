using System;
using System.Collections.Generic;

namespace dotnetmicroservicetwo.Models;
public class Complaint
{
    public int ComplaintID { get; set; }
    public string CustomerID { get; set; }
    public string ComplaintType { get; set; }
    public DateTime ComplaintDate { get; set; }
    public string ComplaintStatus { get; set; }


}
