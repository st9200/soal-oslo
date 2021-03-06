﻿using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // The main file of the generator.
    public partial class JBossCxfGenerator : Generator<IEnumerable<SoaObject>, GeneratorContext>
    {
        public EclipseCxfGenerator EclipseCxfGenerator { get; private set; }
        public JavaRestGenerator JavaRestGenerator { get; private set; }
        public JavaSoapGenerator JavaSoapGenerator { get; private set; }
        public XsdWsdlGenerator XsdWsdlGenerator { get; private set; }
        
        public JBossCxfGenerator(IEnumerable<SoaObject> instances, GeneratorContext context)
            : base(instances, context)
        {
            this.Properties = new PropertyGroup_Properties();
            this.EclipseCxfGenerator = new EclipseCxfGenerator(instances, context);
            this.JavaRestGenerator = new JavaRestGenerator(instances, context);
            this.JavaSoapGenerator = new JavaSoapGenerator(instances, context);
            this.XsdWsdlGenerator = new XsdWsdlGenerator(instances, context);
        }
        
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\JBossCxfGenerator.mcg"
            public PropertyGroup_Properties Properties { get; private set; }
            
            public class PropertyGroup_Properties
            {
                public PropertyGroup_Properties()
                {
                    this.ProjectName = "JBossProject";
                    this.ResourcesDir = "../Resources";
                    this.OutputDir = "../../Output";
                    this.NoImplementationDelegates = true;
                    this.ThrowNotImplementedException = true;
                    this.GenerateProxyFeatureConstructors = false;
                    this.GenerateImplementationBase = false;
                    this.GenerateRestfulWebService = false;
                    this.CxfVersion = "2.7.11";
                    this.GenerateJksService = true;
                    this.GenerateJksClient = true;
                }
                
                public string ProjectName { get; set; }
                public string ResourcesDir { get; set; }
                public string OutputDir { get; set; }
                public bool NoImplementationDelegates { get; set; }
                public bool ThrowNotImplementedException { get; set; }
                public bool GenerateProxyFeatureConstructors { get; set; }
                public bool GenerateImplementationBase { get; set; }
                public bool GenerateRestfulWebService { get; set; }
                public string CxfVersion { get; set; }
                public bool GenerateJksService { get; set; }
                public bool GenerateJksClient { get; set; }
            }
            
            public override void Generated_Main()
            {
                JavaSoapGenerator.Properties.NoImplementationDelegates = Properties.NoImplementationDelegates;
                JavaSoapGenerator.Properties.ThrowNotImplementedException = Properties.ThrowNotImplementedException;
                JavaSoapGenerator.Properties.GenerateProxyFeatureConstructors = Properties.GenerateProxyFeatureConstructors;
                JavaSoapGenerator.Properties.GenerateImplementationBase = Properties.GenerateImplementationBase;
                JavaSoapGenerator.Properties.GenerateOracleAnnotations = false;
                JavaRestGenerator.Properties.ThrowNotImplementedException = Properties.ThrowNotImplementedException;
                EclipseCxfGenerator.Properties.ProjectName = Properties.ProjectName;
                EclipseCxfGenerator.Properties.ResourcesDir = Properties.ResourcesDir;
                EclipseCxfGenerator.Properties.OutputDir = Properties.OutputDir;
                EclipseCxfGenerator.Properties.CxfVersion = Properties.CxfVersion;
                EclipseCxfGenerator.Properties.GenerateJksService = Properties.GenerateJksService;
                EclipseCxfGenerator.Properties.GenerateJksClient = Properties.GenerateJksClient;
                EclipseCxfGenerator.Properties.GenerateRestfulWebService = Properties.GenerateRestfulWebService;
                Context.SetOutputFolder(Properties.OutputDir);
                Context.CreateFolder("JBoss");
                if (!Properties.GenerateRestfulWebService)
                {
                    JavaSoapGenerator.Properties.WsdlDirectory = "WEB-INF/wsdl/";
                }
                Context.CreateFolder("JBoss/" + Generated_GetProjectName());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.project");
                Context.Output(EclipseCxfGenerator.Generated_Generate_server_project());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.classpath");
                Context.Output(EclipseCxfGenerator.Generated_Generate_server_classpath());
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/.settings");
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/.jsdtscope");
                Context.Output(EclipseCxfGenerator.Generated_Generate_jsdtscope());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/org.eclipse.jdt.core.prefs");
                Context.Output(EclipseCxfGenerator.Generated_Generate_core_prefs());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/org.eclipse.wst.common.component");
                Context.Output(EclipseCxfGenerator.Generated_Generate_common_component());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/org.eclipse.wst.common.project.facet.core.xml");
                Context.Output(EclipseCxfGenerator.Generated_Generate_facet_core());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/org.eclipse.wst.jsdt.ui.superType.container");
                Context.Output(EclipseCxfGenerator.Generated_Generate_superType_container());
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/.settings/org.eclipse.wst.jsdt.ui.superType.name");
                Context.Output(EclipseCxfGenerator.Generated_Generate_superType_name());
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/build");
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/WebContent");
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/WebContent/services.jsp");
                Context.Output(EclipseCxfGenerator.Generated_Generate_web_services_jsp());
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/WebContent/META-INF");
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/WebContent/META-INF/MANIFEST.MF");
                if (Properties.GenerateRestfulWebService)
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_MetaInf_Manifest(true));
                }
                else
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_MetaInf_Manifest(false));
                }
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF");
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF/lib");
                Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF/web.xml");
                if (Properties.GenerateRestfulWebService)
                {
                    Context.Output(Generated_Generate_web_xml(true));
                }
                else
                {
                    Context.Output(Generated_Generate_web_xml(false));
                }
                if (!Properties.GenerateRestfulWebService)
                {
                    Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF/jbossws-cxf.xml");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_cxf_xml(true, Properties.GenerateJksService));
                }
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/src");
                if (Properties.GenerateJksService && !Properties.GenerateRestfulWebService)
                {
                    Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/src/SecurityCallbackHandler.java");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_SecurityCallbackHandler(""));
                }
                if (Properties.GenerateJksService)
                {
                    Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/src/server_signature.properties");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_security_properties("server_keystore.jks"));
                    Context.SetOutput("JBoss/" + Generated_GetProjectName() + "/src/server_encryption.properties");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_security_properties("server_truststore.jks"));
                    File.Copy(Properties.ResourcesDir + "/Java/server_keystore.jks", "JBoss/" + Generated_GetProjectName() + "/src/server_keystore.jks", true);
                    File.Copy(Properties.ResourcesDir + "/Java/server_truststore.jks", "JBoss/" + Generated_GetProjectName() + "/src/server_truststore.jks", true);
                }
                if (Properties.GenerateRestfulWebService)
                {
                    JavaRestGenerator.Properties.GenerateServerStubs = true;
                }
                else
                {
                    JavaSoapGenerator.Properties.GenerateServerStubs = true;
                    JavaSoapGenerator.Properties.GenerateClientProxies = false;
                }
                if (Properties.GenerateRestfulWebService)
                {
                    JavaRestGenerator.Generated_GenerateJavaCode("JBoss/" + Generated_GetProjectName() + "/src");
                }
                else
                {
                    JavaSoapGenerator.Generated_GenerateJavaCode("JBoss/" + Generated_GetProjectName() + "/src");
                }
                Context.CreateFolder("JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF");
                if (!Properties.GenerateRestfulWebService)
                {
                    Context.SetOutputFolder(Properties.OutputDir + "/JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF");
                    XsdWsdlGenerator.Properties.OutputDir = Properties.OutputDir + "/JBoss/" + Generated_GetProjectName() + "/WebContent/WEB-INF";
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
                        XsdWsdlGenerator.Generated_GenerateXsdWsdl(ns);
                    }
                }
                Context.SetOutputFolder(Properties.OutputDir);
                if (!Properties.GenerateRestfulWebService)
                {
                    JavaSoapGenerator.Properties.WsdlDirectory = "META-INF";
                }
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName());
                Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/.project");
                if (Properties.GenerateRestfulWebService)
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_client_project(true));
                }
                else
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_client_project(false));
                }
                Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/.classpath");
                if (Properties.GenerateRestfulWebService)
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_client_classpath_rest());
                    Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/pom.xml");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_pom());
                }
                else
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_client_classpath());
                }
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/.settings");
                Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/.settings/org.eclipse.jdt.core.prefs");
                Context.Output(EclipseCxfGenerator.Generated_Generate_core_prefs());
                Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/.settings/org.eclipse.jst.ws.cxf.core.prefs");
                Context.Output(EclipseCxfGenerator.Generated_Generate_ws_cxf_core_prefs());
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/bin");
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF");
                if (!Properties.GenerateRestfulWebService)
                {
                    Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/cxf-client.xml");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_cxf_xml(false, Properties.GenerateJksClient));
                }
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF");
                Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/MANIFEST.MF");
                if (Properties.GenerateRestfulWebService)
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_MetaInf_Manifest(true));
                }
                else
                {
                    Context.Output(EclipseCxfGenerator.Generated_Generate_MetaInf_Manifest(false));
                }
                if (Properties.GenerateJksClient && !Properties.GenerateRestfulWebService)
                {
                    Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/SecurityCallbackHandler.java");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_SecurityCallbackHandler(""));
                }
                if (Properties.GenerateJksClient)
                {
                    Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF");
                    Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/client_signature.properties");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_security_properties("client_keystore.jks"));
                    Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/client_encryption.properties");
                    Context.Output(EclipseCxfGenerator.Generated_Generate_security_properties("client_truststore.jks"));
                    File.Copy(Properties.ResourcesDir + "/Java/client_keystore.jks", "JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/client_keystore.jks", true);
                    File.Copy(Properties.ResourcesDir + "/Java/client_truststore.jks", "JBoss/" + Generated_GetClientProjectName() + "/src/META-INF/client_truststore.jks", true);
                }
                if (Properties.GenerateRestfulWebService)
                {
                    JavaRestGenerator.Properties.GenerateServerStubs = false;
                }
                else
                {
                    JavaSoapGenerator.Properties.GenerateServerStubs = false;
                    JavaSoapGenerator.Properties.GenerateClientProxies = true;
                }
                if (Properties.GenerateRestfulWebService)
                {
                    JavaRestGenerator.Generated_GenerateJavaCode("JBoss/" + Generated_GetClientProjectName() + "/src/main/java");
                }
                else
                {
                    JavaSoapGenerator.Generated_GenerateJavaCode("JBoss/" + Generated_GetClientProjectName() + "/src");
                }
                if (Properties.GenerateRestfulWebService)
                {
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
                        Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/main/resources/" + Generated_GetPackage(ns).ToLower() + "client");
                        Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/test/java/" + Generated_GetPackage(ns).ToLower() + "client");
                        Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/test/resources/" + Generated_GetPackage(ns).ToLower() + "client");
                        Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/main/java/" + Generated_GetPackage(ns).ToLower() + "client");
                        Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/main/java/" + Generated_GetPackage(ns).ToLower() + "client/Program.java");
                        Context.Output(EclipseCxfGenerator.Generated_Generate_Program_java_rest(ns));
                    }
                }
                else
                {
                    int __loop3_iteration = 0;
                    var __loop3_result =
                        (from __loop3_tmp_item___noname3 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop3_tmp_item_ns in EnumerableExtensions.Enumerate((__loop3_tmp_item___noname3).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop3_item___noname3 = __loop3_tmp_item___noname3,
                                __loop3_item_ns = __loop3_tmp_item_ns,
                            }).ToArray();
                    foreach (var __loop3_item in __loop3_result)
                    {
                        var __noname3 = __loop3_item.__loop3_item___noname3;
                        var ns = __loop3_item.__loop3_item_ns;
                        ++__loop3_iteration;
                        Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/" + Generated_GetPackage(ns).ToLower() + "client");
                        Context.SetOutput("JBoss/" + Generated_GetClientProjectName() + "/src/" + Generated_GetPackage(ns).ToLower() + "client/Program.java");
                        Context.Output(EclipseCxfGenerator.Generated_Generate_Program_java(ns));
                    }
                }
                Context.CreateFolder("JBoss/" + Generated_GetClientProjectName() + "/src/META-INF");
                Context.SetOutputFolder(Properties.OutputDir + "/JBoss/" + Generated_GetClientProjectName() + "/src/META-INF");
                if (!Properties.GenerateRestfulWebService)
                {
                    XsdWsdlGenerator.Properties.OutputDir = Properties.OutputDir + "/JBoss/" + Generated_GetClientProjectName() + "/META-INF";
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
                        XsdWsdlGenerator.Generated_GenerateXsdWsdl(ns);
                    }
                }
                Context.SetOutputFolder(Properties.OutputDir);
            }
            
            public string Generated_GetProjectName()
            {
                return Properties.ProjectName;
            }
            
            public string Generated_GetClientProjectName()
            {
                return Properties.ProjectName + "Client";
            }
            
            public List<string> Generated_Generate_web_xml(bool rest)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("<web-app");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(" version=\"2.5\" xmlns=\"http://java.sun.com/xml/ns/javaee\" ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(" xsi:schemaLocation=\"http://java.sun.com/xml/ns/javaee http://java.sun.com/xml/ns/javaee/web-app_2_5.xsd\">");
                    __printer.WriteLine();
                    if (rest)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	<display-name>");
                        __printer.Write(Properties.ProjectName);
                        __printer.WriteTemplateOutput("</display-name>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	<servlet-mapping>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<servlet-name>javax.ws.rs.core.Application</servlet-name>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("		<url-pattern>/*</url-pattern>");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	</servlet-mapping>");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("</web-app>");
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
        
