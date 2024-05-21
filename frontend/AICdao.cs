using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace dbproject
{
    internal class AICdao
    {
        string connectionString = "datasource = localhost;port=3306;username=root;password=root;database=ktmdb;";
        
        public List<AIC> getAllAICs()
        {
            List<AIC> returnlist = new List<AIC>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM area_incharge",connection);

            using(MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    AIC a = new AIC
                    {
                        ID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        MiddleName = reader.GetString(2),
                        LastName = reader.GetString(3)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<AIC> searchName(String searchTerm)
        {
            List<AIC> returnlist = new List<AIC>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String phrase = "%"+searchTerm+"%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM area_incharge WHERE `First Name` like @search";
            command.Parameters.AddWithValue("@search", phrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    AIC a = new AIC
                    {
                        ID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        MiddleName = reader.GetString(2),
                        LastName = reader.GetString(3)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int addentry(AIC aic)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `area_incharge`(`ID`, `First Name`, `Middle Name`, `Last Name`) VALUES (@id,@fname,@mname,@lname)", connection);
            command.Parameters.AddWithValue("@id", aic.ID);
            command.Parameters.AddWithValue("@fname", aic.FirstName);
            command.Parameters.AddWithValue("@mname", aic.MiddleName);
            command.Parameters.AddWithValue("@lname", aic.LastName);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        public List<Area> areabyic(int icid)
        {
            List<Area> returnlist = new List<Area>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM area WHERE `ic` = @abcd;";
            command.Parameters.AddWithValue("@abcd", icid);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Area a = new Area()
                    {
                        Area_Name = reader.GetString(0),
                        AIC_ID = reader.GetInt32(1)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<Area> getAllAreas()
        {
            List<Area> returnlist = new List<Area>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM area", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Area a = new Area
                    {
                        Area_Name = reader.GetString(0),
                        AIC_ID = reader.GetInt32(1)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<Workshop> getAllWorkshops()
        {
            List<Workshop> returnlist = new List<Workshop>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM workshop", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Workshop a = new Workshop
                    {
                        wkCode = reader.GetInt32(0),
                        wkName = reader.GetString(1),
                        wkArea = reader.GetString(2),
                        manpower = reader.GetInt32(3),
                        customer_visits = reader.GetInt32(4),
                        recovery = reader.GetString(5),
                        score = reader.GetInt32(6)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<Workshop> workshopbyarea(String areaname)
        {
            List<Workshop> returnlist = new List<Workshop>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM workshop WHERE `area` = @abcd;";
            command.Parameters.AddWithValue("@abcd", areaname);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Workshop a = new Workshop()
                    {
                        wkCode = reader.GetInt32(0),
                        wkName = reader.GetString(1),
                        wkArea = reader.GetString(2),
                        manpower = reader.GetInt32(3),
                        customer_visits = reader.GetInt32(4),
                        recovery = reader.GetString(5),
                        score = reader.GetInt32(6)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<Workshop> searchWorkshop(String searchTerm)
        {
            List<Workshop> returnlist = new List<Workshop>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String phrase = "%" + searchTerm + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM workshop WHERE `wk_name` like @search";
            command.Parameters.AddWithValue("@search", phrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Workshop a = new Workshop
                    {
                        wkCode = reader.GetInt32(0),
                        wkName = reader.GetString(1),
                        wkArea = reader.GetString(2),
                        manpower = reader.GetInt32(3),
                        customer_visits = reader.GetInt32(4),
                        recovery = reader.GetString(5),
                        score = reader.GetInt32(6)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int addWorkshop(Workshop workshop)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `workshop`(`wk_code`, `wk_name`, `area`, `manpower`, `customer_visits`, `recovery`, `score`) VALUES (@wk_code,@wk_name,@area,@manpower,@customer_visits,@recovery,@score)", connection);
            command.Parameters.AddWithValue("@wk_code", workshop.wkCode);
            command.Parameters.AddWithValue("@wk_name", workshop.wkName);
            command.Parameters.AddWithValue("@area", workshop.wkArea);
            command.Parameters.AddWithValue("@manpower", workshop.manpower);
            command.Parameters.AddWithValue("@customer_visits", workshop.customer_visits);
            command.Parameters.AddWithValue("@recovery", workshop.recovery);
            command.Parameters.AddWithValue("@score",workshop.score);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        public List<WorkshopIC> getAllWorkshopICs()
        {
            List<WorkshopIC> returnlist = new List<WorkshopIC>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM workshop_ic", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    WorkshopIC a = new WorkshopIC
                    {
                        WkICID = reader.GetInt32(0),
                        FName = reader.GetString(1),
                        MName = reader.GetString(2),
                        LName = reader.GetString(3),
                        Rating = reader.GetInt32(4),
                        AreaIC = reader.GetInt32(5)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<WorkshopIC> WorkshopICbyAreaIC(int areaic)
        {
            List<WorkshopIC> returnlist = new List<WorkshopIC>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM workshop_ic WHERE `area_ic` = @abcd;";
            command.Parameters.AddWithValue("@abcd", areaic);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    WorkshopIC a = new WorkshopIC()
                    {
                        WkICID = reader.GetInt32(0),
                        FName = reader.GetString(1),
                        MName = reader.GetString(2),
                        LName = reader.GetString(3),
                        Rating = reader.GetInt32(4),
                        AreaIC = reader.GetInt32(5)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<WorkshopIC> searchWorkshopIC(String searchTerm)
        {
            List<WorkshopIC> returnlist = new List<WorkshopIC>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String phrase = "%" + searchTerm + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM workshop_ic WHERE `fname` like @search";
            command.Parameters.AddWithValue("@search", phrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    WorkshopIC a = new WorkshopIC
                    {
                        WkICID = reader.GetInt32(0),
                        FName = reader.GetString(1),
                        MName = reader.GetString(2),
                        LName = reader.GetString(3),
                        Rating = reader.GetInt32(4),
                        AreaIC = reader.GetInt32(5)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int addWorkshopIC(WorkshopIC workshopIC)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `workshop_ic` (`id`, `fname`, `mname`, `lname`, `rating`, `area_ic`)  VALUES (@id,@fname,@mname,@lname,@rating,@areaic)", connection);
            command.Parameters.AddWithValue("@id", workshopIC.WkICID);
            command.Parameters.AddWithValue("@fname", workshopIC.FName);
            command.Parameters.AddWithValue("@mname", workshopIC.MName);
            command.Parameters.AddWithValue("@lname", workshopIC.LName);
            command.Parameters.AddWithValue("@rating", workshopIC.Rating);
            command.Parameters.AddWithValue("@areaic", workshopIC.AreaIC);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        public List<Manages> getAllManages()
        {
            List<Manages> returnlist = new List<Manages>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM manages", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Manages a = new Manages
                    {
                        WkshpID = reader.GetInt32(0),
                        ICID = reader.GetInt32(1)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int addManages(Manages manages)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `manages` (`wk_code`, `ic_id`) VALUES (@wk,@ic)", connection);
            command.Parameters.AddWithValue("@wk", manages.WkshpID);
            command.Parameters.AddWithValue("@ic", manages.ICID);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        public List<Manages> managesbyworkshop(int wkshp)
        {
            List<Manages> returnlist = new List<Manages>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM manages WHERE `wk_code` = @abcd;";
            command.Parameters.AddWithValue("@abcd", wkshp);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Manages a = new Manages()
                    {
                        WkshpID = reader.GetInt32(0),
                        ICID = reader.GetInt32(1)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<Manages> managesbyic(int ic)
        {
            List<Manages> returnlist = new List<Manages>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM manages WHERE `ic_id` = @abcd;";
            command.Parameters.AddWithValue("@abcd", ic);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Manages a = new Manages()
                    {
                        WkshpID = reader.GetInt32(0),
                        ICID = reader.GetInt32(1)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        public List<revenue> getallrevenues()
        {
            List<revenue> returnlist = new List<revenue>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("fetching_all_revenues", connection);
            command.CommandType = CommandType.StoredProcedure;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    revenue a = new revenue
                    {
                        wkcode = reader.GetInt32(0),
                        year = reader.GetInt32(1),
                        quarter = reader.GetInt32(2),
                        total_sales = reader.GetInt32(3),
                        service_cost = reader.GetInt32(4),
                        profit = reader.GetInt32(5)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int addrevenues(revenue revenue)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("Insert_Revenue", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@wk_code", revenue.wkcode);
            command.Parameters.AddWithValue("@year", revenue.year);
            command.Parameters.AddWithValue("@quarter", revenue.quarter);
            command.Parameters.AddWithValue("@total_sales", revenue.total_sales);
            command.Parameters.AddWithValue("@service_cost", revenue.service_cost);
            command.Parameters.AddWithValue("@profit", revenue.profit);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        public List<revenue> revenuebyworkshop(int wkcode)
        {
            List<revenue> returnlist = new List<revenue>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `revenue` WHERE `wk_code` = @abcd;";
            command.Parameters.AddWithValue("@abcd", wkcode);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    revenue a = new revenue()
                    {
                        wkcode = reader.GetInt32(0),
                        year = reader.GetInt32(1),
                        quarter = reader.GetInt32(2),
                        total_sales = reader.GetInt32(3),
                        service_cost = reader.GetInt32(4),
                        profit = reader.GetInt32(5)
                    };
                    returnlist.Add(a);
                }
            }

            connection.Close();

            return returnlist;
        }

        internal int updateRevenue(revenue revenue, int wkcode)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `revenue` SET `total_sales`= @total_sales,`service_cost`= @service_cost,`profit`= @profit WHERE  `revenue`.`wk_code` = @wkcode AND `revenue`.`year`= @year AND `revenue`.`quarter`= @quarter;", conn);
            command.Parameters.AddWithValue("@total_sales", revenue.total_sales);
            command.Parameters.AddWithValue("@service_cost", revenue.service_cost);
            command.Parameters.AddWithValue("@profit", revenue.profit);
            command.Parameters.AddWithValue("@year", revenue.year);
            command.Parameters.AddWithValue("@quarter", revenue.quarter);
            command.Parameters.AddWithValue("@wkcode", wkcode); 
            int res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        internal int updateAICs(AIC aIC, int icCode)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `area_incharge` SET `First Name`= @fn,`Middle Name`= @mn,`Last Name`= @ln WHERE  `area_incharge`.`ID` = @id;", conn);
            command.Parameters.AddWithValue("@fn", aIC.FirstName);
            command.Parameters.AddWithValue("@mn", aIC.MiddleName);
            command.Parameters.AddWithValue("@ln", aIC.LastName);
            command.Parameters.AddWithValue("@id", aIC.ID);
            int res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }
        internal int updateWkshp(Workshop wkshp, int code)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `workshop` SET `wk_name`= @wn,`area`= @ar,`manpower`= @mp,`customer_visits`= @cv, `recovery`= @rv, `score`= @sc WHERE  `workshop`.`wk_code` = @wc;", conn);
            command.Parameters.AddWithValue("@wn", wkshp.wkName);
            command.Parameters.AddWithValue("@ar", wkshp.wkArea);
            command.Parameters.AddWithValue("@mp", wkshp.manpower);
            command.Parameters.AddWithValue("@cv", wkshp.customer_visits);
            command.Parameters.AddWithValue("@rv", wkshp.recovery);
            command.Parameters.AddWithValue("@sc", wkshp.score);
            command.Parameters.AddWithValue("@wc", code);
            int res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }
        internal int deleterevenue(int revenueID, int revenueyear, int revenuequarter)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM `revenue` WHERE `revenue`.`wk_code` = @wkcode AND `revenue`.`year` = @year AND `revenue`.`quarter` = @quarter;", connection);
            command.Parameters.AddWithValue("@wkcode",revenueID);
            command.Parameters.AddWithValue("@year", revenueyear);
            command.Parameters.AddWithValue("@quarter", revenuequarter);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }
        internal int deleteworkshop(int workshopID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM `workshop` WHERE `workshop`.`wk_code` = @wkcode;", connection);
            command.Parameters.AddWithValue("@wkcode", workshopID);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }
        internal int deletewkshpic(int workshopIC)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM `workshop_ic` WHERE `workshop_ic`.`id` = @wkiccode;", connection);
            command.Parameters.AddWithValue("@wkiccode", workshopIC);
            int res = command.ExecuteNonQuery();

            connection.Close();

            return res;
        }

        internal int updateWkshpIC(WorkshopIC abcd, int wk)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `workshop_ic` SET `fname`=@fn,`mname`=@mn,`lname`=@ln,`rating`=@rt,`area_ic`=@aic WHERE `workshop_ic`.`id` = @wk;", conn);
            command.Parameters.AddWithValue("@fn", abcd.FName);
            command.Parameters.AddWithValue("@mn", abcd.MName);
            command.Parameters.AddWithValue("@ln", abcd.LName);
            command.Parameters.AddWithValue("@rt", abcd.Rating);
            command.Parameters.AddWithValue("@aic", abcd.AreaIC);
            command.Parameters.AddWithValue("@wk", wk);
            int res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }
    }
}
