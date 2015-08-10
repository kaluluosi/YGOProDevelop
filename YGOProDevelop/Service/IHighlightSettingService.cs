using System;
namespace YGOProDevelop.Service
{
    public interface IHighlightSettingService
    {
        System.Collections.Generic.IReadOnlyCollection<ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition> HighlightingDefs { get; }
        ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition GetHighlightingDefinition(string languageName);
    }
}
