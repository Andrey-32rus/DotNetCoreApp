using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Xunit;
using XUnitTestProject.Models;

namespace XUnitTestProject
{
    public class WeeklyPrizeMysql
    {
        [Fact]
        public void Insert()
        {
            int countOfDays = 400000;
            var now = DateTime.UtcNow.Date.AddDays((double)-countOfDays);
            //List<DailyBet> list = new List<DailyBet>(countOfDays);

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < countOfDays; i++)
            {
                var dt = now.AddDays(i);
                DailyBet doc = new DailyBet
                {
                    UserId = Convert.ToUInt32(i),
                    Dt = dt,
                    TransactionId = Convert.ToUInt64(i),
                    IsUsed = false,
                };

                strBuilder.Append($@"({doc.UserId}, ""{doc.Dt:yyy-MM-dd}"", {doc.TransactionId}, {(doc.IsUsed == false ? 0 : 1)}), ");

                //list.Add(doc);
            }

            strBuilder.Remove(strBuilder.Length - 2, 2);
            strBuilder.Append("'");
            string data = strBuilder.ToString();
            data = data.Insert(0, "'");

            MySqlConnection connection = new MySqlConnection("User Id=root;Host=localhost;Character Set=utf8");
            var command = new MySqlCommand($"call weeklyprize.InsertDailyBets({data})", connection);
            var adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
        }
    }
}
