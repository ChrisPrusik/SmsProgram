using System.IO;
using System.Text;
using System;

namespace SmsProgram.Model 
{
    
    public partial class TemplateExamples 
    {

        public void Read(string fileName)
        {
            StreamReader reader = File.OpenText(fileName);
            StringBuilder str = new StringBuilder();
            string category = "";
            string name = "";
            string description = "";
            string message = "";
            int pos = 0;
            try
            {
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine().Trim();
                    pos++;
                    if (line.StartsWith("@"))
                    {
                        message = str.ToString().Trim();
                        if (category != "" && message != "")
                        {
                            Examples.AddExamplesRow(category, name, message, description);
                            str = new StringBuilder();
                        }
                        line = line.Remove(0, 1);
                        category = "";
                        name = "";
                        description = "";
                        string[] values = line.Split(',');
                        if (values.Length > 0)
                            category = values[0].Trim();
                        if (values.Length > 1)
                            name = values[1].Trim();
                        if (values.Length > 2)
                            description = values[2].Trim();
                    }
                    else if (line.StartsWith(";") == false) // komentarz
                        str.AppendLine(line);
                }
                if (category != "" && message != "")
                {
                    Examples.AddExamplesRow(category, name, message, description);
                    str = new StringBuilder();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(Messages.ErrorAtLine, pos) + " " + ex.Message);
            }
        }

        public void Write(string fileName)
        {
            File.Delete(fileName);
            foreach (ExamplesRow row in Examples)
            {
                File.AppendAllText(fileName, 
                    String.Format("@{0}, {1}, {2}\r\n", row.Category, row.Name, row.Description));
                File.AppendAllText(fileName, row.Message + "\r\n");
            }
        }
    }
}
