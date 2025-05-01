
using System.ComponentModel.DataAnnotations;

namespace Module.WorkItemService.Shared.Enums;
public enum WorkItemStatusEnum
{
    [Display(Description = "Pendiente")]
    Pending,
    [Display(Description = "Completado")]
    Completed,
}