using Dal.Models;

using ClosedXML.Excel;

public class ExcelService
    {
        public byte[] GenerateOrdersExcel(List<Order> orders)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Orders");

            // כותרות
            ws.Cell(1, 1).Value = "ID";
            ws.Cell(1, 2).Value = "Customer ID";
            ws.Cell(1, 3).Value = "Customer Name";
            ws.Cell(1, 4).Value = "Order Date";
            ws.Cell(1, 5).Value = "Delivery Date";
            ws.Cell(1, 6).Value = "Price";
            ws.Cell(1, 7).Value = "Status";
            ws.Cell(1, 8).Value = "Address";

            int row = 2;

            foreach (var o in orders)
            {
                ws.Cell(row, 1).Value = o.Id;
                ws.Cell(row, 2).Value = o.CustId;
                ws.Cell(row, 3).Value = o.CustName;
                ws.Cell(row, 4).Value = o.OrderDate?.ToString("yyyy-MM-dd");
                ws.Cell(row, 5).Value = o.DeliveryDate?.ToString("yyyy-MM-dd");
                ws.Cell(row, 6).Value = o.Price;
                ws.Cell(row, 7).Value = o.Status;

                ws.Cell(row, 8).Value =
                    $"{o.Street} {o.BuildingNum}, Floor {o.Floor}, Apt {o.ApartmentNum}";

                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }


