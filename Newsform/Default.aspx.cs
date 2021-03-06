﻿using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Newsform;


// enjoy



namespace Newsform
{
   // public string username { get; set; }
    public partial class Default : System.Web.UI.Page
    {
        // This hash table is for keeping track of sites and their respective website ID's
        Hashtable Site_Keys = new Hashtable();
        
        protected void Generate_hashtable()
        {

            DBconn mydb = new DBconn();
            mydb.connect();

            SqlDataReader rdr = mydb.execsp("CMS_RecipeBox_Hashtable", new Object[,] {
            { "@searchEmail" , T_email.Text } 
              });

            // generates hashtable by loading table values in
            while (rdr.Read())
            {
                Site_Keys.Add(rdr.GetString(rdr.GetOrdinal("UR")), rdr.GetInt32(rdr.GetOrdinal("Common_WebSiteID")));
            }
            rdr.Close();
            rdr.Dispose();
            mydb.close();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // hides visibility of the update form
            Update.Visible = false;
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            // shows visiblity of  update form when data is read from db
            Update.Visible = true;
            // hide status of update or delete notification
            dvMsg.Visible = false;

            // read from database. 
            DBconn mydb = new DBconn();
            mydb.connect();

            // first sqlDataReader is for finding the personal info with email. (CMS_USER)
            SqlDataReader rdr = mydb.execsp("CMS_RecipeBox_Search", new Object[,] {
            { "@searchEmail" , T_email.Text } 
              }
                 );
             GenerateOutPersonalInfo(rdr);
                    rdr.Close();
                    rdr.Dispose();
                
            // second sqlDataReader is for finding the one-to-many relationship
            // for all websites to e-mail
                SqlDataReader rdr2 = mydb.execsp("CMS_RecipeBox_Search_Site", new Object[,] {
                    {"@searchEmail" , T_email.Text}
                }
                    );
                ClearCheckBoxes();
                GenerateOutSites(rdr2);
                rdr2.Close();
                rdr2.Dispose();
                mydb.close();
        }

protected void GenerateOutPersonalInfo(SqlDataReader rdr)
        { 
    //update information on page 
    // data binding
          
        //    try
        //    {
                while (rdr.Read())
                {
                    Updt_email.Text = rdr.GetString(rdr.GetOrdinal("EmailAddress"));
                    Updt_city.Text = rdr.GetString(rdr.GetOrdinal("City"));
                    Updt_fname.Text = rdr.GetString(rdr.GetOrdinal("FirstName"));
                    Updt_lname.Text = rdr.GetString(rdr.GetOrdinal("LastName"));
                    Updt_add.Text = rdr.GetString(rdr.GetOrdinal("Address1"));
                    Updt_zip.Text = rdr.GetString(rdr.GetOrdinal("PostalCode"));
                }
          //  }
          /*  catch(Exception exe)
            {
                Response.Write("<script>alert('test')</script>");
            } */
        }

protected void GenerateOutSites(SqlDataReader rdr)
{
    // CheckBoxList1 - 6
    // first parse all sites and store them into an array
    // array to store strings
    // iterator to step through array 
    // ASSUMPTION: we won't be adding any more sites to Recipe Box sector
    string[] sites;
    sites = new string[50];
    int iterator = 1;

    while (rdr.Read())
    {
        // first parse all the sites into an array 
        //ASSUMPTION: from database side, all the websites are stored in a certain format and I'm parsing that format
        // the format is http://www.xxx.com/ 
        sites[iterator] = rdr.GetString(rdr.GetOrdinal("UR"));
        iterator++;
    }
    // a function to dynamically mark all websites that are found in the array
     MarkCheckBoxes(sites);
}

// utility function for reading websites
protected void MarkCheckBoxes(string[] sites)
{

        // read the sites into appropiate listboxes
        // 6 comes from listbox id's of 1-6
        for (int i = 1; i <= 28; i++)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
            foreach (ListItem item in CheckBoxList3.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
            foreach (ListItem item in CheckBoxList4.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
            foreach (ListItem item in CheckBoxList5.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
            foreach (ListItem item in CheckBoxList6.Items)
            {
                if (sites[i] == item.Value.ToString())
                    item.Selected = true;
            }
        }
}
// utility function
// clear all marked list boxes
protected void ClearCheckBoxes()
{
    foreach (ListItem item in CheckBoxList1.Items)
    {
        item.Selected = false;
    }

    foreach (ListItem item in CheckBoxList2.Items)
    {
        item.Selected = false;
    }
    foreach (ListItem item in CheckBoxList3.Items)
    {
        item.Selected = false;
    }

    foreach (ListItem item in CheckBoxList4.Items)
    {
        item.Selected = false;
    }

    foreach (ListItem item in CheckBoxList5.Items)
    {
        item.Selected = false;
    }

    foreach (ListItem item in CheckBoxList6.Items)
    {
        item.Selected = false;
    }
}
        // utility function
        // clears text boxes on update or delete after db connections
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }

        protected void Updt_btn_Click(object sender, EventArgs e)
        {
            // process update
              DBconn mydb = new DBconn();
                mydb.connect();
            // commenting out for testing
            // test for exceptions
            // create rdr sqldatareader to pass into a function that will
            // output the data.

                SqlDataReader rdr = mydb.execsp("CMS_RecipeBox_Update", new Object[,] {
            {"@SearchEmail" , T_email.Text },
            {"@EmailAddress",Updt_email.Text },
            {"@FirstName",Updt_fname.Text},
            {"@LastName",Updt_lname.Text},
            {"@Address", Updt_add.Text},
            {"@City", Updt_city.Text},
            {"@PostalCode",Updt_zip.Text}
            }
                    );
                rdr.Close();
                rdr.Dispose();
    
 /**********************   SITE UPDATE ****************************/
            // this array is for keeping track of active and inactive website id's
            // We will insert each of the values in the array intoi a temporary sql table
            //we will then determine what is active or non-active check box.
                int[] siteArray;
                siteArray = new int[50];
            // hash table has all the respective site names their id's.  The id's are the values.
                Generate_hashtable();
            // returns array for all active check boxes
                siteArray = count_markboxes();
            // failsafe to eliminate duplicates
                siteArray = siteArray.Distinct().ToArray();
            //Next step is to insert all the elements in the array, 'siteArray' in a new sql temp table
                for (int i = 0; i < siteArray.Length; i++)
                {
                    // because I allocated 50 spots for the array, we want to ignore those 0's
                    // the first key of the website id's start at 1.
                    // this builds the temporary table in sql
                    if (siteArray[i] != 0)
                    {
                        SqlDataReader rdr2 = mydb.execsp("CMS_RecipeBox_Update_SiteList", new Object[,] {
                    {"@data",siteArray[i]},
                    { "@SearchEmail", T_email.Text }
                                         });
                        rdr2.Close();
                        rdr2.Dispose();
                    }
                }
            // now that we built the temp table(is important we delete the data after we do the update)
            // we run the standard update proc for websites
            // this proc should toggle website's Active to 0 or 1 or insert a new site for that user
                SqlDataReader rdr3 = mydb.execsp("CMS_RecipeBox_Update_Site", new Object[,] {
                {"@SearchEmail", T_email.Text }
            });

                rdr3.Close();
                rdr3.Dispose();
                mydb.close();     
            // clean up the page after processing and no exceptions
            // after db processes clear text boxes
            ClearTextBoxes(Page);
            ClearCheckBoxes();
            // show that the whole process was successful to the user
            dvMsg.Visible = true;
            lblMsg.Text = "Successfully Updated!";
        }



        protected int[] count_markboxes()
        {
             int[] siteArray;
             siteArray = new int[50];
           //There is no way to pass arrays to sql server, but i'm gathering the marked check boxed to an array

            //ASSUMPTIONS:
            // order will not matter, we this array to update checkboxes
            int count = 0;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    // stores value of checkbox in key
                    string key = item.Value.ToString();
                    // grabs value from hashtable using the key string
                    // The value returned is an object, so we need to convert it to an int data type
                    int value = Convert.ToInt32(Site_Keys[key]);
                    //adds the value to the array we will return back
                    siteArray[count] = value;
                    // increment for next spot in array
                    count++;
                }
            } 
            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected == true)
                {
                    string key = item.Value.ToString();
                    int value = Convert.ToInt32(Site_Keys[key]);
                    siteArray[count] = value;
                    count++;
                }
            }
            foreach (ListItem item in CheckBoxList3.Items)
            {
                if (item.Selected == true)
                {
                    string key = item.Value.ToString();
                    int value = Convert.ToInt32(Site_Keys[key]);
                    siteArray[count] = value;
                    count++;
                }
            }
            foreach (ListItem item in CheckBoxList4.Items)
            {
                if (item.Selected == true)
                {
                    string key = item.Value.ToString();
                    int value = Convert.ToInt32(Site_Keys[key]);
                    siteArray[count] = value;
                    count++;
                }
            }
            foreach (ListItem item in CheckBoxList5.Items)
            {
                if (item.Selected == true)
                {
                    string key = item.Value.ToString();
                    int value = Convert.ToInt32(Site_Keys[key]);
                    siteArray[count] = value;
                    count++;
                }
            }
            foreach (ListItem item in CheckBoxList6.Items)
            {
                if (item.Selected == true)
                {
                    string key = item.Value.ToString();
                    int value = Convert.ToInt32(Site_Keys[key]);
                    siteArray[count] = value;
                    count++;
                }
            }
            return siteArray;
        }

        protected void Dlt_btn_Click(object sender, EventArgs e)
        {
            // process update
            DBconn mydb = new DBconn();
            mydb.connect();
            // Delete does not actually remove the information, but simply toggles Active to 0.
            SqlDataReader rdr = mydb.execsp("CMS_RecipeBox_Delete_User", new Object[,] {
                    { "@SearchEmail", T_email.Text }
                                         });
            rdr.Close();
            rdr.Dispose();
            // clean up the page after processing and no exceptions
            // after db processes clear text boxes
            ClearTextBoxes(Page);
            ClearCheckBoxes();
            // show that the whole process was successful to the user
            dvMsg.Visible = true;
            lblMsg.Text = "Successfully Deleted!";
        }
    }
}