using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.DocumentDetail)]
    public sealed record DocumentDetailRecord
    {
        [Column(DocumentDetail.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Column(DocumentDetail.DocumentId)]
        public int DocumentID { get; set; }

        [Column(DocumentDetail.DocumentNumber)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Column(DocumentDetail.DocumentDateOut)]
        public DateTime? DocumentDateOut { get; set; }

        [Column(DocumentDetail.DocumentDateIn)]
        public DateTime? DocumentDateIn { get; set; }

        [Column(DocumentDetail.Quantity)]
        public decimal Quantity { get; set; }

        [Column(DocumentDetail.Sum)]
        public decimal Sum { get; set; }

        [Column(DocumentDetail.TotalSum)]
        public decimal TotalSum { get; set; }

        [Column(DocumentDetail.EquipmentId)]
        public int EquipmentID { get; set; }

        [Column(DocumentDetail.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}