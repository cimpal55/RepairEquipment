namespace RepairEquipment.Shared.Models.Data
{
    public sealed class DocumentsListItem
    {
        public DocumentsListItem(int key) { }
        public int ID { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string? Client { get; set; } = string.Empty;
        public int? ClientID { get; set; }
        public string? Employee { get; set; } = string.Empty;
        public int? EmployeeID { get; set; }
    }
}