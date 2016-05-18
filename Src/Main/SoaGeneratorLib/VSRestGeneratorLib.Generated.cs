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
                    __printer.WriteTemplateOutput("  ");
                    int __loop1_iteration = 0;
                    var __loop1_result =
                        (from __loop1_tmp_item___noname1 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop1_tmp_item_endpoint in EnumerableExtensions.Enumerate((__loop1_tmp_item___noname1).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop1_item___noname1 = __loop1_tmp_item___noname1,
                                __loop1_item_endpoint = __loop1_tmp_item_endpoint,
                            }).ToArray();
                    foreach (var __loop1_item in __loop1_result)
                    {
                        var __noname1 = __loop1_item.__loop1_item___noname1;
                        var endpoint = __loop1_item.__loop1_item_endpoint;
                        ++__loop1_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("  <serviceBehaviors>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  <behavior name=\"");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("Behavior\">  ");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<serviceMetadata httpGetEnabled=\"true\"/>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<serviceDebug includeExceptionDetailInFaults=\"false\"/>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  </behavior>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("  </serviceBehaviors>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("  <endpointBehaviors>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        <behavior name=\"web\">");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("          <webHttp/>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        </behavior>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("  </endpointBehaviors>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("  ");
                    }
                    __printer.TrimLine();
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
                    __printer.WriteTemplateOutput("	");
                    int __loop2_iteration = 0;
                    var __loop2_result =
                        (from __loop2_tmp_item___noname2 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop2_tmp_item_endpoint in EnumerableExtensions.Enumerate((__loop2_tmp_item___noname2).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop2_item___noname2 = __loop2_tmp_item___noname2,
                                __loop2_item_endpoint = __loop2_tmp_item_endpoint,
                            }).ToArray();
                    foreach (var __loop2_item in __loop2_result)
                    {
                        var __noname2 = __loop2_item.__loop2_item___noname2;
                        var endpoint = __loop2_item.__loop2_item_endpoint;
                        ++__loop2_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  <behavior name=\"");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("Behavior\">  ");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<serviceMetadata httpGetEnabled=\"true\"/>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<serviceDebug includeExceptionDetailInFaults=\"false\"/>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  </behavior>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
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
                    __printer.WriteTemplateOutput("	");
                    int __loop3_iteration = 0;
                    var __loop3_result =
                        (from __loop3_tmp_item___noname3 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop3_tmp_item_endpoint in EnumerableExtensions.Enumerate((__loop3_tmp_item___noname3).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop3_item___noname3 = __loop3_tmp_item___noname3,
                                __loop3_item_endpoint = __loop3_tmp_item_endpoint,
                            }).ToArray();
                    foreach (var __loop3_item in __loop3_result)
                    {
                        var __noname3 = __loop3_item.__loop3_item___noname3;
                        var endpoint = __loop3_item.__loop3_item_endpoint;
                        ++__loop3_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	<service name=\"");
                        __printer.Write(endpoint.Interface.Namespace.FullName);
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("\" behaviorConfiguration=\"");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("Behavior\">");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<endpoint address=\"\" binding=\"webHttpBinding\" contract=\"");
                        __printer.Write(endpoint.Interface.Namespace.FullName);
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(endpoint.Interface.Name);
                        __printer.WriteTemplateOutput("\"");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				  behaviorConfiguration=\"web\"></endpoint>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	</service>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
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
                    __printer.WriteTemplateOutput("	");
                    int __loop4_iteration = 0;
                    var __loop4_result =
                        (from __loop4_tmp_item___noname4 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop4_tmp_item_endpoint in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname4).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop4_item___noname4 = __loop4_tmp_item___noname4,
                                __loop4_item_endpoint = __loop4_tmp_item_endpoint,
                            }).ToArray();
                    foreach (var __loop4_item in __loop4_result)
                    {
                        var __noname4 = __loop4_item.__loop4_item___noname4;
                        var endpoint = __loop4_item.__loop4_item_endpoint;
                        ++__loop4_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  <endpoint name=\"");
                        __printer.Write(endpoint.Interface.Namespace.FullName);
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("\" contract=\"");
                        __printer.Write(endpoint.Interface.Namespace.FullName);
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(endpoint.Interface.Name);
                        __printer.WriteTemplateOutput("\" binding=\"customBinding\" bindingConfiguration=\"");
                        __printer.Write(endpoint.Binding.Name);
                        __printer.WriteTemplateOutput("\" behaviorConfiguration=\"");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("Behavior\" address=\"");
                        __printer.Write(endpoint.Address.Uri);
                        __printer.WriteTemplateOutput("\">");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	  </endpoint>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</client>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            #endregion
        }
    }
    
