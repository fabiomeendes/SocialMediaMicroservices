using System;
using AwesomeSocialMedia.Posts.Core.Events;

namespace AwesomeSocialMedia.Posts.Core.Entities
{
	public class AggregateRoot : BaseEntity
	{
		public AggregateRoot() : base()
		{
			Events = new List<IEvent>();
		}

		public List<IEvent> Events { get; private set; }

		protected void AddEvent(IEvent @event)
		{
			Events.Add(@event);
		}
	}
}

