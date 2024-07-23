using System;
using System.Collections.Generic;

namespace Blog2.Models;

public partial class KorisnikObjaveView
{
    public string Username { get; set; } = null!;

    public string? Naslov { get; set; }

    public string? Sadrzaj { get; set; }

    public string? Slika { get; set; }
}
