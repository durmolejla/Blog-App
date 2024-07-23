using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class TblLajkovi
{
    public int IdLike { get; set; }

    public int IdKorisnika { get; set; }

    public int IdObjave { get; set; }

    public virtual TblObjave IdObjaveNavigation { get; set; } = null!;
}
