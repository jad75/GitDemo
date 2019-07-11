using ppedv.VollE.Model.Contracts;

namespace ppedv.VollE.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo) //DI in here 
        {
            this.Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

    }
}
