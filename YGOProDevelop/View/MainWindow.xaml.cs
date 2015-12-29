﻿using System.Windows;
using YGOProDevelop.ViewModel;
using System.Collections.Generic;
using Xceed.Wpf.AvalonDock.Themes;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using YGOProDevelop.View;
using Microsoft.Win32;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace YGOProDevelop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            layoutSerilizer = new XmlLayoutSerializer(dock);

            Closing += (s, e) => { ViewModelLocator.Cleanup(); Properties.Settings.Default.Save(); };

            ChangeTheme(Properties.Settings.Default.Theme);

//             Messenger.Default.Register<NotificationMessageAction<string>>(this, "MainWindow", (msg) => {
//                 switch (msg.Notification) {
//                     case "OpenFile":
//                         OpenFileDialog openDlg = new OpenFileDialog();
//                         openDlg.AddExtension = true;
//                         openDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
//                         openDlg.FilterIndex = 1;
//                         if (openDlg.ShowDialog() == true) {
//                             msg.Execute(openDlg.FileName);
//                         }
//                         break;
//                     case "SaveFile":
//                         SaveFileDialog saveDlg = new SaveFileDialog();
//                         saveDlg.AddExtension = true;
//                         saveDlg.Filter = "Lua脚本文件|*.lua|C#文件|*.cs|文本文件|*.txt|所有文件|*.*";
//                         saveDlg.FilterIndex = 1;
//                         if (saveDlg.ShowDialog() == true) {
//                             msg.Execute(saveDlg.FileName);
//                         }
//                         break;
//                 }
//             });

        }

        private XmlLayoutSerializer layoutSerilizer;

        private void themesMenu_Click(object sender, RoutedEventArgs e) {
            string header = (e.Source as MenuItem).Header.ToString();
            ChangeTheme(header);
        }

        public void ChangeTheme(string themeName) {
            switch (themeName) {
                case "VS2010":
                    dock.Theme = new VS2010Theme();
                    break;
                case "Aero":
                    dock.Theme = new AeroTheme();
                    break;
                case "ExpressLight":
                    dock.Theme = new ExpressionLightTheme();
                    break;
                case "Generic":
                    dock.Theme = new GenericTheme();
                    break;
                case "Metro":
                    dock.Theme = new MetroTheme();
                    break;
                default:
                case "ExpressDark":
                    dock.Theme = new ExpressionDarkTheme();
                    break;
            }
            Properties.Settings.Default.Theme = themeName;
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            layoutSerilizer.Serialize(@".\layout.cfg");
        }

        private void window_Loaded(object sender, RoutedEventArgs e) {
            try {
                layoutSerilizer.Deserialize(@".\layout.cfg");
            }
            catch (System.Exception ex) {
                throw;
            }
        }

    }
}