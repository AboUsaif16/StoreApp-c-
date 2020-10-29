using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1
{
    public static class CSVUtlity
    {
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count-1; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 2)
                {
                    sw.Write("\t\t");
                }
            }
            sw.Write("\n-----------------------------------");
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count-1; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 2)
                    {
                        sw.Write("\t\t");
                    }
                }
                sw.Write("\n-----------------------------------");
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public static void SaveExportedData(this DataGridView DatGrdV, string filename)
        {
            string dataExport = "";
            string fColumnHeader = "";
            for (int j = 0; j < DatGrdV.Columns.Count; j++)
                fColumnHeader = fColumnHeader.ToString() +
                Convert.ToString(DatGrdV.Columns[j].HeaderText) + "\t";
            dataExport += fColumnHeader + "\r\n";
            for (int i = 0; i < DatGrdV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < DatGrdV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() +
                    Convert.ToString(DatGrdV.Rows[i].Cells[j].Value) + "\t";
                dataExport += stLine + "\r\n";
            }
            Encoding u16LE = new UnicodeEncoding(); //Include Preamble/Byte Order Mark
            //Encoding u16LE = Encoding.Unicode;
            byte[] output = u16LE.GetBytes(dataExport);
            FileStream FleSys = new FileStream(filename, FileMode.Create);
            BinaryWriter BinryWrtr = new BinaryWriter(FleSys);
            BinryWrtr.Write(output, 0, output.Length);
            BinryWrtr.Flush();
            BinryWrtr.Close();
            FleSys.Close();
        }
    }

}
