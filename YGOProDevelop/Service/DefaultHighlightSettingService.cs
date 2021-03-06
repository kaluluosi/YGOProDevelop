﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System.Xml;
using System.IO;

namespace YGOProDevelop.Service
{
    /// <summary>
    /// 高亮语法设置服务
    /// </summary>
    public class DefaultHighlightSettingService : YGOProDevelop.Service.IHighlightSettingService
    {
        private HighlightingManager _highlightingMgr = HighlightingManager.Instance;
        private string _highlighDefFolderPath;

        public DefaultHighlightSettingService(string highlighDefFolderPath) {
            _highlighDefFolderPath = highlighDefFolderPath;
            CustomSettingInit();
        }

        /// <summary>
        /// 加载并初始化用户自定义的高亮语法配置文件
        /// </summary>
        private void CustomSettingInit() {
            string[] files = Directory.GetFiles(_highlighDefFolderPath);

            foreach(string fileName in files) {
                XmlTextReader xmlReader = new XmlTextReader(fileName);
                IHighlightingDefinition hlDef = HighlightingLoader.Load(xmlReader,HighlightingManager.Instance);
                string extension = "."+Path.GetFileName(fileName).Split('-')[0].ToLower();
                HighlightingManager.Instance.RegisterHighlighting(hlDef.Name, new[] { extension }, hlDef);
            }
        }

        /// <summary>
        /// 获取所有的高亮语法配置
        /// </summary>
        public IReadOnlyCollection<IHighlightingDefinition> HighlightingDefs {
            get {
                return _highlightingMgr.HighlightingDefinitions;
            }
        }


        public IHighlightingDefinition GetDefinition(string languageName) {
            return _highlightingMgr.GetDefinition(languageName);
        }

        public IHighlightingDefinition GetDefinitionByExtension(string extension) {
            return _highlightingMgr.GetDefinitionByExtension(extension);
        }
    }
}
