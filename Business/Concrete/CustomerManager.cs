using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _CustomerDal;


        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }


        public IResult Add(Customer customer)
        {
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
    }
}
