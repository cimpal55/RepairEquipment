using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services
{
    public sealed class PdfService : IPdfService
    {
        public Task<IDocument> CreateClientPdf(IEnumerable<DocExportRecord> data, string docType)
        {
            var docExportRecords = data.ToList();
            var client = docExportRecords.Select(x => x.Client).FirstOrDefault();
            var clientRegNr = docExportRecords.Select(x => x.ClientRegistrationNr).FirstOrDefault();
            var clientContactPerson = docExportRecords.Select(x => x.ClientContactPerson).FirstOrDefault();
            var totalSum = docExportRecords.Select(x => x.TotalSum).FirstOrDefault();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.MarginHorizontal(1f, Unit.Centimetre);
                    page.DefaultTextStyle(static x => x.FontSize(15));
                    page.DefaultTextStyle(x => x.FontFamily("Arial"));

                    page.Header()
                        .Text(x =>
                        {
                            x.AlignCenter();
                            x.Span("Pieņemšanas - Nodošanas akts Nr.").SemiBold().FontSize(24);
                        });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(10);

                            x.Item().Text(text =>
                            {
                                text.Span($"Mārupē, {DateTime.Today:yyyy.MM.dd}").Bold();
                                text.Span("Iznomātājs SIA Dayton ").Bold();
                                text.Span("(reģistrācijas Nr. 40003966407), tās projektu vadītājas asistentes Natāljas Bortaševičas personā, nodod un ");
                                text.Span($"Nomnieks - {client} ").Bold();
                                text.Span($"(reģistrācijas Nr. {clientRegNr}), tās {clientContactPerson} personā, pieņem nomā aprīkojumu par kopējo vērtību ");
                                text.Span($"EUR {totalSum.ToString("N2")} ").Bold();
                                text.Span("bez PVN. Pievienotās vērtības nodokli (PVN) aprēķina un maksā valsts budžetā Pircējs, " +
                                          "saskaņā ar PIevienotās vērtības nodokļa likuma 143.5. pantā noteikto \"reversā\" (apgrieztā) PVN piemērošanas kārtību elektroprecēm.");
                            });


                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(static columns =>
                                {
                                    columns.RelativeColumn(5.5f);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Row(1).ColumnSpan(4).AlignLeft().Text("Iekārtu specifikācija").Bold();

                                    header.Cell().Row(2).ColumnSpan(4).BorderTop(1).BorderBottom(1);
                                    header.Cell().Row(2).Column(1).Text("Nosaukums").Bold();
                                    header.Cell().Row(2).Column(2).AlignRight().Text("Cena EUR bez PVN 21%").Bold();
                                    header.Cell().Row(2).Column(3).AlignCenter().Text("Daudz.").Bold();
                                    header.Cell().Row(2).Column(4).AlignRight().Text("Summa EUR bez PVN 21%").Bold();
                                });

                                uint i = 1;
                                var totalSummary = 0m;
                                foreach (var item in docExportRecords)
                                {
                                    table.Cell().Row(i).Column(1).Text($"{item.Equipment}");
                                    table.Cell().Row(i).Column(2).AlignRight().Text(item.Sum);
                                    table.Cell().Row(i).Column(3).AlignCenter().Text(1);
                                    table.Cell().Row(i).Column(4).AlignRight().Text(item.TotalSum);

                                    table.Cell().Row(i).ColumnSpan(4).BorderBottom(0.25f);

                                    totalSummary += item.TotalSum;

                                    i++;
                                }
                                table.Cell().Row(i).ColumnSpan(4).BorderTop(1f);

                                table.Cell().Row(i).Column(1).ColumnSpan(3).AlignRight().Text("Kopā EUR:").Bold();
                                table.Cell().Row(i).Column(4).AlignRight().Text(totalSummary).Bold();
                                table.Cell().Row(i).ColumnSpan(4).BorderBottom(0.25f);

                                table.Cell().Row(i + 1).Column(1).ColumnSpan(3).AlignRight().Text("PVN 0% EUR:").Bold();
                                table.Cell().Row(i + 1).Column(4).AlignRight().Text(0.00).Bold();
                                table.Cell().Row(i + 1).ColumnSpan(4).BorderBottom(0.25f);

                                table.Cell().Row(i + 2).Column(1).ColumnSpan(3).AlignRight().Text("Kopā ar PVN 0% EUR:").Bold();
                                table.Cell().Row(i + 2).Column(4).AlignRight().Text(totalSummary).Bold();
                                table.Cell().Row(i + 2).ColumnSpan(4).BorderBottom(1f);
                            });

                            x.Item().Text(text =>
                            {
                                text.Span("Saskaņā ar šo Pieņemšanas - Nodošanas aktu, Nomnieks nekļūst par Iekārtas īpašnieku. ");
                                text.Span("Parakstot šo aktu, puses apliecina, ka Iekārta ir piegādāta pilnā komplektācijā, darbojas atbilstoši " +
                                          "prasībām un Pusēm nav, savstarpēju pretenziju attiecībā uz iekārtu darbību un komplektāciju.");
                                text.Span("Pieņemšanas - nodošanas akts sastādīts uz 1 (vienas) lapas, 2 (divos) autentiskos eksemplāros, " +
                                          "kas glabājas pie katras līgumslēdzejas puses");
                            });
                        });

                    page.Footer()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(static columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Cell().Row(1).Column(1).Text("Pušu paraksti:").Underline().Bold();
                            if (docType == "outgoing")
                            {
                                table.Cell().Row(2).Column(1).AlignLeft().Text("Iznomātājs").Bold();
                                table.Cell().Row(2).Column(2).AlignRight().Text("Nomnieks").Bold();
                                table.Cell().Row(5).Column(1).AlignLeft().Text("N. Bortaševiča");
                            }
                            else
                            {
                                table.Cell().Row(2).Column(1).AlignLeft().Text("Nomnieks").Bold();
                                table.Cell().Row(2).Column(2).AlignRight().Text("Iznomātājs").Bold();
                                table.Cell().Row(5).Column(2).AlignRight().Text("N. Bortaševiča");
                            }

                            table.Cell().Row(3).Column(1).ColumnSpan(2).Text("");
                            table.Cell().Row(4).Column(1).AlignLeft().Text("_______________");
                            table.Cell().Row(4).Column(2).AlignRight().Text("_______________");

                            table.Cell().Row(6).Column(1).ColumnSpan(2).Text("");
                        });

                });
            });

            return Task.FromResult<IDocument>(document);
        }

        public Task<IDocument> CreateEmployeePdf(IEnumerable<DocExportRecord> data, string docType)
        {
            var docExportRecords = data.ToList();
            var employee = docExportRecords.Select(x => x.Employee).FirstOrDefault();
            var totalSum = docExportRecords.Select(x => x.TotalSum).FirstOrDefault();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.MarginHorizontal(1f, Unit.Centimetre);
                    page.DefaultTextStyle(static x => x.FontSize(15));
                    page.DefaultTextStyle(x => x.FontFamily("Arial"));

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(10);

                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(static columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().Row(1).Column(1).RowSpan(4).AlignMiddle().Image("wwwroot\\img\\dayton_logo.png");
                                table.Cell().Row(1).Column(2).AlignRight().Text("Adrese: Lielā iela 47/1, Mārupe, Mārupes nov., LV-2167").FontSize(10);
                                table.Cell().Row(2).Column(2).AlignRight().Text("Tālr.: +371 67772120, e-pasts: info@daytongroup.lv").FontSize(10);
                                table.Cell().Row(3).Column(2).AlignRight().Text("Reģ.Nr.: 40003966407 PVN reg.Nr.: LV40003966407").FontSize(10);
                                table.Cell().Row(4).Column(2).AlignRight().Text("Pielikums pie Darba līguma Nr. _______").FontSize(10);
                            });

                            x.Item().Text(text =>
                            {
                                text.AlignCenter();
                                text.Span("Pieņemšanas - Nodošanas akts").Bold();
                            });

                            x.Item().Text(text =>
                            {
                                text.AlignCenter();
                                text.Span("Par materiālo vērtību pieņemšanu un/vai nodošanu").FontSize(10).Italic();
                            });

                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(static columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().Row(1).Column(1).AlignLeft().Text("Mārupē").FontSize(10);
                                table.Cell().Row(1).Column(2).AlignRight().Text($"Akts sastādīts {DateTime.Today:yyyy.MM.dd}").FontSize(10);
                            });

                            x.Item().Text(text =>
                            {
                                text.Span("SIA \"Dayton\" ").Bold();
                                text.Span(", reģistrēta Latvijas Republikas Uzņēmumu reģistrā ar numuru 40003966407, adrese: Lielā 47/1, Mārupe, Mārupes nov., ");
                                text.Span("LV-2167,kuras vārdā uz pilnvarojuma pamata rīkojas prokūrists Aivars Linkevičs, p.k. 220174-11525, turpmāk tekstā saukts - ");
                                text.Span("Darba devējs").Bold();
                                text.Span(", no vienas puses un, ");
                                text.Span($"{employee}").Bold();
                                text.Span(", kas tiek nodarbināts pie Darba devēja servisa darbinieka amatā, turpmāk tekstā - ");
                                text.Span("Darbinieks ").Bold();
                                text.Span(", no otras puses, noslēdz šo materiālo vērtību pieņemšanas - nodošanasaktu, turpmāk tekstā - Akts, ar kuru: ");
                            });

                            x.Item().Text("1. Darba devējs NODOD, bet Darbinieks PIEŅEM lietošanā sekojošas Darba devējam piederošas mantiskās vērtības: ");

                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(static columns =>
                                {
                                    columns.RelativeColumn(3.5f);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Row(1).ColumnSpan(6).BorderTop(1).BorderBottom(1);
                                    header.Cell().Row(1).Column(1).Text("Iekārta").Bold();
                                    header.Cell().Row(1).Column(2).AlignCenter().Text("Numurs").Bold();
                                    header.Cell().Row(1).Column(3).AlignCenter().Text("Datums").Bold();
                                    header.Cell().Row(1).Column(4).AlignCenter().Text("Daudz.").Bold();
                                    header.Cell().Row(1).Column(5).AlignRight().Text("Cena EUR bez PVN").Bold();
                                    header.Cell().Row(1).Column(6).AlignRight().Text("Kopā EUR bez PVN").Bold();
                                });


                                uint i = 1;
                                foreach (var item in docExportRecords)
                                {
                                    table.Cell().Row(i).Column(1).Text($"{item.Equipment}");
                                    table.Cell().Row(i).Column(2).AlignCenter().Text(item.DocumentDetailNumber);
                                    table.Cell().Row(i).Column(3).AlignCenter().Text(item.DocumentDateOut.Value.ToString("yyyy.MM.dd"));
                                    table.Cell().Row(i).Column(4).AlignCenter().Text(1);
                                    table.Cell().Row(i).Column(5).AlignRight().Text(item.Sum);
                                    table.Cell().Row(i).Column(6).AlignRight().Text(item.TotalSum);

                                    table.Cell().Row(i).ColumnSpan(6).BorderBottom(0.25f);

                                    i++;
                                }
                            });

                            x.Item().Text("2. Puses atzīst, ka Akts, ar tā abpusējas parakstīšanas brīdi, kļūst par Darba līguma nr. _______ neatņemamu sastāvdaļu. ");
                            x.Item().Text("3. Akts sastādīts latviešu valodā divos eksemplāros, pa vienam paredzēts katrai Pusei.");
                            x.Item().Text("4. Jebkādas izmaiņas Aktā tiek noslēgtas rakstiski, veicot tā grozījumus. Par spēkā esošu tiek uzskatīta pēdējā parakstītā akta versija.");
                        });

                    page.Footer()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(static columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            if (docType == "outgoing")
                            {
                                table.Cell().Row(1).Column(1).AlignLeft().Text("Darba devējs:").Bold();
                                table.Cell().Row(1).Column(2).AlignRight().Text("Darbinieks:").Bold();
                                table.Cell().Row(4).Column(1).AlignLeft().Text("A. Linkevičs").FontSize(10);
                                table.Cell().Row(4).Column(2).AlignRight().Text(employee).FontSize(10);
                            }
                            else
                            {
                                table.Cell().Row(1).Column(1).AlignLeft().Text("Darbinieks").Bold();
                                table.Cell().Row(1).Column(2).AlignRight().Text("Darba devējs:").Bold();
                                table.Cell().Row(4).Column(1).AlignLeft().Text(employee).FontSize(10);
                                table.Cell().Row(4).Column(2).AlignRight().Text("A. Linkevičs").FontSize(10);
                            }

                            table.Cell().Row(2).Column(1).ColumnSpan(2).Text("");

                            table.Cell().Row(3).Column(1).AlignLeft().Text("_______________");
                            table.Cell().Row(3).Column(2).AlignRight().Text("_______________");


                            table.Cell().Row(5).Column(1).ColumnSpan(2).Text("");

                            table.Cell().Row(6).Column(1).AlignLeft().Text("_______________");
                            table.Cell().Row(6).Column(2).AlignRight().Text("_______________");

                            table.Cell().Row(7).Column(1).AlignLeft().Text("Datums").FontSize(10);
                            table.Cell().Row(7).Column(2).AlignRight().Text("Datums").FontSize(10);
                            table.Cell().Row(8).Column(1).ColumnSpan(2).Text("");
                        });
                });
            });

            return Task.FromResult<IDocument>(document);
        }
    }
}
