using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class TblObjave
{
    public int IdObjave { get; set; }

    public int IdKorisnika { get; set; }

    public string Naslov { get; set; } = null!;

    public string Sadrzaj { get; set; } = null!;

    public string? Slika { get; set; }

    public int? BrojPregleda { get; set; }

    public virtual ICollection<TblLajkovi> TblLajkovis { get; } = new List<TblLajkovi>();

    public virtual ICollection<TblPregledi> TblPregledis { get; } = new List<TblPregledi>();
}
