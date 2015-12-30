using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace YGOProDevelop2 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        static App() {
            DispatcherHelper.Initialize();
            AggregateCatalog agCatalog = new AggregateCatalog();
            agCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            agCatalog.Catalogs.Add(new DirectoryCatalog(@".\Plugin"));
            CompositionIniter.Container = new CompositionContainer(agCatalog);
        }

        public static class CompositionIniter {
            public static CompositionContainer Container;
            public static void ComposeParts(object obj) {
                Container.ComposeParts(obj);
            }
        }
    }
}
