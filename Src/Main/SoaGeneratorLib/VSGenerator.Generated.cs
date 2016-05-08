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
    public partial class VSGenerator : Generator<IEnumerable<SoaObject>, GeneratorContext>
    {
        
        public VSGenerator(IEnumerable<SoaObject> instances, GeneratorContext context)
            : base(instances, context)
        {
            this.Properties = new PropertyGroup_Properties();
        }
        
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\VSGenerator.mcg"
            public PropertyGroup_Properties Properties { get; private set; }
            
            public class PropertyGroup_Properties
            {
                public PropertyGroup_Properties()
                {
                    this.ProjectName = "VisualStudioProject";
                    this.ResourcesDir = "../Resources";
                    this.OutputDir = "../../Output";
                }
                
                public string ProjectName { get; set; }
                public string ResourcesDir { get; set; }
                public string OutputDir { get; set; }
            }
            
            public override void Generated_Main()
            {
            }
            
            public List<string> Generated_PrintType(Type type)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    if (type == PseudoType.Void || type == PseudoType.Async)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("void");
                        __printer.WriteLine();
                    }
                    else if (type is BuiltInType)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        if (type == BuiltInType.Guid)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("Guid");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else if (type == BuiltInType.Date || type == BuiltInType.Time)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("string");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else if (type == BuiltInType.DateTime)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("DateTime");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else if (type == BuiltInType.TimeSpan)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("TimeSpan");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.Write(type.Name);
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    else if (type is StructType || type is EnumType || type is ExceptionType)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteLine();
                    }
                    else if (type is ArrayType)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if (((ArrayType)type).ItemType == BuiltInType.Byte)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("byte");
                            __printer.Write("[]");
                            __printer.WriteLine();
                        }
                        else if (((ArrayType)type).ItemType is NullableType)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("ArrayOfNullable");
                            __printer.Write(Generated_PrintType(((NullableType)((ArrayType)type).ItemType).InnerType));
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("ArrayOf");
                            __printer.Write(Generated_PrintType(((ArrayType)type).ItemType));
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    else if (type is NullableType)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(Generated_PrintType(((NullableType)type).InnerType));
                        __printer.WriteTemplateOutput("?");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateDataTypes(Namespace ns)
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
                    __printer.Write(Generated_GenerateDataTypesPart(ns));
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateDataTypesPart(Namespace ns)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    int __loop1_iteration = 0;
                    var __loop1_result =
                        (from __loop1_tmp_item___noname1 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop1_tmp_item_type in EnumerableExtensions.Enumerate((__loop1_tmp_item___noname1).GetEnumerator()).OfType<ArrayType>()
                        select
                            new
                            {
                                __loop1_item___noname1 = __loop1_tmp_item___noname1,
                                __loop1_item_type = __loop1_tmp_item_type,
                            }).ToArray();
                    foreach (var __loop1_item in __loop1_result)
                    {
                        var __noname1 = __loop1_item.__loop1_item___noname1;
                        var type = __loop1_item.__loop1_item_type;
                        ++__loop1_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if (((ArrayType)type).ItemType is NullableType)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.CollectionDataContractAttribute(Name = \"ArrayOfNullable");
                            __printer.Write(Generated_PrintType(((NullableType)((ArrayType)type).ItemType).InnerType));
                            __printer.WriteTemplateOutput("\", Namespace = \"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\", ItemName = \"");
                            __printer.Write(((NullableType)((ArrayType)type).ItemType).InnerType.Name);
                            __printer.WriteTemplateOutput("\")");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ArrayOfNullable");
                            __printer.Write(Generated_PrintType(((NullableType)((ArrayType)type).ItemType).InnerType));
                            __printer.WriteTemplateOutput(" : List<");
                            __printer.Write(Generated_PrintType(((NullableType)((ArrayType)type).ItemType).InnerType));
                            __printer.WriteTemplateOutput(">");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        else if (((ArrayType)type).ItemType != BuiltInType.Byte)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.CollectionDataContractAttribute(Name = \"ArrayOf");
                            __printer.Write(Generated_PrintType(((ArrayType)type).ItemType));
                            __printer.WriteTemplateOutput("\", Namespace = \"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\", ItemName = \"");
                            __printer.Write(((ArrayType)type).ItemType.Name);
                            __printer.WriteTemplateOutput("\")");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ArrayOf");
                            __printer.Write(Generated_PrintType(((ArrayType)type).ItemType));
                            __printer.WriteTemplateOutput(" : List<");
                            __printer.Write(Generated_PrintType(((ArrayType)type).ItemType));
                            __printer.WriteTemplateOutput(">");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop2_iteration = 0;
                    var __loop2_result =
                        (from __loop2_tmp_item___noname2 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop2_tmp_item_str in EnumerableExtensions.Enumerate((__loop2_tmp_item___noname2).GetEnumerator()).OfType<StructType>()
                        select
                            new
                            {
                                __loop2_item___noname2 = __loop2_tmp_item___noname2,
                                __loop2_item_str = __loop2_tmp_item_str,
                            }).ToArray();
                    foreach (var __loop2_item in __loop2_result)
                    {
                        var __noname2 = __loop2_item.__loop2_item___noname2;
                        var str = __loop2_item.__loop2_item_str;
                        ++__loop2_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        __printer.Write("[");
                        __printer.WriteTemplateOutput("System.Runtime.Serialization.DataContractAttribute(Name = \"");
                        __printer.Write(str.Name);
                        __printer.WriteTemplateOutput("\", Namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\")");
                        __printer.Write("]");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                        int __loop3_iteration = 0;
                        var __loop3_result =
                            (from __loop3_tmp_item_strde in EnumerableExtensions.Enumerate((str.GetAllDescendants()).GetEnumerator())
                            select
                                new
                                {
                                    __loop3_item_strde = __loop3_tmp_item_strde,
                                }).ToArray();
                        foreach (var __loop3_item in __loop3_result)
                        {
                            var strde = __loop3_item.__loop3_item_strde;
                            ++__loop3_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.KnownTypeAttribute(typeof(");
                            __printer.Write(strde.Namespace.FullName);
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(strde.Name);
                            __printer.WriteTemplateOutput("))");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("	");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        if (str.SuperType != null)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ");
                            __printer.Write(str.Name);
                            __printer.WriteTemplateOutput(" : ");
                            __printer.Write(str.SuperType.Namespace.FullName);
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(str.SuperType.Name);
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ");
                            __printer.Write(str.Name);
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        int __loop4_iteration = 0;
                        var __loop4_result =
                            (from __loop4_tmp_item___noname3 in EnumerableExtensions.Enumerate((str.Fields).GetEnumerator())
                            from __loop4_tmp_item_field in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname3).GetEnumerator()).OfType<StructField>()
                            select
                                new
                                {
                                    __loop4_item___noname3 = __loop4_tmp_item___noname3,
                                    __loop4_item_field = __loop4_tmp_item_field,
                                }).ToArray();
                        foreach (var __loop4_item in __loop4_result)
                        {
                            var __noname3 = __loop4_item.__loop4_item___noname3;
                            var field = __loop4_item.__loop4_item_field;
                            ++__loop4_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        private ");
                            __printer.Write(Generated_PrintType(field.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(field.Name));
                            __printer.WriteTemplateOutput("Field;");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("	");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        int __loop5_iteration = 0;
                        int order = 0;
                        var __loop5_result =
                            (from __loop5_tmp_item___noname4 in EnumerableExtensions.Enumerate((str.Fields).GetEnumerator())
                            from __loop5_tmp_item_field in EnumerableExtensions.Enumerate((__loop5_tmp_item___noname4).GetEnumerator()).OfType<StructField>()
                            select
                                new
                                {
                                    __loop5_item___noname4 = __loop5_tmp_item___noname4,
                                    __loop5_item_field = __loop5_tmp_item_field,
                                }).ToArray();
                        foreach (var __loop5_item in __loop5_result)
                        {
                            var __noname4 = __loop5_item.__loop5_item___noname4;
                            var field = __loop5_item.__loop5_item_field;
                            ++__loop5_iteration;
                            if (__loop5_iteration >= 2)
                            {
                                order = order + 1;
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = ");
                            __printer.Write(order);
                            __printer.WriteTemplateOutput(")");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        public ");
                            __printer.Write(Generated_PrintType(field.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterUp(field.Name));
                            __printer.WriteTemplateOutput(" ");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        { ");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            ");
                            if (field.Type is ArrayType && ((ArrayType)field.Type).ItemType != BuiltInType.Byte)
                            {
                                __printer.TrimLine();
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            get ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            { ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                if (this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field == null)");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                {");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                    this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field = new ");
                                __printer.Write(Generated_PrintType(field.Type));
                                __printer.WriteTemplateOutput("();");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                return this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field; ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            ");
                            }
                            else
                            {
                                __printer.TrimLine();
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            get { return this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field; }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            set { this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field = value; }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            ");
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop6_iteration = 0;
                    var __loop6_result =
                        (from __loop6_tmp_item___noname5 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop6_tmp_item_en in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname5).GetEnumerator()).OfType<EnumType>()
                        select
                            new
                            {
                                __loop6_item___noname5 = __loop6_tmp_item___noname5,
                                __loop6_item_en = __loop6_tmp_item_en,
                            }).ToArray();
                    foreach (var __loop6_item in __loop6_result)
                    {
                        var __noname5 = __loop6_item.__loop6_item___noname5;
                        var en = __loop6_item.__loop6_item_en;
                        ++__loop6_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        __printer.Write("[");
                        __printer.WriteTemplateOutput("System.Runtime.Serialization.DataContractAttribute(Name = \"");
                        __printer.Write(en.Name);
                        __printer.WriteTemplateOutput("\", Namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\")");
                        __printer.Write("]");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public enum ");
                        __printer.Write(en.Name);
                        __printer.WriteTemplateOutput(" : int");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    {");
                        __printer.WriteLine();
                        int __loop7_iteration = 0;
                        int counter = 0;
                        var __loop7_result =
                            (from __loop7_tmp_item___noname6 in EnumerableExtensions.Enumerate((en.Values).GetEnumerator())
                            from __loop7_tmp_item_val in EnumerableExtensions.Enumerate((__loop7_tmp_item___noname6).GetEnumerator()).OfType<EnumValue>()
                            select
                                new
                                {
                                    __loop7_item___noname6 = __loop7_tmp_item___noname6,
                                    __loop7_item_val = __loop7_tmp_item_val,
                                }).ToArray();
                        foreach (var __loop7_item in __loop7_result)
                        {
                            var __noname6 = __loop7_item.__loop7_item___noname6;
                            var val = __loop7_item.__loop7_item_val;
                            ++__loop7_iteration;
                            if (__loop7_iteration >= 2)
                            {
                                counter = counter + 1;
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.EnumMemberAttribute()");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        ");
                            __printer.Write(val.Name);
                            __printer.WriteTemplateOutput(" = ");
                            __printer.Write(counter);
                            __printer.WriteTemplateOutput(",");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop8_iteration = 0;
                    var __loop8_result =
                        (from __loop8_tmp_item___noname7 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop8_tmp_item_ex in EnumerableExtensions.Enumerate((__loop8_tmp_item___noname7).GetEnumerator()).OfType<ExceptionType>()
                        select
                            new
                            {
                                __loop8_item___noname7 = __loop8_tmp_item___noname7,
                                __loop8_item_ex = __loop8_tmp_item_ex,
                            }).ToArray();
                    foreach (var __loop8_item in __loop8_result)
                    {
                        var __noname7 = __loop8_item.__loop8_item___noname7;
                        var ex = __loop8_item.__loop8_item_ex;
                        ++__loop8_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        __printer.Write("[");
                        __printer.WriteTemplateOutput("System.Runtime.Serialization.DataContractAttribute(Name = \"");
                        __printer.Write(ex.Name);
                        __printer.WriteTemplateOutput("\", Namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\")");
                        __printer.Write("]");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("	");
                        int __loop9_iteration = 0;
                        var __loop9_result =
                            (from __loop9_tmp_item_exde in EnumerableExtensions.Enumerate((ex.GetAllDescendants()).GetEnumerator())
                            select
                                new
                                {
                                    __loop9_item_exde = __loop9_tmp_item_exde,
                                }).ToArray();
                        foreach (var __loop9_item in __loop9_result)
                        {
                            var exde = __loop9_item.__loop9_item_exde;
                            ++__loop9_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.KnownTypeAttribute(typeof(");
                            __printer.Write(exde.Namespace.FullName);
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(exde.Name);
                            __printer.WriteTemplateOutput("))");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("	");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        if (ex.SuperType != null)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ");
                            __printer.Write(ex.Name);
                            __printer.WriteTemplateOutput(" : ");
                            __printer.Write(ex.SuperType.Namespace.FullName);
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(ex.SuperType.Name);
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public class ");
                            __printer.Write(ex.Name);
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        int __loop10_iteration = 0;
                        var __loop10_result =
                            (from __loop10_tmp_item___noname8 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop10_tmp_item_field in EnumerableExtensions.Enumerate((__loop10_tmp_item___noname8).GetEnumerator()).OfType<ExceptionField>()
                            select
                                new
                                {
                                    __loop10_item___noname8 = __loop10_tmp_item___noname8,
                                    __loop10_item_field = __loop10_tmp_item_field,
                                }).ToArray();
                        foreach (var __loop10_item in __loop10_result)
                        {
                            var __noname8 = __loop10_item.__loop10_item___noname8;
                            var field = __loop10_item.__loop10_item_field;
                            ++__loop10_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        private ");
                            __printer.Write(Generated_PrintType(field.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(field.Name));
                            __printer.WriteTemplateOutput("Field;");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("	");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        int __loop11_iteration = 0;
                        int order = 0;
                        var __loop11_result =
                            (from __loop11_tmp_item___noname9 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop11_tmp_item_field in EnumerableExtensions.Enumerate((__loop11_tmp_item___noname9).GetEnumerator()).OfType<ExceptionField>()
                            select
                                new
                                {
                                    __loop11_item___noname9 = __loop11_tmp_item___noname9,
                                    __loop11_item_field = __loop11_tmp_item_field,
                                }).ToArray();
                        foreach (var __loop11_item in __loop11_result)
                        {
                            var __noname9 = __loop11_item.__loop11_item___noname9;
                            var field = __loop11_item.__loop11_item_field;
                            ++__loop11_iteration;
                            if (__loop11_iteration >= 2)
                            {
                                order = order + 1;
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        ");
                            __printer.Write("[");
                            __printer.WriteTemplateOutput("System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = ");
                            __printer.Write(order);
                            __printer.WriteTemplateOutput(")");
                            __printer.Write("]");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        public ");
                            __printer.Write(Generated_PrintType(field.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterUp(field.Name));
                            __printer.WriteTemplateOutput(" ");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        { ");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            ");
                            if (field.Type is ArrayType && ((ArrayType)field.Type).ItemType != BuiltInType.Byte)
                            {
                                __printer.TrimLine();
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            get ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            { ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                if (this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field == null)");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                {");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                    this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field = new ");
                                __printer.Write(Generated_PrintType(field.Type));
                                __printer.WriteTemplateOutput("();");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("                return this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field; ");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            ");
                            }
                            else
                            {
                                __printer.TrimLine();
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            get { return this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field; }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            set { this.");
                                __printer.Write(Generated_FirstLetterLow(field.Name));
                                __printer.WriteTemplateOutput("Field = value; }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("            ");
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateOperationCall(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.Write(op.Name);
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop12_iteration = 0;
                    string comma = "";
                    var __loop12_result =
                        (from __loop12_tmp_item_pa in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        select
                            new
                            {
                                __loop12_item_pa = __loop12_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop12_item in __loop12_result)
                    {
                        var pa = __loop12_item.__loop12_item_pa;
                        ++__loop12_iteration;
                        if (__loop12_iteration >= 2)
                        {
                            comma = ", ";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.Write(pa.Name);
                        __printer.WriteTemplateOutput("\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(")");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateOperationHead(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.Write(Generated_PrintType(op.ReturnType));
                    __printer.WriteTemplateOutput(" ");
                    __printer.Write(op.Name);
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop13_iteration = 0;
                    string comma = "";
                    var __loop13_result =
                        (from __loop13_tmp_item_pa in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        select
                            new
                            {
                                __loop13_item_pa = __loop13_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop13_item in __loop13_result)
                    {
                        var pa = __loop13_item.__loop13_item_pa;
                        ++__loop13_iteration;
                        if (__loop13_iteration >= 2)
                        {
                            comma = ", ";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.Write(Generated_PrintType(pa.Type));
                        __printer.WriteTemplateOutput(" ");
                        __printer.Write(pa.Name);
                        __printer.WriteTemplateOutput("\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(")");
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
        
