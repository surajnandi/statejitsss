using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
public partial class DashboardView
{
    [Column("id")]
    public long? Id { get; set; }

    [Column("total_agencies")]
    public long? TotalAgencies { get; set; }

    [Column("new_agencies")]
    public long? NewAgencies { get; set; }

    [Column("total_scheme_component")]
    public long? TotalSchemeComponent { get; set; }

    [Column("new_scheme_component")]
    public long? NewSchemeComponent { get; set; }

    [Column("total_scheme_config")]
    public long? TotalSchemeConfig { get; set; }

    [Column("new_scheme_config")]
    public long? NewSchemeConfig { get; set; }

    [Column("total_vendor")]
    public long? TotalVendor { get; set; }

    [Column("new_vendor")]
    public long? NewVendor { get; set; }
}
