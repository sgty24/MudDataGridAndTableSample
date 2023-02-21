using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using MudDataGridAndTableSample.Data;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace MudDataGridAndTableSample.Data
{
    public class ElementService
    {
        private List<Element> m_elements = Element.GetTestData();
        private List<Element> m_elements_befor = new();
        private List<Element> m_elements_dif = new();

        public Task<IEnumerable<Element>> GetElementAsync() => Task.FromResult(m_elements.AsEnumerable());

        public Task<IEnumerable<Element>> GetElementBeforAsync() => Task.FromResult(m_elements_befor.AsEnumerable());

        public Task<IEnumerable<Element>> GetElementDifAsync() => Task.FromResult(m_elements_dif.AsEnumerable());

        public Task<bool> IsExists(Element _element)
        {
            return Task.FromResult(m_elements.IndexOf(_element) != -1);
        }

        public Task<bool> AddElement(Element _element)
        {
            if (0 <= m_elements.IndexOf(_element))
            {
                return Task.FromResult(false);
            }
            m_elements.Add(_element);
            m_elements.Sort();
            return Task.FromResult(true);
        }

        public Task<bool> EditElement(Element _element)
        {
            m_elements.Remove(_element);
            m_elements.Add(_element);
            m_elements.Sort();

            return Task.FromResult(true);
        }

        public Task<bool> DeleteElement(Element _element)
        {
            m_elements.Remove(_element);
            return Task.FromResult(true);
        }
        static CsvConfiguration GetCSVConf()
        {
            return new CsvHelper.Configuration.CsvConfiguration(new CultureInfo("ja-JP", false))
            {
                HasHeaderRecord = false,
                Encoding = Encoding.UTF8,
                TrimOptions = TrimOptions.Trim,
                AllowComments = true,
                Comment = '#',
                Delimiter = ",",
                DetectColumnCountChanges = true,
            };
        }

        public async Task<(bool sucsess, string err_msg)> LoadfromCSV(Stream _stream)
        {
            using (var reader = new StreamReader(_stream, Encoding.UTF8))
            {
                using (var csv = new CsvReader(reader, GetCSVConf()))
                {
                    var err_rec = new List<string>();
                    int index = 0;
                    var tmp = new List<Element>();

                    try
                    {
                        var records =  csv.GetRecordsAsync<Element>();
                        await foreach (var rec in records)
                        {
                            var ret = rec.ValidateElement();
                            if (0 < ret.Count)
                            {
                                err_rec.Add(index.ToString() + ": " + String.Join(", ", ret));
                            }
                            tmp.Add(rec);
                            index++;
                        }
                    }
                    catch(Exception _ex)
                    {
                        if (_ex is CsvHelper.MissingFieldException)
                        {
                            return (false, $"row {index + 1} : Some fields are missing.");
                        }
                        else
                        {
                            return (false, $"row {index + 1} : Contains Bad data.");
                        }
                    }

                    foreach (var rec in tmp)
                    {
                        var find = m_elements.Find(x => x == rec);
                        if (find is null)
                        {
                            m_elements_dif.Add(rec);
                        }
                        else if(!find.IsExactMatch(rec))
                        {
                            m_elements_befor.Add(find);
                            m_elements_dif.Add(rec);
                        }
                    }
                }
            }

            return (true, "");
        }

        public async Task WriteCSV(StreamWriter _writer)
        {
            using (var csv = new CsvWriter(_writer, GetCSVConf(), true))
            {
                await csv.WriteRecordsAsync(m_elements);
                await _writer.FlushAsync();
            }
        }

        public void Commit()
        {
            foreach (var elm in m_elements_dif)
            {
                m_elements.Remove(elm);
                m_elements.Add(elm);
            }
            m_elements.Sort();
            m_elements_befor.Clear();
            m_elements_dif.Clear();
        }


        public void Cancel()
        {
            m_elements_befor.Clear();
            m_elements_dif.Clear();
        }
    }
}
