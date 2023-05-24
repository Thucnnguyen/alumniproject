﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlumniProject.Entity;

public class School
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    [StringLength(int.MaxValue)]
    public string Description { get; set; }
    public string SubDomain { get; set; }
    public string BackGround1 { get; set; }
    public string BackGround2 { get; set; }
    public string BackGround3 { get; set; }
    public string Icon { get; set; }
    public string ProvinceName { get; set; }
    public string CityName { get; set; }
    public string Address { get; set; }
    public string Theme { get; set; }
    public bool RequestStatus { get; set; }
    public DateTime EndTime { get; set; }
    public string EvidenceUrl { get; set; }

    public bool Archived { get; set; }

    public virtual ICollection<Grade> Grade { get; set; }
    public virtual ICollection<Post> Post { get; set; }
    public virtual ICollection<New> New { get; set; }
    public virtual ICollection<Event> Event { get; set; }
    public virtual ICollection<Fund> Fund { get; set; }
}
