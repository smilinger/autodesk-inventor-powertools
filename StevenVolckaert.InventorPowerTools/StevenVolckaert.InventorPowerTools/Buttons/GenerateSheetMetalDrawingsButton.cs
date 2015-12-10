﻿using System;
using Inventor;
using StevenVolckaert.InventorPowerTools.Windows;
using Environment = System.Environment;

namespace StevenVolckaert.InventorPowerTools.Buttons
{
    internal class GenerateSheetMetalDrawingsButton : ButtonBase
    {
        private readonly GenerateSheetMetalDrawingsWindow _generateSheetMetalDrawingsWindow = new GenerateSheetMetalDrawingsWindow();

        public override string DisplayName
        {
            get { return "Sheet Metal" + Environment.NewLine + "Flat Pattern"; }
        }

        public override string Description
        {
            get { return "Generate a flat pattern drawing of every" + Environment.NewLine + "sheet metal part in the active document."; }
        }

        protected override void OnExecute(NameValueMap context)
        {
            try
            {
                var assembly = AddIn.GetAssemblyDocument();

                if (assembly == null)
                    return;

                var sheetMetalParts = assembly.SheetMetalParts();

                if (sheetMetalParts.Count == 0)
                {
                    ShowWarningMessageBox("Assembly {0} doesn't contain any sheet metal parts.", assembly.FullFileName);
                    return;
                }

                _generateSheetMetalDrawingsWindow.Show(assembly, sheetMetalParts);
            }
            catch (Exception ex)
            {
                ShowWarningMessageBox(ex);
            }
        }
    }
}
