using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.DocumentDetail)]
    public sealed record DocumentDetailRecord
    {
        [Column(DocumentDetail.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(DocumentDetail.DocumentId)]
        public int DocumentID { get; init; }

        [Column(DocumentDetail.DocumentNumber)]
        public string DocumentNumber { get; init; } = string.Empty;

        [Column(DocumentDetail.DocumentDateOut)]
        public DateTime? DocumentDateOut { get; init; }

        [Column(DocumentDetail.DocumentDateIn)]
        public DateTime? DocumentDateIn { get; init; }

        [Column(DocumentDetail.Quantity)]
        public decimal Quantity { get; init; }

        [Column(DocumentDetail.Sum)]
        public decimal Sum { get; init; }

        [Column(DocumentDetail.TotalSum)]
        public decimal TotalSum { get; init; }

        [Column(DocumentDetail.EquipmentId)]
        public int EquipmentID { get; init; }

        [Column(DocumentDetail.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}