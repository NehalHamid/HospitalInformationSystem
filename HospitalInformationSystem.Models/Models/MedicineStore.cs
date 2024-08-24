using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalInformationSystem.Models.Models;
[PrimaryKey(nameof(MedicineId), nameof(StoreId))]
public partial class MedicineStore
{
   
    public int MedicineId { get; set; }
    public int StoreId { get; set; }
    public DateOnly ProductionDate { get; set; }

    public DateOnly ExpiringDate { get; set; }

    public DateOnly Expiry { get; set; }

    public DateOnly DateOfReceipt { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public MedicinesAndItem? Medicine { get; set; }

    public Store? Store { get; set; }
}
