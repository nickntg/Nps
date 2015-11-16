using NHibernate;

namespace ETravel.Nps.DataAccess.Repositories
{
    public class Repository
    {
        protected readonly ISession Session;

        public Repository()
        {
            Session = SessionManager.Instance.GetSession();
        }

        public Repository(ISession session)
        {
            Session = session;
        }
    }
}
