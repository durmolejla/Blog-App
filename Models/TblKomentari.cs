using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class TblKomentari
{
    public int IdKomentara { get; set; }

    public int IdKorisnika { get; set; }

    public int IdObjave { get; set; }

    public string Sadrzaj { get; set; } = null!;
}
