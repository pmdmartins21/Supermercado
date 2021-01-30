using System;
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

            if (File.Exists(fileName))
            {
                Console.WriteLine("Deleting old file");
                File.Delete(fileName);
            }
            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, il);
            fileStream.Close();
        }

        public static InvoiceList ReadInvoiceList()
        {
            string location = Directory.GetCurrentDirectory();
            string fileName = "/../../../invoicelist.txt";

            if (File.Exists(fileName))
            {
                Console.WriteLine("EStIVE QUI 3");
                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    Console.WriteLine("Estive aqui 3");
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
