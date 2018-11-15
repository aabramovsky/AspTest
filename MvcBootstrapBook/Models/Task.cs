using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace MvcBootstrapBook.Models
{
  public class Task
  {
    static int numObjects = 0;

    public Task()
    {
      numObjects++;
      Debug.WriteLine("!!!!!!! Task object created: {0}", numObjects);
    }

    public string Text { get; set; }
    public bool IsCompleted { get; set; }
  }
}