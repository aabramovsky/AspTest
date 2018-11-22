using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace MvcBootstrapBook.Models
{
  public class Task
  {
    public int Id { get; set; }
    public string Text { get; set; }

    [UIHint("BooleanButtonLabel")]
    public bool IsCompleted { get; set; }
  }
}