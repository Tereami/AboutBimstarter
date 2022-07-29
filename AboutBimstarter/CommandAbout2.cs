using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.IO;


namespace AboutWeandrevit
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Automatic)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    class CommandAbout2 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            int installedVersion = 0;
            string appdataFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string bimstarterFolder =
                Path.Combine(appdataFolder, "Autodesk", "Revit", "Addins", "20xx", "BimStarter");
            if (Directory.Exists(bimstarterFolder))
            {
                string[] files = Directory.GetFiles(bimstarterFolder);
                string[] versionFiles = files
                    .Where(i => char.IsDigit(i.Last()))
                    .ToArray();
                if (versionFiles.Length > 0)
                {
                    string filename = versionFiles[0];
                    string filename0 = filename.Substring(filename.Length - 3);
                    int.TryParse(filename0, out installedVersion);
                }
            }

            AboutBimstarter.AboutForm form = new AboutBimstarter.AboutForm(installedVersion);

            form.ShowDialog();

            return Result.Succeeded;

        }
    }
}
