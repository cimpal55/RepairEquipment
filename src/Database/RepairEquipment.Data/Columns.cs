namespace RepairEquipment.Data
{
    public static class Columns
    {
        public static class Employee
        {
            public const string Id = "ID";
            public const string Code = "Code";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string PersonalCode = "PersonalCode";
            public const string Phone = "Phone";
            public const string Email = "Email";
            public const string Address = "Address";
            public const string Created = "Created";
        }
        public static class EquipmentType
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string FixedAssetNeeded = "FixedAssetNeeded";
            public const string Created = "Created";
        }
        public static class Equipment
        {
            public const string Id = "ID";
            public const string TypeId = "TypeID";
            public const string Location = "Location";
            public const string Name = "Name";
            public const string SerialNumber = "SerialNumber";
            public const string FixedAssetNr = "FixedAssetNr";
            public const string PurchaseDate = "PurchaseDate";
            public const string PurchaseSum = "PurchaseSum";
            public const string PurchaseInvoiceNr = "PurchaseInvoiceNr";
            public const string PurchaseInvoiceLink = "PurchaseInvoiceLink";
            public const string DepreciationPeriod = "DepreciationPeriod";
            public const string Depreciation = "Depreciation";
            public const string Notes = "Notes";
            public const string Created = "Created";
        }
        public static class EquipmentHistory
        {
            public const string Id = "ID";
            public const string EquipmentId = "EquipmentID";
            public const string ClientId = "ClientID";
            public const string EmployeeId = "EmployeeID";
            public const string Location = "Location";
            public const string DateOut = "DateOut";
            public const string DateIn = "DateIn";
            public const string Created = "Created";
        }
        public static class Document
        {
            public const string Id = "ID";
            public const string DocumentNumber = "DocumentNumber";
            public const string ClientId = "ClientID";
            public const string EmployeeId = "EmployeeID";
            public const string Status = "Status";
            public const string Created = "Created";
        }
        public static class DocumentDetail
        {
            public const string Id = "ID";
            public const string DocumentId = "DocumentID";
            public const string EquipmentId = "EquipmentID";
            public const string DocumentNumber = "DocumentNumber";
            public const string DocumentDate = "DocumentDate";
            public const string Quantity = "Quantity";
            public const string Sum = "Sum";
            public const string TotalSum = "TotalSum";
            public const string Created = "Created";
        }
        public static class Client
        {
            public const string Id = "ID";
            public const string Code = "Code";
            public const string Name = "Name";
            public const string RegistrationNr = "RegistrationNr";
            public const string LegalAddress = "LegalAddress";
            public const string Phone = "Phone";
            public const string Email = "Email";
            public const string ContactPersonName = "ContactPersonName";
            public const string ContactPersonAddress = "ContactPersonAddress";
            public const string ContactPersonPhone = "ContactPersonPhone";
            public const string ContactPersonEmail = "ContactPersonEmail";
            public const string Created = "Created";
        }

        public static class Location
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string Created = "Created";
        }

    }
}