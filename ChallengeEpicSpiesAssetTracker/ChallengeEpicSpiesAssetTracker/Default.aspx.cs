using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //initialize 3 arrays
                string[] assets = new string[0];
                int[] elections = new int[0];
                int[] acts = new int[0];
                //setup viewstate for arrays
                ViewState.Add("Assets", assets);
                ViewState.Add("Elections", elections);
                ViewState.Add("Acts", acts);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //link arrays to viewstate to record their data
            string[] assets = (string[])ViewState["Assets"];
            int[] elections = (int[])ViewState["Elections"];
            int[] acts = (int[])ViewState["Acts"];
            // this index helps makes new arrays through resize method
            int newLength = assets.Length + 1;
            Array.Resize(ref assets, newLength);
            Array.Resize(ref elections, newLength);
            Array.Resize(ref acts, newLength);
            //this index helps link arrays to accept text box values
            int newIndex = assets.GetUpperBound(0); 
            assets[newIndex] = TextBox1.Text;
            elections[newIndex] = int.Parse(TextBox2.Text);
            acts[newIndex] = int.Parse(TextBox3.Text);
            //link viewstate to arrays
            ViewState["Assets"] = assets;
            ViewState["Elections"] = elections;
            ViewState["Acts"] = acts;
            //record in formatted string
            Label1.Text = String.Format("Total Elections Rigged: {0}" +
                "<br />Average Acts of Subterfuge: {1}" +
                "<br />Last Asset you Added: {2}",
                elections.Sum(),
                acts.Average(), 
                assets[newIndex]);
            //clear out text boxes
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            

        }
    }
}