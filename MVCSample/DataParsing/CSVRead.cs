using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParsing
{
    public class CSVRead
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead(@"E:\Physician_Compare_National_Downloadable_File(2).csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("NPI", typeof(string));
            dt.Columns.Add("PACID", typeof(string));
            dt.Columns.Add("Professional Enrollment ID", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Middle Name", typeof(string));
            dt.Columns.Add("Suffix", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Credential", typeof(string));
            dt.Columns.Add("Medical school name", typeof(string));
            dt.Columns.Add("Graduation year", typeof(string));
            dt.Columns.Add("Primary specialty", typeof(string));
            dt.Columns.Add("Secondary specialty 1", typeof(string));
            dt.Columns.Add("Secondary specialty 2", typeof(string));
            dt.Columns.Add("Secondary specialty 3", typeof(string));
            dt.Columns.Add("Secondary specialty 4", typeof(string));
            dt.Columns.Add("All secondary specialties", typeof(string));
            dt.Columns.Add("Organization legal name", typeof(string));
            dt.Columns.Add("Group Practice PAC ID", typeof(string));
            dt.Columns.Add("Number of Group Practice members", typeof(string));
            dt.Columns.Add("Line 1 Street Address", typeof(string));
            dt.Columns.Add("Line 2 Street Address", typeof(string));
            dt.Columns.Add("Marker of address line 2 suppression", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Zip Code", typeof(string));
            dt.Columns.Add("Phone Number", typeof(string));
            dt.Columns.Add("Hospital affiliation CCN 1", typeof(string));
            dt.Columns.Add("Hospital affiliation LBN 1", typeof(string));
            dt.Columns.Add("Hospital affiliation CCN 2", typeof(string));
            dt.Columns.Add("Hospital affiliation LBN 2", typeof(string));
            dt.Columns.Add("Hospital affiliation CCN 3", typeof(string));
            dt.Columns.Add("Hospital affiliation LBN 3", typeof(string));
            dt.Columns.Add("Hospital affiliation CCN 4", typeof(string));
            dt.Columns.Add("Hospital affiliation LBN 4", typeof(string));
            dt.Columns.Add("Hospital affiliation CCN 5", typeof(string));
            dt.Columns.Add("Hospital affiliation LBN 5", typeof(string));
            dt.Columns.Add("Professional accepts Medicare Assignment", typeof(string));
            dt.Columns.Add("Reported Quality Measures", typeof(string));
            dt.Columns.Add("Used electronic health records", typeof(string));
            dt.Columns.Add("Participated in the Medicare Maintenance of Certification Program", typeof(string));
            dt.Columns.Add("Committed to heart health through the Million Hearts® initiative.", typeof(string));

            bool isHeader = true;
            while (!reader.EndOfStream)
            {
                //if (isHeader == false)
                //{
                    DataRow dRow = dt.NewRow();
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    dRow[0] = values[0];
                    dRow[1] = values[1];
                    dRow[2] = values[2];
                    dRow[3] = values[3];
                    dRow[4] = values[4];
                    dRow[5] = values[5];
                    dRow[6] = values[6];
                    dRow[7] = values[7];
                    dRow[8] = values[8];
                    dRow[9] = values[9];
                    dRow[10] = values[10];
                    dRow[11] = values[11];
                    dRow[12] = values[12];
                    dRow[13] = values[13];
                    dRow[14] = values[14];
                    dRow[15] = values[15];
                    dRow[16] = values[16];
                    dRow[17] = values[17];
                    dRow[18] = values[18];
                    dRow[19] = values[19];
                    dRow[20] = values[20];
                    dRow[21] = values[21];
                    dRow[22] = values[22];
                    dRow[23] = values[23];
                    dRow[24] = values[24];
                    dRow[25] = values[25];
                    dRow[26] = values[26];
                    dRow[27] = values[27];
                    dRow[28] = values[28];
                    dRow[29] = values[29];
                    dRow[30] = values[30];
                    dRow[31] = values[31];
                    dRow[32] = values[32];
                    dRow[33] = values[33];
                    dRow[34] = values[34];
                    dRow[35] = values[35];
                    dRow[36] = values[36];
                    dRow[37] = values[37];
                    dRow[38] = values[38];
                    dRow[39] = values[39];
                    dRow[40] = values[40];
                    dRow[41] = values[41];

                    dt.Rows.Add(dRow);
                //}
                //isHeader = false;

            }
            int k = 0;
        }
    }
}










































