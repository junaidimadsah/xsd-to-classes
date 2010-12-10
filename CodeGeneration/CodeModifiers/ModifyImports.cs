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

namespace CodeGeneration.CodeModifiers
{
    /// <summary>
    /// The collection type converter give a slightly more useable view of a collection
    /// in the property grid
    /// </summary>
    public class ModifyImports : BaseCodeModifier
    {

        ModifyImportsOptions m_options;

        public ModifyImportsOptions Options
        {
            get
            {
                if (m_options == null)
                    m_options = GetOptions<ModifyImportsOptions>();
                return m_options;
            }            
        }

        #region ICodeModifier Members

        public override void Execute(CodeNamespace codeNamespace)
        {
            foreach (ImportType import in Options.AddImport)
            {
                codeNamespace.Imports.Add(new CodeNamespaceImport(import.Name));
            }
        }

        #endregion
    }
}
