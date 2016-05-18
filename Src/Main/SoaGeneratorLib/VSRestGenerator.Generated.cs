using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // The main file of the generator.
    public partial class VSRestGenerator : Generator<IEnumerable<SoaObject>, GeneratorContext>
    {
        public VSGenerator VSGenerator { get; private set; }
        
        public VSRestGenerator(IEnumerable<SoaObject> instances, GeneratorContext context)
            : base(instances, context)
        {
            this.Properties = new PropertyGroup_Properties();
            this.VSGenerator = new VSGenerator(instances, context);
        }
        
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\VSRestGenerator.mcg"
            public PropertyGroup_Properties Properties { get; private set; }
            
            public class PropertyGroup_Properties
            {
                public PropertyGroup_Properties()
                {
                    this.ProjectName = "VisualStudioProject";
                    this.ResourcesDir = "../Resources";
                    this.OutputDir = "../../Output";
                    this.ThrowNotImplementedException = true;
                    this.NoWindowsIdentityFoundation = true;
                }
                
                public string ProjectName { get; set; }
                public string ResourcesDir { get; set; }
                public string OutputDir { get; set; }
                public bool ThrowNotImplementedException { get; set; }
                public bool NoWindowsIdentityFoundation { get; set; }
            }
            
            public override void Generated_Main()
            {
                VSGenerator.Properties.ProjectName = Properties.ProjectName;
                VSGenerator.Properties.ResourcesDir = Properties.ResourcesDir;
                VSGenerator.Properties.OutputDir = Properties.OutputDir;
                Context.SetOutputFolder(Properties.OutputDir);
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/About.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/About.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/About.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/About.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Default.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Default.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Default.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Default.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Global.asax", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Global.asax", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Site.master", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Site.master", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Site.master.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Site.master.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/web.config", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/web.config", true);
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account");
                File.Copy(Properties.ResourcesDir + "/VisualStudio/ChangePassword.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/ChangePassword.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/ChangePassword.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/ChangePassword.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/ChangePasswordSuccess.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/ChangePasswordSuccess.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/ChangePasswordSuccess.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/ChangePasswordSuccess.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Login.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/Login.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Login.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/Login.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Register.aspx", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/Register.aspx", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Register.aspx.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/Register.aspx.cs", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/AccountWeb.config", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Account/Web.config", true);
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code");
                if (!Properties.NoWindowsIdentityFoundation)
                {
                    File.Copy(Properties.ResourcesDir + "/VisualStudio/SampleRequestValidator.cs", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code/SampleRequestValidator.cs", true);
                }
                int __loop1_iteration = 0;
                var __loop1_result =
                    (from __loop1_tmp_item___noname1 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                    from __loop1_tmp_item_ns in EnumerableExtensions.Enumerate((__loop1_tmp_item___noname1).GetEnumerator()).OfType<Namespace>()
                    select
                        new
                        {
                            __loop1_item___noname1 = __loop1_tmp_item___noname1,
                            __loop1_item_ns = __loop1_tmp_item_ns,
                        }).ToArray();
                foreach (var __loop1_item in __loop1_result)
                {
                    var __noname1 = __loop1_item.__loop1_item___noname1;
                    var ns = __loop1_item.__loop1_item_ns;
                    ++__loop1_iteration;
                    int i = 0;
                    int __loop2_iteration = 0;
                    var __loop2_result =
                        (from __loop2_tmp_item___noname2 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop2_tmp_item_d in EnumerableExtensions.Enumerate((__loop2_tmp_item___noname2).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop2_item___noname2 = __loop2_tmp_item___noname2,
                                __loop2_item_d = __loop2_tmp_item_d,
                            }).ToArray();
                    foreach (var __loop2_item in __loop2_result)
                    {
                        var __noname2 = __loop2_item.__loop2_item___noname2;
                        var d = __loop2_item.__loop2_item_d;
                        ++__loop2_iteration;
                        i = i + 1;
                    }
                    if (ns.Declarations.Count > i)
                    {
                        Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code/" + ns.FullName + ".cs");
                        Context.Output(VSGenerator.Generated_GenerateDataTypes(ns));
                    }
                }
                int __loop3_iteration = 0;
                var __loop3_result =
                    (from __loop3_tmp_item___noname3 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                    from __loop3_tmp_item_intf in EnumerableExtensions.Enumerate((__loop3_tmp_item___noname3).GetEnumerator()).OfType<Interface>()
                    select
                        new
                        {
                            __loop3_item___noname3 = __loop3_tmp_item___noname3,
                            __loop3_item_intf = __loop3_tmp_item_intf,
                        }).ToArray();
                foreach (var __loop3_item in __loop3_result)
                {
                    var __noname3 = __loop3_item.__loop3_item___noname3;
                    var intf = __loop3_item.__loop3_item_intf;
                    ++__loop3_iteration;
                    Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code/" + intf.Name + ".cs");
                    Context.Output(Generated_GenerateInterface(intf));
                }
                int __loop4_iteration = 0;
                var __loop4_result =
                    (from __loop4_tmp_item___noname4 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                    from __loop4_tmp_item_endp in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname4).GetEnumerator()).OfType<Endpoint>()
                    select
                        new
                        {
                            __loop4_item___noname4 = __loop4_tmp_item___noname4,
                            __loop4_item_endp = __loop4_tmp_item_endp,
                        }).ToArray();
                foreach (var __loop4_item in __loop4_result)
                {
                    var __noname4 = __loop4_item.__loop4_item___noname4;
                    var endp = __loop4_item.__loop4_item_endp;
                    ++__loop4_iteration;
                    Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code/" + endp.Name + ".cs");
                    Context.Output(Generated_GenerateInterfaceImpl(endp));
                    Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Code/" + endp.Name + "Client.cs");
                    Context.Output(VSGenerator.Generated_GenerateClient(endp));
                }
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/App_Data");
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/" + Properties.ProjectName + ".csproj");
                Context.Output(VSGenerator.Generated_GenerateServerProject());
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Scripts");
                File.Copy(Properties.ResourcesDir + "/VisualStudio/jquery-1.4.1.js", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Scripts/jquery-1.4.1.js", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/jquery-1.4.1.min.js", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Scripts/jquery-1.4.1.min.js", true);
                File.Copy(Properties.ResourcesDir + "/VisualStudio/jquery-1.4.1-vsdoc.js", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Scripts/jquery-1.4.1-vsdoc.js", true);
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Services");
                int __loop5_iteration = 0;
                var __loop5_result =
                    (from __loop5_tmp_item___noname5 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                    from __loop5_tmp_item_endp in EnumerableExtensions.Enumerate((__loop5_tmp_item___noname5).GetEnumerator()).OfType<Endpoint>()
                    select
                        new
                        {
                            __loop5_item___noname5 = __loop5_tmp_item___noname5,
                            __loop5_item_endp = __loop5_tmp_item_endp,
                        }).ToArray();
                foreach (var __loop5_item in __loop5_result)
                {
                    var __noname5 = __loop5_item.__loop5_item___noname5;
                    var endp = __loop5_item.__loop5_item_endp;
                    ++__loop5_iteration;
                    Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Services/" + endp.Name + ".svc");
                    Context.Output(VSGenerator.Generated_GenerateService(endp));
                }
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Services/Web.config");
                Context.Output(Generated_GenerateWebConfig());
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Clients");
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Clients/App.config");
                Context.Output(Generated_GenerateClientAppConfig());
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Services/Default.aspx");
                Context.Output(VSGenerator.Generated_GenerateServicesDefaultAspx());
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Services/Default.aspx.cs");
                Context.Output(VSGenerator.Generated_GenerateServicesDefaultAspxCs());
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Styles");
                File.Copy(Properties.ResourcesDir + "/VisualStudio/Site.css", "VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "/Styles/Site.css", true);
                Context.SetOutputFolder(Properties.OutputDir);
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client");
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + ".sln");
                Context.Output(VSGenerator.Generated_GenerateSolution());
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/" + Properties.ProjectName + "Client.csproj");
                Context.Output(VSGenerator.Generated_GenerateClientProject());
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/Program.cs");
                Context.Output(Generated_GenerateProgramCs());
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/App.config");
                Context.Output(Generated_GenerateClientAppConfig());
                Context.CreateFolder("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/Properties");
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/Properties/AssemblyInfo.cs");
                Context.Output(VSGenerator.Generated_GenerateAssemblyInfo());
                int __loop6_iteration = 0;
                var __loop6_result =
                    (from __loop6_tmp_item___noname6 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                    from __loop6_tmp_item_ns in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname6).GetEnumerator()).OfType<Namespace>()
                    select
                        new
                        {
                            __loop6_item___noname6 = __loop6_tmp_item___noname6,
                            __loop6_item_ns = __loop6_tmp_item_ns,
                        }).ToArray();
                foreach (var __loop6_item in __loop6_result)
                {
                    var __noname6 = __loop6_item.__loop6_item___noname6;
                    var ns = __loop6_item.__loop6_item_ns;
                    ++__loop6_iteration;
                    if (ns.HasDeclarations())
                    {
                        Context.SetOutput("VisualStudio/" + Properties.ProjectName + "/" + Properties.ProjectName + "Client/" + ns.FullName + ".cs");
                        Context.Output(Generated_GenerateFullNamespace(ns));
                    }
                }
                Context.SetOutput("VisualStudio/" + Properties.ProjectName + "_windows_script.bat");
                Context.Output(VSGenerator.Generated_GenerateInstallCertificates());
            }
            
            public List<string> Generated_GenerateFullNamespace(Namespace ns)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("using System;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Collections.Generic;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Linq;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Runtime.Serialization;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.ServiceModel;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Text;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("namespace ");
                    __printer.Write(ns.FullName);
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("{");
                    __printer.WriteLine();
                    __printer.Write(VSGenerator.Generated_GenerateDataTypesPart(ns));
                    __printer.WriteLine();
                    __printer.Write(Generated_GenerateInterfacePart(ns));
                    __printer.WriteLine();
                    __printer.Write(VSGenerator.Generated_GenerateClientPart(ns));
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateInterfacePart(Namespace ns)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    int __loop7_iteration = 0;
                    var __loop7_result =
                        (from __loop7_tmp_item___noname7 in EnumerableExtensions.Enumerate((ns).GetEnumerator())
                        from __loop7_tmp_item_Declarations in EnumerableExtensions.Enumerate((__loop7_tmp_item___noname7.Declarations).GetEnumerator())
                        from __loop7_tmp_item_intf in EnumerableExtensions.Enumerate((__loop7_tmp_item_Declarations).GetEnumerator()).OfType<Interface>()
                        select
                            new
                            {
                                __loop7_item___noname7 = __loop7_tmp_item___noname7,
                                __loop7_item_Declarations = __loop7_tmp_item_Declarations,
                                __loop7_item_intf = __loop7_tmp_item_intf,
                            }).ToArray();
                    foreach (var __loop7_item in __loop7_result)
                    {
                        var __noname7 = __loop7_item.__loop7_item___noname7;
                        var Declarations = __loop7_item.__loop7_item_Declarations;
                        var intf = __loop7_item.__loop7_item_intf;
                        ++__loop7_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        __printer.Write(Generated_GenerateInterfacePart(intf));
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateInterface(Interface intf)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("using System;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Collections.Generic;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Linq;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Runtime.Serialization;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.ServiceModel;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.ServiceModel.Web;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Text;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("namespace ");
                    __printer.Write(intf.Namespace.FullName);
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("{");
                    __printer.WriteLine();
                    __printer.Write(Generated_GenerateInterfacePart(intf));
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateInterfacePart(Interface intf)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("System.ServiceModel.ServiceContractAttribute");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public interface ");
                    __printer.Write(intf.Name);
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    {");
                    __printer.WriteLine();
                    int __loop8_iteration = 0;
                    var __loop8_result =
                        (from __loop8_tmp_item___noname8 in EnumerableExtensions.Enumerate((intf.Operations).GetEnumerator())
                        from __loop8_tmp_item_op in EnumerableExtensions.Enumerate((__loop8_tmp_item___noname8).GetEnumerator()).OfType<Operation>()
                        select
                            new
                            {
                                __loop8_item___noname8 = __loop8_tmp_item___noname8,
                                __loop8_item_op = __loop8_tmp_item_op,
                            }).ToArray();
                    foreach (var __loop8_item in __loop8_result)
                    {
                        var __noname8 = __loop8_item.__loop8_item___noname8;
                        var op = __loop8_item.__loop8_item_op;
                        ++__loop8_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        ");
                        __printer.Write("[");
                        __printer.WriteTemplateOutput("System.ServiceModel.OperationContractAttribute");
                        __printer.Write("]");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        ");
                        __printer.Write("[");
                        __printer.WriteTemplateOutput("System.ServiceModel.Web.WebInvokeAttribute(Method=\"POST\", UriTemplate=\"");
                        __printer.Write(op.Name);
                        __printer.WriteTemplateOutput("\", BodyStyle=WebMessageBodyStyle.Wrapped, ResponseFormat=WebMessageFormat.Xml, RequestFormat=WebMessageFormat.Xml)");
                        __printer.Write("]");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		");
                        __printer.Write(VSGenerator.Generated_GenerateOperationHead(op));
                        __printer.WriteTemplateOutput(";");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateInterfaceImpl(Endpoint endp)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("using System;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Collections.Generic;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Linq;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Web;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.ServiceModel;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("namespace ");
                    __printer.Write(endp.Namespace.FullName);
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("{   ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public class ");
                    __printer.Write(endp.Name);
                    __printer.WriteTemplateOutput(" : ");
                    __printer.Write(endp.Interface.Name);
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    {");
                    __printer.WriteLine();
                    int __loop9_iteration = 0;
                    var __loop9_result =
                        (from __loop9_tmp_item___noname9 in EnumerableExtensions.Enumerate((endp.Interface.Operations).GetEnumerator())
                        from __loop9_tmp_item_op in EnumerableExtensions.Enumerate((__loop9_tmp_item___noname9).GetEnumerator()).OfType<Operation>()
                        select
                            new
                            {
                                __loop9_item___noname9 = __loop9_tmp_item___noname9,
                                __loop9_item_op = __loop9_tmp_item_op,
                            }).ToArray();
                    foreach (var __loop9_item in __loop9_result)
                    {
                        var __noname9 = __loop9_item.__loop9_item___noname9;
                        var op = __loop9_item.__loop9_item_op;
                        ++__loop9_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        public ");
                        __printer.Write(VSGenerator.Generated_GenerateOperationHead(op));
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        {           ");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("            ");
                        if (Properties.ThrowNotImplementedException)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            throw new NotImplementedException();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            ");
                        }
                        __printer.WriteTemplateOutput("           ");
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateProgramCs()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("using System;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Collections.Generic;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Linq;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Text;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.ServiceModel;");
                    __printer.WriteLine();
                    int __loop10_iteration = 0;
                    var __loop10_result =
                        (from __loop10_tmp_item___noname10 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop10_tmp_item_ns in EnumerableExtensions.Enumerate((__loop10_tmp_item___noname10).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop10_item___noname10 = __loop10_tmp_item___noname10,
                                __loop10_item_ns = __loop10_tmp_item_ns,
                            }).ToArray();
                    foreach (var __loop10_item in __loop10_result)
                    {
                        var __noname10 = __loop10_item.__loop10_item___noname10;
                        var ns = __loop10_item.__loop10_item_ns;
                        ++__loop10_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if (ns.HasDeclarations())
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("using ");
                            __printer.Write(ns.FullName);
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("namespace ");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("{");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    enum TargetFramework");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        Wcf,");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        Metro,");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        TomcatCxf,");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        Oracle,");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        Ibm");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public class Program");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        private const bool PrintExceptions = false;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        private static readonly Dictionary<TargetFramework, string> Urls = new Dictionary<TargetFramework, string>();");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        private const TargetFramework Target = TargetFramework.Wcf;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        static void Main(string");
                    __printer.Write("[]");
                    __printer.WriteTemplateOutput(" args)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            using (ConsoleCopy cc = new ConsoleCopy(@\"..\\..\\Wcf.txt\"))");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                Urls.Add(TargetFramework.Wcf, \"http://localhost/WsInteropTest/Services/{0}.svc\");");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                Urls.Add(TargetFramework.Metro, \"http://localhost:8080/WsInteropTest/services/{0}\");");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                Urls.Add(TargetFramework.TomcatCxf, \"http://localhost:9080/WsInteropTest/services/{0}\");");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                Urls.Add(TargetFramework.Oracle, \"http://192.168.136.128:7101/WsInteropTest/services/{0}\");");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                Urls.Add(TargetFramework.Ibm, \"http://192.168.136.128:9080/WsInteropTest/{0}\");");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                string url = Urls");
                    __printer.Write("[Target]");
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                try");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("					");
                    int __loop11_iteration = 0;
                    var __loop11_result =
                        (from __loop11_tmp_item___noname11 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop11_tmp_item_endp in EnumerableExtensions.Enumerate((__loop11_tmp_item___noname11).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop11_item___noname11 = __loop11_tmp_item___noname11,
                                __loop11_item_endp = __loop11_tmp_item_endp,
                            }).ToArray();
                    foreach (var __loop11_item in __loop11_result)
                    {
                        var __noname11 = __loop11_item.__loop11_item___noname11;
                        var endp = __loop11_item.__loop11_item_endp;
                        ++__loop11_iteration;
                        __printer.WriteTemplateOutput("                ");
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					Test");
                        __printer.Write(endp.Interface.Name);
                        __printer.WriteTemplateOutput("(\"");
                        __printer.Write(endp.Name);
                        __printer.WriteTemplateOutput("\", url);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                catch (Exception ex)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                    Console.WriteLine(ex);");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		");
                    int __loop12_iteration = 0;
                    var __loop12_result =
                        (from __loop12_tmp_item___noname12 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop12_tmp_item_intf in EnumerableExtensions.Enumerate((__loop12_tmp_item___noname12).GetEnumerator()).OfType<Interface>()
                        select
                            new
                            {
                                __loop12_item___noname12 = __loop12_tmp_item___noname12,
                                __loop12_item_intf = __loop12_tmp_item_intf,
                            }).ToArray();
                    foreach (var __loop12_item in __loop12_result)
                    {
                        var __noname12 = __loop12_item.__loop12_item___noname12;
                        var intf = __loop12_item.__loop12_item_intf;
                        ++__loop12_iteration;
                        __printer.WriteTemplateOutput("                ");
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		private static void Test");
                        __printer.Write(intf.Name);
                        __printer.WriteTemplateOutput("(string endpoint, string url, bool close = true)");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			Console.WriteLine(endpoint);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			try");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				var factory = new ChannelFactory<");
                        __printer.Write(intf.Name);
                        __printer.WriteTemplateOutput(">(\"");
                        __printer.Write(intf.Namespace.FullName);
                        __printer.WriteTemplateOutput(".\"+endpoint);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				var address = new EndpointAddress(new Uri(string.Format(url, endpoint)), EndpointIdentity.CreateDnsIdentity(\"WspService\"));");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				");
                        __printer.Write(intf.Name);
                        __printer.WriteTemplateOutput(" service = factory.CreateChannel(address);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				try");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					// call service");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					try");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("						if (close)");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("                        {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("                            ((IDisposable)service).Dispose();");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("                        }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					catch (Exception ex)");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("						Console.WriteLine(\"Close failed.\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("						if (PrintExceptions) Console.WriteLine(ex);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				catch (Exception ex)");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					Console.WriteLine(\"Call failed.\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("					if (PrintExceptions) Console.WriteLine(ex);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("				}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			catch (Exception ex)");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			{");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	            Console.WriteLine(\"Init failed.\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	            if (PrintExceptions) Console.WriteLine(ex);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("			Console.WriteLine(\"----\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		}");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            #endregion
                #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\GeneratorLib.mcg"
                public string Generated_FirstLetterLow(string s)
                {
                    return s.Substring(0, 1).ToLower() + s.Substring(1);
                }
                
                public string Generated_FirstLetterUp(string s)
                {
                    return s.Substring(0, 1).ToUpper() + s.Substring(1);
                }
                
                public string Generated_GetUri(Namespace ns)
                {
                    return GeneratorLibExtensions.GetUri(ns);
                }
                
                public string Generated_GetUriWithSlash(Namespace ns)
                {
                    return GeneratorLibExtensions.GetUriWithSlash(ns);
                }
                
                public string Generated_GetPackage(Namespace ns)
                {
                    return GeneratorLibExtensions.GetPackage(ns);
                }
                
                public string Generated_IsNillableType(Type t)
                {
                    if (t is BuiltInType)
                    {
                        if (t == BuiltInType.String)
                        {
                            return "true";
                        }
                        else
                        {
                            return "false";
                        }
                    }
                    else if (t is EnumType)
                    {
                        return "false";
                    }
                    else
                    {
                        return "true";
                    }
                }
                
                #endregion
            }
        }
        
