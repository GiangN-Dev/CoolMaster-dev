using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoolMaster.Utils
{
    // Lightweight CSV import/export helper.
    // - Exports list of objects (reflection) to CSV (UTF-8 BOM).
    // - Imports CSV returning rows as string arrays.
    // Note: For real Excel (.xlsx) support, add ClosedXML via NuGet and implement export/import there.
    public static class ExcelHelper
    {
        // Export list of objects to CSV file. Uses public properties as columns.
        public static void ExportToCsv<T>(IEnumerable<T> items, string filePath)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            var list = items.ToList();

            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                                 .Where(p => p.CanRead)
                                 .ToArray();

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(fs, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)))
            {
                // header
                writer.WriteLine(string.Join(",", props.Select(p => Escape(p.Name))));

                // rows
                foreach (var it in list)
                {
                    var vals = props.Select(p =>
                    {
                        var v = p.GetValue(it, null);
                        return Escape(v?.ToString() ?? string.Empty);
                    });
                    writer.WriteLine(string.Join(",", vals));
                }
            }
        }

        // Read CSV file into list of string[] rows.
        // Simple parser: splits on commas, supports quoted fields with double quote escaping.
        public static List<string[]> ImportFromCsv(string filePath, int skipHeaderLines = 0)
        {
            var rows = new List<string[]>();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(fs, Encoding.UTF8))
            {
                int lineIndex = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineIndex++ < skipHeaderLines) continue;
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        rows.Add(new string[0]);
                        continue;
                    }
                    rows.Add(ParseCsvLine(line).ToArray());
                }
            }
            return rows;
        }

        // Helper: escape CSV field
        private static string Escape(string s)
        {
            if (s == null) return string.Empty;
            if (s.Contains("\"")) s = s.Replace("\"", "\"\"");
            if (s.Contains(",") || s.Contains("\n") || s.Contains("\r") || s.Contains("\""))
                return $"\"{s}\"";
            return s;
        }

        // CSV line parser (handles quoted fields)
        private static IEnumerable<string> ParseCsvLine(string line)
        {
            if (line == null) yield break;
            int i = 0;
            while (i < line.Length)
            {
                if (line[i] == '"')
                {
                    i++; // skip quote
                    var sb = new StringBuilder();
                    while (i < line.Length)
                    {
                        if (line[i] == '"')
                        {
                            // lookahead for double quote (escaped) or end
                            if (i + 1 < line.Length && line[i + 1] == '"')
                            {
                                sb.Append('"');
                                i += 2;
                                continue;
                            }
                            i++; // consume closing quote
                            break;
                        }
                        sb.Append(line[i]);
                        i++;
                    }
                    // skip optional comma
                    while (i < line.Length && line[i] != ',') i++;
                    if (i < line.Length && line[i] == ',') i++;
                    yield return sb.ToString();
                }
                else
                {
                    var start = i;
                    while (i < line.Length && line[i] != ',') i++;
                    yield return line.Substring(start, i - start);
                    if (i < line.Length && line[i] == ',') i++;
                }
            }
            // handle empty line
            if (line.Length == 0) yield return string.Empty;
        }
    }
}
