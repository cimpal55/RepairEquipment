using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Shared.Models.Export
{
    [FileExport(FileType.Pdf)]
    [MapFrom(typeof(DocumentRecord))]
    public sealed record DocExportRecord
    {
        public string? Client { get; init; } = string.Empty;

        public string? ClientRegistrationNr { get; init; } = string.Empty;

        public string? ClientContactPerson { get; init; } = string.Empty;

        public string? Employee { get; init; } = string.Empty;

        public string Equipment { get; init; } = string.Empty;

        public string DocumentNumber { get; set; } = string.Empty;

        public string DocumentDetailNumber { get; set; } = string.Empty;

        public DateTime? DocumentDateOut { get; set; }

        public DateTime? DocumentDateIn { get; set; }

        public decimal Quantity { get; set; }

        public decimal Sum { get; set; }

        public decimal TotalSum { get; set; }

    }

    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class FileExportAttribute : Attribute
    {
        public FileExportAttribute(params FileType[] exportTypes) { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class FileExportPropertyAttribute : Attribute
    {
        public string LocaleHeader { get; init; } = string.Empty;

        public string ValueFormat { get; init; } = string.Empty;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class MapToAttribute : Attribute
    {
        public MapToAttribute(Type type) { }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class MapFromAttribute : Attribute
    {
        public MapFromAttribute(Type type) { }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class UpdateFromAttribute : Attribute
    {
        public UpdateFromAttribute(Type type) { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class CloneAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    internal sealed class MapPropertyAttribute : Attribute
    {
        public MapPropertyAttribute(string propertyName) { }
    }
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class MapIgnoreAttribute : Attribute { }



    internal enum FileType : byte
    {
        Pdf
    }
}