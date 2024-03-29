﻿using OfficeOpenXml;
using System;
using System.Drawing;
using System.IO;

namespace lab1
{
    class ExcelTools
    {
        public static void SaveStudentsGroup(Group group, string path)
        {
            var newFile = new FileInfo(path);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Group - " + DateTime.Now.ToString());
                worksheet.Cells[1, 1].Value = "Группа:";
                worksheet.Cells[1, 2].Value = group.name;

                worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, 2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                worksheet.Cells[1, 2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                for (int i = 0; i < group.header.Length; i++)
                {
                    worksheet.Cells[2, i + 1].Value = group.header[i];
                    worksheet.Cells[2, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[2, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightPink);
                }

                worksheet.Cells[2, group.header.Length + 1].Value = "Средний балл";
                worksheet.Cells[2, group.header.Length + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[2, group.header.Length + 1].Style.Fill.BackgroundColor.SetColor(Color.LightPink);

                int lastRow = 3;

                for (int i = 0, row = 3; i < group.students.Count; i++, row++)
                { // Row by row...
                    int col = 1;

                    worksheet.Column(col).Width = 16;

                    worksheet.Cells[row, col].Value = group.students[i].name;
                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    col++;

                    worksheet.Column(col).Width = 16;

                    worksheet.Cells[row, col].Value = group.students[i].surname;
                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    col++;

                    worksheet.Column(col).Width = 18;

                    worksheet.Cells[row, col].Value = group.students[i].patronymic;
                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                    col++;

                    worksheet.Column(col).Width = 16;

                    for (int j = 0; j < group.students[i].subjects.Count; j++, col++)
                    {
                        worksheet.Cells[row, col].Value = group.students[i].subjects[j].mark;
                        worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);
                        worksheet.Column(col).Width = 16;

                    }

                    worksheet.Cells[row, col].Value = group.students[i].averageMark;
                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                    worksheet.Column(col).Width = 16;

                    lastRow = row;
                }

                lastRow++;


                worksheet.Cells[lastRow, 3].Value = "Средний по группе:";

                for (int i = 0; i < group.subjects.Count - 1; i++)
                {
                    worksheet.Cells[lastRow, i + 4].Value = group.averageMarks[group.header[i + 3]];
                    worksheet.Cells[lastRow, i + 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[lastRow, i + 4].Style.Fill.BackgroundColor.SetColor(Color.LightSlateGray);
                }


                worksheet.Cells[lastRow, group.subjects.Count + 3].Value = group.averageMarks["Средний"];
                worksheet.Cells[lastRow, group.subjects.Count + 3].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[lastRow, group.subjects.Count + 3].Style.Fill.BackgroundColor.SetColor(Color.LightSlateGray);

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    xlPackage.Save();
                }
                catch
                {
                    System.Console.WriteLine("Неверное имя или путь к файлу.");
                }
                
            }
        }
    }
}
