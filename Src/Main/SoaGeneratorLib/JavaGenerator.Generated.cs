using OsloExtensions;
using OsloExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoaMetaModel
{
    // The main file of the generator.
    public partial class JavaGenerator : Generator<IEnumerable<SoaObject>, GeneratorContext>
    {
        
        public JavaGenerator(IEnumerable<SoaObject> instances, GeneratorContext context)
            : base(instances, context)
        {
            this.Properties = new PropertyGroup_Properties();
        }
        
            #region functions from "D:\git\soal-oslo\Src\Main\SoaGeneratorLib\JavaGenerator.mcg"
            public PropertyGroup_Properties Properties { get; private set; }
            
            public class PropertyGroup_Properties
            {
                public PropertyGroup_Properties()
                {
                    this.NoImplementationDelegates = false;
                }
                
                public bool NoImplementationDelegates { get; set; }
            }
            
            public override void Generated_Main()
            {
            }
            
            public string Generated_NamespaceToPath(Namespace ns)
            {
                return Generated_GetPackage(ns).Replace('.', '/').ToLower();
            }
            
            public String Generated_PrintType(Type type)
            {
                if (type == PseudoType.Void || type == PseudoType.Async)
                {
                    return "void";
                }
                else if (type is BuiltInType)
                {
                    if (type == BuiltInType.Bool)
                    {
                        return "boolean";
                    }
                    else if (type == BuiltInType.String || type == BuiltInType.Guid)
                    {
                        return "String";
                    }
                    else if (type == BuiltInType.Date || type == BuiltInType.DateTime || type == BuiltInType.DateTime)
                    {
                        return "javax.xml.datatype.XMLGregorianCalendar";
                    }
                    else if (type == BuiltInType.TimeSpan)
                    {
                        return "javax.xml.datatype.Duration";
                    }
                    else if (type == BuiltInType.Byte || type == BuiltInType.Int || type == BuiltInType.Long || type == BuiltInType.Float || type == BuiltInType.Double)
                    {
                        return type.Name;
                    }
                }
                else if (type is StructType || type is EnumType || type is ExceptionType)
                {
                    return Generated_GetPackage(type.Namespace).ToLower() + "." + Generated_FirstLetterUp(type.Name);
                }
                else if (type is ArrayType)
                {
                    if (((ArrayType)type).ItemType is NullableType)
                    {
                        return "ArrayOfNullable" + Generated_FirstLetterUp(((ArrayType)type).ItemType.Name);
                    }
                    else if (((ArrayType)type).ItemType == BuiltInType.Byte)
                    {
                        return "byte[]";
                    }
                    else
                    {
                        return "ArrayOf" + Generated_FirstLetterUp(((ArrayType)type).ItemType.Name);
                    }
                }
                else if (type is NullableType)
                {
                    return Generated_PrintClassType(((NullableType)type).InnerType);
                }
                return "";
            }
            
            public String Generated_PrintClassType(Type type)
            {
                if (type is BuiltInType)
                {
                    if (type == BuiltInType.Bool)
                    {
                        return "Boolean";
                    }
                    else if (type == BuiltInType.String || type == BuiltInType.Guid)
                    {
                        return "String";
                    }
                    else if (type == BuiltInType.Date || type == BuiltInType.DateTime || type == BuiltInType.DateTime)
                    {
                        return "javax.xml.datatype.XMLGregorianCalendar";
                    }
                    else if (type == BuiltInType.TimeSpan)
                    {
                        return "javax.xml.datatype.Duration";
                    }
                    else if (type == BuiltInType.Int)
                    {
                        return "Integer";
                    }
                    else if (type == BuiltInType.Byte || type == BuiltInType.Long || type == BuiltInType.Float || type == BuiltInType.Double)
                    {
                        return Generated_FirstLetterUp(type.Name);
                    }
                }
                else
                {
                    return Generated_PrintType(type);
                }
                return "";
            }
            
            public List<string> Generated_GeneratePackageInfo(Namespace ns)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("@javax.xml.bind.annotation.XmlSchema(namespace = \"");
                    __printer.Write(Generated_GetUri(ns));
                    __printer.WriteTemplateOutput("\", elementFormDefault = javax.xml.bind.annotation.XmlNsForm.QUALIFIED)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(ns).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateEnum(EnumType en)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(en.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlEnum;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlEnumValue;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput("\")");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlEnum");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public enum ");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    int __loop1_iteration = 0;
                    string comma = "";
                    var __loop1_result =
                        (from __loop1_tmp_item___noname1 in EnumerableExtensions.Enumerate((en).GetEnumerator())
                        from __loop1_tmp_item_value in EnumerableExtensions.Enumerate((__loop1_tmp_item___noname1.Values).GetEnumerator())
                        select
                            new
                            {
                                __loop1_item___noname1 = __loop1_tmp_item___noname1,
                                __loop1_item_value = __loop1_tmp_item_value,
                            }).ToArray();
                    foreach (var __loop1_item in __loop1_result)
                    {
                        var __noname1 = __loop1_item.__loop1_item___noname1;
                        var value = __loop1_item.__loop1_item_value;
                        ++__loop1_iteration;
                        if (__loop1_iteration >= 2)
                        {
                            comma = ",";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlEnumValue(\"");
                        __printer.Write(value.Name);
                        __printer.WriteTemplateOutput("\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        __printer.Write(value.Name.ToUpper());
                        __printer.WriteTemplateOutput("(\"");
                        __printer.Write(value.Name);
                        __printer.WriteTemplateOutput("\")\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    private final String value;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    ");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput("(String v) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        value = v;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public String value() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        return value;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public static ");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput(" fromValue(String v) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        for (");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput(" c: ");
                    __printer.Write(en.Name);
                    __printer.WriteTemplateOutput(".values()) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            if (c.value.equals(v)) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("                return c;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        throw new IllegalArgumentException(v);");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public string Generated_GenSeeAlso(StructType str)
            {
                string result = "@javax.xml.bind.annotation.XmlSeeAlso({";
                int __loop2_iteration = 0;
                string delim = "";
                var __loop2_result =
                    (from __loop2_tmp_item_strde in EnumerableExtensions.Enumerate((str.GetAllDescendants()).GetEnumerator())
                    select
                        new
                        {
                            __loop2_item_strde = __loop2_tmp_item_strde,
                        }).ToArray();
                foreach (var __loop2_item in __loop2_result)
                {
                    var strde = __loop2_item.__loop2_item_strde;
                    ++__loop2_iteration;
                    if (__loop2_iteration >= 2)
                    {
                        delim = ", ";
                    }
                    result = result + delim + Generated_GetPackage(strde.Namespace).ToLower() + "." + strde.Name + ".class";
                }
                if (__loop2_iteration == 0)
                {
                    result = "";
                }
                if (result != "")
                {
                    result = result + "})";
                }
                return result;
            }
            
            public string Generated_GenSeeAlso(ExceptionType ex)
            {
                string result = "@javax.xml.bind.annotation.XmlSeeAlso({";
                int __loop3_iteration = 0;
                string delim = "";
                var __loop3_result =
                    (from __loop3_tmp_item_exde in EnumerableExtensions.Enumerate((ex.GetAllDescendants()).GetEnumerator())
                    select
                        new
                        {
                            __loop3_item_exde = __loop3_tmp_item_exde,
                        }).ToArray();
                foreach (var __loop3_item in __loop3_result)
                {
                    var exde = __loop3_item.__loop3_item_exde;
                    ++__loop3_iteration;
                    if (__loop3_iteration >= 2)
                    {
                        delim = ", ";
                    }
                    result = result + delim + Generated_GetPackage(exde.Namespace).ToLower() + "." + exde.Name + ".class";
                }
                if (__loop3_iteration == 0)
                {
                    result = "";
                }
                if (result != "")
                {
                    result = result + "})";
                }
                return result;
            }
            
            public List<string> Generated_GenerateStruct(StructType st)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(st.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"");
                    __printer.Write(st.Name);
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    int __loop4_iteration = 0;
                    string comma = "";
                    var __loop4_result =
                        (from __loop4_tmp_item___noname2 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop4_tmp_item_fi in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname2).GetEnumerator()).OfType<StructField>()
                        select
                            new
                            {
                                __loop4_item___noname2 = __loop4_tmp_item___noname2,
                                __loop4_item_fi = __loop4_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop4_item in __loop4_result)
                    {
                        var __noname2 = __loop4_item.__loop4_item___noname2;
                        var fi = __loop4_item.__loop4_item_fi;
                        ++__loop4_iteration;
                        if (__loop4_iteration >= 2)
                        {
                            comma = ",";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    \"");
                        __printer.Write(Generated_FirstLetterLow(fi.Name));
                        __printer.WriteTemplateOutput("\"\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.Write(Generated_GenSeeAlso(st));
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(st.Name);
                    __printer.WriteTemplateOutput(" \\");
                    __printer.WriteLine();
                    if (st.SuperType != null)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("extends ");
                        __printer.Write(Generated_GetPackage(st.SuperType.Namespace).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(st.SuperType.Name);
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
                    int __loop5_iteration = 0;
                    var __loop5_result =
                        (from __loop5_tmp_item___noname3 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop5_tmp_item_fi in EnumerableExtensions.Enumerate((__loop5_tmp_item___noname3).GetEnumerator()).OfType<StructField>()
                        select
                            new
                            {
                                __loop5_item___noname3 = __loop5_tmp_item___noname3,
                                __loop5_item_fi = __loop5_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop5_item in __loop5_result)
                    {
                        var __noname3 = __loop5_item.__loop5_item___noname3;
                        var fi = __loop5_item.__loop5_item_fi;
                        ++__loop5_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElementWrapper(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = true)");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(((ArrayType)fi.Type).ItemType.Name);
                            __printer.WriteTemplateOutput("\", type = ");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(".class, nillable = ");
                            __printer.Write(Generated_IsNillableType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = ");
                            __printer.Write(Generated_IsNillableType(fi.Type));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(st.Name);
                    __printer.WriteTemplateOutput("() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    if (st.HasNonArrayFields())
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(st.Name);
                        __printer.WriteTemplateOutput("(\\");
                        __printer.WriteLine();
                        int __loop6_iteration = 0;
                        string delim = "";
                        var __loop6_result =
                            (from __loop6_tmp_item___noname4 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                            from __loop6_tmp_item_fi in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname4).GetEnumerator()).OfType<StructField>()
                            where !(__loop6_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop6_item___noname4 = __loop6_tmp_item___noname4,
                                    __loop6_item_fi = __loop6_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop6_item in __loop6_result)
                        {
                            var __noname4 = __loop6_item.__loop6_item___noname4;
                            var fi = __loop6_item.__loop6_item_fi;
                            ++__loop6_iteration;
                            if (__loop6_iteration >= 2)
                            {
                                delim = ", ";
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.Write(delim);
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput("\\");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput(") {");
                        __printer.WriteLine();
                        int __loop7_iteration = 0;
                        var __loop7_result =
                            (from __loop7_tmp_item___noname5 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                            from __loop7_tmp_item_fi in EnumerableExtensions.Enumerate((__loop7_tmp_item___noname5).GetEnumerator()).OfType<StructField>()
                            where !(__loop7_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop7_item___noname5 = __loop7_tmp_item___noname5,
                                    __loop7_item_fi = __loop7_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop7_item in __loop7_result)
                        {
                            var __noname5 = __loop7_item.__loop7_item___noname5;
                            var fi = __loop7_item.__loop7_item_fi;
                            ++__loop7_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
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
                        (from __loop8_tmp_item___noname6 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop8_tmp_item_fi in EnumerableExtensions.Enumerate((__loop8_tmp_item___noname6).GetEnumerator()).OfType<StructField>()
                        select
                            new
                            {
                                __loop8_item___noname6 = __loop8_tmp_item___noname6,
                                __loop8_item_fi = __loop8_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop8_item in __loop8_result)
                    {
                        var __noname6 = __loop8_item.__loop8_item___noname6;
                        var fi = __loop8_item.__loop8_item_fi;
                        ++__loop8_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        if (this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" == null) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = new java.util.ArrayList<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(">();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public void set");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = value;");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateClaimset(ClaimsetType cs)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(cs.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"");
                    __printer.Write(cs.Name);
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    int __loop9_iteration = 0;
                    string comma = "";
                    var __loop9_result =
                        (from __loop9_tmp_item___noname7 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop9_tmp_item_fi in EnumerableExtensions.Enumerate((__loop9_tmp_item___noname7).GetEnumerator()).OfType<ClaimField>()
                        select
                            new
                            {
                                __loop9_item___noname7 = __loop9_tmp_item___noname7,
                                __loop9_item_fi = __loop9_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop9_item in __loop9_result)
                    {
                        var __noname7 = __loop9_item.__loop9_item___noname7;
                        var fi = __loop9_item.__loop9_item_fi;
                        ++__loop9_iteration;
                        if (__loop9_iteration >= 2)
                        {
                            comma = ",";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    \"");
                        __printer.Write(Generated_FirstLetterLow(fi.Name));
                        __printer.WriteTemplateOutput("\"\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(cs.Name);
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    int __loop10_iteration = 0;
                    var __loop10_result =
                        (from __loop10_tmp_item___noname8 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop10_tmp_item_fi in EnumerableExtensions.Enumerate((__loop10_tmp_item___noname8).GetEnumerator()).OfType<ClaimField>()
                        select
                            new
                            {
                                __loop10_item___noname8 = __loop10_tmp_item___noname8,
                                __loop10_item_fi = __loop10_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop10_item in __loop10_result)
                    {
                        var __noname8 = __loop10_item.__loop10_item___noname8;
                        var fi = __loop10_item.__loop10_item_fi;
                        ++__loop10_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElementWrapper(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = true)");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(((ArrayType)fi.Type).ItemType.Name);
                            __printer.WriteTemplateOutput("\", type = ");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(".class, nillable = ");
                            __printer.Write(Generated_IsNillableType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = ");
                            __printer.Write(Generated_IsNillableType(fi.Type));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
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
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(cs.Name);
                    __printer.WriteTemplateOutput("() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    if (cs.HasNonArrayFields())
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(cs.Name);
                        __printer.WriteTemplateOutput("(\\");
                        __printer.WriteLine();
                        int __loop11_iteration = 0;
                        string delim = "";
                        var __loop11_result =
                            (from __loop11_tmp_item___noname9 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                            from __loop11_tmp_item_fi in EnumerableExtensions.Enumerate((__loop11_tmp_item___noname9).GetEnumerator()).OfType<ClaimField>()
                            where !(__loop11_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop11_item___noname9 = __loop11_tmp_item___noname9,
                                    __loop11_item_fi = __loop11_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop11_item in __loop11_result)
                        {
                            var __noname9 = __loop11_item.__loop11_item___noname9;
                            var fi = __loop11_item.__loop11_item_fi;
                            ++__loop11_iteration;
                            if (__loop11_iteration >= 2)
                            {
                                delim = ", ";
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.Write(delim);
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput("\\");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput(") {");
                        __printer.WriteLine();
                        int __loop12_iteration = 0;
                        var __loop12_result =
                            (from __loop12_tmp_item___noname10 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                            from __loop12_tmp_item_fi in EnumerableExtensions.Enumerate((__loop12_tmp_item___noname10).GetEnumerator()).OfType<ClaimField>()
                            where !(__loop12_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop12_item___noname10 = __loop12_tmp_item___noname10,
                                    __loop12_item_fi = __loop12_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop12_item in __loop12_result)
                        {
                            var __noname10 = __loop12_item.__loop12_item___noname10;
                            var fi = __loop12_item.__loop12_item_fi;
                            ++__loop12_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop13_iteration = 0;
                    var __loop13_result =
                        (from __loop13_tmp_item___noname11 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop13_tmp_item_fi in EnumerableExtensions.Enumerate((__loop13_tmp_item___noname11).GetEnumerator()).OfType<ClaimField>()
                        select
                            new
                            {
                                __loop13_item___noname11 = __loop13_tmp_item___noname11,
                                __loop13_item_fi = __loop13_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop13_item in __loop13_result)
                    {
                        var __noname11 = __loop13_item.__loop13_item___noname11;
                        var fi = __loop13_item.__loop13_item_fi;
                        ++__loop13_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        if (this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" == null) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = new java.util.ArrayList<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(">();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public void set");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = value;");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateException(ExceptionType ex)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(ex.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    int __loop14_iteration = 0;
                    string comma = "";
                    var __loop14_result =
                        (from __loop14_tmp_item___noname12 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop14_tmp_item_fi in EnumerableExtensions.Enumerate((__loop14_tmp_item___noname12).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop14_item___noname12 = __loop14_tmp_item___noname12,
                                __loop14_item_fi = __loop14_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop14_item in __loop14_result)
                    {
                        var __noname12 = __loop14_item.__loop14_item___noname12;
                        var fi = __loop14_item.__loop14_item_fi;
                        ++__loop14_iteration;
                        if (__loop14_iteration >= 2)
                        {
                            comma = ",";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    \"");
                        __printer.Write(Generated_FirstLetterLow(fi.Name));
                        __printer.WriteTemplateOutput("\"\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.Write(Generated_GenSeeAlso(ex));
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("Fault \\");
                    __printer.WriteLine();
                    if (ex.SuperType != null)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("extends ");
                        __printer.Write(Generated_GetPackage(ex.SuperType.Namespace).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(ex.SuperType.Name);
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
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    int __loop15_iteration = 0;
                    var __loop15_result =
                        (from __loop15_tmp_item___noname13 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop15_tmp_item_fi in EnumerableExtensions.Enumerate((__loop15_tmp_item___noname13).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop15_item___noname13 = __loop15_tmp_item___noname13,
                                __loop15_item_fi = __loop15_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop15_item in __loop15_result)
                    {
                        var __noname13 = __loop15_item.__loop15_item___noname13;
                        var fi = __loop15_item.__loop15_item_fi;
                        ++__loop15_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElementWrapper(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = true)");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(((ArrayType)fi.Type).ItemType.Name);
                            __printer.WriteTemplateOutput("\", type = ");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(".class, nillable = ");
                            __printer.Write(Generated_IsNillableType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @javax.xml.bind.annotation.XmlElement(name = \"");
                            __printer.Write(fi.Name);
                            __printer.WriteTemplateOutput("\", required = true, nillable = ");
                            __printer.Write(Generated_IsNillableType(fi.Type));
                            __printer.WriteTemplateOutput(")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    protected ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("Fault() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    if (ex.HasNonArrayFields())
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(ex.Name);
                        __printer.WriteTemplateOutput("Fault(\\");
                        __printer.WriteLine();
                        int __loop16_iteration = 0;
                        string delim = "";
                        var __loop16_result =
                            (from __loop16_tmp_item___noname14 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop16_tmp_item_fi in EnumerableExtensions.Enumerate((__loop16_tmp_item___noname14).GetEnumerator()).OfType<ExceptionField>()
                            where !(__loop16_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop16_item___noname14 = __loop16_tmp_item___noname14,
                                    __loop16_item_fi = __loop16_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop16_item in __loop16_result)
                        {
                            var __noname14 = __loop16_item.__loop16_item___noname14;
                            var fi = __loop16_item.__loop16_item_fi;
                            ++__loop16_iteration;
                            if (__loop16_iteration >= 2)
                            {
                                delim = ", ";
                            }
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.Write(delim);
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput("\\");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput(") {");
                        __printer.WriteLine();
                        int __loop17_iteration = 0;
                        var __loop17_result =
                            (from __loop17_tmp_item___noname15 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop17_tmp_item_fi in EnumerableExtensions.Enumerate((__loop17_tmp_item___noname15).GetEnumerator()).OfType<ExceptionField>()
                            where !(__loop17_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop17_item___noname15 = __loop17_tmp_item___noname15,
                                    __loop17_item_fi = __loop17_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop17_item in __loop17_result)
                        {
                            var __noname15 = __loop17_item.__loop17_item___noname15;
                            var fi = __loop17_item.__loop17_item_fi;
                            ++__loop17_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = ");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop18_iteration = 0;
                    var __loop18_result =
                        (from __loop18_tmp_item___noname16 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop18_tmp_item_fi in EnumerableExtensions.Enumerate((__loop18_tmp_item___noname16).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop18_item___noname16 = __loop18_tmp_item___noname16,
                                __loop18_item_fi = __loop18_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop18_item in __loop18_result)
                    {
                        var __noname16 = __loop18_item.__loop18_item___noname16;
                        var fi = __loop18_item.__loop18_item_fi;
                        ++__loop18_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        if ((fi.Type is ArrayType) && !(((ArrayType)fi.Type).ItemType == BuiltInType.Byte))
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public java.util.List<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput("> get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        if (this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" == null) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("            this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = new java.util.ArrayList<");
                            __printer.Write(Generated_PrintType(((ArrayType)fi.Type).ItemType));
                            __printer.WriteTemplateOutput(">();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        else
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" get");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(";");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public void set");
                            __printer.Write(Generated_FirstLetterUp(fi.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_PrintType(fi.Type));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        this.");
                            __printer.Write(Generated_FirstLetterLow(fi.Name));
                            __printer.WriteTemplateOutput(" = value;");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateNullableArray(ArrayType ar, Namespace ns)
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
                    __printer.WriteTemplateOutput("import java.util.ArrayList;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import java.util.List;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlElement;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"ArrayOfNullable");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    \"_");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput("\"");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ArrayOfNullable");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    @XmlElement(name = \"");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput("\", type = ");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput(".class, nillable = true)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    protected List<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput("> _");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public List<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput("> get");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput("() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        if (_");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(" == null) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            _");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(" = new ArrayList<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput(">();");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        return this._");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateArray(ArrayType ar, Namespace ns)
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
                    __printer.WriteTemplateOutput("import java.util.ArrayList;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import java.util.List;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlElement;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"ArrayOf");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    \"_");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput("\"");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ArrayOf");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    @XmlElement(name = \"");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput("\", type = ");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput(".class, nillable = true)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    protected List<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput("> _");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public List<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput("> get");
                    __printer.Write(Generated_FirstLetterUp(ar.ItemType.Name));
                    __printer.WriteTemplateOutput("() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        if (_");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(" == null) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("            _");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(" = new ArrayList<");
                    __printer.Write(Generated_PrintClassType(ar.ItemType));
                    __printer.WriteTemplateOutput(">();");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        return this._");
                    __printer.Write(ar.ItemType.Name);
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("}");
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateOperationType(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(op.Interface.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlElement;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlType(name = \"");
                    __printer.Write(op.Name);
                    __printer.WriteTemplateOutput("\", propOrder = {");
                    __printer.WriteLine();
                    int __loop19_iteration = 0;
                    string comma = "";
                    var __loop19_result =
                        (from __loop19_tmp_item___noname17 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop19_tmp_item_fi in EnumerableExtensions.Enumerate((__loop19_tmp_item___noname17).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop19_item___noname17 = __loop19_tmp_item___noname17,
                                __loop19_item_fi = __loop19_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop19_item in __loop19_result)
                    {
                        var __noname17 = __loop19_item.__loop19_item___noname17;
                        var fi = __loop19_item.__loop19_item_fi;
                        ++__loop19_iteration;
                        if (__loop19_iteration >= 2)
                        {
                            comma = ",";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    \"");
                        __printer.Write(Generated_FirstLetterLow(fi.Name));
                        __printer.WriteTemplateOutput("\"\\");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("})");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(Generated_FirstLetterUp(op.Name));
                    __printer.WriteTemplateOutput(" {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    int __loop20_iteration = 0;
                    var __loop20_result =
                        (from __loop20_tmp_item___noname18 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop20_tmp_item_pa in EnumerableExtensions.Enumerate((__loop20_tmp_item___noname18).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop20_item___noname18 = __loop20_tmp_item___noname18,
                                __loop20_item_pa = __loop20_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop20_item in __loop20_result)
                    {
                        var __noname18 = __loop20_item.__loop20_item___noname18;
                        var pa = __loop20_item.__loop20_item_pa;
                        ++__loop20_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElement(name = \"");
                        __printer.Write(pa.Name);
                        __printer.WriteTemplateOutput("\", required = true, nillable = ");
                        __printer.Write(Generated_IsNillableType(pa.Type));
                        __printer.WriteTemplateOutput(")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    protected ");
                        __printer.Write(Generated_PrintType(pa.Type));
                        __printer.WriteTemplateOutput(" ");
                        __printer.Write(pa.Name);
                        __printer.WriteTemplateOutput(";");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop21_iteration = 0;
                    var __loop21_result =
                        (from __loop21_tmp_item___noname19 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop21_tmp_item_pa in EnumerableExtensions.Enumerate((__loop21_tmp_item___noname19).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop21_item___noname19 = __loop21_tmp_item___noname19,
                                __loop21_item_pa = __loop21_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop21_item in __loop21_result)
                    {
                        var __noname19 = __loop21_item.__loop21_item___noname19;
                        var pa = __loop21_item.__loop21_item_pa;
                        ++__loop21_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(Generated_PrintType(pa.Type));
                        __printer.WriteTemplateOutput(" get");
                        __printer.Write(Generated_FirstLetterUp(pa.Name));
                        __printer.WriteTemplateOutput("() {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return ");
                        __printer.Write(Generated_FirstLetterLow(pa.Name));
                        __printer.WriteTemplateOutput(";");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public void set");
                        __printer.Write(Generated_FirstLetterUp(pa.Name));
                        __printer.WriteTemplateOutput("(");
                        __printer.Write(Generated_PrintType(pa.Type));
                        __printer.WriteTemplateOutput(" value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        this.");
                        __printer.Write(Generated_FirstLetterLow(pa.Name));
                        __printer.WriteTemplateOutput(" = value;");
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
            
            public List<string> Generated_GenerateOperationResponseType(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(op.Interface.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlAccessorType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlElement;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlType;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlAccessorType(XmlAccessType.FIELD)");
                    __printer.WriteLine();
                    if (op.ReturnType == PseudoType.Void)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("@XmlType(name = \"");
                        __printer.Write(op.Name);
                        __printer.WriteTemplateOutput("Response\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("public class ");
                        __printer.Write(Generated_FirstLetterUp(op.Name));
                        __printer.WriteTemplateOutput("Response {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("}");
                        __printer.WriteLine();
                    }
                    else
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("@XmlType(name = \"");
                        __printer.Write(op.Name);
                        __printer.WriteTemplateOutput("Response\", propOrder = {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    \"");
                        __printer.Write(Generated_FirstLetterLow(op.Name));
                        __printer.WriteTemplateOutput("Result\"");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("})");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("public class ");
                        __printer.Write(Generated_FirstLetterUp(op.Name));
                        __printer.WriteTemplateOutput("Response {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElement(name = \"");
                        __printer.Write(op.Name);
                        __printer.WriteTemplateOutput("Result\", required = true, nillable = ");
                        __printer.Write(Generated_IsNillableType(op.ReturnType));
                        __printer.WriteTemplateOutput(")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    protected ");
                        __printer.Write(Generated_PrintType(op.ReturnType));
                        __printer.WriteTemplateOutput(" ");
                        __printer.Write(Generated_FirstLetterLow(op.Name));
                        __printer.WriteTemplateOutput("Result;");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(Generated_PrintType(op.ReturnType));
                        __printer.WriteTemplateOutput(" get");
                        __printer.Write(Generated_FirstLetterUp(op.Name));
                        __printer.WriteTemplateOutput("Result() {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return ");
                        __printer.Write(Generated_FirstLetterLow(op.Name));
                        __printer.WriteTemplateOutput("Result;");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public void set");
                        __printer.Write(Generated_FirstLetterUp(op.Name));
                        __printer.WriteTemplateOutput("Result(");
                        __printer.Write(Generated_PrintType(op.ReturnType));
                        __printer.WriteTemplateOutput(" value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        this.");
                        __printer.Write(Generated_FirstLetterLow(op.Name));
                        __printer.WriteTemplateOutput("Result = value;");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("}");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateOperationException(ExceptionType ex)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("package ");
                    __printer.Write(Generated_GetPackage(ex.Namespace).ToLower());
                    __printer.WriteTemplateOutput(";");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.ws.WebFault;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@WebFault(name = \"");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("\", targetNamespace = \"");
                    __printer.Write(Generated_GetUri(ex.Namespace));
                    __printer.WriteTemplateOutput("\")");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput(" extends Exception {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    private ");
                    __printer.Write(Generated_PrintType(ex));
                    __printer.WriteTemplateOutput("Fault faultInfo;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("(String message, ");
                    __printer.Write(Generated_PrintType(ex));
                    __printer.WriteTemplateOutput("Fault faultInfo) {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        super(message);");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("        this.faultInfo = faultInfo;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ");
                    __printer.Write(ex.Name);
                    __printer.WriteTemplateOutput("(String message, ");
                    __printer.Write(Generated_PrintType(ex));
                    __printer.WriteTemplateOutput("Fault faultInfo, Throwable cause) {");
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
                    __printer.Write(Generated_PrintType(ex));
                    __printer.WriteTemplateOutput("Fault getFaultInfo() {");
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
            
            public List<string> Generated_GenerateOperationCall(Operation op)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.Write(Generated_FirstLetterLow(op.Name));
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop22_iteration = 0;
                    string comma = "";
                    var __loop22_result =
                        (from __loop22_tmp_item___noname20 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop22_tmp_item_pa in EnumerableExtensions.Enumerate((__loop22_tmp_item___noname20).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop22_item___noname20 = __loop22_tmp_item___noname20,
                                __loop22_item_pa = __loop22_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop22_item in __loop22_result)
                    {
                        var __noname20 = __loop22_item.__loop22_item___noname20;
                        var pa = __loop22_item.__loop22_item_pa;
                        ++__loop22_iteration;
                        if (__loop22_iteration >= 2)
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
            
            public List<string> Generated_GenerateOperationRefHead(OperationImplementation oi)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("public ");
                    __printer.Write(Generated_PrintType(oi.Operation.ReturnType));
                    __printer.WriteTemplateOutput(" ");
                    __printer.Write(Generated_FirstLetterLow(oi.Operation.Name));
                    __printer.WriteTemplateOutput(" ");
                    __printer.Write(Generated_GenerateOperationRefHeadParams(oi));
                    __printer.Write(Generated_ThrowsSoaMMException());
                    int __loop23_iteration = 0;
                    string del = ", ";
                    var __loop23_result =
                        (from __loop23_tmp_item___noname21 in EnumerableExtensions.Enumerate((oi.Operation.Exceptions).GetEnumerator())
                        from __loop23_tmp_item_ex in EnumerableExtensions.Enumerate((__loop23_tmp_item___noname21).GetEnumerator()).OfType<ExceptionType>()
                        select
                            new
                            {
                                __loop23_item___noname21 = __loop23_tmp_item___noname21,
                                __loop23_item_ex = __loop23_tmp_item_ex,
                            }).ToArray();
                    foreach (var __loop23_item in __loop23_result)
                    {
                        var __noname21 = __loop23_item.__loop23_item___noname21;
                        var ex = __loop23_item.__loop23_item_ex;
                        ++__loop23_iteration;
                        __printer.Write(del);
                        __printer.Write(ex.Name);
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public string Generated_ThrowsSoaMMException()
            {
                if (!Properties.NoImplementationDelegates)
                {
                    return " throws SoaMMException";
                }
                else
                {
                    return " throws ";
                }
            }
            
            public List<string> Generated_GenerateOperationRefHeadParams(OperationImplementation oi)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop24_iteration = 0;
                    string comma = "";
                    var __loop24_result =
                        (from __loop24_tmp_item___noname22 in EnumerableExtensions.Enumerate((oi.References).GetEnumerator())
                        from __loop24_tmp_item_re in EnumerableExtensions.Enumerate((__loop24_tmp_item___noname22).GetEnumerator()).OfType<Reference>()
                        where __loop24_tmp_item_re.Object is OperationParameter
                        select
                            new
                            {
                                __loop24_item___noname22 = __loop24_tmp_item___noname22,
                                __loop24_item_re = __loop24_tmp_item_re,
                            }).ToArray();
                    foreach (var __loop24_item in __loop24_result)
                    {
                        var __noname22 = __loop24_item.__loop24_item___noname22;
                        var re = __loop24_item.__loop24_item_re;
                        ++__loop24_iteration;
                        if (__loop24_iteration >= 2)
                        {
                            comma = ", ";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.Write(Generated_PrintType(((OperationParameter)re.Object).Type));
                        __printer.WriteTemplateOutput(" ");
                        __printer.Write(re.Name);
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
            
            public List<string> Generated_GenerateOperationRefCall(OperationImplementation oi)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.Write(Generated_FirstLetterLow(oi.Operation.Name));
                    __printer.Write(Generated_GenerateOperationRefCallParams(oi));
                    __printer.WriteLine();
                }
                return __result;
            }
            
            public List<string> Generated_GenerateOperationRefCallParams(OperationImplementation oi)
            {
                List<string> __result = new List<string>();
                using(TemplatePrinter __printer = new TemplatePrinter(__result))
                {
                    __printer.WriteTemplateOutput("(\\");
                    __printer.WriteLine();
                    int __loop25_iteration = 0;
                    string comma = "";
                    var __loop25_result =
                        (from __loop25_tmp_item___noname23 in EnumerableExtensions.Enumerate((oi.References).GetEnumerator())
                        from __loop25_tmp_item_re in EnumerableExtensions.Enumerate((__loop25_tmp_item___noname23).GetEnumerator()).OfType<Reference>()
                        where __loop25_tmp_item_re.Object is OperationParameter
                        select
                            new
                            {
                                __loop25_item___noname23 = __loop25_tmp_item___noname23,
                                __loop25_item_re = __loop25_tmp_item_re,
                            }).ToArray();
                    foreach (var __loop25_item in __loop25_result)
                    {
                        var __noname23 = __loop25_item.__loop25_item___noname23;
                        var re = __loop25_item.__loop25_item_re;
                        ++__loop25_iteration;
                        if (__loop25_iteration >= 2)
                        {
                            comma = ", ";
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.Write(comma);
                        __printer.Write(re.Name);
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
        
