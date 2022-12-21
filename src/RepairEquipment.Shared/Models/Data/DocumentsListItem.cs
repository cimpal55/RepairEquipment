namespace RepairEquipment.Shared.Models.Data
{
    public sealed class DocumentsListItem
    {
        private readonly string _id;
        public DocumentsListItem(int key) 
        {
            _id = key.ToString();
        }

        public int ID { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;

        public string? Client { get; set; } = string.Empty;

        public int? ClientID { get; set; }

        public string? Employee { get; set; } = string.Empty;

        public int? EmployeeID { get; set; }
    }
}