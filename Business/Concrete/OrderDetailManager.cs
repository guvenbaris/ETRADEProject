using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailsService
    {
        private IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public List<OrderDetail> GetAll()
        {
            return _orderDetailDal.GetAll();
        }

        public OrderDetail Get(int id)
        {
            return _orderDetailDal.Get(id);
        }

        public void Add(OrderDetail entity)
        {
            if (_orderDetailDal.Add(entity))
            {
                Console.WriteLine("Order Details added");
            }
            else
            {
                Console.WriteLine("Order Details eklenemdi");
            }

        }

        public void Update(OrderDetail entity)
        {
            if (_orderDetailDal.Update(entity))
            {
                Console.WriteLine("Order Details updated");
            }
            else
            {
                Console.WriteLine("Order Details güncellenemedi");
            }
           
        }

        public void Delete(OrderDetail entity)
        {
            if (_orderDetailDal.Delete(entity))
            {
                Console.WriteLine("Order Details silindi");
            }
            else
            {
                Console.WriteLine("Order Details silinemedi");
            }
            
        }


    }
}

