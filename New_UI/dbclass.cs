using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_UI
{
    class dbclass
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("prodID")]
        public int prodID { get; set; }
        [BsonElement("prodName")]
        public string prodName { get; set; }
        [BsonElement("prodVal")]
        public double prodVal { get; set; }
        [BsonElement("prodStock")]
        public int prodStock { get; set; }

        public dbclass(int prodID, string prodName, double prodVal, int prodStock)
        {
            this.prodID = prodID;
            this.prodName = prodName;
            this.prodVal = prodVal;
            this.prodStock = prodStock;
        }
    }
    
}
