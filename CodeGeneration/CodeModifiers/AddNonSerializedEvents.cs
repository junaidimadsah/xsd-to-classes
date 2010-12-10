using System.CodeDom;

namespace CodeGeneration.CodeModifiers
{
    /// <summary>
    /// When generating code for WCF services, all public properties are by default 
    /// serialized. This code modifier attempts to marks as NonSerialzied all events.
    /// </summary>
    class AddNonSerializedEvents: BaseCodeModifier
    {
        public AddNonSerializedEvents() { }

        #region ICodeModifier Members

        public override void Execute(CodeNamespace codeNamespace)
        {
            //// foreach datatype in the codeNamespace
            //foreach (CodeTypeDeclaration type in codeNamespace.Types)
            //{
            //    if (type.IsEnum) continue;

            //    foreach (CodeTypeMember member in type.Members)
            //    {
            //        CodeEventReferenceExpression
            //        CodeMemberField codeField = member as CodeMemberField;
            //        if (codeField == null)
            //            continue;

            //        // check if the Field is XmlElement
            //        //"[System.ComponentModel.TypeConverter(typeof(ByteTypeConverter))]";
            //        if (codeField.Type.BaseType == typeof(Delegate).ToString())
            //        {
            //            // add the custom type editor attribute
            //            CodeAttributeDeclaration attr = new CodeAttributeDeclaration("System.NonSerialized");
            //            codeField.CustomAttributes.Add(attr);

            //        }
            //    }

            //}
        }

        #endregion
    }
}
