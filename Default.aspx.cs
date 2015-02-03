using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page//partial because it is half the class, and the .aspx file is the other half of the class
    //that's why the event has to show up in both files
    
    /*********************************************
     * Jenny Crimp
     * ITC172 WN15
     * Assignment 2
     * This web site allows users to select an artist
     * from the dropdown, and the retrieves and displays
     * show and venue details from the database
     * *******************************************/
{
    ShowTrackerEntities db = new ShowTrackerEntities();//this is at class-level because we will
    //use it in a couple methods
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //backwards sql query
            var artists = from a in db.Artists
                          orderby a.ArtistName
                          select new { a.ArtistName, a.ArtistKey };

            DropDownList1.DataSource = artists.ToList();
            DropDownList1.DataTextField = "ArtistName";//this must match exactly a.ArtistName above. Name will show
            DropDownList1.DataValueField = "ArtistKey";//Key will be stored, but not show
            DropDownList1.DataBind();
        }
        
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int key = int.Parse(DropDownList1.SelectedValue.ToString());

        var shows = from s in db.Shows
                    from sd in s.ShowDetails
                    where sd.ArtistKey == key
                    select new { s.ShowName, s.ShowDate, s.ShowTime, s.Venue.VenueName, sd.Artist.ArtistName};
                    // get show name, show date, and show time from Show db, venue name from Venue db via Show db, and artist name from 
                    // Artist db via ShowDetail db.
        GridView1.DataSource = shows.ToList();
        GridView1.DataBind();
    }
}