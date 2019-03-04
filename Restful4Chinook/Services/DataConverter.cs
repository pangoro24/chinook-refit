using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restful4Chinook.Services
{
    public class DataConverter
    {
        public enum Properties
        {
            Album = 0,
            Artist = 1,
            Customer = 2,
            Employee = 3,
            Genre = 4,
            Invoice = 5,
            InvoiceItem = 6,
            Media = 7,
            Playlist = 8,
            PlayListTrack = 9,
            Track = 10
        }

        public static string[][] options = new string[11][]
            {
                new string[3] { "AlbumId", "Title", "ArtistId" },
                new string[2] { "ArtistId", "Name" },
                new string[13] { "CustomerId", "FirstName", "LastName", "Company", "Address", "City", "State", "Country", "PostalCode", "Phone", "Fax", "Email", "SupportRepId" },
                new string[15] { "EmployeeId", "LastName", "FirstName", "Title", "ReportsTo", "BirthDate", "HireDate", "Address", "City", "State", "Country", "PostalCode", "Phone", "Fax", "Email" },
                new string[2] { "GenreId", "Name" },
                new string[] { "InvoiceId", "CustomerId", "InvoiceDate", "BillingAddress", "BillingCity", "BillingState", "BillingCountry", "BillingPostalCode", "Total" },
                new string[5] { "InvoiceLineId", "InvoiceId", "TrackId", "UnitPrice", "Quantity" },
                new string[] { "MediaTypeId", "Name" },
                new string[] { "PlaylistId", "Name" },
                new string[] { "PlaylistId", "TrackId" },
                new string[] { "TrackId", "Name", "AlbumId", "MediaTypeId", "GenreId", "Composer", "Milliseconds", "Bytes", "UnitPrice" }
            };
       
        public static void convertToJson(string path, string pathOutput, Properties prop)
        {
            int op = (int)prop;
            string[] properties = options[op];
            string all = File.ReadAllText(path);
            var chars = new Char[] { ']', '[', ',', ' ', '\n', '\r', '\t', '.', '-', };
            string[] items = all.Split(chars[0]);
            string allFixed = "";
            for (int i = 0; i < items.Length; i++)
            {
                if (i == 13)
                {

                }
                string re = Regex.Replace(items[i], @"\[|\n", "");
                string[] line = re.Split(chars[5]);

                int c = 0;
                string cell = "";


                foreach (var j in line)
                {
                    if (!string.IsNullOrWhiteSpace(j) && (j != ","))
                    {
                        if (c == 0)
                        {
                            if (i == 0)
                            {
                                cell = cell + "[\r\n ";//beginning of file
                            }
                            cell = cell + string.Format("{{\r\n \"{0}\":{1}", properties[c], j);
                        }
                        else if (c == properties.Length - 1)
                        {
                            cell = cell + string.Format("\r\n \"{0}\":{1}\r\n}}", properties[c], j);
                            if (i == items.Length - 2)
                            {
                                cell = cell + "\r\n]";//beginning of file
                            }
                            else
                            {
                                cell = cell + ",\r\n";
                            }
                        }
                        else
                        {
                            cell = cell + string.Format("\r\n \"{0}\":{1}", properties[c], j);
                        }
                        c = c + 1;
                    }
                }
                allFixed = allFixed + cell;
            }
            File.WriteAllText(pathOutput, allFixed);
        }
    }

}
