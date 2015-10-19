namespace CloudTemple.XML
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Xml;

    using Models;

    using ReportsModels;

    public class XmlData : IXmlData
    {
        public void GenerateAllLocationsReport(IEnumerable<LocationReport> locationReports)
        {
            var report = new XmlDocument();
            var xmlDeclaration = report.CreateXmlDeclaration("1.0", "UTF-8", null);
            var root = report.CreateElement("sales");
            report.AppendChild(root);
            report.InsertBefore(xmlDeclaration, root);

            foreach (var locationReport in locationReports)
            {
                var sale = report.CreateElement("location");
                sale.SetAttribute("name", locationReport.LocationName);
                root.AppendChild(sale);
                foreach (var entry in locationReport.Entries)
                {
                    var summary = report.CreateElement("summary");
                    summary.SetAttribute("date", entry.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture));
                    summary.SetAttribute("total-sum", entry.TotalSum.ToString(CultureInfo.InvariantCulture));
                    sale.AppendChild(summary);
                }
            }

            if (!Directory.Exists(XmlSettings.Default.ReportDestinationFolderLocation))
            {
                Directory.CreateDirectory(XmlSettings.Default.ReportDestinationFolderLocation);
            }

            report.Save(
                XmlSettings.Default.ReportDestinationFolderLocation + XmlSettings.Default.ReportDestionationFileName);
        }

        public IEnumerable<VendorExpense> GetAllVendorExpenses()
        {
            var allVendorExpenses = new List<VendorExpense>();

            var doc = new XmlDocument();
            doc.Load(XmlSettings.Default.InitialXmlFileLocation);

            var vendorNodesList = doc.SelectNodes("/expenses-by-month/vendor");

            if (vendorNodesList != null)
            {
                foreach (XmlNode vendorNode in vendorNodesList)
                {
                    if (vendorNode.Attributes != null)
                    {
                        var vendorName = vendorNode.Attributes.GetNamedItem("name").Value;
                        if (string.IsNullOrEmpty(vendorName))
                        {
                            throw new ArgumentNullException("Vendor name cannot be empty!", nameof(vendorName));
                        }
                        var vendorExpenses = vendorNode.SelectNodes("expenses");
                        if (vendorExpenses != null)
                        {
                            foreach (XmlNode expense in vendorExpenses)
                            {
                                var vendorExpense = new VendorExpense { VendorName = vendorName };

                                decimal parsedAmmount = 0;
                                if (
                                    !decimal.TryParse(
                                        expense.InnerText,
                                        NumberStyles.Any,
                                        CultureInfo.InvariantCulture,
                                        out parsedAmmount))
                                {
                                    throw new FormatException(
                                        "Unable to parse expenses ammount in"
                                        + XmlSettings.Default.InitialXmlFileLocation + "! Parse string: "
                                        + expense.InnerText);
                                }

                                vendorExpense.Ammount = parsedAmmount;

                                var parsedDate = new DateTime();
                                if (
                                    !DateTime.TryParseExact(
                                        expense.Attributes.GetNamedItem("month").Value,
                                        "MMM-yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out parsedDate))
                                {
                                    throw new FormatException(
                                        "Unable to parse date from expenses entry in"
                                        + XmlSettings.Default.InitialXmlFileLocation + "! Parse string: "
                                        + expense.Attributes.GetNamedItem("month").Value);
                                }

                                vendorExpense.Date = parsedDate;
                                allVendorExpenses.Add(vendorExpense);
                            }
                        }
                    }
                }
            }

            return allVendorExpenses;
        }
    }
}