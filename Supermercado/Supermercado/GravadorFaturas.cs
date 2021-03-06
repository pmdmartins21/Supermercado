﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    [Serializable]
    static class GravadorFaturas
    {
        
        public static void SaveInvoiceList(InvoiceList il)
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../invoicelist.txt";

            if (File.Exists(location + fileName))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(location + fileName);
            }
            FileStream fileStream = File.Create(location + fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, il);
            fileStream.Close();
        }

        public static InvoiceList ReadInvoiceList()
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../invoicelist.txt";

            if (File.Exists(location + fileName))
            {
                using (FileStream fileStream = File.OpenRead(location + fileName))
                {
                    BinaryFormatter f = new BinaryFormatter();

                    while (fileStream.Position < fileStream.Length)
                    {
                        InvoiceList il = f.Deserialize(fileStream) as InvoiceList;
                        return il;

                    }
                    fileStream.Close();
                }
            }
            else
            {
                return null;
            }
            return null;

        }
    }
}
