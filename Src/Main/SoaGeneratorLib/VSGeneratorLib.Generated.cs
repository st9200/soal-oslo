using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // Inheritace from 'Generator<List<object>, GeneratorContext>' and constructor is only generated into the main file.
    public partial class VSGenerator
    {
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\VSGeneratorLib.mcg"
            public List<string> Generated_GenerateService(Endpoint endp)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<%@ ServiceHost Language=\"C#\" Debug=\"true\" Service=\"");
                    __printer.Write(endp.Namespace.FullName);
                    __printer.WriteTemplateOutput(".");
                    __printer.Write(endp.Name);
                    __printer.WriteTemplateOutput("\" CodeBehind=\"~/App_Code/");
                    __printer.Write(endp.Name);
                    __printer.WriteTemplateOutput(".cs\" %>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateServicesDefaultAspx()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<%@ Page Title=\"Services Home Page\" Language=\"C#\" MasterPageFile=\"~/Site.master\" AutoEventWireup=\"true\"");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    CodeFile=\"~/Services/Default.aspx.cs\" Inherits=\"Services._Default\" %>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<asp:Content ID=\"HeaderContent\" runat=\"server\" ContentPlaceHolderID=\"HeadContent\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</asp:Content>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<asp:Content ID=\"BodyContent\" runat=\"server\" ContentPlaceHolderID=\"MainContent\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <h2>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        Services");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </h2>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <p>");
                    __printer.WriteLine();
                    int __loop1_iteration = 0;
                    int id = 1;
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
                        if (__loop1_iteration >= 2)
                        {
                            id = id + 1;
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    <asp:HyperLink ID=\"HyperLink");
                        __printer.Write(id);
                        __printer.WriteTemplateOutput("\" runat=\"server\" NavigateUrl=\"~/Services/");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput(".svc\">");
                        __printer.Write(endpoint.Name);
                        __printer.WriteTemplateOutput("</asp:HyperLink><br/>");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </p>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</asp:Content>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateServicesDefaultAspxCs()
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
                    __printer.WriteTemplateOutput("using System.Web.UI;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Web.UI.WebControls;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("namespace Services");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("{");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	public partial class _Default : System.Web.UI.Page");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	{");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		protected void Page_Load(object sender, EventArgs e)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		{");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		}");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	}");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateSolution()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("Microsoft Visual Studio Solution File, Format Version 11.00");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("# Visual Studio 2010");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client\", \"");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client\\");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client.csproj\", \"{25817C9A-811D-4D02-B475-927904A404FD}\"");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("EndProject");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("Global");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		Debug|x86 = Debug|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		Release|x86 = Release|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	EndGlobalSection");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		{25817C9A-811D-4D02-B475-927904A404FD}.Debug|x86.ActiveCfg = Debug|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		{25817C9A-811D-4D02-B475-927904A404FD}.Debug|x86.Build.0 = Debug|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		{25817C9A-811D-4D02-B475-927904A404FD}.Release|x86.ActiveCfg = Release|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		{25817C9A-811D-4D02-B475-927904A404FD}.Release|x86.Build.0 = Release|x86");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	EndGlobalSection");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	GlobalSection(SolutionProperties) = preSolution");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("		HideSolutionNode = FALSE");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	EndGlobalSection");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("EndGlobal");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateClientProject()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Platform Condition=\" '$(Platform)' == '' \">x86</Platform>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ProductVersion>8.0.30703</ProductVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <SchemaVersion>2.0</SchemaVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ProjectGuid>{25817C9A-811D-4D02-B475-927904A404FD}</ProjectGuid>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputType>Exe</OutputType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <RootNamespace>");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client</RootNamespace>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <AssemblyName>");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client</AssemblyName>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <TargetFrameworkProfile>Client</TargetFrameworkProfile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <FileAlignment>512</FileAlignment>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|x86' \">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <PlatformTarget>x86</PlatformTarget>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugSymbols>true</DebugSymbols>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugType>full</DebugType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Optimize>false</Optimize>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputPath>bin\\Debug\\</OutputPath>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DefineConstants>DEBUG;TRACE</DefineConstants>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ErrorReport>prompt</ErrorReport>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <WarningLevel>4</WarningLevel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|x86' \">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <PlatformTarget>x86</PlatformTarget>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugType>pdbonly</DebugType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Optimize>true</Optimize>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputPath>bin\\Release\\</OutputPath>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DefineConstants>TRACE</DefineConstants>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ErrorReport>prompt</ErrorReport>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <WarningLevel>4</WarningLevel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Core\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Runtime.Serialization\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.ServiceModel\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml.Linq\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Data.DataSetExtensions\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"Microsoft.CSharp\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Data\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    int __loop2_iteration = 0;
                    var __loop2_result =
                        (from __loop2_tmp_item___noname2 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop2_tmp_item_ns in EnumerableExtensions.Enumerate((__loop2_tmp_item___noname2).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop2_item___noname2 = __loop2_tmp_item___noname2,
                                __loop2_item_ns = __loop2_tmp_item_ns,
                            }).ToArray();
                    foreach (var __loop2_item in __loop2_result)
                    {
                        var __noname2 = __loop2_item.__loop2_item___noname2;
                        var ns = __loop2_item.__loop2_item_ns;
                        ++__loop2_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if (ns.HasDeclarations())
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    <Compile Include=\"");
                            __printer.Write(ns.FullName);
                            __printer.WriteTemplateOutput(".cs\" />");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Program.cs\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <None Include=\"App.config\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>Designer</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </None>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("       Other similar extension points exist, see Microsoft.Common.targets.");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Target Name=\"BeforeBuild\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </Target>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Target Name=\"AfterBuild\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </Target>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  -->");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</Project>");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateAssemblyInfo()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("using System.Reflection;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Runtime.CompilerServices;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("using System.Runtime.InteropServices;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// General Information about an assembly is controlled through the following ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// set of attributes. Change these attribute values to modify the information");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// associated with an assembly.");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyTitle(\"");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyDescription(\"\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyConfiguration(\"\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyCompany(\"\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyProduct(\"");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("Client\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyCopyright(\"Copyright ©  2014\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyTrademark(\"\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyCulture(\"\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// Setting ComVisible to false makes the types in this assembly not visible ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// to COM components.  If you need to access a type in this assembly from ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// COM, set the ComVisible attribute to true on that type.");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: ComVisible(false)");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// The following GUID is for the ID of the typelib if this project is exposed to COM");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: Guid(\"ef038eee-e47d-4905-84cc-5e147df1ffec\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// Version information for an assembly consists of the following four values:");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//      Major Version");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//      Minor Version ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//      Build Number");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//      Revision");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("//");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// You can specify all the values or you can default the Build and Revision Numbers ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// by using the '*' as shown below:");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("// ");
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyVersion(\"1.0.*\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyVersion(\"1.0.0.0\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                    __printer.Write("[");
                    __printer.WriteTemplateOutput("assembly: AssemblyFileVersion(\"1.0.0.0\")");
                    __printer.Write("]");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            #endregion
        }
    }
    
