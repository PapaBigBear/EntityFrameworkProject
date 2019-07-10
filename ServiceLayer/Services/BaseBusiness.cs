using DataAccessLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class BaseBusiness
    {
        protected readonly IUnitOfWork unitOfWork;

        public BaseBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
