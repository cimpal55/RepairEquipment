using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Document)]
    public sealed record DocumentRecord
    {
        [Column(Document.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; init; }
        
        [Column(Document.DocumentNumber, CanBeNull = false)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Column(Document.ClientId, CanBeNull = true)]
        public int? ClientId { get; set; }

        [Column(Document.EmployeeId, CanBeNull = true)]
        public int? EmployeeId { get; set; }

        [Column(Document.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}