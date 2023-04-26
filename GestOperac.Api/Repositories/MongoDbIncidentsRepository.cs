using Microsoft.AspNetCore.Connections;
using MongoDB.Bson;
using MongoDB.Driver;
using GestOperac.Api.Models;
using System.Runtime.CompilerServices;
using System;

namespace GestOperac.Api.Repositories
{
    public class MongoDbIncidentsRepository : IIncidentsRepository
    {

        private const string databaseName = "Occurences";
        private const string collectionName = "Incidents";

        private readonly IMongoCollection<Incident> incidentsCollection;
        private readonly FilterDefinitionBuilder<Incident> filterBuilder = Builders<Incident>.Filter;
        public MongoDbIncidentsRepository(IMongoClient mongoClient) 
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            incidentsCollection = database.GetCollection<Incident>(collectionName);
        }

        public async Task CreateIncidentAsync(Incident incident)
        {
            await incidentsCollection.InsertOneAsync(incident);
        }

        public async Task DeleteIncidentAsync(Guid id)
        {
            var filter = filterBuilder.Eq(incident => incident.Id, id);
            await incidentsCollection.DeleteOneAsync(filter);
        }

        public async Task<Incident> GetIncidentAsync(Guid id)
        {
            var filter = filterBuilder.Eq(incident => incident.Id, id);
            return await incidentsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Incident>> GetIncidentsAsync()
        {
            return await incidentsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task  UpdateIncidentAsync(Incident incident)
        {
            var filter = filterBuilder.Eq(existingincident => existingincident.Id, incident.Id);
            await incidentsCollection.ReplaceOneAsync(filter, incident);

        }
    }
}
