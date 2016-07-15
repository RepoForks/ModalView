using Plugin.ModalView.Abstractions;
using System;

namespace Plugin.ModalView
{
  /// <summary>
  /// Cross platform ModalView implemenations
  /// </summary>
  public class CrossModalView
  {
    static Lazy<IModalView> Implementation = new Lazy<IModalView>(() => CreateModalView(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IModalView Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IModalView CreateModalView()
    {
#if PORTABLE
        return null;
#else
        return new ModalViewImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
