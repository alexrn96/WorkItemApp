using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Module.WorkItemService.Shared.Enums;
public enum WorkItemPriorityEnum
{
    [Display(Description = "Alta")]
    High,
    [Display(Description = "Baja")]
    Low,
}