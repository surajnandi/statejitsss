using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statejitsss.DAL.Entities;

[Keyless]
[Table("mm_gen_department", Schema = "ifmsadmin")]
public partial class MmGenDepartment
{
    [Column("int_dept_id")]
    public int IntDeptId { get; set; }

    [Column("department_code")]
    [StringLength(2)]
    public string? DepartmentCode { get; set; }

    [Column("description")]
    [StringLength(200)]
    public string? Description { get; set; }

    [Column("demand_no")]
    [StringLength(2)]
    public string? DemandNo { get; set; }

    [Column("active_flag")]
    [StringLength(1)]
    public string? ActiveFlag { get; set; }

    [Column("created_user_id")]
    public int CreatedUserId { get; set; }

    [Column("modified_user_id")]
    public int ModifiedUserId { get; set; }

    [Column("created_timestamp")]
    public DateTime CreatedTimestamp { get; set; }

    [Column("modified_timestamp")]
    public DateTime ModifiedTimestamp { get; set; }

    [Column("dept_code")]
    [StringLength(60)]
    public string? DeptCode { get; set; }
}
