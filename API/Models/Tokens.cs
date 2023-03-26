﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class Tokens
{
    [Key]
    public int idToken { get; set; }

    public int? idUsuario { get; set; }

    public string? Token { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? Expiration { get; set; }

    public bool? Active { get; set; }
}
