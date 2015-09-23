using System;
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
    /// This module does not do anything really. The module creates an item in the database menu.
    /// </remarks>
    public class WIPlugin : IVRPlugin
    {

        IVRViewerSdk pviewer = null;
        ToolStripMenuItem pwi_item = null;


        internal static VRPluginDescriptor pDescriptor = new VRPluginDescriptor(VRPluginType.Unknown, 1, "", "19/01/2009", "Example 2", "Walkinside Plugin Step 2.", "Vrcontext_SDK");
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

        
        public bool CreatePlugin(IVRViewerSdk viewer)
        {
            pviewer = viewer;

            // Do initialisation of plugin instance.
            //string message = "Walkinside Plugin Step 2 : Initialised";
            //Console.WriteLine(message);
            //MessageBox.Show(message);
            // Create a new menu item in the database menu of walkinside.

            // ********** Create new menu in the Toolbar *************
            //ToolStripMenuItem wi_item = viewer.UI.Menu.Items.Add("Example2") as ToolStripMenuItem;

            // ********** Insert new menu in the Plugins menu (preferred) *************
            pwi_item = viewer.UI.PluginMenu.DropDownItems.Add("Example2") as ToolStripMenuItem;

            // ********** Get the walkinside database menu item.*************
            //ToolStripMenuItem wi_item = viewer.UI.Menu.Items["VRDatabaseMenu"] as ToolStripMenuItem;
             System.Diagnostics.Debug.Assert(pwi_item != null);

            // Create the sub menu item for this plugin.

            if (pwi_item != null)
            {
                
                ToolStripItem myItem1 = this.CreateMenuItem("Example2_1");
                pwi_item.DropDownItems.Add(myItem1);
                pwi_item.Enabled = true;
            }

            if (pwi_item != null)
            {
                
                ToolStripItem myItem2 = this.CreateMenuItem("Example2_2");
                pwi_item.DropDownItems.Add(myItem2);
                pwi_item.Enabled = true;
            }
            
            return true;
        }

        /// <summary>
        /// The method called by walkinside, just before the plugin is removed from walkinside environment.
        /// </summary>
        /// <param name="pars">The context of the viewer when plugin is created.</param>
        /// <returns>True if destruction of plugin succeeded.</returns>
        public bool DestroyPlugin(IVRViewerSdk viewer)
        {
            viewer.UI.PluginMenu.DropDownItems.Remove(pwi_item);

            return true;
        }

        // Create a physical menu item for my plugin.
        private ToolStripItem CreateMenuItem(String text)
        {
            ToolStripItem myItem = new ToolStripMenuItem(text);
            myItem.Name = text;
            myItem.Click += new EventHandler(myItem_Click);
            return myItem;
        }

        // Event Handler when the user clicks my plugins menu item.
        private void myItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Example 2 item is clicked by the user.");
            string path = System.IO.Directory.GetCurrentDirectory() + "\\plugins\\Application\\WIExample1.dll";
            pviewer.PluginManager.Load(path);
            
        }
    }
}
