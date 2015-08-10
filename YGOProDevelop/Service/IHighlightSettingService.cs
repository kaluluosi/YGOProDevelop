using System;
using ICSharpCode.AvalonEdit.Highlighting;
namespace YGOProDevelop.Service
{
    public interface IHighlightSettingService
    {
        System.Collections.Generic.IReadOnlyCollection<ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition> HighlightingDefs { get; }
        IHighlightingDefinition GetDefinition(string languageName);
        IHighlightingDefinition GetDefinitionByExtension(string extension);
    }
}
