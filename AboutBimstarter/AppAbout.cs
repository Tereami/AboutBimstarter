﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Media.Imaging;
using System.Windows.Media;

using Autodesk.Revit;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;


namespace AboutBimstarter
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.ReadOnly)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class AppAbout : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string assemblyPath = typeof(AppAbout).Assembly.Location;

            string tabName = "BIM-STARTER";
            try { application.CreateRibbonTab(tabName); }
            catch { }


            //Панель "About"
            RibbonPanel panelAbout = application.CreateRibbonPanel(tabName, "BIM-STARTER");
            PushButton btnAbout = panelAbout.AddItem(new PushButtonData(
                "About",
                "О проекте",
                assemblyPath,
                "AboutBimstarter.CommandAbout")
                ) as PushButton;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;

        }

    }
}
