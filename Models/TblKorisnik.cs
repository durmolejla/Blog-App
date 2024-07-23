using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class TblKorisnik
{
    public int IdKorisnika { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? DatumRodjena { get; set; }
}
