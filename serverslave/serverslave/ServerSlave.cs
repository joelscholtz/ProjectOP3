using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using CronScheduling;

class ServerSlave
{
    string ApiUrl = "http://opendata.technolution.nl/opendata/parkingdata/v1";  // The location where the API is located.
    string datatext;  // The data returned as text.
    JObject rawdataset; // The data converted into Json objects.
    IList<JToken> parkingGaragesRaw; // Contains the raw information from each parking garage.
    List<PG_Info> parkingGarages = new List<PG_Info>(); // Converted objects.
   

    public ServerSlave()
    {

        Console.WriteLine("Loaded the server slave.");
        datatext = getStringFromUrl(ApiUrl); // Insert the API url here containing the parking garages.
        rawdataset = JObject.Parse(datatext); 
        if(rawdataset != null)
        {

            Console.WriteLine("Seperating the parking garages from the data.");
            parkingGaragesRaw = rawdataset["parkingFacilities"].Children().ToList();
            Console.WriteLine($"There is currently raw data for {parkingGaragesRaw.Count()} parking facilities.");
            if(parkingGaragesRaw.Count() != 0)
            {

                // TODO : Convert JObject to native objects to work with by type casting the data.
                foreach(JToken jt in parkingGaragesRaw)
                {
                    // For these strings, a ternary operator is used to extract potential data from the objects.
                    // It's a safe way to check whether something is empty/null. If something returns null, it sets itself
                    // to a default value. 
                    // 
                    // USAGE  : condition ? first_expression : second_expression  | if this, do this, else this.
                    // Reference on ternary operators : https://msdn.microsoft.com/en-us/library/ty67wk28.aspx
                    string id = jt["identifier"] != null ? id = (string)jt["identifier"] : id = "";
                    string name = jt["name"] != null ? name = (string)jt["name"] : name = "";
                    string sdu = jt["staticDataUrl"] != null ? sdu = (string)jt["staticDataUrl"] : sdu = "";
                    string ddu =jt["dynamicDataUrl"] != null ? ddu = (string)jt["dynamicDataUrl"] : ddu = "";

                    parkingGarages.Add(new PG_Info(id, name, sdu, ddu));
                }

                Console.WriteLine($"Amount of converted main objects. : {parkingGarages.Count}");

                // Run once for u know
                insertDataIntoDatabase();

                // TODO : Add Cronjob function here.
                //var cd = CronDaemon.Start<string>(
                //value => {
                //    Console.WriteLine(value);
                //    insertDataIntoDatabase();
                //});
                //
                //cd.Add("Doing the hourly thing", Cron.Hourly(), 999);
            }
            else
            {
                Console.WriteLine("No entries found.");
            }
                      
        }

    
    }


    /// <summary>
    /// Function which needs to be called by the cronjob.
    /// </summary>
    public void insertDataIntoDatabase()
    {
        // The variables used for logging in to the database.
        string Server = "127.0.0.1";
        string Port = "3306";
        string User = "project_user";
        string Password = "project";
        string Database = "projectop3";
        string Table = "dyngarinfo";

        // Do not change this line. This string is used to connect to the database.
        string cstring = $"server={Server}; Port={Port}; Database={Database}; Uid={User}; Pwd={Password};";
        //string cstring = $"Server{Server};Database={Database};Uid={User};";
        MySqlConnection connection = new MySqlConnection(cstring);
        try
        {
            int jo_count = 0;
            int infosuccess_count = 0;
             
            string nodata = "";
            string cannotparse = "";

            connection.Open();
            Console.WriteLine($"Connected to server : {Server}");
            // TODO : Handle insertion etc. here.
            foreach(PG_Info pg in parkingGarages)
            {
                string rd = getStringFromUrl(pg.DynUrl);
                JObject jo = rd != "" ? jo = JObject.Parse(rd) : jo = null; // Ternary Operator to prevent an error just incase there is nothing to convert.
                if(jo != null)
                {
                    jo_count++;
                    try
                    {
                        int vacant = (int)jo["parkingFacilityDynamicInformation"]["facilityActualStatus"]["vacantSpaces"]; // get info
                        // Query
                        string q = $"INSERT INTO {Table} (garage_id, vacant, date, hour) VALUES ('{pg.ID}',{vacant},'{DateTime.Now.ToString("yyyy-MM-dd")}',{DateTime.Now.ToString("HH")})";
                        MySqlCommand cmd = new MySqlCommand(q);
                        cmd.Connection = connection;
                        cmd.ExecuteNonQuery();

                        infosuccess_count++;
                    }
                    catch
                    {
                        cannotparse += $"\n {pg.Name}";
                    }

                }
                else
                {
                    nodata += $"\n {pg.Name}";
                    Console.WriteLine($"----- \n Couldn't parse the data given from {pg.DynUrl}. It's either a bad url or returns no reponse ----- \n");
                    
                }
                // TODO : Retrieve shit, upload shit to DB.
                Console.WriteLine($"Done shit with {pg.Name}");
            }
            Console.WriteLine($"\n Done for now, of {parkingGarages.Count}, {jo_count} were converted and {infosuccess_count} were succesfully parsed. \n \n");
            Console.WriteLine($"The following garages fucked up and returned no data. \n ---------- {nodata}");


            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }


     
    }

    

    public string getStringFromUrl(string _url)
    {
        string ret;
        if (_url != "")
        {
            using (WebClient wc = new WebClient())
            {
                try { ret = wc.DownloadString(_url); Console.WriteLine($"Succesfully retrieved the data from {_url}."); return ret; }
                catch { Console.WriteLine($"Couldn't retrieve data from {_url}."); return ""; }
            }
        }
        else
        {
            Console.WriteLine("No URL given to use.");
            return "";
        }
    } 
}

/// <summary>
/// Container class for the main information of each parking garage.
/// </summary>
public class PG_Info
{
    string name,id, dynDataUrl,statDataUrl;
    public string Name { get { return name; } }
    public string ID {  get { return id; } }
    public string DynUrl {  get { return dynDataUrl; } }
    public string StatUrl { get { return statDataUrl; } }

    JObject dynDataRaw;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_id">The unique ID of the parking garage saved as a string.</param>
    /// <param name="_name">The name of the parking garage as a string.</param>
    /// <param name="_statUrl">The url of this parking garage which contains more static information.</param>
    /// <param name="_dynUrl">The url of this parking garage which contains more dynamic information.</param>
    public PG_Info(string _id, string _name, string _statUrl, string _dynUrl)
    {
        name = _name;
        id = _id;
        statDataUrl = _statUrl;
        dynDataUrl = _dynUrl;
    }

    class statInfo
    {

    }

    class dynamicInfo
    {

    }
}


