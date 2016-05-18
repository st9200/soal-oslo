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
                    __printer.WriteTemplateOutput("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"VSProj\", \"VSProj\\VSProj.csproj\", \"{33796CD6-1826-4543-8802-EADFCA82243A}\"");
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
                    __printer.WriteTemplateOutput("    <Reference Include=\"Microsoft.CSharp\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.DynamicData\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Entity\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.ApplicationServices\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Configuration\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Core\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Data\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Drawing\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.EnterpriseServices\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Runtime.Serialization\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.ServiceModel\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.ServiceModel.Web\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Extensions\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Services\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml.Linq\" />");
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
            
            public List<string> Generated_GenerateServerProject()
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ProductVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </ProductVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <SchemaVersion>2.0</SchemaVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ProjectGuid>{33796CD6-1826-4543-8802-EADFCA82243A}</ProjectGuid>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ProjectTypeGuids>{349c5851-65df-11da-9384-00065b846f21};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}</ProjectTypeGuids>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputType>Library</OutputType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <AppDesignerFolder>Properties</AppDesignerFolder>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <RootNamespace>");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("</RootNamespace>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <AssemblyName>");
                    __printer.Write(Properties.ProjectName);
                    __printer.WriteTemplateOutput("</AssemblyName>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <WcfConfigValidationEnabled>True</WcfConfigValidationEnabled>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <UseIISExpress>true</UseIISExpress>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <IISExpressSSLPort />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <IISExpressAnonymousAuthentication />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <IISExpressWindowsAuthentication />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <IISExpressUseClassicPipelineMode />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <UseGlobalApplicationHostFile />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugSymbols>true</DebugSymbols>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugType>full</DebugType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Optimize>false</Optimize>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputPath>bin\\</OutputPath>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DefineConstants>DEBUG;TRACE</DefineConstants>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <ErrorReport>prompt</ErrorReport>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <WarningLevel>4</WarningLevel>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <DebugType>pdbonly</DebugType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Optimize>true</Optimize>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <OutputPath>bin\\</OutputPath>");
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
                    __printer.WriteTemplateOutput("    <Reference Include=\"Microsoft.CSharp\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.DynamicData\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Entity\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.ApplicationServices\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Configuration\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Core\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Data\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Drawing\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.EnterpriseServices\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Runtime.Serialization\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.ServiceModel\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.ServiceModel.Web\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Extensions\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Web.Services\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Reference Include=\"System.Xml.Linq\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Folder Include=\"App_Data\\\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Folder Include=\"Properties\\\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"About.aspx\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Account\\ChangePassword.aspx\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Account\\ChangePasswordSuccess.aspx\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Default.aspx\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Global.asax\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Services\\Default.aspx\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	");
                    int __loop3_iteration = 0;
                    var __loop3_result =
                        (from __loop3_tmp_item___noname3 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop3_tmp_item_endp in EnumerableExtensions.Enumerate((__loop3_tmp_item___noname3).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop3_item___noname3 = __loop3_tmp_item___noname3,
                                __loop3_item_endp = __loop3_tmp_item_endp,
                            }).ToArray();
                    foreach (var __loop3_item in __loop3_result)
                    {
                        var __noname3 = __loop3_item.__loop3_item___noname3;
                        var endp = __loop3_item.__loop3_item_endp;
                        ++__loop3_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    <Content Include=\"Services\\");
                        __printer.Write(endp.Name);
                        __printer.WriteTemplateOutput(".svc\" />");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Styles\\Site.css\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <None Include=\"Scripts\\jquery-1.4.1-vsdoc.js\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Scripts\\jquery-1.4.1.js\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Scripts\\jquery-1.4.1.min.js\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Services\\Web.config\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Site.master\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"web.config\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <None Include=\"web.Debug.config\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>web.config</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </None>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <None Include=\"web.Release.config\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>web.config</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </None>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"About.aspx.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>About.aspx</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Account\\ChangePassword.aspx.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>ChangePassword.aspx</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Account\\ChangePasswordSuccess.aspx.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>ChangePasswordSuccess.aspx</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Default.aspx.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>Default.aspx</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Services\\Default.aspx.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>Default.aspx</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Compile Include=\"Site.master.cs\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <DependentUpon>Site.master</DependentUpon>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <SubType>ASPXCodeBehind</SubType>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </Compile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    int __loop4_iteration = 0;
                    var __loop4_result =
                        (from __loop4_tmp_item___noname4 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop4_tmp_item_ns in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname4).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop4_item___noname4 = __loop4_tmp_item___noname4,
                                __loop4_item_ns = __loop4_tmp_item_ns,
                            }).ToArray();
                    foreach (var __loop4_item in __loop4_result)
                    {
                        var __noname4 = __loop4_item.__loop4_item___noname4;
                        var ns = __loop4_item.__loop4_item_ns;
                        ++__loop4_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                        if (ns.HasDeclarations())
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("		<Compile Include=\"App_Code\\");
                            __printer.Write(ns.FullName);
                            __printer.WriteTemplateOutput(".cs\" />");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("	");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	");
                    int __loop5_iteration = 0;
                    var __loop5_result =
                        (from __loop5_tmp_item___noname5 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop5_tmp_item_intf in EnumerableExtensions.Enumerate((__loop5_tmp_item___noname5).GetEnumerator()).OfType<Interface>()
                        select
                            new
                            {
                                __loop5_item___noname5 = __loop5_tmp_item___noname5,
                                __loop5_item_intf = __loop5_tmp_item_intf,
                            }).ToArray();
                    foreach (var __loop5_item in __loop5_result)
                    {
                        var __noname5 = __loop5_item.__loop5_item___noname5;
                        var intf = __loop5_item.__loop5_item_intf;
                        ++__loop5_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<Compile Include=\"App_Code\\");
                        __printer.Write(intf.Name);
                        __printer.WriteTemplateOutput(".cs\" />");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("	");
                    int __loop6_iteration = 0;
                    var __loop6_result =
                        (from __loop6_tmp_item___noname6 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop6_tmp_item_endp in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname6).GetEnumerator()).OfType<Endpoint>()
                        select
                            new
                            {
                                __loop6_item___noname6 = __loop6_tmp_item___noname6,
                                __loop6_item_endp = __loop6_tmp_item_endp,
                            }).ToArray();
                    foreach (var __loop6_item in __loop6_result)
                    {
                        var __noname6 = __loop6_item.__loop6_item___noname6;
                        var endp = __loop6_item.__loop6_item_endp;
                        ++__loop6_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<Compile Include=\"App_Code\\");
                        __printer.Write(endp.Name);
                        __printer.WriteTemplateOutput(".cs\" />");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<Compile Include=\"App_Code\\");
                        __printer.Write(endp.Name);
                        __printer.WriteTemplateOutput("Client.cs\" />");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Account\\Web.config\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <Content Include=\"Clients\\App.config\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ItemGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <VisualStudioVersion Condition=\"'$(VisualStudioVersion)' == ''\">10.0</VisualStudioVersion>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <VSToolsPath Condition=\"'$(VSToolsPath)' == ''\">$(MSBuildExtensionsPath32)\\Microsoft\\VisualStudio\\v$(VisualStudioVersion)</VSToolsPath>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </PropertyGroup>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Import Project=\"$(VSToolsPath)\\WebApplications\\Microsoft.WebApplication.targets\" Condition=\"'$(VSToolsPath)' != ''\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <Import Project=\"$(MSBuildExtensionsPath32)\\Microsoft\\VisualStudio\\v10.0\\WebApplications\\Microsoft.WebApplication.targets\" Condition=\"false\" />");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  <ProjectExtensions>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    <VisualStudio>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      <FlavorProperties GUID=\"{349c5851-65df-11da-9384-00065b846f21}\">");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        <WebProjectProperties>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <UseIIS>True</UseIIS>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <AutoAssignPort>True</AutoAssignPort>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <DevelopmentServerPort>54307</DevelopmentServerPort>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <DevelopmentServerVPath>/</DevelopmentServerVPath>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <IISUrl>http://localhost:54307/</IISUrl>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <NTLMAuthentication>False</NTLMAuthentication>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <UseCustomServer>False</UseCustomServer>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <CustomServerUrl>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          </CustomServerUrl>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("          <SaveServerSettingsInUserFile>False</SaveServerSettingsInUserFile>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        </WebProjectProperties>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("      </FlavorProperties>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    </VisualStudio>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("  </ProjectExtensions>");
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
    
