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
            
            public List<string> Generated_GenerateObjectFactory(Namespace ns)
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
                    __printer.WriteTemplateOutput("import javax.xml.bind.JAXBElement;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlElementDecl;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.bind.annotation.XmlRegistry;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("import javax.xml.namespace.QName;");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("^");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("@XmlRegistry");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("public class ObjectFactory {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    public ObjectFactory() {");
                    __printer.WriteLine();
                    __printer.WriteTemplateOutput("    }");
                    __printer.WriteLine();
                    int __loop1_iteration = 0;
                    var __loop1_result =
                        (from __loop1_tmp_item___noname1 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop1_tmp_item_type in EnumerableExtensions.Enumerate((__loop1_tmp_item___noname1).GetEnumerator()).OfType<StructType>()
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
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    private final static QName _");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("_QNAME = new QName(\"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\",\"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput(" create");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("() {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("();");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\", name = \"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("> create");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("(");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(" value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(">(_");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("_QNAME, ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(".class, null, value);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop2_iteration = 0;
                    var __loop2_result =
                        (from __loop2_tmp_item___noname2 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop2_tmp_item_type in EnumerableExtensions.Enumerate((__loop2_tmp_item___noname2).GetEnumerator()).OfType<EnumType>()
                        select
                            new
                            {
                                __loop2_item___noname2 = __loop2_tmp_item___noname2,
                                __loop2_item_type = __loop2_tmp_item_type,
                            }).ToArray();
                    foreach (var __loop2_item in __loop2_result)
                    {
                        var __noname2 = __loop2_item.__loop2_item___noname2;
                        var type = __loop2_item.__loop2_item_type;
                        ++__loop2_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    private final static QName _");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("_QNAME = new QName(\"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\",\"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\", name = \"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("> create");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("(");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(" value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(">(_");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("_QNAME, ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput(".class, null, value);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop3_iteration = 0;
                    var __loop3_result =
                        (from __loop3_tmp_item___noname3 in EnumerableExtensions.Enumerate((Instances).GetEnumerator())
                        from __loop3_tmp_item_type in EnumerableExtensions.Enumerate((__loop3_tmp_item___noname3).GetEnumerator()).OfType<ArrayType>()
                        select
                            new
                            {
                                __loop3_item___noname3 = __loop3_tmp_item___noname3,
                                __loop3_item_type = __loop3_tmp_item_type,
                            }).ToArray();
                    foreach (var __loop3_item in __loop3_result)
                    {
                        var __noname3 = __loop3_item.__loop3_item___noname3;
                        var type = __loop3_item.__loop3_item_type;
                        ++__loop3_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    ");
                        if (type.ItemType is NullableType)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    private final static QName _ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("_QNAME = new QName(\"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\",\"ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("\");");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(" create_ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\", name = \"_ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("\")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("> create_ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(">(_ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("_QNAME, ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOfNullable");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(".class, null, value);");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        else if (type.ItemType != BuiltInType.Byte)
                        {
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    private final static QName _ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("_QNAME = new QName(\"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\",\"ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("\");");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(" createArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\", name = \"ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("\")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("> createArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(">(_ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput("_QNAME, ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".ArrayOf");
                            __printer.Write(Generated_FirstLetterUp(type.ItemType.Name));
                            __printer.WriteTemplateOutput(".class, null, value);");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                        }
                        __printer.TrimLine();
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    if (!Properties.NoImplementationDelegates)
                    {
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    private final static QName _SoaMMFault_QNAME = new QName(\"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\",\"SoaMMException\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault createSoaMMFault() {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault();");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\", name = \"SoaMMException\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault> createSoaMMFault(");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault>(_SoaMMFault_QNAME, ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".SoaMMFault.class, null, value);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop4_iteration = 0;
                    var __loop4_result =
                        (from __loop4_tmp_item___noname4 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
                        from __loop4_tmp_item_type in EnumerableExtensions.Enumerate((__loop4_tmp_item___noname4).GetEnumerator()).OfType<ExceptionType>()
                        select
                            new
                            {
                                __loop4_item___noname4 = __loop4_tmp_item___noname4,
                                __loop4_item_type = __loop4_tmp_item_type,
                            }).ToArray();
                    foreach (var __loop4_item in __loop4_result)
                    {
                        var __noname4 = __loop4_item.__loop4_item___noname4;
                        var type = __loop4_item.__loop4_item_type;
                        ++__loop4_iteration;
                        __printer.TrimLine();
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    private final static QName _");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("Fault_QNAME = new QName(\"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\",\"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\");");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault create");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("Fault() {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault();");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("^");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                        __printer.Write(Generated_GetUri(ns));
                        __printer.WriteTemplateOutput("\", name = \"");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("\")");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    public JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault> create");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("Fault(");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault value) {");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("        return new JAXBElement<");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault>(_");
                        __printer.Write(Generated_FirstLetterUp(type.Name));
                        __printer.WriteTemplateOutput("Fault_QNAME, ");
                        __printer.Write(Generated_GetPackage(ns).ToLower());
                        __printer.WriteTemplateOutput(".");
                        __printer.Write(type.Name);
                        __printer.WriteTemplateOutput("Fault.class, null, value);");
                        __printer.WriteLine();
                        __printer.WriteTemplateOutput("    }");
                        __printer.WriteLine();
                    }
                    __printer.TrimLine();
                    __printer.WriteLine();
                    int __loop5_iteration = 0;
                    var __loop5_result =
                        (from __loop5_tmp_item___noname5 in EnumerableExtensions.Enumerate((ns.Declarations).GetEnumerator())
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
                        int __loop6_iteration = 0;
                        var __loop6_result =
                            (from __loop6_tmp_item___noname6 in EnumerableExtensions.Enumerate((intf.Operations).GetEnumerator())
                            from __loop6_tmp_item_type in EnumerableExtensions.Enumerate((__loop6_tmp_item___noname6).GetEnumerator()).OfType<Operation>()
                            select
                                new
                                {
                                    __loop6_item___noname6 = __loop6_tmp_item___noname6,
                                    __loop6_item_type = __loop6_tmp_item_type,
                                }).ToArray();
                        foreach (var __loop6_item in __loop6_result)
                        {
                            var __noname6 = __loop6_item.__loop6_item___noname6;
                            var type = __loop6_item.__loop6_item_type;
                            ++__loop6_iteration;
                            __printer.TrimLine();
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    private final static QName _");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("_QNAME = new QName(\"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\",\"");
                            __printer.Write(type.Name);
                            __printer.WriteTemplateOutput("\");");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput(" create");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("() {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("();");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("^");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                            __printer.Write(Generated_GetUri(ns));
                            __printer.WriteTemplateOutput("\", name = \"");
                            __printer.Write(type.Name);
                            __printer.WriteTemplateOutput("\")");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    public JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("> create");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("(");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput(" value) {");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("        return new JAXBElement<");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput(">(_");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput("_QNAME, ");
                            __printer.Write(Generated_GetPackage(ns).ToLower());
                            __printer.WriteTemplateOutput(".");
                            __printer.Write(Generated_FirstLetterUp(type.Name));
                            __printer.WriteTemplateOutput(".class, null, value);");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    }");
                            __printer.WriteLine();
                            __printer.WriteTemplateOutput("    ");
                            if (type.ReturnType != PseudoType.Async)
                            {
                                __printer.TrimLine();
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("^");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    private final static QName _");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response_QNAME = new QName(\"");
                                __printer.Write(Generated_GetUri(ns));
                                __printer.WriteTemplateOutput("\",\"");
                                __printer.Write(type.Name);
                                __printer.WriteTemplateOutput("Response\");");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("^");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    public ");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response create");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response() {");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("        return new ");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response();");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("^");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    @XmlElementDecl(namespace = \"");
                                __printer.Write(Generated_GetUri(ns));
                                __printer.WriteTemplateOutput("\", name = \"");
                                __printer.Write(type.Name);
                                __printer.WriteTemplateOutput("Response\")");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    public JAXBElement<");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response> create");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response(");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response value) {");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("        return new JAXBElement<");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response>(_");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response_QNAME, ");
                                __printer.Write(Generated_GetPackage(ns).ToLower());
                                __printer.WriteTemplateOutput(".");
                                __printer.Write(Generated_FirstLetterUp(type.Name));
                                __printer.WriteTemplateOutput("Response.class, null, value);");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    }");
                                __printer.WriteLine();
                                __printer.WriteTemplateOutput("    ");
                            }
                            __printer.TrimLine();
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
                    int __loop7_iteration = 0;
                    string comma = "";
                    var __loop7_result =
                        (from __loop7_tmp_item___noname7 in EnumerableExtensions.Enumerate((en).GetEnumerator())
                        from __loop7_tmp_item_value in EnumerableExtensions.Enumerate((__loop7_tmp_item___noname7.Values).GetEnumerator())
                        select
                            new
                            {
                                __loop7_item___noname7 = __loop7_tmp_item___noname7,
                                __loop7_item_value = __loop7_tmp_item_value,
                            }).ToArray();
                    foreach (var __loop7_item in __loop7_result)
                    {
                        var __noname7 = __loop7_item.__loop7_item___noname7;
                        var value = __loop7_item.__loop7_item_value;
                        ++__loop7_iteration;
                        if (__loop7_iteration >= 2)
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
                int __loop8_iteration = 0;
                string delim = "";
                var __loop8_result =
                    (from __loop8_tmp_item_strde in EnumerableExtensions.Enumerate((str.GetAllDescendants()).GetEnumerator())
                    select
                        new
                        {
                            __loop8_item_strde = __loop8_tmp_item_strde,
                        }).ToArray();
                foreach (var __loop8_item in __loop8_result)
                {
                    var strde = __loop8_item.__loop8_item_strde;
                    ++__loop8_iteration;
                    if (__loop8_iteration >= 2)
                    {
                        delim = ", ";
                    }
                    result = result + delim + Generated_GetPackage(strde.Namespace).ToLower() + "." + strde.Name + ".class";
                }
                if (__loop8_iteration == 0)
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
                int __loop9_iteration = 0;
                string delim = "";
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
                    if (__loop9_iteration >= 2)
                    {
                        delim = ", ";
                    }
                    result = result + delim + Generated_GetPackage(exde.Namespace).ToLower() + "." + exde.Name + ".class";
                }
                if (__loop9_iteration == 0)
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
                    int __loop10_iteration = 0;
                    string comma = "";
                    var __loop10_result =
                        (from __loop10_tmp_item___noname8 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop10_tmp_item_fi in EnumerableExtensions.Enumerate((__loop10_tmp_item___noname8).GetEnumerator()).OfType<StructField>()
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
                        if (__loop10_iteration >= 2)
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
                    int __loop11_iteration = 0;
                    var __loop11_result =
                        (from __loop11_tmp_item___noname9 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop11_tmp_item_fi in EnumerableExtensions.Enumerate((__loop11_tmp_item___noname9).GetEnumerator()).OfType<StructField>()
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
                        int __loop12_iteration = 0;
                        string delim = "";
                        var __loop12_result =
                            (from __loop12_tmp_item___noname10 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                            from __loop12_tmp_item_fi in EnumerableExtensions.Enumerate((__loop12_tmp_item___noname10).GetEnumerator()).OfType<StructField>()
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
                            if (__loop12_iteration >= 2)
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
                        int __loop13_iteration = 0;
                        var __loop13_result =
                            (from __loop13_tmp_item___noname11 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                            from __loop13_tmp_item_fi in EnumerableExtensions.Enumerate((__loop13_tmp_item___noname11).GetEnumerator()).OfType<StructField>()
                            where !(__loop13_tmp_item_fi.Type is ArrayType)
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
                    int __loop14_iteration = 0;
                    var __loop14_result =
                        (from __loop14_tmp_item___noname12 in EnumerableExtensions.Enumerate((st.Fields).GetEnumerator())
                        from __loop14_tmp_item_fi in EnumerableExtensions.Enumerate((__loop14_tmp_item___noname12).GetEnumerator()).OfType<StructField>()
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
                    int __loop15_iteration = 0;
                    string comma = "";
                    var __loop15_result =
                        (from __loop15_tmp_item___noname13 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop15_tmp_item_fi in EnumerableExtensions.Enumerate((__loop15_tmp_item___noname13).GetEnumerator()).OfType<ClaimField>()
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
                        if (__loop15_iteration >= 2)
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
                    int __loop16_iteration = 0;
                    var __loop16_result =
                        (from __loop16_tmp_item___noname14 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop16_tmp_item_fi in EnumerableExtensions.Enumerate((__loop16_tmp_item___noname14).GetEnumerator()).OfType<ClaimField>()
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
                        int __loop17_iteration = 0;
                        string delim = "";
                        var __loop17_result =
                            (from __loop17_tmp_item___noname15 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                            from __loop17_tmp_item_fi in EnumerableExtensions.Enumerate((__loop17_tmp_item___noname15).GetEnumerator()).OfType<ClaimField>()
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
                            if (__loop17_iteration >= 2)
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
                        int __loop18_iteration = 0;
                        var __loop18_result =
                            (from __loop18_tmp_item___noname16 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                            from __loop18_tmp_item_fi in EnumerableExtensions.Enumerate((__loop18_tmp_item___noname16).GetEnumerator()).OfType<ClaimField>()
                            where !(__loop18_tmp_item_fi.Type is ArrayType)
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
                    int __loop19_iteration = 0;
                    var __loop19_result =
                        (from __loop19_tmp_item___noname17 in EnumerableExtensions.Enumerate((cs.Fields).GetEnumerator())
                        from __loop19_tmp_item_fi in EnumerableExtensions.Enumerate((__loop19_tmp_item___noname17).GetEnumerator()).OfType<ClaimField>()
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
                    int __loop20_iteration = 0;
                    string comma = "";
                    var __loop20_result =
                        (from __loop20_tmp_item___noname18 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop20_tmp_item_fi in EnumerableExtensions.Enumerate((__loop20_tmp_item___noname18).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop20_item___noname18 = __loop20_tmp_item___noname18,
                                __loop20_item_fi = __loop20_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop20_item in __loop20_result)
                    {
                        var __noname18 = __loop20_item.__loop20_item___noname18;
                        var fi = __loop20_item.__loop20_item_fi;
                        ++__loop20_iteration;
                        if (__loop20_iteration >= 2)
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
                    int __loop21_iteration = 0;
                    var __loop21_result =
                        (from __loop21_tmp_item___noname19 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop21_tmp_item_fi in EnumerableExtensions.Enumerate((__loop21_tmp_item___noname19).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop21_item___noname19 = __loop21_tmp_item___noname19,
                                __loop21_item_fi = __loop21_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop21_item in __loop21_result)
                    {
                        var __noname19 = __loop21_item.__loop21_item___noname19;
                        var fi = __loop21_item.__loop21_item_fi;
                        ++__loop21_iteration;
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
                        int __loop22_iteration = 0;
                        string delim = "";
                        var __loop22_result =
                            (from __loop22_tmp_item___noname20 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop22_tmp_item_fi in EnumerableExtensions.Enumerate((__loop22_tmp_item___noname20).GetEnumerator()).OfType<ExceptionField>()
                            where !(__loop22_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop22_item___noname20 = __loop22_tmp_item___noname20,
                                    __loop22_item_fi = __loop22_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop22_item in __loop22_result)
                        {
                            var __noname20 = __loop22_item.__loop22_item___noname20;
                            var fi = __loop22_item.__loop22_item_fi;
                            ++__loop22_iteration;
                            if (__loop22_iteration >= 2)
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
                        int __loop23_iteration = 0;
                        var __loop23_result =
                            (from __loop23_tmp_item___noname21 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                            from __loop23_tmp_item_fi in EnumerableExtensions.Enumerate((__loop23_tmp_item___noname21).GetEnumerator()).OfType<ExceptionField>()
                            where !(__loop23_tmp_item_fi.Type is ArrayType)
                            select
                                new
                                {
                                    __loop23_item___noname21 = __loop23_tmp_item___noname21,
                                    __loop23_item_fi = __loop23_tmp_item_fi,
                                }).ToArray();
                        foreach (var __loop23_item in __loop23_result)
                        {
                            var __noname21 = __loop23_item.__loop23_item___noname21;
                            var fi = __loop23_item.__loop23_item_fi;
                            ++__loop23_iteration;
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
                    int __loop24_iteration = 0;
                    var __loop24_result =
                        (from __loop24_tmp_item___noname22 in EnumerableExtensions.Enumerate((ex.Fields).GetEnumerator())
                        from __loop24_tmp_item_fi in EnumerableExtensions.Enumerate((__loop24_tmp_item___noname22).GetEnumerator()).OfType<ExceptionField>()
                        select
                            new
                            {
                                __loop24_item___noname22 = __loop24_tmp_item___noname22,
                                __loop24_item_fi = __loop24_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop24_item in __loop24_result)
                    {
                        var __noname22 = __loop24_item.__loop24_item___noname22;
                        var fi = __loop24_item.__loop24_item_fi;
                        ++__loop24_iteration;
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
                    int __loop25_iteration = 0;
                    string comma = "";
                    var __loop25_result =
                        (from __loop25_tmp_item___noname23 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop25_tmp_item_fi in EnumerableExtensions.Enumerate((__loop25_tmp_item___noname23).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop25_item___noname23 = __loop25_tmp_item___noname23,
                                __loop25_item_fi = __loop25_tmp_item_fi,
                            }).ToArray();
                    foreach (var __loop25_item in __loop25_result)
                    {
                        var __noname23 = __loop25_item.__loop25_item___noname23;
                        var fi = __loop25_item.__loop25_item_fi;
                        ++__loop25_iteration;
                        if (__loop25_iteration >= 2)
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
                    int __loop26_iteration = 0;
                    var __loop26_result =
                        (from __loop26_tmp_item___noname24 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop26_tmp_item_pa in EnumerableExtensions.Enumerate((__loop26_tmp_item___noname24).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop26_item___noname24 = __loop26_tmp_item___noname24,
                                __loop26_item_pa = __loop26_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop26_item in __loop26_result)
                    {
                        var __noname24 = __loop26_item.__loop26_item___noname24;
                        var pa = __loop26_item.__loop26_item_pa;
                        ++__loop26_iteration;
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
                    int __loop27_iteration = 0;
                    var __loop27_result =
                        (from __loop27_tmp_item___noname25 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop27_tmp_item_pa in EnumerableExtensions.Enumerate((__loop27_tmp_item___noname25).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop27_item___noname25 = __loop27_tmp_item___noname25,
                                __loop27_item_pa = __loop27_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop27_item in __loop27_result)
                    {
                        var __noname25 = __loop27_item.__loop27_item___noname25;
                        var pa = __loop27_item.__loop27_item_pa;
                        ++__loop27_iteration;
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
                    int __loop28_iteration = 0;
                    string comma = "";
                    var __loop28_result =
                        (from __loop28_tmp_item___noname26 in EnumerableExtensions.Enumerate((op.Parameters).GetEnumerator())
                        from __loop28_tmp_item_pa in EnumerableExtensions.Enumerate((__loop28_tmp_item___noname26).GetEnumerator()).OfType<OperationParameter>()
                        select
                            new
                            {
                                __loop28_item___noname26 = __loop28_tmp_item___noname26,
                                __loop28_item_pa = __loop28_tmp_item_pa,
                            }).ToArray();
                    foreach (var __loop28_item in __loop28_result)
                    {
                        var __noname26 = __loop28_item.__loop28_item___noname26;
                        var pa = __loop28_item.__loop28_item_pa;
                        ++__loop28_iteration;
                        if (__loop28_iteration >= 2)
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
                    int __loop29_iteration = 0;
                    string del = ", ";
                    var __loop29_result =
                        (from __loop29_tmp_item___noname27 in EnumerableExtensions.Enumerate((oi.Operation.Exceptions).GetEnumerator())
                        from __loop29_tmp_item_ex in EnumerableExtensions.Enumerate((__loop29_tmp_item___noname27).GetEnumerator()).OfType<ExceptionType>()
                        select
                            new
                            {
                                __loop29_item___noname27 = __loop29_tmp_item___noname27,
                                __loop29_item_ex = __loop29_tmp_item_ex,
                            }).ToArray();
                    foreach (var __loop29_item in __loop29_result)
                    {
                        var __noname27 = __loop29_item.__loop29_item___noname27;
                        var ex = __loop29_item.__loop29_item_ex;
                        ++__loop29_iteration;
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
                    int __loop30_iteration = 0;
                    string comma = "";
                    var __loop30_result =
                        (from __loop30_tmp_item___noname28 in EnumerableExtensions.Enumerate((oi.References).GetEnumerator())
                        from __loop30_tmp_item_re in EnumerableExtensions.Enumerate((__loop30_tmp_item___noname28).GetEnumerator()).OfType<Reference>()
                        where __loop30_tmp_item_re.Object is OperationParameter
                        select
                            new
                            {
                                __loop30_item___noname28 = __loop30_tmp_item___noname28,
                                __loop30_item_re = __loop30_tmp_item_re,
                            }).ToArray();
                    foreach (var __loop30_item in __loop30_result)
                    {
                        var __noname28 = __loop30_item.__loop30_item___noname28;
                        var re = __loop30_item.__loop30_item_re;
                        ++__loop30_iteration;
                        if (__loop30_iteration >= 2)
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
                    int __loop31_iteration = 0;
                    string comma = "";
                    var __loop31_result =
                        (from __loop31_tmp_item___noname29 in EnumerableExtensions.Enumerate((oi.References).GetEnumerator())
                        from __loop31_tmp_item_re in EnumerableExtensions.Enumerate((__loop31_tmp_item___noname29).GetEnumerator()).OfType<Reference>()
                        where __loop31_tmp_item_re.Object is OperationParameter
                        select
                            new
                            {
                                __loop31_item___noname29 = __loop31_tmp_item___noname29,
                                __loop31_item_re = __loop31_tmp_item_re,
                            }).ToArray();
                    foreach (var __loop31_item in __loop31_result)
                    {
                        var __noname29 = __loop31_item.__loop31_item___noname29;
                        var re = __loop31_item.__loop31_item_re;
                        ++__loop31_iteration;
                        if (__loop31_iteration >= 2)
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
        
