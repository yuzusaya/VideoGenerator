using Excel = Microsoft.Office.Interop.Excel;

namespace VideoGenerator.Services;
public class ExcelService
{
    public void ReadGraphFromExcel(string excelPath)
    {
        // Load the Excel application
        var excelApp = new Excel.Application();
        try
        {
            var workbook = excelApp.Workbooks.Open(excelPath);

            // Access the worksheet that contains the chart
            Excel.Worksheet worksheet = workbook.Sheets[1];  // Assuming the chart is in the first sheet
            // Get the ChartObjects collection (all embedded charts in the worksheet)
            Excel.ChartObjects chartObjects = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);

            // Get the count of charts in the worksheet
            int chartCount = chartObjects.Count;

            for (int i = 0; i < chartCount; i++)
            {
                // Get the chart object
                Excel.ChartObject chartObject = chartObjects.Item(i + 1);
                // Copy the chart as a picture
                var outputPath = Directory.GetCurrentDirectory() + $@"\images\{i + 1}.png";
                if(File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
                chartObject.Chart.Export(outputPath, "PNG");
            }

            // Clean up
            workbook.Close(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // Clean up
            excelApp.Quit();
        }
    }
}