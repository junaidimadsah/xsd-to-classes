//=============================================================================
//
// Copyright (C) 2007 Michael Coyle, Blue Toque
// http://www.BlueToque.ca/Products/XmlGridControl2.html
// michael.coyle@BlueToque.ca
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// http://www.gnu.org/licenses/gpl.txt
//
//=============================================================================
using System.CodeDom;
using BlueToque.XmlLibrary.CodeModifiers.Schemas;
using CodeGeneration.CodeModifiers;

namespace BlueToque.XmlLibrary.CodeModifiers
{
    /// <summary>
    /// Implement attributes for Google's Protcol buffers as implemented by protobuf.net
    /// http://code.google.com/p/protobuf-net/
    /// </summary>
    public class Protobuf : BaseCodeModifier
    {
        #region ICodeModifier Members
        public override void Execute(CodeNamespace codeNamespace)
        {
            // for each type
            foreach (CodeTypeDeclaration type in codeNamespace.Types)
            {
                if (type.IsEnum) continue;

                // add the "ProtoContract" attribute to the class
                type.CustomAttributes.Add(new CodeAttributeDeclaration("ProtoContract"));

                int number = 1;

                // for each member
                foreach (CodeTypeMember member in type.Members)
                {
                    // if the member is a property
                    CodeMemberProperty codeProperty = member as CodeMemberProperty;
                    if (codeProperty == null)
                        continue;

                    // add the custom type editor attribute
                    CodeAttributeDeclaration attr = new CodeAttributeDeclaration("ProtoMember");
                    attr.Arguments.Add(new CodeAttributeArgument(
                        new CodePrimitiveExpression(number) ));
                    codeProperty.CustomAttributes.Add(attr);

                    number++;
                }
            }

            // add an include for "ProtoBuf" which is th namespace of the ProtoContract and ProtoMember attributes
            codeNamespace.Imports.Add(new CodeNamespaceImport("ProtoBuf"));
        }

        #endregion
    }
}
