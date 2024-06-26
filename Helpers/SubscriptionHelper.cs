﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class SubscriptionHelper
    {
        public static List<Subscription> GetFromDataSet(DataSet ds)
        {
            List<Subscription> Subscriptions = new List<Subscription>();

            foreach (DataRow row in ds.Tables["Subscriptions"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int limitQuery = Convert.ToInt32(row["limit_query"]);
                int limitConversation = Convert.ToInt32(row["limit_conversation"]);
                string name = row["name"].ToString();
                decimal role = Convert.ToDecimal(row["price"]);
                string periodString = (string)row["period"];
                Subscription.PeriodTypes period = (Subscription.PeriodTypes)Enum.Parse(typeof(Subscription.PeriodTypes), periodString);
                string modelString = (string)row["model"];
                Subscription.ModelTypes model = (Subscription.ModelTypes)Enum.Parse(typeof(Subscription.ModelTypes), modelString);

                Subscription Subscription = new Subscription(id, name, role, period, model,limitQuery, limitConversation);
                Subscriptions.Add(Subscription);
            }

            return Subscriptions;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, Subscription subscription)
        {
            cmd.Parameters.AddWithValue("@name", subscription.Name);
            cmd.Parameters.AddWithValue("@period", subscription.Period.ToString());
            cmd.Parameters.AddWithValue("@model", subscription.Model.ToString());
            cmd.Parameters.AddWithValue("@limit", subscription.LimitQuery);
            cmd.Parameters.AddWithValue("@converstion", subscription.LimitConversation);
            cmd.Parameters.AddWithValue("@price", subscription.Price);

            return cmd;
        }
    }
}