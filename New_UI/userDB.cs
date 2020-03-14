using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_UI
{
    class userDB
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("employeeName")]
        public string EmployeeName { get; set; }
        [BsonElement("employeeSalary")]
        public Double EmployeeSalary { get; set; }

        public userDB(string username, string password, string employeeName, double employeeSalary)
        {
            Username = username;
            Password = password;
            EmployeeName = employeeName;
            EmployeeSalary = employeeSalary;
        }
    }
}
