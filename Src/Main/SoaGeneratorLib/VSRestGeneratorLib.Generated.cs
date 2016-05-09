using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // Inheritace from 'Generator<List<object>, GeneratorContext>' and constructor is only generated into the main file.
    public partial class VSRestGenerator
    {
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\VSRestGeneratorLib.mcg"
            public List<string> Generated_GenerateWebConfig()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<?xml version=\"1.0\"?>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<configuration>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <system.serviceModel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write(Generated_GenerateBehaviors());
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write(Generated_GenerateServices());
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </system.serviceModel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</configuration>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateClientAppConfig()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<?xml version=\"1.0\"?>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<configuration>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <system.serviceModel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write(Generated_GenerateClientBehaviors());
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write(Generated_GenerateClientEndpoints());
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </system.serviceModel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</configuration>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateBehaviors()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<behaviors>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  TODO");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</behaviors>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateClientBehaviors()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<behaviors>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <endpointBehaviors>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	TODO");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </endpointBehaviors>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</behaviors>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateServices()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<services>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	TODO");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</services>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateClientEndpoints()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<client>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	TODO");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</client>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            #endregion
        }
    }
    
