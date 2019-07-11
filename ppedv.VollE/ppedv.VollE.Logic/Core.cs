using ppedv.VollE.Model.Contracts;

namespace ppedv.VollE.Logic
{
    public class Core
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        public Core(IUnitOfWork uow) //DI in here 
        {
            this.UnitOfWork = uow;
        }

        public Core() : this(new Data.EF.EfUnitOfWork())
        { }

    }
}
