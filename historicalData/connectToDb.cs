using System;
using System.Data;
using System.Data.SqlClient;

namespace historicalData
{
    class connectToDb
    {
        //string connectString = @"Data Source = NUMERAXIAL; Initial Catalog = Numerxial_Calculation; user=sa;Password= mnipl-1234";
        string connectString = @"Data Source=SEAN\MSSQL_SEAN;Initial Catalog = mydb; Integrated Security = True";

        public connectToDb(string ticker, Rootobject obj)
        {

            DoConnect(ticker, obj);
        }



        public void DoConnect(string ticker, Rootobject obj)
        {

            foreach (var p in obj.data)
            {


                //string myQuery = @"insert into dbo.tlb_" + ticker + @"Log (stock_value, RecordOn, RecordBy) values ( "
                //+ p.close + @",  '" + Convert.ToDateTime(p.date) + @"', 'Sean')";

                // string myQuery2 = @"Select * from dbo.tlb_" + ticker + @"Log ";

                string myQuery = @"insert into dbo.stock_sp500(stock_date,stock_ticker, open_price, high, low, close_price, adj_close, volume, dividend) values (" +
                                    "'"+Convert.ToDateTime(p.date) + @"', " +
                                    @"'" + ticker + @"', " +
                                    p.open + @", " +
                                    p.high + @", " +
                                    p.low + @", " +
                                    p.close + @", " +
                                    p.adj_close + @", " +
                                    p.volume + @", " +
                                    p.ex_dividend + @")";

                using (SqlConnection con = new SqlConnection(connectString))
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(connectString);
                        SqlCommand cmd = new SqlCommand(myQuery, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        //Console.WriteLine("Data inserted...");
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("exception occured while creating table:" + e.Message + "\t" + e.GetType());
                    }

                }

            }

        }
    }
}
