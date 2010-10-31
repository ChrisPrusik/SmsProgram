using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Data;
using SmsProgram;

namespace SmsProgram.Tests
{
    [TestClass]
    public class MainFormTest
    {
        [TestMethod]
        public void ControlNamesTest()
        {
            // TODO: Sprawdzić, czy wszystkie nazwy mają prawidłowe przyrostki
        }

        [TestMethod]
        public void PropertiesFormTest()
        {
            using (PropertiesForm form = new PropertiesForm())
            {
                //form.ShowDialog();
            }
        }
    }
}
