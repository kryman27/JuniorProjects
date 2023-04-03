using System;
using System.Collections.Generic;

namespace Notepad.Model;

public partial class Note
{
    public int Id { get; set; }

    public string? Note1 { get; set; }

    public DateTime CreatedOn { get; set; }
}
