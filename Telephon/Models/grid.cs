using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using static Telephon.Models.shapka;

namespace Telephon.Models
{
    public class grid
    {
        public string buttonstop { get; set; }   // кнопки над таблицей
        public string buttonsdown { get; set; }  // кнопки под таблицей
        public List<FieldSection> Columns { get; set; } = new List<FieldSection>();
        public List<string> Recs { get; set; }
        public DataTable dt { get; set; }

        public grid(XElement parameters)
        {
            Columns = FillCustomElements.FieldsFill(parameters.Element("grid"));
            Recs = FillCustomElements.RecsFill(parameters.Element("grid"));
            dt = GridFill(Columns, Recs);
        }
        static public DataTable GridFill(List<FieldSection> Columns, List<string> Recs)
        {


            var dt = new DataTable();

            foreach (FieldSection stroca in Columns)
            {
                switch (stroca.tip)
                {

                    case "bool":
                        dt.Columns.Add(stroca.name, typeof(Boolean));
                        break;
                    case "int":
                        dt.Columns.Add(stroca.name, typeof(Int32));
                        break;
                    case "string":
                        dt.Columns.Add(stroca.name, typeof(String));
                        break;
                    case "Double":
                        dt.Columns.Add(stroca.name, typeof(Double));
                        break;
                    case "time.Time":
                        dt.Columns.Add(stroca.name, typeof(DateTime));
                        break;
                }
            }

            foreach (string stroca in Recs)
            {
                DataRow row;
                row = dt.NewRow();
                string[] mass = stroca.Split(",");
                for (int i = 0; i < mass.Length; i++)
                {
                    switch (Columns[i].tip)
                    {
                        case "bool":
                            row[Columns[i].name] = mass[i];
                            break;
                        case "int":
                            row[Columns[i].name] = Int32.Parse(mass[i]);
                            break;
                        case "string":
                            row[Columns[i].name] = mass[i];
                            break;
                        case "Double":
                            row[Columns[i].name] = mass[i];
                            break;
                        case "time.Time":
                            row[Columns[i].name] = mass[i];
                            break;
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

    }

 }
