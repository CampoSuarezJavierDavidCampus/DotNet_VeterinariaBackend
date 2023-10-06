namespace Core.Entities;
public class MedicationsSuppliers{
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public int MedicinesId { get; set; }
    public Medicine Medicines { get; set; } = null!;
}