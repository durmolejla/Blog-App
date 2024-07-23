using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class TblPregledi
{
    public int IdPregleda { get; set; }

    public int IdObjave { get; set; }

    public virtual TblObjave IdObjaveNavigation { get; set; } = null!;
}
