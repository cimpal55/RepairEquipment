using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Models
{
    public class MockDataService
    {
        private static List<Employee>? _employees = default!;
        private static List<Document> _documents = default!;
        private static List<DocumentDetail> _documentDetails = default!;
        private static List<Equipment> _equipments = default!;
        private static List<EquipmentType> _equipmentTypes = default!;
        private static List<EquipmentHistory> _equipmentHistories = default!;
        private static List<Clients> _clients = default!;

        public static List<Employee>? Employees
        {
            get
            {
                _equipmentTypes ??= InitializeMockEquipmentTypes();

                _equipments ??= InitializeMockEquipments();

                _equipmentHistories = InitializeMockEquipmentHistories();

                _documents ??= InitializeMockDocuments();

                _documentDetails ??= InitializeMockDocumentDetails();

                _clients ??= InitializeMockClients();

                _employees ??= InitializeMockEmployees();

                return _employees;
            }
        }

        private static List<EquipmentHistory> InitializeMockEquipmentHistories()
        {
            var eh1 = new EquipmentHistory
            {
                Id = 1,
                EquipmentId = 1,
                Equipment = "Something",
                ClientId = 1,
                Client = "Ivans",
                EmployeeId = 1,
                Employee = "Vladislavs Suspanovs",
                Location = "satimskes",
                DateOut = new DateTime(2022, 11, 05),
                DateIn = new DateTime(2022, 11, 08),
            };

            return new List<EquipmentHistory>() { eh1 };
        }

        private static List<Equipment> InitializeMockEquipments()
        {
            var eq1 = new Equipment
            {
                Id = 1,
                Name = "Laptop",
                TypeId = 2,
                Type = "dd",
                LocationId = 1,
                Location = "Satiksmes..",
                SerialNumber = "123456",
                FixedAssetNr = 1,
                PurchaseDate = new DateTime(2022, 11, 08),
                PurchaseSum = 19531,
                PurchaseInvoiceNr = "123",
                PurchaseInvoiceLink = "1dsadasdsadasdwqa",
                DepreciationPeriod = 12,
                Depreciation = 132,
                Notes = "Something wrong with this laptop",
                IsWriteOff = true,
                IsInStock = true,
            };
            
            return new List<Equipment>() { eq1 };
        }

        private static List<EquipmentType> InitializeMockEquipmentTypes()
        {
            return new List<EquipmentType>
            {
                new EquipmentType { Id = 1, Name = "Nomas iekarta" },
                new EquipmentType { Id = 2, Name = "Pamatlīdzeklis" },
                new EquipmentType { Id = 3, Name = "Mazvērtīgais inventārs" },
            };        
        }

        private static List<Employee> InitializeMockEmployees()
        {
            var e1 = new Employee
            {
                Name = "Vladislavs",
                Surname = "Suspanovs",
                Code = "01",
                PersonalCode = "040104-20067",
                Phone = "20318705",
                Email = "cimpals71@gmail.com",
                Address = "Jelgava, Satiksmes iela 33-64, LV-3007",
            };

            return new List<Employee>() { e1 };
        }

        private static List<Clients> InitializeMockClients()
        {
            var c1 = new Clients
            {
                Id = 1,
                Name = "Ivans",
                Code = "01",
                RegistrationNr = "0401041231",
                LegalAddress = "Imanta, Damme, LV-1934",
                Phone = "29682652",
                Email = "cimpals71@gmail.com",
            };

            return new List<Clients>() { c1 };
        }

        private static List<Document> InitializeMockDocuments()
        {
            var d1 = new Document
            {
                Id = 1,
                DocumentNumber = "01",
                ClientId = 1,
                Client = "Ivans",
                EmployeeId = 1,
                Employee = "Vladislavs Suspanovs",
            };

            return new List<Document>() { d1 };
        }
        private static List<DocumentDetail> InitializeMockDocumentDetails()
        {
            var dd1 = new DocumentDetail   
            {
                Id = 1,
                DocumentId = 1,
                DocumentNumber = "01",
                DocumentDate = new DateTime(2022, 11, 08),
                Quantity = 52,
                Sum = 1952,
                TotalSum = 3000,
                EquipmentId = 1,
                Equipment = "Laptop",
            };

            return new List<DocumentDetail>() { dd1 };
        }
    }
}
