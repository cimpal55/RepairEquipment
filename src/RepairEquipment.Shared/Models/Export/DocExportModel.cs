namespace RepairEquipment.Shared.Models.Export
{
    public sealed record DocExportModel
    {
        public string? Client { get; init; }

        public int? ClientId { get; init; }

        public string? ClientRegistrationNr { get; init; } = string.Empty;

        public string? ClientContactPerson { get; init; } = string.Empty;

        public string? Employee { get; init; }

        public int? EmployeeId { get; init; }

        public string Equipment { get; init; } = string.Empty;

        public int EquipmentId { get; init; }

        public string DocumentNumber { get; set; } = string.Empty;

        public string DocumentDetailNumber { get; set; } = string.Empty;

        public DateTime? DocumentDateOut { get; set; }

        public DateTime? DocumentDateIn { get; set; }

        public decimal Quantity { get; set; }

        public decimal Sum { get; set; }

        public decimal TotalSum { get; set; }
    }
}
