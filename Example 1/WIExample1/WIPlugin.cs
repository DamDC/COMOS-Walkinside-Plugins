using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using vrcontext.walkinside.sdk;

namespace WIExample
{
    /// <summary>
    /// The most basic example of a working plugin for walkinside.
    /// </summary>
    /// <remarks>
    /// This module does not do anything realy. The module just shows a message
    /// when the plugin is created and destroyed.
    /// </remarks>
    public class WIPlugin : IVRPlugin
    {
        internal static VRPluginDescriptor pDescriptor = new VRPluginDescriptor(VRPluginType.Unknown, 1, "", "19/01/2009", "Example 1", "Walkinside Plugin Step 1.", "Vrcontext_SDK");
        /// <summary>
        /// Get the plugin descriptor of this WIPlugin_step1 walkinside module without creating plugin instance.
        /// </summary>
        static public VRPluginDescriptor GetDescriptor
        {
            get
            {
                return pDescriptor;
            }
        }

        /// <summary>
        /// Get the plugin descriptor of this WIPlugin_step1 walkinside module object.
        /// </summary>
        public VRPluginDescriptor Description
        {
            get
            {
                return pDescriptor;
            }
        }

        /// <summary>
        /// The method called by walkinside, immediatly after the plugin assembly is loaded in walkinside.
        /// </summary>
        /// <param name="pars">The context of the viewer when plugin is created.</param>
        /// <returns>True if creation of plugin succeeded.</returns>
        public bool CreatePlugin(IVRViewerSdk pars)
        {
            // Do initialisation of plugin instance.
            string message = "Walkinside Plugin Step 1 : Initialised";
            Console.WriteLine(message);
            MessageBox.Show(message);
            return true;
        }

        /// <summary>
        /// The method called by walkinside, just before the plugin is removed from walkinside environment.
        /// </summary>
        /// <param name="pars">The context of the viewer when plugin is created.</param>
        /// <returns>True if destruction of plugin succeeded.</returns>
        public bool DestroyPlugin(IVRViewerSdk viewer)
        {
            // Do finalisation of plugin instance.
            string message2 = "Walkinside Plugin Step 1 : Destroyed";
            Console.WriteLine(message2);
            MessageBox.Show(message2);
            
            return true;
        }
    }
}
