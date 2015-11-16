using System.Collections.Generic;
using System.Linq;
using ETravel.Nps.DataAccess.Repositories.Interfaces;
using NHibernate;
using NHibernate.Criterion;

namespace ETravel.Nps.DataAccess.Repositories
{
    public class NpsRepository : Repository, INpsRepository
    {
        public NpsRepository() { }
        
        public NpsRepository(ISession session) : base(session) { }

        public void Save(Entities.Nps nps)
        {
            Session.Save(nps);
            Session.Flush();
        }

        public Entities.Nps[] RetrieveByRatableType(string ratableType)
        {
            return Session.CreateCriteria<Entities.Nps>()
                .Add(Restrictions.Eq("RatableType", ratableType))
                .List<Entities.Nps>()
                .ToArray();
        }

        public Entities.Nps[] RetrieveByRatableId(string ratableId)
        {
            return Session.CreateCriteria<Entities.Nps>()
                .Add(Restrictions.Eq("RatableId", ratableId))
                .List<Entities.Nps>()
                .ToArray();
        }

        public Entities.Nps[] RetrieveByRatableTypeAndId(string ratableType, string ratableId)
        {
            return Session.CreateCriteria<Entities.Nps>()
                .Add(Restrictions.Eq("RatableType", ratableType))
                .Add(Restrictions.Eq("RatableId", ratableId))
                .List<Entities.Nps>()
                .ToArray();
        }

        public Entities.Nps Get(string id)
        {
            return Session.Get<Entities.Nps>(id);
        }

        public void Update(Entities.Nps nps)
        {
            Session.Update(nps);
            Session.Flush();
        }
    }
}
