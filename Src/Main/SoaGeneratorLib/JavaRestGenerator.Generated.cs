using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // The main file of the generator.
    public partial class JavaRestGenerator : Generator<IEnumerable<SoaObject>, GeneratorContext>
    {
        public JavaGenerator JavaGenerator { get; private set; }
        
        public JavaRestGenerator(IEnumerable<SoaObject> instances, GeneratorContext context)
            : base(instances, context)
        {
            this.Properties = new PropertyGroup_Properties();
            this.JavaGenerator = new JavaGenerator(instances, context);
        }
        
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\JavaRestGenerator.mcg"
            public PropertyGroup_Properties Properties { get; private set; }
            
            public class PropertyGroup_Properties
            {
                public PropertyGroup_Properties()
                {
                    this.ProjectName = "JDeveloperProject";
                    this.ResourcesDir = "../Resources";
                    this.OutputDir = "../../Output";
                    this.ThrowNotImplementedException = true;
                    this.GenerateServerStubs = true;
                }
                
                public string ProjectName { get; set; }
                public string ResourcesDir { get; set; }
                public string OutputDir { get; set; }
                public bool ThrowNotImplementedException { get; set; }
                public bool GenerateServerStubs { get; set; }
            }
            
            public override void Generated_Main()
            {
            }
            
            public void Generated_GenerateJavaCode(string rootDirectory)
            {
                rootDirectory = rootDirectory + "/";
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
                        Context.CreateFolder(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns));
                    }
                }
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
                    int i = 0;
                    int __loop4_iteration = 0;
                    var __loop4_result =
                        (from __loop4_tmp_item___noname4 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop4_tmp_item_d in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname4).GetEnumerator()).OfType<Namespace>()
                        select
                            new
                            {
                                __loop4_item___noname4 = __loop4_tmp_item___noname4,
                                __loop4_item_d = __loop4_tmp_item_d,
                            }).ToArray();
                    foreach (var __loop4_item in __loop4_result)
                    {
                        var __noname4 = __loop4_item.__loop4_item___noname4;
                        var d = __loop4_item.__loop4_item_d;
                        ++__loop4_iteration;
                        i = i + 1;
                    }
                    if (ns.Declarations.Count > i)
                    {
                        Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/package-info.java");
                        Context.Output(JavaGenerator.Generated_GeneratePackageInfo(ns));
                        Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/ObjectFactory.java");
                        Context.Output(JavaGenerator.Generated_GenerateObjectFactory(ns));
                        int __loop5_iteration = 0;
                        var __loop5_result =
                            (from __loop5_tmp_item___noname5 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop5_tmp_item_en in EnumerableExtensions.Enumerate((__loop5_tmp_item___noname5).GetEnumerator()).OfType<EnumType>()
                            select
                                new
                                {
                                    __loop5_item___noname5 = __loop5_tmp_item___noname5,
                                    __loop5_item_en = __loop5_tmp_item_en,
                                }).ToArray();
                        foreach (var __loop5_item in __loop5_result)
                        {
                            var __noname5 = __loop5_item.__loop5_item___noname5;
                            var en = __loop5_item.__loop5_item_en;
                            ++__loop5_iteration;
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + en.Name + ".java");
                            Context.Output(JavaGenerator.Generated_GenerateEnum(en));
                        }
                        int __loop6_iteration = 0;
                        var __loop6_result =
                            (from __loop6_tmp_item___noname6 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop6_tmp_item_st in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname6).GetEnumerator()).OfType<StructType>()
                            select
                                new
                                {
                                    __loop6_item___noname6 = __loop6_tmp_item___noname6,
                                    __loop6_item_st = __loop6_tmp_item_st,
                                }).ToArray();
                        foreach (var __loop6_item in __loop6_result)
                        {
                            var __noname6 = __loop6_item.__loop6_item___noname6;
                            var st = __loop6_item.__loop6_item_st;
                            ++__loop6_iteration;
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + st.Name + ".java");
                            Context.Output(JavaGenerator.Generated_GenerateStruct(st));
                        }
                        int __loop7_iteration = 0;
                        var __loop7_result =
                            (from __loop7_tmp_item___noname7 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop7_tmp_item_cs in EnumerableExtensions.Enumerate((__loop7_tmp_item___noname7).GetEnumerator()).OfType<ClaimsetType>()
                            select
                                new
                                {
                                    __loop7_item___noname7 = __loop7_tmp_item___noname7,
                                    __loop7_item_cs = __loop7_tmp_item_cs,
                                }).ToArray();
                        foreach (var __loop7_item in __loop7_result)
                        {
                            var __noname7 = __loop7_item.__loop7_item___noname7;
                            var cs = __loop7_item.__loop7_item_cs;
                            ++__loop7_iteration;
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + cs.Name + ".java");
                            Context.Output(JavaGenerator.Generated_GenerateClaimset(cs));
                        }
                        int __loop8_iteration = 0;
                        var __loop8_result =
                            (from __loop8_tmp_item___noname8 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop8_tmp_item_ex in EnumerableExtensions.Enumerate((__loop8_tmp_item___noname8).GetEnumerator()).OfType<ExceptionType>()
                            select
                                new
                                {
                                    __loop8_item___noname8 = __loop8_tmp_item___noname8,
                                    __loop8_item_ex = __loop8_tmp_item_ex,
                                }).ToArray();
                        foreach (var __loop8_item in __loop8_result)
                        {
                            var __noname8 = __loop8_item.__loop8_item___noname8;
                            var ex = __loop8_item.__loop8_item_ex;
                            ++__loop8_iteration;
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + ex.Name + "Fault.java");
                            Context.Output(JavaGenerator.Generated_GenerateException(ex));
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + ex.Name + ".java");
                            Context.Output(JavaGenerator.Generated_GenerateOperationException(ex));
                        }
                        int __loop9_iteration = 0;
                        var __loop9_result =
                            (from __loop9_tmp_item___noname9 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                            from __loop9_tmp_item_ar in EnumerableExtensions.Enumerate((__loop9_tmp_item___noname9).GetEnumerator()).OfType<ArrayType>()
                            select
                                new
                                {
                                    __loop9_item___noname9 = __loop9_tmp_item___noname9,
                                    __loop9_item_ar = __loop9_tmp_item_ar,
                                }).ToArray();
                        foreach (var __loop9_item in __loop9_result)
                        {
                            var __noname9 = __loop9_item.__loop9_item___noname9;
                            var ar = __loop9_item.__loop9_item_ar;
                            ++__loop9_iteration;
                            if (ar.ItemType is NullableType)
                            {
                                Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/ArrayOfNullable" + Generated_FirstLetterUp(ar.ItemType.Name) + ".java");
                                Context.Output(JavaGenerator.Generated_GenerateNullableArray(ar, ns));
                            }
                            else
                            {
                                Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/ArrayOf" + Generated_FirstLetterUp(ar.ItemType.Name) + ".java");
                                Context.Output(JavaGenerator.Generated_GenerateArray(ar, ns));
                            }
                        }
                        int __loop10_iteration = 0;
                        var __loop10_result =
                            (from __loop10_tmp_item___noname10 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop10_tmp_item_intf in EnumerableExtensions.Enumerate((__loop10_tmp_item___noname10).GetEnumerator()).OfType<Interface>()
                            select
                                new
                                {
                                    __loop10_item___noname10 = __loop10_tmp_item___noname10,
                                    __loop10_item_intf = __loop10_tmp_item_intf,
                                }).ToArray();
                        foreach (var __loop10_item in __loop10_result)
                        {
                            var __noname10 = __loop10_item.__loop10_item___noname10;
                            var intf = __loop10_item.__loop10_item_intf;
                            ++__loop10_iteration;
                            int __loop11_iteration = 0;
                            var __loop11_result =
                                (from __loop11_tmp_item___noname11 in EnumerableExtensions.Enumerate((intf.Operations).GetEnumerator())
                                from __loop11_tmp_item_op in EnumerableExtensions.Enumerate((__loop11_tmp_item___noname11).GetEnumerator()).OfType<Operation>()
                                select
                                    new
                                    {
                                        __loop11_item___noname11 = __loop11_tmp_item___noname11,
                                        __loop11_item_op = __loop11_tmp_item_op,
                                    }).ToArray();
                            foreach (var __loop11_item in __loop11_result)
                            {
                                var __noname11 = __loop11_item.__loop11_item___noname11;
                                var op = __loop11_item.__loop11_item_op;
                                ++__loop11_iteration;
                                Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + Generated_FirstLetterUp(op.Name) + ".java");
                                Context.Output(JavaGenerator.Generated_GenerateOperationType(op));
                                if (op.ReturnType != PseudoType.Async)
                                {
                                    Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + Generated_FirstLetterUp(op.Name) + "Response.java");
                                    Context.Output(JavaGenerator.Generated_GenerateOperationResponseType(op));
                                }
                            }
                            Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + intf.Name + ".java");
                            Context.Output(Generated_GenerateInterface(intf));
                        }
                        int __loop12_iteration = 0;
                        var __loop12_result =
                            (from __loop12_tmp_item___noname12 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                            from __loop12_tmp_item_endp in EnumerableExtensions.Enumerate((__loop12_tmp_item___noname12).GetEnumerator()).OfType<Endpoint>()
                            select
                                new
                                {
                                    __loop12_item___noname12 = __loop12_tmp_item___noname12,
                                    __loop12_item_endp = __loop12_tmp_item_endp,
                                }).ToArray();
                        foreach (var __loop12_item in __loop12_result)
                        {
                            var __noname12 = __loop12_item.__loop12_item___noname12;
                            var endp = __loop12_item.__loop12_item_endp;
                            ++__loop12_iteration;
                            if (Properties.GenerateServerStubs)
                            {
                                Context.SetOutput(rootDirectory + JavaGenerator.Generated_NamespaceToPath(ns) + "/" + endp.Name + ".java");
                                Context.Output(Generated_GenerateImpl(endp));
                            }
                        }
                    }
                }
            }
            
            public List<string> Generated_GenerateOperationHead(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("public ");
                    __printer.Write(JavaGenerator.Generated_PrintType(op.ReturnType));
                    __printer.WriteTemplateOutput(" ");
                    __printer.Write(Generated_FirstLetterLow(op.Name));
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop13_iteration = 0;
                    string comma = "";
                    var __loop13_result =
                        (from __loop13_tmp_item___noname13 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop13_tmp_item_pa in EnumerableExtensions.Enumerate((__loop13_tmp_item___noname13).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop13_item___noname13 = __loop13_tmp_item___noname13,
                                __loop13_item_pa = __loop13_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop13_item in __loop13_result)
                    {
                        var __noname13 = __loop13_item.__loop13_item___noname13;
                        var pa = __loop13_item.__loop13_item_pa;
                        ++__loop13_iteration;
                        if (__loop13_iteration >= 2)
                        {
                            comma = ", ";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.Write(JavaGenerator.Generated_PrintType(pa.Type));
                        __printer.WriteTemplateOutput(" ");
                        __printer.Write(pa.Name);
                        __printer.WriteTemplateOutput("\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(")");
                    int __loop14_iteration = 0;
                    string del = JavaGenerator.Generated_ThrowsSoaMMException();
                    var __loop14_result =
                        (from __loop14_tmp_item___noname14 in EnumerableExtensions.Enumerate((op.Exceptions).GetEnumerator())
                        from __loop14_tmp_item_ex in EnumerableExtensions.Enumerate((__loop14_tmp_item___noname14).GetEnumerator()).OfType<ExceptionType>()
                        select
                            new
                            {
                                __loop14_item___noname14 = __loop14_tmp_item___noname14,
                                __loop14_item_ex = __loop14_tmp_item_ex,
                            }).ToArray();
                    foreach (var __loop14_item in __loop14_result)
                    {
                        var __noname14 = __loop14_item.__loop14_item___noname14;
                        var ex = __loop14_item.__loop14_item_ex;
                        ++__loop14_iteration;
                        if (__loop14_iteration >= 2)
                        {
                            del = ", ";
                        }
                        __printer.Write(del);
                        __printer.Write(ex.Name);
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
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(intf.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.ws.rs.Path;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.ws.rs.POST;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.ws.rs.Produces;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlSeeAlso;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@Path(\"");
                    __printer.Write(intf.Name);
                    __printer.WriteTemplateOutput("\")");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlSeeAlso({");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ObjectFactory.class");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public interface ");
                    __printer.Write(intf.Name);
                    __printer.WriteTemplateOutput(" \\");
                    __printer.WriteLine();
                    if (intf.SuperInterfaces.Count != 0)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("extends \\");
                        __printer.WriteLine();
                        int __loop15_iteration = 0;
                        string comma = "";
                        var __loop15_result =
                            (from __loop15_tmp_item___noname15 in EnumerableExtensions.Enumerate((intf.SuperInterfaces).GetEnumerator())
                            from __loop15_tmp_item_sup in EnumerableExtensions.Enumerate((__loop15_tmp_item___noname15).GetEnumerator()).OfType<Interface>()
                            select
                                new
                                {
                                    __loop15_item___noname15 = __loop15_tmp_item___noname15,
                                    __loop15_item_sup = __loop15_tmp_item_sup,
                                }).ToArray();
                        foreach (var __loop15_item in __loop15_result)
                        {
                            var __noname15 = __loop15_item.__loop15_item___noname15;
                            var sup = __loop15_item.__loop15_item_sup;
                            ++__loop15_iteration;
                            if (__loop15_iteration >= 2)
                            {
                                comma = ", ";
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.Write(comma);
                            __printer.Write(Generated_GetPackage(sup.Namespace).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(sup.Name);
                            __printer.WriteTemplateOutput("\\");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput(" {");
                        __printer.WriteLine();
                    }
                    else
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("{");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop16_iteration = 0;
                    var __loop16_result =
                        (from __loop16_tmp_item___noname16 in EnumerableExtensions.Enumerate((intf.Operations).GetEnumerator())
                        from __loop16_tmp_item_op in EnumerableExtensions.Enumerate((__loop16_tmp_item___noname16).GetEnumerator()).OfType<Operation>()
                        select
                            new
                            {
                                __loop16_item___noname16 = __loop16_tmp_item___noname16,
                                __loop16_item_op = __loop16_tmp_item_op,
                            }).ToArray();
                    foreach (var __loop16_item in __loop16_result)
                    {
                        var __noname16 = __loop16_item.__loop16_item___noname16;
                        var op = __loop16_item.__loop16_item_op;
                        ++__loop16_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @POST");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	@Path(\"");
                        __printer.Write(op.Name);
                        __printer.WriteTemplateOutput("\")    ");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	@Produces({\"application/json\", \"application/xml\"})");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                        __printer.Write(Generated_GenerateOperationHead(op));
                        __printer.WriteTemplateOutput(";");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateImpl(Endpoint endp)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(endp.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(endp.Name);
                    __printer.WriteTemplateOutput(" implements ");
                    __printer.Write(endp.Interface.Name);
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    int __loop17_iteration = 0;
                    var __loop17_result =
                        (from __loop17_tmp_item___noname17 in EnumerableExtensions.Enumerate((endp.Interface.Operations).GetEnumerator())
                        from __loop17_tmp_item_op in EnumerableExtensions.Enumerate((__loop17_tmp_item___noname17).GetEnumerator()).OfType<Operation>()
                        select
                            new
                            {
                                __loop17_item___noname17 = __loop17_tmp_item___noname17,
                                __loop17_item_op = __loop17_tmp_item_op,
                            }).ToArray();
                    foreach (var __loop17_item in __loop17_result)
                    {
                        var __noname17 = __loop17_item.__loop17_item___noname17;
                        var op = __loop17_item.__loop17_item_op;
                        ++__loop17_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @Override");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                        __printer.Write(Generated_GenerateOperationHead(op));
                        __printer.WriteTemplateOutput(" {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        ");
                        if (Properties.ThrowNotImplementedException)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        // TODO implement this method");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        throw new UnsupportedOperationException(\"Not implemented yet.\");");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        ");
                        }
                        __printer.WriteTemplateOutput("      ");
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateSoaMMException(Namespace ns)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.ws.WebFault;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@WebFault(name = \"SoaMMException\", targetNamespace = \"");
                    __printer.Write(Generated_GetUri(ns));
                    __printer.WriteTemplateOutput("\")");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class SoaMMException extends Exception {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    private ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(".SoaMMFault faultInfo;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public SoaMMException(String message, ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(".SoaMMFault faultInfo) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        super(message);");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        this.faultInfo = faultInfo;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public SoaMMException(String message, ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(".SoaMMFault faultInfo, Throwable cause) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        super(message, cause);");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        this.faultInfo = faultInfo;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(".SoaMMFault getFaultInfo() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        return faultInfo;");
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
        
