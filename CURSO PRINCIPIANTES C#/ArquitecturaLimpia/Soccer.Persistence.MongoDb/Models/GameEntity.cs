using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Soccer.Persistence.MongoDb.Models
{
    public class GameEntity
    {
		[BsonId]
		[BsonGuidRepresentation(GuidRepresentation.Standard)]
		public Guid Id { get; init; }
		public string LocalTeamCode { get; init; } = string.Empty;
		public string AwayTeamCode { get; init; } = string.Empty;
		public DateTime? StartedOn { get; init; }
		public DateTime? EndedOn { get; init; }
		public IEnumerable<GoalEntity> LocalGoals { get; init; } = Enumerable.Empty<GoalEntity>();
		public IEnumerable<GoalEntity> AwayGoals { get; init; } = Enumerable.Empty<GoalEntity>();
	}

	public class GoalEntity
	{
		public DateTime ScoredOn { get; init; }
		public string ScoredBy { get; init; } = string.Empty;
	
}
}
