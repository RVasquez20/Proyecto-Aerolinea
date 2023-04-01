﻿using System.ComponentModel.DataAnnotations;

namespace API.Models;

public partial class ComprasDetalle
{
    [Key]
    public int idComprasDetalle { get; set; }

    public int? idCompra { get; set; }

    public int? idVuelo { get; set; }

    public int? Cantidad { get; set; }
}
