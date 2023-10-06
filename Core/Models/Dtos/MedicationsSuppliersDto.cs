using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MedicationsSuppliersDto{
    [Required]
    public int SupplierId { get; set; }
    [Required]
    public int MedicinesId { get; set; }
}