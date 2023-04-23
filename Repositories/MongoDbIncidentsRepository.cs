using Microsoft.AspNetCore.Connections;
using MongoDB.Bson;
using MongoDB.Driver;
using GestOperac.Models;
using System.Runtime.CompilerServices;

namespace GestOperac.Repositories
{
    public class MongoDbIncidentsRepository : IIncidentsRepository
    {

        private const string databaseName = "Occurences";
        private const string collectionName = "Incidents";

        private readonly IMongoCollection<Incident> incidentsCollection;
        public MongoDbIncidentsRepository(IMongoClient mongoClient) 
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            incidentsCollection = database.GetCollection<Incident>(collectionName);
        }

        public void CreateIncident(Incident incident)
        {
            incidentsCollection.InsertOne(incident);
        }

        public void DeleteIncident(Guid id)
        {
            throw new NotImplementedException();
        }

        public Incident GetIncident(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Incident> GetIncidents()
        {
            return incidentsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateIncident(Incident incident)
        {
            throw new NotImplementedException();
        }
    }
}
