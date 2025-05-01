
using System.ComponentModel.DataAnnotations;

namespace Module.WorkItemApp.Shared.Enums;
public enum WorkItemStatusEnum
{
    [Display(Description = "Pendiente")]
    Pending,
    [Display(Description = "Completado")]
    Completed,
}