﻿using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Location)]
    public sealed record LocationRecord
    {
        [Column(Location.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(Location.Name, CanBeNull = false)]
        public string Name { get; init; } = string.Empty;

        [Column(Location.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}
