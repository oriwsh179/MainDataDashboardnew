using MainDataDashboard.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

public static class DbHelper
{
    private static string ConnectionString => ConfigurationManager.ConnectionStrings["FinanceConnection"].ConnectionString;

    public static List<StatusItem> GetCarStatuses()
    {
        var items = new List<StatusItem>();

        using (var connection = new SqlConnection(ConnectionString))
        {
            var query = "SELECT c7 AS Status, COUNT(*) AS Count FROM [CAR_A] GROUP BY c7";

            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new StatusItem
                        {
                            Status = reader["Status"].ToString(),
                            Count = Convert.ToInt32(reader["Count"])
                        });
                    }
                }
            }
        }

        return items;
    }

    public static List<DeptOfficeItem> GetDeptOfficeData()
    {
        var items = new List<DeptOfficeItem>();

        using (var connection = new SqlConnection(ConnectionString))
        {
            var query = "SELECT c2 AS Office, c3 AS Department, COUNT(*) AS Count FROM [CAR_A] GROUP BY c2, c3";

            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new DeptOfficeItem
                        {
                            Office = reader["Office"].ToString(),
                            Department = reader["Department"].ToString(),
                            Count = Convert.ToInt32(reader["Count"])
                        });
                    }
                }
            }
        }

        return items;
    }
}